using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    class DonegalBuoyM4:TestApp.WeatherStation
    {
        internal string _stationID;

        public DonegalBuoyM4()
        {
            _stationID = "M4";
        }
        
        public string StationID { get { return _stationID; } }

        public override void addSub(Subscriber sub)
        {
        }
        public override void removeSub(Subscriber sub)
        {
        }

        public override void UpdateSubs()
        {

            // this.latestUpdate = "Donegal:Jan26 10:00 ☔ 8.3°C  N/NW/18.7kn/Gust25.9kn #BuoyM4";
        }

        public override void getUpdate(ref DateTime lastTime)
        {
            lastTime = DateTime.Now;
        }

    }
}
