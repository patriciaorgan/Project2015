using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    class DublinBuoyM2: TestApp.WeatherStation
    {

        public override void addSub(Subscriber sub) 
        { 
        }
        public override void removeSub(Subscriber sub)
        { 
        }

        public override void setUpdate(String words)
        {
            this.latestUpdate = words;
           // this.latestUpdate = "Dublin:Jan26 10:00 ☔ 6.8°C  W/21kts/Gust25kn Hum81%  #BuoyM2";
        }
     
        public override String getUpdate() 
        {
            
            return this.latestUpdate;
        }
    }
}
