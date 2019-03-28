using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Addition Namespaces
using NorthwindSystem.DAL;
using NorthwindSystem.Data;
using System.Data.SqlClient;
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

        //At times you will need to do a non PK lookup
        //You cannot do .Find()
        //You can call SQL procedure via your contet class via your BLL class method
        //You will use .Database.SqlQuery<T>() NOT the DbSet<T>
        //The args for SqlQuery are
        //a) The sql proc execute statement (as a string)
        //b) If required, any args for the procedure
        //Passing the data args to the procedure will make use of new SqlParamether() object
        //The SqlParameter() object need a using clause (System.Data.SqlClient)
        //SqlParameter takes 2 args
        //a) Procedure parameter name
        //b) Value to be passed
        public List<Product> Product_GetByCategory(int categoryID)
        {
            using (var context = new NorthwindContext())
            {
                //Normally you will find that data from entity framework returns as IEnumerable<T> datatype
                //One can convert the IEnumerable<T> to a list of T using .ToList()
                IEnumerable<Product> results = context.Database.SqlQuery<Product>("Products_GetByCategories @CategoryID", new SqlParameter("CategoryID", categoryID));
                return results.ToList();
            }
        }

        public List<Product> Products_GetByPartialProductName(string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByPartialProductName @PartialName",
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }

        public List<Product> Products_GetBySupplierPartialProductName(int supplierid, string partialproductname)
        {
            using (var context = new NorthwindContext())
            {
                //sometimes there may be a sql error that does not like the new SqlParameter()
                //       coded directly in the SqlQuery call
                //if this happens to you then code your parameters as shown below then
                //       use the parm1 and parm2 in the SqlQuery call instead of the new....
                //don't know why but its weird
                //var parm1 = new SqlParameter("SupplierID", supplierid);
                //var parm2 = new SqlParameter("PartialProductName", partialproductname);
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetBySupplierPartialProductName @SupplierID, @PartialProductName",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("PartialProductName", partialproductname));
                return results.ToList();
            }
        }

        public List<Product> Products_GetForSupplierCategory(int supplierid, int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetForSupplierCategory @SupplierID, @CategoryID",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("CategoryID", categoryid));
                return results.ToList();
            }
        }

        public List<Product> Products_GetByCategoryAndName(int category, string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByCategoryAndName @CategoryID, @PartialName",
                                    new SqlParameter("CategoryID", category),
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
    }
}
