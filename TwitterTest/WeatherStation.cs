using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
     abstract class WeatherStation
    {

        //array of subscribers, setting to what is required for now but can be increased
        //using a List to be dynamic for Substribers
        internal List<Subscriber> subscribers = new List<Subscriber>();
        

        //2d array to hold the potential headings and data values of ERDDAP HTML pages, has a max number of 18
        internal string[,] table;
        internal string  _update;

        // getter and setter, not abstract as will be common behaviour for all subs
        public string Update
        {
            get { return _update; }
            set { _update = value; }
        }

        public abstract void addSub(Subscriber sub);
        public abstract void removeSub(Subscriber sub);

        //this will update all that is subscribed and been previously added
        public abstract void UpdateSubs();

        //this will use the URL of ERDDAP and call it for the last hour, and store the result in the string 2d array
        public abstract void getUpdate(ref DateTime lastTime);
     
    }
}
