using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
     class Die
    {
        private static Random _rnd = new Random();
        //Data Member
        //Usually private
        private int _Sides;
        private string _Color;

        //Properties
        //Responsible for assigning and retrieving data to/from their associated data member
        //Retriving data uses get{}
        //Assigning data uses set{}
        //Properties need to be exposed to outside users

        //Fully Implemented Property
        //has a defined data member that the dev can directly access
        public int Sides
        {
            get
            {
                //Return data of a specific datatype
                return _Sides;
            }
            set
            {
                //Assign a value to the data member
                //The supplied value is located in the keyword: value
                //Can include error managing
                if (value >= 6 && value <= 20)
                {
                    _Sides = value;
                    Roll();
                }
                else
                {
                    throw new Exception("Die cannot be " + value.ToString() + "sided");
                }
            }
        }

        //Auto Implemented Property
        //No data member definition
        //The data member is internally created for you
        //Access to a data member managed by an auto implemented property must be done via the property
        public int FaceValue { get; set; }
        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must supply a color");
                }
                else
                {
                    _Color = value;
                }
            }
        }

        //Constructor
        //Optional
        //Constructor ensure that when an object is created it will be created within a stable state
        //You do not call the constructor directly, it is called for you when you create an instance of a class
        //If you do not code a constructor then one will be created for you with default values
        //If you do code a constructor, then you are responsible for all constructor for the class

        //Syntax: public ClassName(parameters) {coding block}

        //Default Constructor
        //Similar to the system default
        public Die()
        {
            //You can leave the coding block empty
            //You can also set your own default value
            _Sides = 6;
            _Color = "black";
            Roll();
        }

        //Greedy Constructor
        //Will allow the user of a class to pass in a set of values which will be used to set the values of data members
        public Die(int sides, string color, int faceValue)
        {
            Sides = sides;
            Color = color;
            Roll();
        }

        //Behaviors (Methods)
        public void Roll()
        {
            FaceValue = _rnd.Next(1, _Sides + 1);
        }
    }
}
