using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{   //MIPWS means Marine Institute Personal Weather Station connected to www.wunderground.com
    class MIPWS: TestApp.WeatherStation
    {

        public override void addSub(Subscriber sub)
        {
        }
        public override void removeSub(Subscriber sub)
        {
        }

        public override void UpdateSubs()
        {

            // this.latestUpdate = "Dublin:Jan26 10:00 ☔ 6.8°C  W/21kts/Gust25kn Hum81%  #BuoyM2";
        }

        public override DateTime getUpdate(DateTime lastTime)
        {
            return DateTime.Now;

        }
        
    }
}
