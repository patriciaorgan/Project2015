using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    class DublinBuoyM2: TestApp.WeatherStation
    {
        internal string _stationID;

        public DublinBuoyM2()
        {
            _stationID = "M2";
        }
        public string StationID { get { return _stationID; } }

        

        public override void addSub(Subscriber sub)
        {
        }
        public override void removeSub(Subscriber sub)
        {
        }

        public override void UpdateSubs(DateTime lastTime)
        {
            
            // this.latestUpdate = "Dublin:Jan26 10:00 ☔ 6.8°C  W/21kts/Gust25kn Hum81%  #BuoyM2";
        }

        public override DateTime getUpdate(DateTime lastTime)
        {
            return DateTime.Now;
        }

    }
}
