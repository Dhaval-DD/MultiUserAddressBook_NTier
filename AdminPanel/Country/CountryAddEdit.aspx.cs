using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(RouteData.Values["CountryID"] != null)
            {
                lblMessageMode.Text = "Country Edit";
                FillEditContaral(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CountryID"].ToString())));
            }
            else
            {
                lblMessageMode.Text = "Country Add ";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //SqlConnection objConn = new SqlConnection();
        //objConn.ConnectionString = "data source=ELECTRO;initial catalog=AddressBook; Integrated Security=True;";

        #region Connection String 
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Connection String 

        try
        {
            #region Local variable
            //Declare Local variables to insert the data
            SqlString strCountryName = SqlString.Null;
            SqlString strCountryCode = SqlString.Null;
            #endregion Local variable

            #region server side Validation
            //Validation | Server side validation
            string strErrorMessage = "";


            if (txtCountryName.Text.Trim() == "")
                strErrorMessage += " - Enter Country Name ";
            if (txtCountryCode.Text.Trim() == "")
                strErrorMessage += " - Enter Country Code ";

            if (strErrorMessage != "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = strErrorMessage;
                return;
            }

            if (txtCountryName.Text.Trim() != "")
            {
                strCountryName = txtCountryName.Text.Trim();
            }
            if (txtCountryCode.Text.Trim() != "")
            {
                strCountryCode = txtCountryCode.Text.Trim();
            }

            #endregion server side Validation

            //save the country data
            //Establish the connection
           
            #region Set Connection & Command Object

            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            //prepare the command

            //SqlCommand objCmd = new SqlCommand();
            //objCmd.Connection = objConn;
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;


            //Pass the parameter in the SP
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);

            if(Session["UserID"]!=null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
    
            #endregion Set Connection & Command Object

            if (RouteData.Values["CountryID"] != null)
            {
                #region Edit Mode
                objCmd.Parameters.AddWithValue("@CountryId", Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CountryID"].ToString())).ToString().Trim());
                objCmd.CommandText = "[PR_Country_UpdateByPK]";
                objCmd.ExecuteNonQuery();


                Response.Redirect("~/AdminPanel/Country/List", true);
                #endregion Edit Mode

            }
            else
            {
                #region Add Mode

                objCmd.CommandText = "PR_Country_Insert";
                objCmd.ExecuteNonQuery();

                
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = txtCountryName.Text.Trim() + " : " + txtCountryCode.Text.Trim() + " - " + "Insert Successfully";
                txtCountryName.Text = txtCountryCode.Text = "";
                txtCountryName.Focus();
                #endregion Add Mode

            }
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();

        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Violation of UNIQUE KEY constraint "))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "This City already exist!";
            }
            else
            {
                lblMessage.Text = ex.Message;

            }
        }
        finally
        {
            if (ConnectionState.Closed != objConn.State)
                objConn.Close();
        }

    }

    #endregion Button : Save

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/List", true);
    }
    #endregion Button: Cancel

    #region Fill Edit Control
    private void FillEditContaral(SqlInt32 CountryID)
    {
        #region Connection String
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Connection String

        try
        {
            #region Set Connection & Command Object

            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByPK";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());

            #endregion Set Connection & Command Object


            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    //if (objSDR["StateName"].Equals(DBNull.Value) != true)
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CountryID = " + CountryID.ToString();
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
    #endregion Fill Edit Control
}