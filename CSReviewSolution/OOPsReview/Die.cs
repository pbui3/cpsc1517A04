using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
     class Die
    {
        //Data Member
        //Usually private
        private int _Side;
        private string _Color;
        private List<int> listOfValues;

        //Properties
        //Responsible for assigning and retrieving data to/from their associated data member
        //Retriving data uses get{}
        //Assigning data uses set{}
        //Properties need to be exposed to outside users

        //Fully Implemented Property
        //has a defined data member that the dev can directly access
        public int Side
        {
            get
            {
                //Return data of a specific datatype
                return _Side;
            }
            set
            {
                //Assign a value to the data member
                //The supplied value is located in the keyword: value
                //Can include error managing
                if (value >= 6 && value <= 20)
                {
                    _Side = value;
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
    }
}
