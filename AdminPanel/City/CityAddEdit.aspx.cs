using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownCountryList();
            if (RouteData.Values["CityID"] != null)
            {
                lblMessageMode.Text = "City Edit ";
                FillEditControl(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CityID"].ToString())));
                FillDropDownStateList();

            }
            else
            {
                lblMessageMode.Text = "City Add";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Connection String
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Connection String

        #region Local variable
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPINCode = SqlString.Null;
        #endregion Local variable

        try
        {
            #region Server side validation
            //Server side validation
            string strErrorMessage = "";

            if (ddlStateID.SelectedIndex == 0)
                strErrorMessage += " - Select State <br/>";
            if (ddlCountryID.SelectedIndex == 0)
                strErrorMessage += " - Select Country  <br/>";

            if (txtCityName.Text.Trim() == "")
                strErrorMessage += " - Please Enter City Name<br/>";

            if (txtSTDCode.Text.Trim() == "")
                strErrorMessage += " - Please Enter STD Code<br/>";

            if (txtPINCode.Text.Trim() == "")
                strErrorMessage += " - Please Enter PIN Code<br/>";

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion server side validation

            #region Gather information
            //Gather Information

            if (ddlCountryID.SelectedIndex > 0)
            {
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            if (ddlStateID.SelectedIndex > 0)
            {
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            }
            if (txtCityName.Text.Trim() != "")
            {
                strCityName = txtCityName.Text.Trim();
            }
            if (txtSTDCode.Text.Trim() != "")
            {
                strSTDCode = txtSTDCode.Text.Trim();
            }
            if (txtPINCode.Text.Trim() != "")
            {
                strPINCode = txtPINCode.Text.Trim();
            }
            #endregion Gather information

            #region  Set Connection & Command Object
            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PINCode", strPINCode);

            if (RouteData.Values["CityID"] != null)
            {
                #region Update Record
                //Edit Mode
                objCmd.Parameters.AddWithValue("@CityID", Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CityID"].ToString())));
                objCmd.CommandText = "PR_City_UpdateByPK";
                objCmd.ExecuteNonQuery();

                Response.Redirect("~/AdminPanel/City/List", true);
                #endregion Update Record

            }
            else
            {
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "[PR_City_Insert]";
                objCmd.ExecuteNonQuery();

                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "<strong>" + txtCityName.Text.Trim() + "</strong> Insert Successfully";
                txtCityName.Text = "";
                txtSTDCode.Text = "";
                txtPINCode.Text = "";
                ddlStateID.SelectedIndex = 0;
                ddlStateID.Focus();
                

             
                #endregion Insert Record

            }


            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
            #endregion  Set Connection & Command Object

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
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }


    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/List", true);

    }
    #endregion Button : Cancel

    #region Fill DropDown State 
    protected void FillDropDownStateList()
    {
        //CommonDropDownFillMethods.FillDropDownListState(ddlStateID, Session["UserID"]);
        CommonDropDownFillMethods.FillDropDownListStateByCountryID(ddlStateID, ddlCountryID, Session["UserID"]);

        #region comment 
        /*SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

      try
      {
          #region Set Connection & Command Object

          if (ConnectionState.Open != objConn.State)
              objConn.Open();

          SqlCommand objCmd = objConn.CreateCommand();
          objCmd.CommandType = CommandType.StoredProcedure;
          objCmd.CommandText = "[PR_State_SelectForDropDownList]";

          if (Session["UserID"] != null)
              objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
          #endregion Set Connection & Command Object


          SqlDataReader objSDR = objCmd.ExecuteReader();

          if (objSDR.HasRows == true)
          {
              ddlStateID.DataSource = objSDR;
              ddlStateID.DataValueField = "StateID";
              ddlStateID.DataTextField = "StateName";
              ddlStateID.DataBind();
          }

          ddlStateID.Items.Insert(0, new ListItem("- Select State -", "-1"));

          if (ConnectionState.Closed != objConn.State)
              objConn.Close();
      }
      catch (Exception ex)
      {
          lblMessage.Text = ex.ToString();
      }
      finally
      {
          if (ConnectionState.Closed != objConn.State)
              objConn.Close();
      }
          */
        #endregion comment 
    }
    #endregion Fill DropDown State

    #region Fill DropDown Country
    protected void FillDropDownCountryList()
    {

        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID, Session["UserID"]);

        #region /comment/
        //#region Connection String
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //#endregion Connection String

        //try
        //{
        //    #region Set Connection & Command Object

        //    if (objConn.State != ConnectionState.Open)
        //        objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;

        //    if (Session["UserID"] != null)
        //        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

        //    objCmd.CommandText = "PR_Country_SelectForDropDownList";
        //    #endregion Set Connection & Command Object

        //    SqlDataReader objSDR = objCmd.ExecuteReader();

        //    if (objSDR.HasRows == true)
        //    {
        //        ddlCountryID.DataSource = objSDR;
        //        ddlCountryID.DataValueField = "CountryID";
        //        ddlCountryID.DataTextField = "CountryName";
        //        ddlCountryID.DataBind();
        //    }

        //    ddlCountryID.Items.Insert(0, new ListItem("- Select Country -", "-1"));

        //    if (objConn.State != ConnectionState.Closed)
        //        objConn.Close();
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message;
        //}
        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
        #endregion /comment/
    }
    #endregion Fill DropDown Country


    #region Fill Edit Control
    private void FillEditControl(SqlInt32 CityID)
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
            objCmd.CommandText = "PR_City_SelectByPK";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (!objSDR["PINCode"].Equals(DBNull.Value))
                    {
                        txtPINCode.Text = objSDR["PINCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Data available for the CityID = " + CityID.ToString();
            }
            #endregion Read the value and set the controls

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.ToString();
        }
        finally
        {
            if (ConnectionState.Closed != objConn.State)
                objConn.Close();
        }
    }
    #endregion Fill Edit Control

    # region ddl Country Index Changed
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountryID.SelectedIndex != -1)
        {
            
            ddlStateID.Items.Clear();
            FillDropDownStateList();
        }
        else
        {
            ddlStateID.Items.Clear();
           
        }
    }
    # endregion Country Index Changed
}