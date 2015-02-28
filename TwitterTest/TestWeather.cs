using Facebook;
using HtmlAgilityPack;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using TestApp;
using Tweetinvi;


namespace TestApp
{
   
    class TestWeather
    {

        //declaring these object outside main and internal so they can be used within the namespace
        internal static Subscriber twit = new Twitter();
        internal static Subscriber faceb = new FaceBook();
        internal static WeatherStation cork = new CorkBuoyM3();
        internal static DateTime lastTimeUpdate = default(DateTime);

        static void Main() 
        {
            
            try
            {
                FaceBook fb = new FaceBook();
                /*
                FacebookClient fbClient = new FacebookClient();
                //me = client.Get("marineinst.testweather");
                dynamic result = fbClient.Get("marineinst.testweather", new
                {
                    client_id = fbClient.AppId,
                    client_secret = fbClient.AppSecret,
                    grant_type = "fb_exchange_token",
                    fb_exchange_token = fbClient.AccessToken
                });
                Console.WriteLine(result);
                */
                //fbClient.Post();
            
           //test adding of a subscriber to CorkBuoy WeatherStation
            cork.addSub(twit);

            //create a Threading.timer object to call the update method every 300000 milliseconds 5 mins
             Timer time = new Timer(TimerCallback, null, 0, 90000);

            }catch(Exception e)
            {
                Console.WriteLine("Error has occured and was thrown back to Main: " + e.Message);    
            }
            //to keep the console open and to keep the program running
            Console.WriteLine("DO NOT CLOSE  THIS CONSOLE IT WILL STOP THE APPLICATION RUNNING");
            Console.ReadLine();

        }//end main

        private static void TimerCallback(Object o)
        {
           try
            {
                //call the get update but only return a new value if is a new hour since last update
                lastTimeUpdate = cork.getUpdate(lastTimeUpdate);
                Console.WriteLine("Timer method ran");
            }
           catch (Exception e)
           {
                Console.WriteLine("In timerCallBack Error has occured: " + e.Message);
                throw;
            }
            //force the collection
            GC.Collect();
        }

      

    }
}
