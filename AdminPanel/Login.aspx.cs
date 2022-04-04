using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


public partial class AdminPanel_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //valid User or not valid User
        //UserName, Password

        #region Local Variable

        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;


        #endregion Local Variable

        #region Server side validation

        String strErrorMessage = "";

        if(txtUserNameLogin.Text.Trim() == string.Empty)
        {
            strErrorMessage += "Please Enter UserName <br/>";
        }
        if (txtPasswordLogin.Text.Trim() == string.Empty)
        {
            strErrorMessage += "Please Enter Password <br/>";
        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = "Kindly solve following Error(s)<br/>" + strErrorMessage;
            return;  
        }
        #endregion Server side validation

        #region Assign the Value

        if(txtUserNameLogin.Text.Trim() != string.Empty)
            strUserName=txtUserNameLogin.Text.Trim();
       
        if (txtPasswordLogin.Text.Trim() != string.Empty)
            strPassword = txtPasswordLogin.Text.Trim();

        #endregion Assign the Value

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        try
        {
            if(ConnectionState.Open!=objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByUserNamePassword";

            objCmd.Parameters.AddWithValue("@UserName", strUserName);
            objCmd.Parameters.AddWithValue("@Password", strPassword);


            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                //Valid User
                lblMessage.Text = "Valid User";

                while (objSDR.Read())
                {
                    if (!objSDR["UserID"].Equals(DBNull.Value))
                    {
                        Session["UserID"]=objSDR["UserID"].ToString().Trim();
                    }
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    break;
                }

                Response.Redirect("~/AdminPanel/Default.aspx", true);

            }
            else
            {
                lblMessage.Text = "Either UserName or Password is not valid, Try Again with different UserName & Password";
            }

            if (ConnectionState.Closed != objConn.State)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text= ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
}