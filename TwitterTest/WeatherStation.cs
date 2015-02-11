using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
     abstract class WeatherStation
    {
        //array is dynamic so can be changed or added to if needed
        protected  Subscriber[] subscribers = new Subscriber[3];
        protected string latestUpdate;
        
        protected double longitude;
        protected double latitude;
        protected double atmoPressure;
        protected double windDir;
        protected double windSpeed;
        protected double gust;
        protected double AirTemp;
        protected double relHumidity;


        public abstract void addSub(Subscriber sub);
        public abstract void removeSub(Subscriber sub);
        public abstract void setUpdate(String words);

        public abstract String getUpdate();
     
    }
}
