using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;

namespace TestApp
{
    class FaceBook : TestApp.Subscriber
    {
        public override void update(WeatherStation ws)
        {
            var client = new FacebookClient();
            dynamic me = client.Get("totten");

        }
    }
}
