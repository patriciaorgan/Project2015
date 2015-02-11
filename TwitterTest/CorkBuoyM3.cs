using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    class CorkBuoyM3: TestApp.WeatherStation
    {
        //setting the variables used specifically for Cork Buoy M3 as they are not always the same
        /* 
         private string _temp;
         private string _windSpeed;
         private string _humidity;
         private string _gust;
         private string _windDirection;
         private string _time;
         */
        

        private string _stationID;
        //base url http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?time,AtmosphericPressure,WindDirection,WindSpeed,Gust,AirTemperature,RelativeHumidity&station_id=%22M3%22&time>=2015-02-11T13:00:00Z
        //changing the final elemnet related to time and station ID
        private string url = "http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?time,AtmosphericPressure,WindDirection,WindSpeed,Gust,AirTemperature,RelativeHumidity&station_id=";

        //this number is set based on the selections made to feed the URL
        int COLUMNS = 11;
        long hour;
        //getters and setters
        /*
        public string Temp { get{return _temp;}set{_temp = value;} }
        public string WindSpeed { get { return _windSpeed; } set { _windSpeed = value; } }
        public string Humidity { get { return _humidity; } set { _humidity = value; } }
        public string Gust { get { return _gust; } set { _gust = value; } }
        public string WindDirection { get { return _windDirection; } set { _windDirection = value; } }
        public string Time { get{return _time;}set{_time = value;} }
         * */
        public string StationID { get { return _stationID; } }

        //constructor
        public CorkBuoyM3()
        {
            //initialise the 2D array to the required amount of columns
            table = new string[2, COLUMNS];
            _stationID = "M3";
            //create a current data time stamp as this will only be created
            //once the update method is called hourly
            System.DateTime d = DateTime.UtcNow;

             hour = d.Hour;
            d = d.Date;
            string patt = @"yyyy-MM-dd";
            string newD = d.ToString(patt);
            hour = hour - 1;

            url += "%22" + _stationID + "%22&time>=" + newD + "T" + hour + ":00:00Z";
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
        {
            foreach (Subscriber sub in subscribers)
            {
                //call the overridden method of each subscriber 
                //and pass it this weather station object
                sub.update(this);

            }

            // this.latestUpdate = "Cork:Jan26 10:00 ⛅ 9.5°C  NW/14.7kn/Gust19kn Hum67%  #BuoyM3";
        }

        //this method extracts the info from the URL of ERDDAP and populates the table 2d array
        public override void getUpdate()
        {
            //declare a web object and from that a document object that loads teh URL that is required
            //could set up a method that is passed the URL
            HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
             
            //  "http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?station_id,longitude,latitude,time,AtmosphericPressure,WindDirection,WindSpeed,Gust,AirTemperature,DewPoint,RelativeHumidity&station_id=%22M3%22&time>=2015-02-10T13:00:00Z");

            //18 is all selected http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?station_id,longitude,latitude,time,AtmosphericPressure,WindDirection,WindSpeed,Gust,WaveHeight,WavePeriod,MeanWaveDirection,Hmax,AirTemperature,DewPoint,SeaTemperature,salinity,RelativeHumidity,QC_Flag&time%3E=2015-01-28T17:00:00Z&time%3C=2015-01-28T17:00:00Z");
            //11 is jus weather http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?station_id,longitude,latitude,time,AtmosphericPressure,WindDirection,WindSpeed,Gust,AirTemperature,DewPoint,RelativeHumidity&station_id=%22M3%22&time>=2015-02-05T18:00:00Z

            
            //creating a dictionary to hold the table headings and the values
           // Dictionary<string, string> dictionary = new Dictionary<string, string>();

            //create a 2d string array to store the coloumn headings and values
            //string[,] headings = new string[2, COLUMNS];

            //this is to keep count of index in loops
            int i = 0;

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
                        //dictionary.Add(column.InnerHtml, "");
                        table[0, i] = column.InnerHtml;

                    }
                    i++;
                }
            }
            i = 0;
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
                        //with 2d array
                        table[1, i] = cell.InnerHtml;
                        //with dictionary
                       // dictionary[headings[0, i]] = cell.InnerHtml;
                        i++;
                    }
                }

            }

            //printing to check contence
            
       
            foreach (var h in table)
            { Console.WriteLine(h);  }
             

            string month = DateTime.Now.ToShortDateString();
            string day = DateTime.Now.Day.ToString();
            this.update = month.Substring(0, 0) + hour + ":00 #Buoy" + _stationID + "  ⛅Temp/" + table[1, 5];
            //this.update = month.Substring(0, 6) + " " + table[1, 3].Substring(11, 5) + " #Buoy" + table[1, 0] + "  ⛅Temp/" + table[1, 8] + "°C 💨" + table[1, 6] + "kn/Gust/" + table[1, 7] + "kn Hum/" + table[1, 10] + "%";
            /*headings[0, 4] + " "+ headings[1, 4] + " "+
               headings[0, 5] + " "+headings[1, 5] + " "+ 
              
               headings[0, 7] + " "+headings[1, 7] + " "+ 
               headings[0, 9] + " "+headings[1, 9] + " "+ 
             * */

        }

    }
}
