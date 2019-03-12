using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class NewCollection
    {
        private string _Address2;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2
        {
            get
            {
                return _Address2;
            }
            set
            {
                _Address2 = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }

        public NewCollection()
        {

        }

        public NewCollection(string firstName, string lastName, string address1, string address2, string city, string province, string postalCode, string eMail)
        {
            FirstName = firstName;
            LastName = lastName;
            Address1 = address1;
            Address2 = address2;
            City = city;
            Province = province;
            PostalCode = postalCode;
            Email = eMail;
        }
    }
}