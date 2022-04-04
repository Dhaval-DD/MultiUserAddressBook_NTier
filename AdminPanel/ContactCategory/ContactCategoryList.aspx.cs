using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Web.UI.WebControls;


public partial class AdminPanel_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillGrideViewCountry();
        }


        #region //OLD method//

        /*//Establish the connection
    SqlConnection objConn = new SqlConnection();
    objConn.ConnectionString = "data source=ELECTRO;initial catalog=AddressBook; Integrated Security=True;";
    //data source = ELECTRO; --> THis is the source of the Data/Server Name
    //intital catalog=AddressBook; --> This is the name of Database
    //Integrated Security=True;" --> if it is True consider as Windows Authentication.
    //                              in the case of Flase SQL Authentication
    //Integrated Security=False; User ID=aa;Password=passw0d;"  its need ID&Password.

    objConn.Open();   //open connection
    //work here

    //step-2 prepare the command object
    SqlCommand objCmd = new SqlCommand();
    objCmd.Connection = objConn;
    objCmd.CommandType = CommandType.StoredProcedure;
    //objCmd.CommandType = CommandType.Text;
    //objCmd.CommandType = CommandType.TableDirect;
    objCmd.CommandText = "PR_ContactCategory_SelectAll";

    //objCmd.ExecuteNonQuery();   Insert/Update/Delete
    //objCmd.ExecuteReader();     Select
    //objCmd.ExecuteScalar();     only for Scalar value is being return (ex:number row)
    //objCmd.ExecuteXmlReader();  XML type of data

    SqlDataReader objSDR = objCmd.ExecuteReader();
    gvContactCategory.DataSource = objSDR;
    gvContactCategory.DataBind();




    objConn.Close();*/

        #endregion //OLD method//


    }
    #endregion Load Event

    #region FillGrideview Country
    private void FillGrideViewCountry()
    {
        #region connection String
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //Read the connection string from web.Config file
        #endregion connection String
        try
        {
            #region Set connection & Command object
            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectAllByUserID";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set connection & Command object

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                gvContactCategory.DataSource = objSDR;
                gvContactCategory.DataBind();
            }
            if (ConnectionState.Closed != objConn.State)
                objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
    }
    #endregion FillGrideview Country

    #region gvContactcotagory
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //Which command button is clicked | e.CommandName
        //Which Row is Clicked | Get Id of row | e.CommandArgument

        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion gvContactcotagory

    #region Delete Records
    private void DeleteState(SqlInt32 ContactCategoryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        try
        {
            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_DeleteByPK";
             
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString());
            objCmd.ExecuteNonQuery();
            
            if (ConnectionState.Closed != objConn.State)
                objConn.Close();

            FillGrideViewCountry();
            //lblMessage.Text = "Deleted ";
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Data deleted successfully!";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (ConnectionState.Closed != objConn.State)
                objConn.Close();
        }

    }
    #endregion Delete Records

}