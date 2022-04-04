using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        #region Connection String
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Connection String

        try
        {
            #region Set connection & command Object

            //Open the Connection
            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.CommandText = "[PR_Contact_SelectAllByPK_UserID]";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            //objCmd.CommandType = CommandType.Text;
            //objCmd.CommandType = CommandType.TableDirect;


            //objCmd.ExecuteNonQuery(); //Insert/Update/Delete
            //objCmd.ExecuteReader(); //Select
            //objCmd.ExecuteScalar(); //Only one scalar value is being return 
            //objCmd.ExecuteXmlReader(); //XML Type of data

            #endregion Set connection & command Object


            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvContact.DataSource = objSDR;
                gvContact.DataBind();
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close(); //Close the Connection
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion fillGridview

    #region gvContact : RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString()));
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
        #region Connection String
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Connection String

        try
        {
            #region set connection & command object

            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            DeleteContactCategory(ContactID);
            #region Delete Image
            FileInfo file = new FileInfo(Server.MapPath("~/UserContent/" + ContactID.ToString() + ".jpg"));

            if (file.Exists)
            {
                file.Delete();
            }
            #endregion Delete Image


            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_DeleteByPK";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("ContactID", ContactID.ToString());

            #endregion set connection & command object

            objCmd.ExecuteNonQuery();

            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = " Data deleted successfully!";

            if (ConnectionState.Closed != objConn.State)
                objConn.Close();

            
            FillGridView();
            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion Delete record

    #region Delete Image
    private void DeleteContactImage(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("[PR_Contact_DeleteImageByPK]", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();

            FileInfo file = new FileInfo(Server.MapPath("~/UserContent/" + Id.ToString() + ".jpg"));

            if (file.Exists)
            {
                file.Delete();

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Image Deleted Successfully!";
            }
            else
            {
                lblMessage.ForeColor=System.Drawing.Color.Red;
                lblMessage.Text = "Image doesn't upload!";
            }

            #endregion Create Command and Set Parameters

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Delete Image

    private void DeleteContactCategory(SqlInt32 ContactID)
    {
        #region Connection String
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Connection String

        try
        {

            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand("[PR_ContactWiseContactCategory_DeleteByContactID]", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", ContactID);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();

          
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
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