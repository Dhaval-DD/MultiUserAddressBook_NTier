using Addressbook.BAL;
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
        StateBAL balState = new StateBAL();
        DataTable dtState = new DataTable();

        if (Session["UserID"] != null)
        {
            dtState = balState.SelectAll(Convert.ToInt32(Session["UserID"]));
        }
        else
        {
            lblMessage.Text = balState.Message;
        }

        if (dtState.Rows.Count > 0 && dtState != null)
        {
            gvState.DataSource = dtState;
            gvState.DataBind();
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
            if (e.CommandArgument.ToString() != null)
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion gvState : RowCommand

    #region Delete State record
    private void DeleteState(SqlInt32 StateID)
    {
        StateBAL balState = new StateBAL();
        if (balState.DeleteState(StateID, Convert.ToInt32(Session["UserID"])))
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "State deleted successfully";
            FillGridView();
        }
        else
        {
            lblMessage.Text = balState.Message;
        }
    }
    #endregion Delete State record

}