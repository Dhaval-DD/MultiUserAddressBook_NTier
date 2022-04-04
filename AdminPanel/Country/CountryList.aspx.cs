using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;


public partial class AdminPanel_CountryList : System.Web.UI.Page
{
    #region Load event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridViewCountry();
        }



        #region //OLD method//
        /*
    //Establish the connection
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
    objCmd.CommandText = "PR_Country_SelectAll";

    //objCmd.ExecuteNonQuery();   Insert/Update/Delete
    //objCmd.ExecuteReader();     Select
    //objCmd.ExecuteScalar();     only for Scalar value is being return (ex:number row)
    //objCmd.ExecuteXmlReader();  XML type of data

    SqlDataReader objSDR = objCmd.ExecuteReader();
    gvCountry.DataSource = objSDR;
    gvCountry.DataBind();

    objConn.Close();
    */

        #endregion //OLD method//

    }
    #endregion Load event

    #region Fill GrideView Country
    private void FillGridViewCountry()
    {
        #region connection string
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //Read the connection string from web.Config file
        #endregion connection string

        try
        {
            #region Set Connection & Command Object

            objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectAllByUserID";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object


            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                gvCountry.DataSource = objSDR;
                gvCountry.DataBind();
            }
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
    #endregion Fill GrideView Country

    #region gvCountry : RowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Which command button is clicked | e.CommandName
        //Which Row is Clicked | Get Id of row | e.CommandArgument

        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument.ToString() != "")
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }

    }
    #endregion gvCountry : RowCommand

    #region Delete Country
    private void DeleteCountry(SqlInt32 CountryID)
    {
        #region connection string
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion connection string

        try
        {
            #region Set Connection & Command Object
            if(ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_DeleteByPK";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString());

            objCmd.ExecuteNonQuery();
            #endregion Set Connection & Command Object


            objConn.Close();

            FillGridViewCountry();
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Deleted Successfully ";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if(ConnectionState.Closed != objConn.State)
                objConn.Close();
        }

    }
    #endregion Delete Country

}