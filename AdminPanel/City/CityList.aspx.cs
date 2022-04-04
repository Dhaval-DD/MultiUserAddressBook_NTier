using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Web.UI.WebControls;


public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            FillGridView();
        }




        #region //OLD method//
        /* //Establish the connection
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
     objCmd.CommandText = "PR_City_SelectAll";

     //objCmd.ExecuteNonQuery();   Insert/Update/Delete
     //objCmd.ExecuteReader();     Select
     //objCmd.ExecuteScalar();     only for Scalar value is being return (ex:number row)
     //objCmd.ExecuteXmlReader();  XML type of data

     SqlDataReader objSDR = objCmd.ExecuteReader();
     gvCity.DataSource = objSDR;
     gvCity.DataBind();




     objConn.Close();*/

        #endregion //OLD method//

    }
    #endregion Load Event

    #region FillGridview 
    private void FillGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //Read the connection string from web.Config file
        try
        {
            #region set Connection & Command Object
            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectAllByUserID";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion set Connection & Command Object


            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                gvCity.DataSource = objSDR;
                gvCity.DataBind();
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
    #endregion FillGridview 

    #region Delete record
    private void DeleteState(SqlInt32 CityID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region set Connection & Command object
            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_DeleteByPK";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString());
            #endregion set Connection & Command object

            objCmd.ExecuteNonQuery();

            if (ConnectionState.Closed != objConn.State)
                objConn.Close();

            FillGridView();
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
    #endregion Delete record

    #region gvCity RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion gvCity RowCommand

}