using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        //This static variable is being used in this demo example to hang on to the dummy data
        public static List<DDLClass> DataCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            //This event method is executed each and every time this page is processed
            //This event method is executed before any event method is processed

            //Clear out old messages
            OutputMessage.Text = "";

            //This page is an exellent place to do page initialization of your controls
            //There is a property to test for post back of your page called Page.IsPostBack (equivalent to Razor's IsPost)
            if (!Page.IsPostBack)
            {
                //Do 1st page initialization processing

                //Create an instance of the data collection list
                DataCollection = new List<DDLClass>();

                //Load the data collection with dummy data
                //Normally this data would come from your database
                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(2, "CPSC1517"));
                DataCollection.Add(new DDLClass(3, "DMIT2018"));
                DataCollection.Add(new DDLClass(4, "DMIT1508"));

                //To sort a List<T> use the method .Sort()
                //(x, y) x and y represent any 2 instances in your list at any time
                //x.field compare to y.field : ascending
                //y.field compare to x.field : descending
                // => (lambda) means do the following
                DataCollection.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));

                //Set up the drop down list (would work for radio button and checkbox list)

                //a) Assign your data to the control
                CollectionList.DataSource = DataCollection;

                //b) Assign the data list field name to the appropriate control property
                //  1) .DataValueField is the value of the select
                //  2) .DataTextField is the display of the select
                CollectionList.DataValueField = "ValueField";
                CollectionList.DataTextField = nameof(DDLClass.DisplayField);

                //c) Physically bind the data to the control for show
                CollectionList.DataBind();

                //What about a prompt?
                //One can add a prompt to the start of the bound control list
                //One will use the index 0 to position the prompt
                CollectionList.Items.Insert(0, "Select...");
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            //This method is executed when the submit button is pressed
            //This method is concerned with the actions needed for the submit button

            //To access the data of a control, you use the appropriate control (object) property (get, set) and access technique

            //For Textboxes, Labels, Literals, use .Text
            //For a list (DropDownList, RadioButtonList), use one of
            // .SelectedIndex: The physical location of the item in the list
            // .SelectedValue: The associated data value of the item
            // .SelectedItem: The associated display text of the item
            //For booleans (RadioButton, CheckBox), use .Checked
            //Most controls use strings except for boolean

            string submitChoice = TextBoxNumericChoice.Text;

            //Sample Validation
            if (string.IsNullOrEmpty(submitChoice))
            {
                OutputMessage.Text = "Enter a course choice of 1-4";
            }
            else
            {
                //Set the radio button list using the entered data value
                //Property: .SelectedValue
                RadioButtonListChoice.SelectedValue = submitChoice;

                //Set the checkboxto on if the choice was a programming language
                if (submitChoice.Equals("2") || submitChoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                //Position in the drop down list
                //Use entered data value to position
                //Property: .SelectedValue
                CollectionList.SelectedValue = submitChoice;

                //Demontrate the 3 different access techniques for a list
                //Output will be to a label (appearence will be read only)
                DisplayReadOnly.Text = CollectionList.SelectedItem.Text
                    + " at index " + CollectionList.SelectedIndex
                    + " has a value of " + CollectionList.SelectedValue;
            }
        }
    }
}