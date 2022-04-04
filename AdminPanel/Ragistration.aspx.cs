using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


public partial class AdminPanel_Ragistration : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Event

    #region Register Button
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strDisplayName = SqlString.Null;
        SqlString strMobileNo = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        #endregion Local Variable

        #region Server Side Validation

        String strErrorMessage = "";
        if (txtUserNameRegister.Text.Trim() == "")
        {
            strErrorMessage += "Enter User Name <br/>";
        }
        if (txtPasswordRegister.Text.Trim() == "")
        {
            strErrorMessage += "Enter PassWord <br/>";
        }
        if (txtDisplayName.Text.Trim() == "")
        {
            strErrorMessage += "Enter Display Name <br/>";
        }
        if (txtMobileNo.Text.Trim() == "")
        {
            strErrorMessage += "Enter Mobile No <br/>";
        }
        if (txtEmail.Text.Trim() == "")
        {
            strErrorMessage += "Enter Email <br/>";
        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = "Kindly Solve the following Errors <br/>" + strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Assign the Value
        if (txtUserNameRegister.Text.Trim() != "")
            strUserName = txtUserNameRegister.Text.Trim();

        if (txtPasswordRegister.Text.Trim() != "")
            strPassword = txtPasswordRegister.Text.Trim();

        if (txtDisplayName.Text.Trim() != "")
            strDisplayName = txtDisplayName.Text.Trim();

        if (txtMobileNo.Text.Trim() != "")
            strMobileNo = txtMobileNo.Text.Trim();

        if (txtEmail.Text.Trim() != "")
            strEmail = txtEmail.Text.Trim();
        #endregion Assign the Value

        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_Insert";

            objCmd.Parameters.AddWithValue("@UserName", strUserName);
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            objCmd.Parameters.AddWithValue("@DisplayName", strDisplayName);
            objCmd.Parameters.AddWithValue("@MobileNo", strMobileNo);
            objCmd.Parameters.AddWithValue("@Email", strEmail);

            objCmd.ExecuteNonQuery();
            #endregion Set Connection & Command Object

            lblMessage.Text = strUserName.ToString() + ": Register successfully";

            #region Clear Controls
            txtUserNameRegister.Text = "";
            txtPasswordRegister.Text = "";
            txtDisplayName.Text = "";
            txtMobileNo.Text = "";
            txtEmail.Text = "";
            #endregion  Clear Controls
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch (Exception ex)
        {
            if(ex.Message.Contains("Violation of UNIQUE KEY constraint 'IX_User'"))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "User already exist!";
            }
            else {
                lblMessage.Text = ex.Message;

            }
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
    }
    #endregion Register Button
}