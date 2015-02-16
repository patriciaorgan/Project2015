using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tweetinvi;

namespace TestApp
{
    class Twitter : TestApp.Subscriber
    {
         /*try
          //  {
                TwitterCredentials.ApplicationCredentials = TwitterCredentials.CreateCredentials("2999399709-2wey5BUJYyL7Cm98d8IFFGgF0N3JaBTPMgGDQn2","RpEA4GGmhzU66ib8THEDjbvrYTq4OOHmOuF9MvDi3tE6H",  "d4R7LaqJJWAVB5FgTkkPKtNtY", "boFYhisfKKvBvgZj4pNfDcOQbfqNdv2jeBzh871rkdNrUoBSd3");
                
           /* }
            catch(Exception ex)
            {
                Console.WriteLine("Error has occured: " + ex);
            }*/
             
        public Twitter(){
            //Twitter application connection created and test publishing
            try
            {

                TwitterCredentials.ApplicationCredentials = TwitterCredentials.CreateCredentials(
                    "2999399709-2wey5BUJYyL7Cm98d8IFFGgF0N3JaBTPMgGDQn2",
                    "RpEA4GGmhzU66ib8THEDjbvrYTq4OOHmOuF9MvDi3tE6H",
                    "d4R7LaqJJWAVB5FgTkkPKtNtY",
                    "boFYhisfKKvBvgZj4pNfDcOQbfqNdv2jeBzh871rkdNrUoBSd3");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error has occured: " + ex);
            }
        }

        public override void update(WeatherStation ws)
        {
           // string tweetPost = "";
            string heading = ws.table[1, 0];
            Console.WriteLine("Tweet weather " + heading + " " + DateTime.Now);

            //string date = "", time = "", weather = "";

            Tweet.PublishTweet(ws.update);
        }

    }
}
