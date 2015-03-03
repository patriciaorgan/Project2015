using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using System.Security.Cryptography;
using System.Web;
using System.Net;
using System.IO;

namespace TestApp
{
    class FaceBook : TestApp.Subscriber
    {
        //creating an object of the FacebookClient type from the referanced Facebook API
        FacebookClient client;
        //there is no need for these variables to be used anymore now that have never expireing token
        string app_id = "855349874536252";
        string app_secret ="eeda78e9cf30bc2195a6ac9e46c340d8" ;

        //hard coding in the never ending Access token obtained via the Graph API 
        //by using the temporary access token 
        //to produce a long-life 2 month token for the user, 
        //and then using this token to produce a longlife token for the Fan-page
        string access_token = "CAAMJ76luLzwBAIZAPnZCgC27oojZCmPUfYpkxhHKaajhhsnVBvwyZAgZA7E40HryiIYo6ZCyDLjMMcFoTJhZAZApnpGa6TBqCZC1b7e2EAVXNX2ZCz5yAzuv5vybA3WMcgLYXZCllSZAITG29ZAZANxwZC2uCeqAdLPdUSAfboEIK0ReXMP2TxzegCksi925xZCynmE8dUya3JXHpAmn43tD1C0yzoZCO";

        //constructor
        public FaceBook()
        {
            
            try{
                //instantiating the facebookClient in the constructor and checking for exceptions
                client = new FacebookClient(access_token);
               
            }catch(FacebookOAuthException e)
            {
                Console.WriteLine("Connection to FaceBook failed: " + e);
                throw;
            }
        }

     
        //overriding the update method inherited from Subscriber
        public override void update(WeatherStation ws)
        {
            try
            {
                client.Post("/me/feed", new { message = ws.Update });
                Console.WriteLine("Facebook Post was sent");
            }
            catch
            {
                Console.WriteLine("Posting failed to Facebook");
                throw;
            }

        }  //end update method
 

    }//end Facebook Class

}//end namespace
