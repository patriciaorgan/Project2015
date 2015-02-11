using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    class DonegalBuoyM4:TestApp.WeatherStation
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
            // this.latestUpdate = "Donegal:Jan26 10:00 ☔ 8.3°C  N/NW/18.7kn/Gust25.9kn #BuoyM4";
        }

        public override String getUpdate()
        {

            return this.latestUpdate;
        }
    }
}
