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
            FillGridView();
        }

        #region //Old Method//

        /*
     

    //Establish the connection
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
    objCmd.CommandText = "PR_State_SelectAll";

    //objCmd.ExecuteNonQuery();   Insert/Update/Delete
    //objCmd.ExecuteReader();     Select
    //objCmd.ExecuteScalar();     only for Scalar value is being return (ex:number row)
    //objCmd.ExecuteXmlReader();  XML type of data

    SqlDataReader objSDR = objCmd.ExecuteReader();
    gvState.DataSource = objSDR;
    gvState.DataBind();




    objConn.Close();
    
     */
        #endregion //Old Method//
    }
    #endregion Load Event

    #region FillGridView
    private void FillGridView()
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //Read the connection string from web.Config file
        #endregion Local Variable

        try
        {
            #region Set Connection & Command Object

            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectAllByUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                gvState.DataSource = objSDR;
                gvState.DataBind();
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
            if (ConnectionState.Closed != objConn.State)
                objConn.Close();
        }

    }
    #endregion FillGridView

    #region gvState : RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
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
    #endregion gvState : RowCommand

    #region Delete State record
    private void DeleteState(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set Connection & Command Object
            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_DeleteByPK";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString());

            objCmd.ExecuteNonQuery();

            if (ConnectionState.Closed != objConn.State)
                objConn.Close();

            #endregion Set Connection & Command Object

            FillGridView();
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Data deleted successfully!";
            //lblMessage.Text = "Deleted ";  
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
    #endregion Delete State record

}