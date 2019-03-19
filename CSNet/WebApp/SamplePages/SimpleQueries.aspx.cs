using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Data;
#endregion

namespace WebApp.SamplePages
{
    public partial class SimpleQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CLear old messages
            MessageLabel.Text = "";
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            int productId = 0;

            //Validate your input
            if (string.IsNullOrEmpty(SearchArg.Text.Trim()))
            {
                //Bad: Message to user
                MessageLabel.Text = "then perish";
            }
            else if (int.TryParse(SearchArg.Text, out productId))
            {
                //Good: Standard lookup pattern and display
                //Since we are leaving this project(WebApp) and going to another project(BLL), user friendly error handling is required
                try
                {
                    //1) Create an instance of the appropriate BLL class
                    ProductController sysmgr = new ProductController();
                    //2) Issue your request to the appropriate BLL class method
                    Product results = sysmgr.Product_Get(int.Parse(SearchArg.Text));
                    //3) Test result to see if anything was found
                    //Null: Product ID not found
                    //Otherwise: Product instance exists
                    if (results == null)
                    {
                        MessageLabel.Text = "No data found for supplied ID";
                    }
                    else
                    {
                        ProductID.Text = results.ProductID.ToString();
                        ProductName.Text = results.ProductName;
                    }
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
            else
            {
                //Bad: Message to user
                MessageLabel.Text = "Product ID must be a number greater than 0";
            }
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            SearchArg.Text = "";
            ProductID.Text = "";
            ProductName.Text = "";
        }
    }
}