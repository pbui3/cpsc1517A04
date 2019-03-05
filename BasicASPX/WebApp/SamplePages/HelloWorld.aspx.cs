using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class HelloWorld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This method will execute each and every time this page is processed
            //This method will execute before any event method
        }

        protected void PressMe_Click(object sender, EventArgs e)
        {
            OutputMessage.Text = "Hello " + YourName.Text;
        }
    }
}