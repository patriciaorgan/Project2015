using System;
/*Patricia Organ - 01110489 - CT546 - Assignment 4
 * */
namespace Assignment4
{
    //Car class is a subclass of Vehicle
    class Car:Vehicle
    {
        //this local variable is only used in the Car Subclass
        private bool _automatic = false;

        //call the base constructor and pass it the value
        public Car(double value) : base(value)
        {//no change to the automatic status here
        }

        // alternative constructor with a value setting the automatic or not
        // as well as a call to the base constructor that passes the value of vehicle
        public Car( bool engineType, double value) : base(value)
        {
            _automatic = engineType;
        }

        // read only property set for the boolean variable
        public bool Automatic
        { get{return _automatic;}
        }

        // overriding the display method from vehicle super class
        public override void Display()
        {
            // using the this keyword to referance the value stored in 
            // the base class for this object
            Console.WriteLine("Car E{0}", base.Value);
        }//end display method
    }//end Car Class
    
}//end namespace
