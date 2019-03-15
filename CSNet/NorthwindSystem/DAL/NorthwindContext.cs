using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This class needs to have access to ADO.Net entity framework
//The Nuget package EntityFramework has already been added
//This project also need the assemby System.Data.Entity
//This project will need using clauses that points to
//a) the System.Data.Entity namespace
//b) Your data project namesapce
#region Additional Namespaces
using System.Data.Entity;
using NorthwindSystem.Data;
#endregion

namespace NorthwindSystem.DAL
{
    //Thi scontext class will need to inherit DbContext from entity framework
    internal class NorthwindContext:DbContext
    {
        //Setup your class default constructor to supply connection string name to the DbContext inherited class
        public NorthwindContext():base("NWDB")
        {

        }

        //Create an EntityFramework DbSet<T> for each mapped SQL table
        //<T> is your class in the .Data project
        public DbSet<Product> Products { get; set; }
    }
}
