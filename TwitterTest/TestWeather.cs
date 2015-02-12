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
        internal static Subscriber twit = new Twitter();
        internal static WeatherStation cork = new CorkBuoyM3();
        internal static DateTime lastTimeUpdate = default(DateTime);

        static void Main() 
        {   
            
           //test adding of a subscriber to CorkBuoy WeatherStation
            cork.addSub(twit);
            
             
          //create a Threading.timer object to call the update method every 20000 milliseconds
            Timer time = new Timer(TimerCallback, null, 0, 20000);
            //to keep the console open and to keep the program running
            Console.WriteLine("DO NOT CLOSE  THIS CONSOLE IT WILL STOP THE APPLICATION RUNNING");
            Console.ReadLine();

            /*
            // TwitterCredentials.SetCredentials("2999399709-2wey5BUJYyL7Cm98d8IFFGgF0N3JaBTPMgGDQn2", "RpEA4GGmhzU66ib8THEDjbvrYTq4OOHmOuF9MvDi3tE6H", "d4R7LaqJJWAVB5FgTkkPKtNtY", "boFYhisfKKvBvgZj4pNfDcOQbfqNdv2jeBzh871rkdNrUoBSd3");
            TwitterCredentials.ApplicationCredentials = TwitterCredentials.CreateCredentials("2999399709-2wey5BUJYyL7Cm98d8IFFGgF0N3JaBTPMgGDQn2", "RpEA4GGmhzU66ib8THEDjbvrYTq4OOHmOuF9MvDi3tE6H", "d4R7LaqJJWAVB5FgTkkPKtNtY", "boFYhisfKKvBvgZj4pNfDcOQbfqNdv2jeBzh871rkdNrUoBSd3");

            var credentials = TwitterCredentials.CreateCredentials("Access_Token", "Access_Token_Secret", "Consumer_Key", "Consumer_Secret");
            TwitterCredentials.ExecuteOperationWithCredentials(credentials, () =>
            {
                Tweet.PublishTweet("myTweet");
            });
            * */
        }//end main

        private static void TimerCallback(Object o)
        {
            //call the get update but only return a new value if is a new hour since last update
            lastTimeUpdate = cork.getUpdate(lastTimeUpdate);
            cork.UpdateSubs(lastTimeUpdate);

            //force the collection
            GC.Collect();
        }

      

    }
}
