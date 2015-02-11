using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{   //MIPWS means Marine Institute Personal Weather Station connected to www.wunderground.com
    class MIPWS: TestApp.WeatherStation
    {

        public override void addSub(Subscriber sub) {
        }
        public override void removeSub(Subscriber sub)
        {
        }
        public override void setUpdate(String words)
        { 
        }

        public override String getUpdate()
        {
            string variable="";
            return variable;

        }
    }
}
