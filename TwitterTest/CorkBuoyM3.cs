﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    class CorkBuoyM3: TestApp.WeatherStation
    {
 
        private string _stationID;
        //base url http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?time,AtmosphericPressure,WindDirection,WindSpeed,Gust,AirTemperature,RelativeHumidity&station_id=%22M3%22&time>=2015-02-11T13:00:00Z
        //changing the final element related to time and station ID
        private string url;
        //this number is set based on the selections made to feed the URL
        int COLUMNS = 7;
        
        //create a current data time variable
        DateTime currentTime;
        //getters and setters
        public string StationID { get { return _stationID; } }

        //constructor
        public CorkBuoyM3()
        {
            //initialise the 2D array to the required amount of columns
            table = new string[2, COLUMNS];
            _stationID = "M3";
            
        }

        //like twitter or facebook or website widget
        public override void addSub(Subscriber sub)
        {
            for (int i = 0; i < subscribers.Length; i++)
            {
                if (subscribers[i] == null)
                {
                    subscribers[i] = sub;
                }

            }

        }
        public override void removeSub(Subscriber sub)
        {
            for (int i = 0; i < subscribers.Length; i++)
            {
                if (sub == subscribers[i])
                {
                    subscribers[i] = null;
                }

            }
        }

        //this method will update all the subscribers
        public override void UpdateSubs()
        {   //loop through all Subscribers
            foreach (Subscriber sub in subscribers)
            {
                //call the overridden method of each subscriber 
                //and pass it this weather station object
                sub.update(this);
            }
        }//end UpdateSubs method

        //this method extracts the info from the URL of ERDDAP and populates the table 2d array
        public override DateTime getUpdate(DateTime lastTime)
        {
            //set the current Date time to now
            currentTime = DateTime.Now;
            //store the hour
            long hour = currentTime.Hour;
            url = "http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?time,AtmosphericPressure,WindDirection,WindSpeed,Gust,AirTemperature,RelativeHumidity&station_id=";

            //only carry out this method if the time of the hour is different from the last hour
            //and only if it is past 30 mins in the hour as the URL usually will not have displayed
            if ((lastTime.Hour != hour) && (currentTime.Minute >30))
            {
                
                 try {
                     
                    string patt = @"yyyy-MM-dd";
                    string newD = currentTime.ToString(patt);
                     //add the search parameters like station id and date and time to the url
                    url += "%22" + _stationID + "%22&time>=" + newD + "T" + hour+ ":00:00Z";

                    //declare a web object and from that a document object that loads the URL that is required
                    HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = web.Load(url);
                    Console.WriteLine(url);

                    //this is to keep count of index in loops
                    int i = 0;
                    //this loops throught html tags <th> headers,   using the class that this particular page uses
                    foreach (HtmlNode column in doc.DocumentNode.SelectNodes("//table[@class='erd commonBGColor']/tr/th"))
                    {
                        //check to see if node is null
                        if (column.InnerHtml == null)
                        {
                            continue;
                        }
                        else
                        {
                            //this is the length of column in the table in ERDDAP, will need adjusting if you select differnt URL
                            if (i < COLUMNS)
                            {
                                table[0, i] = column.InnerHtml;

                            }
                            i++;
                        }
                    }
                    //reset the index
                    i = 0;
                    //this loops throught html tags <td> data elements, using the class that this particular page uses
                    foreach (HtmlNode cell in doc.DocumentNode.SelectNodes("//table[@class='erd commonBGColor']/tr/td"))
                    {
                        //a catch to ensure the node is not null
                        if (cell.InnerHtml == null)
                        {
                            continue;
                        }
                        else
                        {
                            if (i < COLUMNS)
                            {
                                //load into 2d array in the second row
                                table[1, i] = cell.InnerHtml;
                                i++;
                            }
                        }
                    }
                }catch(Exception e){
                        Console.WriteLine("Error with reading data from URL: "+ e);
                }

                //printing to check contence
                foreach (var h in table)
                { Console.WriteLine(h); }

                int day = DateTime.Now.Day;
                string month = DateTime.Now.ToString("MMM");
                this.Update =   month + day +" "+ hour + ":00 #Buoy" + _stationID + "\n  ⛅Temp/" + table[1, 5].Trim() + "°C 💨 Dir" + table[1, 2].Trim() + "°/" + table[1, 3].Trim() + "km/Gust" + table[1, 4].Trim() + "kn Hum" + table[1, 6].Trim() + "%";
                
                
                //call the UpdateSub method only if satisfying If statement condition
                //means no need to check the time a second time in the other method
                UpdateSubs();
                return currentTime;

            }//end if
            else 
            {
                return lastTime;
            }

            
            
        }

    }
}
