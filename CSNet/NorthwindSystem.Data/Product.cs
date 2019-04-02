using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The annotation used within the .Data project will require the System.ComponentModel.DataAnnotaions assembly
//This assembly is added via your references
#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace NorthwindSystem.Data
{
    //Use an annotation to link this class to the appropriate SQL table
    [Table("Products")]
    public class Product
    {
        //Mapping of the SQL table attributes will be to class prop

            private string _QuantityPerUnit;
        //Use an annotaion to identify the primary key
        //1) Identity pkey on your SQL table
        //   [Key] Pkey name must end in ID or Id
        //2) A compound pkey on your SQL table
        //   [Key, Column(Order=n)] Where n is the natural number indicating the physical order of the attribute in the pkey
        //3) A user supplied pkey on your SQL table (any pkey that is not an identity)
        //   [Key, DatabaseGenerated(DatabaseGeneratedOptions.None)]
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(40, ErrorMessage = "Product Name is limited to 40 characters")]
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        [StringLength(20, ErrorMessage = "Quantity per Unit is limited to 20 characters")]
        public string QuantityPerUnit
        {
            get
            {
                return _QuantityPerUnit;
            }
            set
            {
                _QuantityPerUnit = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        [Range(0.00, double.MaxValue, ErrorMessage = "Unit Price must be 0 dollars or greater")]
        public decimal? UnitPrice { get; set; }
        [Range(0, Int16.MaxValue, ErrorMessage = "Unit In Stock must be 0 dollars or greater")]
        public Int16? UnitsInStock { get; set; }
        [Range(0, Int16.MaxValue, ErrorMessage = "Unit On Order must be 0 dollars or greater")]
        public Int16? UnitsOnOrder { get; set; }
        [Range(0, Int16.MaxValue, ErrorMessage = "Reorder Level must be 0 dollars or greater")]
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //Sample of a computed field on SQL
        //To annotate this property to be takebn as a SQL computed field, use
        //[DatabaseGenerated(DatabaseGeneratedOptions.Computed)]
        //public decimal Total { get; set; }

        //Sample creating a read only property that is not an actual field on your SQL table (FirstName LastName)
        //Use the NotMapped annotation to handle this
        //[NotMapped]
        //public string FullName
        //{
        //    get FirstName + " " + LastName;
        //}
    }
}
