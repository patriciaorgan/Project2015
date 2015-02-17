using System;
/*Patricia Organ - 01110489 - CT546 - Assignment 4
 * */
namespace Assignment4
{
    //the base class is going to implement the IComparable interface
    class Vehicle: IComparable
    {
        // as we want all subclasses to have a value setting common state 
        // and behaviours in this vehicle class as it will not be abstract
        private double _value;
        // declaring the variables but not setting them as the 
        // constructor will initialize them
        private int _wheels;
        private int _doors;
        private int _seats;


        // construtor when called will set the value property and 
        // we will have a getter method also
        public Vehicle(double price)
        {
            _value = price;
            _wheels = 4;
            _doors = 4;
            _seats = 4;
        }//end constructor

        //getters and setters
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public int Wheels
        {
            get { return _wheels; }
            set { _wheels = value; }
        }
        public int Doors
        {
            get { return _doors; }
            set { _doors = value; }
        }
        public int Seats
        {
            get { return _seats; }
            set { _seats = value; }
        }


        // making this method virtual to allow other subclass to 
        // write their own versions with an override method
        public virtual void Display()
        {
            Console.WriteLine("Standard vehicle as it is not Abstract,"
            + "has a value of: E{0}", _value);
        }//end display method

        //this methos is implemented as required by the interface IComparable
        public int CompareTo(object obj)
        {
            //this is to ensure the object in teh list is not Null
            if (obj == null)
                return 1;
            
            //create another object variable to initiate the incoming parameter obj
            Vehicle otherVehicle = obj as  Vehicle;
            if (otherVehicle != null) { 
                if (this.GetType().Name == otherVehicle.GetType().Name)
                {
                    //had to reverse the calling from 'other' and the 'this'
                    //to allow for sorting by high to low
                    return otherVehicle.Value.CompareTo(this.Value);
                }

                //this defaults to Alphebetical which is what is required
                return this.GetType().Name.CompareTo(otherVehicle.GetType().Name);
            }
            else { 
                //this errors if  obj is not a Vehicle type or subclass
                throw new ArgumentException("Object is not a Vehicle");
            }
               
        }//end CompareTo method
    }//end Vehicle Class
}//end namespace
