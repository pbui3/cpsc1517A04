using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Addition Namespaces
using NorthwindSystem.DAL;
using NorthwindSystem.Data;
#endregion

namespace NorthwindSystem.BLL
{
    //This class will be called from an external source, in our example, this source will be the web page
    //Naming standard is <T>Controller, which represents a particular data class/SQL table
    public class ProductController
    {
        //Code method which will be called for processing
        //Method will be public
        //These methods will be referred to as the system interface

        //A method to look up data from the database by the primary key
        //Input: PK value
        //Output: Instance of data class
        public Product Product_Get(int productId)
        {
            //The procesing of the request will be done in a transaction using the Context class
            //a) Instance of COntext class
            //b) Issue the request via the appropriate DbSet<T>
            //c) Return result
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productId);
            }
        }

        //A method to retrieve all records on the DbSet<T>
        //Input: None
        //Output: List<T>
        public List<Product> Product_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }
    }
}
