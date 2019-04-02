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
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";

            //The ddl control will be loaded with data form the database
            //Considerations need to be given to the data as to its change frequency
            //If your data doesn't change frequenly, you an load data on page load
            if (!Page.IsPostBack)
            {
                //Use user frienly error handling
                try
                {
                    //Create and connect to the appropriate dll class
                    CategoryController sysmgr = new CategoryController();
                    //Issue the request to the appropriate dll class method and capture results
                    List<Category> datainfo = sysmgr.Category_List();
                    //Optionally sort the result
                    datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                    //Attach data source collection to the ddl
                    CategoryList.DataSource = datainfo;
                    //Set the DataTextField and the DataValueField props
                    CategoryList.DataTextField = "CategoryName";
                    CategoryList.DataValueField = "CategoryID";
                    //Physically bind the data to the ddl control
                    CategoryList.DataBind();
                    //Optionally add a prompt to the ddl control
                    CategoryList.Items.Insert(0, "Select...");
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Ensure a selection was made
            if (CategoryList.SelectedIndex == 0)
            {
                //No selection: Message to user
                MessageLabel.Text = "Select a category";
            }
            else
            {
                //Yes selection: Process lookup
                try
                {
                    //Create and connect to BLL class
                    ProductController sysmgr = new ProductController();
                    //issue request for lookup to appropriate BLL class method and capture result
                    List<Product> datainfo = sysmgr.Product_GetByCategory(int.Parse(CategoryList.SelectedValue));
                    //Check results (.Count() == 0)
                    if (datainfo.Count() == 0)
                    {
                        //No record: message to user
                        MessageLabel.Text = "No entries found for selected category";
                        //Optionally you might want to remove from display any old data so it is not confused with this message
                        //CategoryProductList.DataSource = null;

                        //If you have an empty data template on the gridview and the datasource is empty of records (not null) then the message in the template will be displayed
                        CategoryProductList.DataSource = datainfo;
                        CategoryProductList.DataBind();
                    }
                    else
                    {
                        //Yes record: disply data
                        CategoryProductList.DataSource = datainfo;
                        CategoryProductList.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    //User friendly error handling
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CategoryList.ClearSelection();
            CategoryProductList.DataSource = null;
            CategoryProductList.DataBind();
        }

        protected void CategoryProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //The developer must code this event method wnen they install paging
            //This method will do 2 things
            //a) Set the control's PageIndex property to the data "page" of the data collection, the new page index is located in the e parameter of this method
            CategoryProductList.PageIndex = e.NewPageIndex;

            //b) Refresh the data collection for the control
            //Reissue the call to the database
            //Assign data result to control
            //Bind
            Submit_Click(sender, new EventArgs());
        }

        protected void CategoryProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Access data on the gridview selected row
            //The rows of the gridview are in a collection reffenced by .Rows
            //The row index of the selectde gridview row can be referenced by .SelectedIndex
            //Personal style for convienience
            GridViewRow agvrow = CategoryProductList.Rows[CategoryProductList.SelectedIndex];

            //Accreessing the data on a gridview celll is dependant on how the cell was set up
            //We are using a Template with a web control inside the ItemTemplate
            //Syntax:
            //  (agvrow.FindControl("controlid") as controltype).controltypeaccess
            //.FindControl("controlid") look for the control on the row by the controlid
            //as controltype: Identifies the type of control
            //.controltypeaccess: how the control tpye is accessed for data
            string productid = (agvrow.FindControl("ProductID") as Label).Text;
            string productname = (agvrow.FindControl("ProductName") as Label).Text;
            string discontinued;
            if ((agvrow.FindControl("Discontinued") as CheckBox).Checked)
            {
                discontinued = "discontinued";
            }
            else
            {
                discontinued = "available";
            }
            MessageLabel.Text = productname + " (" + productid + ") is " + discontinued;
        }
    }
}