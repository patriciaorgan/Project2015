using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    class CorkBuoyM3: TestApp.WeatherStation
    {
        private string ID = "M3";
        private DateTime dates;
            //"2015-02-02";
        private DateTime time;
            //"10:00:00";

        //this URL is the source of the weather data form ERDDAP, set to equal Buoy M3, changing parameters are the date and the time
       // private string baseURL = "http://erddap.marine.ie/erddap/tabledap/IWBNetwork.htmlTable?station_id,longitude,latitude,time,AtmosphericPressure,WindDirection,WindSpeed,Gust,AirTemperature,RelativeHumidity&station_id=%22M3%22&time>=";
       // private string strdate = dates.ToString;

       // private string complete= baseURL + dates.ToString;
        //Uri update = complete;

        //constructor initialising all the value to the URL html page with the table
        public CorkBuoyM3()
        {
            dates = (DateTime.Now);
            time = DateTime.Now;
            longitude = 0;
            latitude = 0;
            atmoPressure = 0;
            windDir = 0;
            windSpeed = 0;
            gust = 0;
            AirTemp = 0;
            relHumidity = 0;
        }

        public DateTime gsDate
        {
            get {
                return dates;
            }
            set{
                dates = value;
            }
         }
        public DateTime gsTime { get { return time; } set { time = value; } }
        public double Longitude {
            get { return longitude; }
            set { longitude = value; }
        }

        public override void addSub(Subscriber sub)
        {
        }
        public override void removeSub(Subscriber sub)
        {
        }

        public override void setUpdate(String words)
        {
            this.latestUpdate = words;
            // this.latestUpdate = "Cork:Jan26 10:00 ⛅ 9.5°C  NW/14.7kn/Gust19kn Hum67%  #BuoyM3";
        }

        public override String getUpdate()
        {

            return this.latestUpdate;
        }
    }
}
