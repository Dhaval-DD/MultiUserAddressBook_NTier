using Addressbook.BAL;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactList : System.Web.UI.Page
{
    #region load event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
            lblMessage.Text = "";
        }
    }
    #endregion load event

    #region fillGridview
    private void FillGridView()
    {

        //Establish the Connection
        //Create empty Connection object 
        ContactBAL balContact = new ContactBAL();
        DataTable dtContact = new DataTable();

        if (Session["UserID"] != null)
        {
            dtContact = balContact.SelectAll(Convert.ToInt32(Session["UserID"]));
        }
        else
        {
            lblMessage.Text = balContact.Message;
        }

        if (dtContact.Rows.Count > 0 && dtContact != null)
        {
            gvContact.DataSource = dtContact;
            gvContact.DataBind();
        }

    }
    #endregion fillGridview

    #region gvContact : RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != null)
            {

                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridView();
            }
        }
        else if (e.CommandName == "DeletePhoto")
        {
            if (e.CommandArgument != null)
            {
                DeleteContactImage(Convert.ToInt32(e.CommandArgument.ToString()));
                FillGridView();
            }
        }

    }
    #endregion gvContact : RowCommand

    #region Delete record
    private void DeleteContact(SqlInt32 ContactID)
    {

        ContactBAL balContact = new ContactBAL();
        DeleteContactWiseContactCategory(ContactID);
        #region Delete Image
        FileInfo file = new FileInfo(Server.MapPath("~/UserContent/" + ContactID.ToString() + ".jpg"));

        if (file.Exists)
        {
            file.Delete();
        }
        #endregion Delete Image
        DeleteContactImage(ContactID);
        if (balContact.DeleteContact(ContactID, Convert.ToInt32(Session["UserID"])))
        {

            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Contact deleted successfully";
            FillGridView();
        }
        else
        {
            lblMessage.Text = balContact.Message;
        }
        FillGridView();

    }
    #endregion Delete record

    #region Delete Image
    private void DeleteContactImage(SqlInt32 ContactID)
    {
        ContactBAL balContact = new ContactBAL();
        if (balContact.DeleteImage(ContactID, Convert.ToInt32(Session["UserID"])))
        {
            FileInfo file = new FileInfo(Server.MapPath("~/UserContent/" + ContactID.ToString() + ".jpg"));

            if (file.Exists)
            {
                file.Delete();
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Image Deleted Successfully!";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Image doesn't uploaded!";
            }

        }
        else
        {
            lblMessage.Text = balContact.Message;

        }

    }
    #endregion Delete Image

    private void DeleteContactWiseContactCategory(SqlInt32 ContactID)
    {

        ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
        if (!balContactWiseContactCategory.DeleteContactWiseContactCategory(ContactID, Convert.ToInt32(Session["UserID"])))
        {
            lblMessage.Text = balContactWiseContactCategory.Message;
        }
    }

}











































#region //OLD method//
/*//Establish the connection
SqlConnection objConn = new SqlConnection();
objConn.ConnectionString = "data source=ELECTRO;initial catalog=AddressBook; Integrated Security=True;";
//data source = ELECTRO; --> THis is the source of the Data/Server Name
//intital catalog=AddressBook; --> This is the name of Database
//Integrated Security=True;" --> if it is True consider as Windows Authentication.
//                              in the case of False SQL Authentication
//Integrated Security=False; User ID=aa;Password=passw0d;"  its need ID&Password.

objConn.Open();   //open connection
//work here

//step-2 prepare the command object
SqlCommand objCmd = new SqlCommand();
objCmd.Connection = objConn;
objCmd.CommandType = CommandType.StoredProcedure;
//objCmd.CommandType = CommandType.Text;
//objCmd.CommandType = CommandType.TableDirect;
objCmd.CommandText = "PR_Contact_SelectAll";

//objCmd.ExecuteNonQuery();   Insert/Update/Delete
//objCmd.ExecuteReader();     Select
//objCmd.ExecuteScalar();     only for Scalar value is being return (ex:number row)
//objCmd.ExecuteXmlReader();  XML type of data

SqlDataReader objSDR = objCmd.ExecuteReader();
gvContact.DataSource = objSDR;
gvContact.DataBind();


objConn.Close();*/
#endregion //OLD method//