using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tweetinvi;
using TestApp;
using HtmlAgilityPack;
using System.Threading;

namespace TestApp
{
    class TestWeather
    {
        //declareing these object outside main and internal so they can be used within  the namespace
        internal static Subscriber twit = new Twitter();
        internal static WeatherStation cork = new CorkBuoyM3();
        internal static DateTime lastTimeUpdate = default(DateTime);

        static void Main() 
        {   
            
           //test adding of a subscriber to CorkBuoy WeatherStation
            cork.addSub(twit);
             
            //create a Threading.timer object to call the update method every 90000 milliseconds
            Timer time = new Timer(TimerCallback, null, 0, 90000);
            //to keep the console open and to keep the program running
            Console.WriteLine("DO NOT CLOSE  THIS CONSOLE IT WILL STOP THE APPLICATION RUNNING");
            Console.ReadLine();

        }//end main

        private static void TimerCallback(Object o)
        {
            //call the get update but only return a new value if is a new hour since last update
            lastTimeUpdate = cork.getUpdate(lastTimeUpdate);

            //force the collection
            GC.Collect();
        }

      

    }
}
