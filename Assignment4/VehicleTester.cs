using System;
using System.Collections.Generic;//required for using List
/*Patricia Organ - 01110489 - CT546 - Assignment 4
 * */
namespace Assignment4
{
    class VehicleTester
    {
        static void Main(string[] args)
        {
            // create a List of object type vehicle
            // this can use the sort method that has a call to IComparable's method
            // compareTo which we have overriden in Vehicle to sort the way we require
            List<Vehicle> vehicles = new List<Vehicle>();

            // add a few vehicles to the list from the subclasses, 
            // using the various constructors
            vehicles.Add(new MotorCycle(1500));
            vehicles.Add(new Car(false, 2500));
            vehicles.Add(new MotorCycle(500));
            vehicles.Add(new MotorCycle(2500));
            vehicles.Add(new Car(true, 25000));
            vehicles.Add(new Car(4000));

            // now call the display method for alll vehicles in the list 
            // using for each loop, which will call the approprate dispaly method
            // depending on which object it is called apon
            foreach(Vehicle v in vehicles)
            {
                v.Display();
            }

            // need to now sort the List on Value (Hight to Low) and then
            // on alphabethical on Object name (Car then Motorcycle)
            // using the IComparable interface we can achive this
            // List implements the IComparable methods so therefore we now have access to them
            // with our already created List, and we have also overriden the CompareTo method called 
            // from with in the sort method from List
            vehicles.Sort();

            //dispplay the list after it has been sorted
            Console.WriteLine("\nAfter the List is sorted");
            foreach (Vehicle v in vehicles)
            {
                v.Display();
            }

            //require this line to keep console open for longer viewing
            Console.ReadKey();

        }//end Main method
    }//end VehicleTester Class
}//end namespace
