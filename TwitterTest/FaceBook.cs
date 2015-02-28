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
        FacebookClient client;
        dynamic me;
        string app_id = "855349874536252";
        string app_secret ="eeda78e9cf30bc2195a6ac9e46c340d8" ;
        string code;
        string oauth;
        string access_token;


        public FaceBook()
        
        {
            
            try{
                /*
                client = new FacebookClient();
                me = client.Get("marineinst.testweather");
                code = me.getAuthOCode;
                me.api('oauth/access_token', {
                client_id: app_id,
                client_secret: app_secret,
                redirect_uri: 'https://www.facebook.com/marineinst.testweather/callback',
                code: code})

                var urlToParse = 'http://yoururl.com/callback?code=.....#_=_';
                
                */

                //string app_secret_proof = GenerateAppSecretProof(access_token, app_secret);
                string shorttoken = HttpUtility.ParseQueryString(HttpUtil.GetHtmlPage("https://graph.facebook.com/oauth/access_token?client_id=" + app_id + "&redirect_uri=http://localhost:3000/&client_secret=" + app_secret + "&code=" + HttpContext.Current.Request.Params.Get("code")))["access_token"];

                string longtoken = HttpUtility.ParseQueryString(HttpUtil.GetHtmlPage("https://graph.facebook.com/oa‌​uth/access_token?client_id=" + app_id + "&client_secret=" + app_secret + "&grant_type=fb_exchange_token&fb_exchange_token=" + shorttoken))["access_token"];

                Facebook.FacebookClient fc = new Facebook.FacebookClient(longtoken);
                dynamic result = fc.Get("me");
                HttpContext.Current.Response.Redirect("/");

                Console.WriteLine("end constructor access short token is {0} /n and long token is {1}", shorttoken, longtoken);
            }catch(Exception e) //FacebookOAuthException e)
            {
                Console.WriteLine("Connection to FaceBook failed: " + e);
                throw;
            }
        }

     

        public override void update(WeatherStation ws)
        {
            me.Post(ws.Update);

        }   
        //this  method will call the encode and decode methods of the Base16 Class
        private string GenerateAppSecretProof(string accessToken, string appSecret)
        {
            byte[] key = Base16.Decode(appSecret);
            byte[] hash;
            using (HMAC hmacAlg = new HMACSHA1(key))
            {
                hash = hmacAlg.ComputeHash(Encoding.ASCII.GetBytes(accessToken));
            }
            return Base16.Encode(hash);
        }
    }//end Facebook Class


    public static class HttpUtil 
    {
        public static string GetHtmlPage(string strURL)
        {
            String strResult;
            WebResponse objResponse;
            WebRequest objRequest = HttpWebRequest.Create(strURL);
            objResponse = objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                strResult = sr.ReadToEnd();
                sr.Close();
            }
            return strResult;
        }
    }//end HttpUtil class

    //the below class is related to making the app_secret proof
    public static class Base16
    {
        private static readonly char[] encoding;
        static Base16()
        {
            encoding = new char[16]
                {
                    '0', '1', '2', '3', '4', '5', '6', '7',
                    '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'
                };
        }
        public static string Encode(byte[] data)
        {
            char[] text = new char[data.Length * 2];
            for (int i = 0, j = 0; i < data.Length; i++)
            {
                text[j++] = encoding[data[i] >> 4];
                text[j++] = encoding[data[i] & 0xf];
            }
            return new string(text);
        }
        public static byte[] Decode(string appsecret)
        {

            int NumberChars = appsecret.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(appsecret.Substring(i, 2), 16);
            return bytes;
        }
    }//end Base16 class


}
