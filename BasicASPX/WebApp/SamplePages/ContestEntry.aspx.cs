using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        //If we had a database we wouldn't use this, this is for demo purpose only
        public static List<NewCollection> nCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                nCollection = new List<NewCollection>();
            }
        }

        protected void Submit_Click1(object sender, EventArgs e)
        {
            //Validate the data coming in
            if (Page.IsValid)
            {
                string firstName = FirstName.Text;
                string lastName = LastName.Text;
                string address1 = StreetAddress1.Text;
                string address2 = StreetAddress2.Text;
                string city = City.Text;
                string province = Province.Text;
                string postalCode = PostalCode.Text;
                string eMail = EmailAddress.Text;
                //Validate the user checking the terms
                if (Terms.Checked)
                {
                    //If yes: Create and load an entry, add to List, display List
                    nCollection.Add(new NewCollection(firstName, lastName, address1, address2, city, province, postalCode, eMail));
                    EntryCollection.DataSource = nCollection;
                    EntryCollection.DataBind();
                }
                else
                {
                    //If no: Message
                    Message.Text = "Please agree to the terms of this contest";
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            Province.SelectedIndex = 0;
            PostalCode.Text = "";
            EmailAddress.Text = "";
            CheckAnswer.Text = "";
            Terms.Checked = false;
        }
    }
}