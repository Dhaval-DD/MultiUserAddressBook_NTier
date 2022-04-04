using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Web.UI.WebControls;


public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            #region Add/Edit Mode
            if (RouteData.Values["StateID"] != null)
            {
                lblMessageMode.Text = "State Edit";
                FillEditControl(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["StateID"].ToString())));
            }
            else
            {
                lblMessageMode.Text = "State Add ";
            }
            #endregion Add/Edit Mode

        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        #endregion Local Variable


        try
        {

            #region server side validation
            //Server side validation
            string strErrorMessage = "";

            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessage += " - Select Country <br/>";

            if (txtStateName.Text.Trim() == "")
                strErrorMessage += " - Please Enter state Name<br/>";

            if (txtStateCode.Text.Trim() == "")
                strErrorMessage += " - Please Enter state Code, Ex:AA<br/>";

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion server side validation


            #region Gather Information
            //Gather Information

            if (ddlCountryID.SelectedIndex > 0)
            {
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            if (txtStateName.Text.Trim() != "")
            {
                strStateName = txtStateName.Text.Trim();
            }
            if (txtStateCode.Text.Trim() != "")
            {
                strStateCode = txtStateCode.Text.Trim();
            }

            #endregion Gather Information


            #region Set Connection & Command Object
            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@StateCode", strStateCode);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object


            if (RouteData.Values["StateID"] != null)
            {
                #region Update Record
                //Edit Mode
                objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["StateID"].ToString())));
                objCmd.CommandText = "PR_State_UpdateByPK";
                objCmd.ExecuteNonQuery();

                Response.Redirect("~/AdminPanel/State/List", true);
                #endregion Update Record

            }
            else
            {
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "PR_State_Insert";
                objCmd.ExecuteNonQuery();
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text ="<strong>"+ txtStateName.Text.Trim() + "</strong> Insert Successfully";

                txtStateName.Text = "";
                txtStateCode.Text = "";
                ddlCountryID.SelectedIndex = 0;
                ddlCountryID.Focus();
                #endregion Insert Record

            }


            if (objConn.State != ConnectionState.Closed)
                objConn.Close();

        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Violation of UNIQUE KEY constraint "))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "This State already exist!";
            }
            else
            {
                lblMessage.Text = ex.Message;

            }
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }

    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/List", true);

    }
    #endregion Button : Cancel

    #region Fill DropDownList
    protected void FillDropDownList()
    {

        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID, Session["UserID"]);

        #region comment 
        /*#region Local Variable

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variable


        try
        {
            #region Set Connection & Command Object
            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            #endregion Set Connection & Command Object


            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();
            }

            ddlCountryID.Items.Insert(0, new ListItem("- Select Country -", "-1"));


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
        }*/
        #endregion comment 

    }
    #endregion Fill DropDownList

    #region Fill Edit Control
    private void FillEditControl(SqlInt32 StateID)
    {
        #region Local Variable

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variable

        try
        {
            #region Set Connection & Command Object

            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectByPK";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());

            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                while (objSDR.Read())
                {
                    //if (objSDR["StateName"].Equals(DBNull.Value) != true)
                    if (!objSDR["StateName"].Equals(DBNull.Value))
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (!objSDR["StateCode"].Equals(DBNull.Value))
                    {
                        txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the StateID = " + StateID.ToString();
            }
            #endregion Read the value and set the controls
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