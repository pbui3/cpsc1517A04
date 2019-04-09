using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Addition Namespaces
using NorthwindSystem.DAL;
using NorthwindSystem.Data;
using System.Data.SqlClient;
using System.ComponentModel;
#endregion

namespace NorthwindSystem.BLL
{
    [DataObject]
    //This class will be called from an external source, in our example, this source will be the web page
    //Naming standard is <T>Controller, which represents a particular data class/SQL table
    public class ProductController
    {
        #region Queries
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
        [DataObjectMethod(DataObjectMethodType.Select, false)]
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
        #endregion

        #region Add, Update, Delete
        //The add method will be used to insert a product instance into the database
        //This method will receive an instance of product
        //This method can optionally return the new identity pkey
        public int Product_Add(Product item)
        {
            //The addition of the data will be done in a transaction block
            using (var context = new NorthwindContext())
            {
                //Step 1: staging
                //One adds the new instance to the appropriate DbSet<T>
                //The data needs to be in an instance of <T>
                //Staging does NOT place the record on the database
                //If the pkey of <T> is an identity, the pkey value is not yet set
                context.Products.Add(item);

                //Step 2: Committing
                //If the command to save your DbSet changes is NOT executed, the transaction fails and a rollback is performed
                //If the command to save your DbSet changes is executed and fails, the transaction is rolledback and the appropriate errormessage is issued
                //At this point all the entity validation is executed
                //If the commad to save your DbSet changes is successful, then the data is in the database (unless the database finds an exception)
                //At this pont you new identity pkey value is present in your <T> instance and can be retreived
                context.SaveChanges();

                //Optionally, you can return the new pkey value
                return item.ProductID;
            }
        }

        //Update
        //This logic will mantain the entire database record when updating
        //The result of the commit will return the number of rows affected
        //Input will be an instance of <T> with the pkey value included
        //Output will be rows affected
        public int Product_Update(Product item)
        {
            using (var context = new NorthwindContext())
            {
                //Staging
                //The entire record will be staged
                //Optionally there may be additional attributes on your record that tracks when your update are done and/or who did the update
                //These attributes are filled by the logic in this controller and should NOT be expected from the user
                //item.LastModified = DateTime.Now;
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;

                //Commit
                //This will return the number of rows affected
                return context.SaveChanges();
                
            }
        }

        //Delete
        //Physical delete
        //Logical delete
        //Input: Pkey of the record
        //Output: rows affected
        public int Product_Delete(int productid)
        {
            using (var context = new NorthwindContext())
            {
                ////Physical delete
                ////Removal of record from the database
                ////Find record to remove
                //var existing = context.Products.Find(productid);
                ////Stage record for removal
                //context.Products.Remove(existing);
                ////Commit
                //return context.SaveChanges();

                //Logical delete
                //This action will actually be an update
                //Any attributes that are required for tracking needs to be handled
                //The attributes that indictes the record is logically removed needs to be handled
                //Find record to be "deleted"
                var existing = context.Products.Find(productid);
                //Adjust logical/tracking attributes
                //existing.LastModified = DateTime.Now;
                existing.Discontinued = true;
                //Stage for update
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                //Commit
                return context.SaveChanges();
            }
        }
        #endregion
    }
}