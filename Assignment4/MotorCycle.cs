using System;
/*Patricia Organ - 01110489 - CT546 - Assignment 4
 * */
namespace Assignment4
{
    //MotorCycle class is a subclass of Vehicle
    class MotorCycle:Vehicle
    {
        //calling the base constructor and passing the parameter that was passed
       public  MotorCycle(double value) : base(value)
       {
           //changing the base variables to suit this subClass
           base.Doors = 0;
           base.Wheels = 2;
           base.Seats = 1;
       }//end constructor

        // overriding the display method from vehicle base class
       public override void Display()
       {
           // using the base keyword to referance the value stored in 
           // the base class for this object   
           Console.WriteLine("MotorCycle E{0}", base.Value);
       }//end diaplay method
    }//end MotorCycle class
}//end namespace
