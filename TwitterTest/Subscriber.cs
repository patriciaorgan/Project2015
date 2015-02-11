using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
     abstract class Subscriber
    {
         public abstract void update(WeatherStation ws);
        
    }
}
