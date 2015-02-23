using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    
    public struct Compass
    {
        //declaring the variable for public access
        public string choice;
        

        public Compass(string degree)
        {
            //using emojicons to set the arrow of the direction
            string N = "⬆";
            string S = "⬇";
            string W = "➡";
            string E = "⬅";
            string NW = "↗";
            string NE = "↖";
            string SW = "↘";
            string SE = "↙";
            //needs to be initialised, but all the if statments sould catach all possible numbers
            choice = "";

            //require error handling for the convert method
            try
            {
                //convert the passed in string into a double
                double degrees = Convert.ToDouble(degree);

                if ((degrees >= 345) || (degrees >= 0 && degrees <= 15))
                    choice = N;
                if ((degrees >= 175 && degrees <= 195))
                    choice = S;
                if ((degrees <= 285 && degrees >= 265))
                    choice = E;
                if ((degrees <= 105 && degrees >= 75))
                    choice = W;
                if ((degrees > 15 && degrees < 75))
                    choice = NW;
                if ((degrees > 285 && degrees < 345))
                    choice = NE;
                if ((degrees > 105 && degrees < 175))
                    choice = SW;
                if ((degrees > 195 && degrees < 265))
                    choice = SE;

            }catch(FormatException){
                Console.WriteLine("Passed in parameter was not of a suitable type to convert to a double");
            }

        }//end constructor

    }//end struct Compass
}
