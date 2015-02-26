using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tweetinvi;

namespace TestApp
{
    class Twitter : TestApp.Subscriber
    {
        //constructor creates the connection using the twitter API     
        public Twitter(){
            
            try
            {
                //Twitter application connection created with my Dev Keys from test twitter account
                TwitterCredentials.ApplicationCredentials = TwitterCredentials.CreateCredentials(
                    "2999399709-2wey5BUJYyL7Cm98d8IFFGgF0N3JaBTPMgGDQn2",
                    "RpEA4GGmhzU66ib8THEDjbvrYTq4OOHmOuF9MvDi3tE6H",
                    "d4R7LaqJJWAVB5FgTkkPKtNtY",
                    "boFYhisfKKvBvgZj4pNfDcOQbfqNdv2jeBzh871rkdNrUoBSd3");
            }
            catch  (Exception ex)
            {
                Console.WriteLine("Error has occured when accessing Twitter: " + ex);
            }
        }

        public override void update(WeatherStation ws)
        {
            if (ws.Update != null)
            {
                //publish to the test twitter account
                Console.WriteLine("Tweet weather :" + ws.Update);
                try
                {
                    Tweet.PublishTweet(ws.Update);
                }
                catch (System.TypeInitializationException)
                {
                    Console.WriteLine("Publish data could not be read");
                }
            }
        }

    }
}
