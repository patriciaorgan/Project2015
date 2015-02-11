using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tweetinvi;
using TestApp;
using HtmlAgilityPack;

namespace TestApp
{
    class TestWeather
    {
        static void Main() 
        {   
            //test creation of Bouy class object and test what date formate is outputted

            CorkBuoyM3 m3 = new CorkBuoyM3();
           // Console.WriteLine(Double.Parse(m3.gsDate.ToString);
            Console.WriteLine(m3.gsTime);
            //Console.ReadLine();


            //declare a web object and from that a document object that loads teh URL that is required
            //could set up a method that is passed the URL
            HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?station_id,longitude,latitude,time,AtmosphericPressure,WindDirection,WindSpeed,Gust,AirTemperature,DewPoint,RelativeHumidity&station_id=%22M3%22&time>=2015-02-10T13:00:00Z");
            
            //18 is all selected http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?station_id,longitude,latitude,time,AtmosphericPressure,WindDirection,WindSpeed,Gust,WaveHeight,WavePeriod,MeanWaveDirection,Hmax,AirTemperature,DewPoint,SeaTemperature,salinity,RelativeHumidity,QC_Flag&time%3E=2015-01-28T17:00:00Z&time%3C=2015-01-28T17:00:00Z");
            //11 is jus weather http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?station_id,longitude,latitude,time,AtmosphericPressure,WindDirection,WindSpeed,Gust,AirTemperature,DewPoint,RelativeHumidity&station_id=%22M3%22&time>=2015-02-05T18:00:00Z

            //this number is set based on the selections made to feed the URL
            int COLUMNS = 11;
            //creating a dictionary to hold the table headings and the values
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            
            //create a 2d string array to store the coloumn headings and values
            string[,] headings = new string[2,COLUMNS];
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
                        dictionary.Add(column.InnerHtml, "");
                        headings[0, i] = column.InnerHtml;
       
                    }
                    i++;
                }
            }
            i=0;
           foreach (HtmlNode cell in doc.DocumentNode.SelectNodes("//table[@class='erd commonBGColor']/tr/td"))
            {
                //a catch to ensure the node is not null
                if (cell.InnerHtml == null )
                {
                    continue;
                }
                else
                {
                    if (i < COLUMNS)
                    {
                    //with 2d array
                    headings[1, i] = cell.InnerHtml;
                    //with dictionary
                    dictionary[headings[0, i]] = cell.InnerHtml;
                    i++;
                      }
                }
           
            }

            //printing to check contence
            /*
            foreach (var d in dictionary)
            { Console.WriteLine(d);  }
            foreach (var h in headings)
            { Console.WriteLine(h);  }
             * */

           string month = DateTime.Now.ToShortDateString();
           string day = DateTime.Now.Day.ToString();
           string update = month.Substring(0,6)+" "+headings[1, 3].Substring(11, 5)+" #Buoy" +headings[1, 0]+ "  ⛅Temp/"+headings[1, 8]+"°C 💨"+headings[1, 6]+"kn/Gust/"+headings[1, 7]+"kn Hum/"+headings[1, 10]+"%";
            /*headings[0, 4] + " "+ headings[1, 4] + " "+
               headings[0, 5] + " "+headings[1, 5] + " "+ 
              
               headings[0, 7] + " "+headings[1, 7] + " "+ 
               headings[0, 9] + " "+headings[1, 9] + " "+ 
             * */
              

            Console.WriteLine(update);
           //string to test emojicons from application
            //string testemoji = "Feb05 18:00 ⛅ 9.5°C 💨NW/14.7kn/Gust19kn Hum67%  #BuoyM3";

           // Console.WriteLine(testemoji);
            //Twitter application connection created and test publishing
            try
            {

                TwitterCredentials.ApplicationCredentials = TwitterCredentials.CreateCredentials(
                    "2999399709-2wey5BUJYyL7Cm98d8IFFGgF0N3JaBTPMgGDQn2",
                    "RpEA4GGmhzU66ib8THEDjbvrYTq4OOHmOuF9MvDi3tE6H",
                    "d4R7LaqJJWAVB5FgTkkPKtNtY",
                    "boFYhisfKKvBvgZj4pNfDcOQbfqNdv2jeBzh871rkdNrUoBSd3");

                Tweet.PublishTweet(update);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error has occured: " + ex);
            }
            
            Console.ReadKey();
        
          
        }

    }
}
