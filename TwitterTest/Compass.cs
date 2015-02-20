using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    
    public struct Compass
    {
        
        public string choice;
        private double degrees;

        public Compass(string degree)
        {
            string N = "⬆";
            string S = "⬇";
            string W = "➡";
            string E = "⬅";
            string NW = "↗";
            string NE = "↖";
            string SW = "↘";
            string SE = "↙";

            Console.WriteLine(degree);
            //convert the passed in string into a double
            degrees = Convert.ToDouble(degree);

            if ((degrees > 200) ||( degrees>0 && degrees <15 ))
                choice = N;
            if ((degrees > 200 && degrees > 200) || (degrees >= 0 && degrees < 15))
                choice = S;
            if ((degrees > 200 && degrees > 200) || (degrees > 0 && degrees < 15))
                choice = E;
            if ((degrees > 200 && degrees > 200) || (degrees > 0 && degrees < 15))
                choice = W;
            if ((degrees > 200 && degrees > 200) || (degrees > 0 && degrees < 15))
                choice = NW;
            if ((degrees > 200 && degrees > 200) || (degrees > 0 && degrees < 15))
                choice = NE;
            if ((degrees > 200 && degrees > 200) || (degrees > 0 && degrees < 15))
                choice = SW;
            if ((degrees > 200 && degrees > 200) || (degrees > 0 && degrees < 15))
                choice = SE;
            else
                choice = degrees.ToString() + "°";
        }

       
      
    }
}
