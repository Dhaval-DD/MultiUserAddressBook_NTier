using Addressbook.BAL;
using Addressbook.ENT;
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


        #region Local variable
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPINCode = SqlString.Null;
        #endregion Local variable

       
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
            CityBAL balCity = new CityBAL();
            CityENT entCity = new CityENT();
            entCity.CityName = strCityName;
            entCity.STDCode = strSTDCode;
            entCity.PINCode = strPINCode;
            entCity.CountryID = strCountryID;
            entCity.StateID = strStateID;
            entCity.UserID = Convert.ToInt32(Session["UserID"]);


            if (RouteData.Values["CityID"] != null)
            {
                #region Update Record
                //Edit Mode
                entCity.CityID = Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CityID"].ToString()));
                if (balCity.UpdateCity(entCity)){

                    Response.Redirect("~/AdminPanel/City/List", true);
                }


                #endregion Update Record

            }
            else
            {
                #region Insert Record
                //Add Mode
                if (balCity.InsertCity(entCity))
                {


                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "<strong>" + txtCityName.Text.Trim() + "</strong> Insert Successfully";
                txtCityName.Text = "";
                txtSTDCode.Text = "";
                txtPINCode.Text = "";
                ddlStateID.SelectedIndex = 0;
                ddlCountryID.SelectedIndex = 0;
                ddlCountryID.Focus();

                }


                #endregion Insert Record

            }


            #endregion  Set Connection & Command Object

      
       

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
        CommonDropDownFillMethods.FillDropDownListStateByCountryID(ddlStateID, Convert.ToInt32(Session["UserID"]), Convert.ToInt32(ddlCountryID.SelectedValue));
    }
    #endregion Fill DropDown State

    #region Fill DropDown Country
    protected void FillDropDownCountryList()
    {

        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID, Convert.ToInt32(Session["UserID"]));

        
    }
    #endregion Fill DropDown Country


    #region Fill Edit Control
    private void FillEditControl(SqlInt32 CityID)
    {
        CityBAL balCity = new CityBAL();
        CityENT entCity = balCity.SelectByPK(CityID, Convert.ToInt32(Session["UserID"]));

        if (entCity != null)
        {
            if (!entCity.CityName.IsNull)
            {
                txtCityName.Text = entCity.CityName.ToString().Trim();
            }
            if (!entCity.CountryID.IsNull)
            {
                ddlCountryID.Text = entCity.CountryID.ToString().Trim();
            }
            if (!entCity.StateID.IsNull)
            {
                ddlStateID.Text = entCity.StateID.ToString().Trim();
            }
            if (!entCity.STDCode.IsNull)
            {
                txtSTDCode.Text = entCity.STDCode.ToString().Trim();
            }
            if (!entCity.PINCode.IsNull)
            {
                txtPINCode.Text = entCity.PINCode.ToString().Trim();
            }
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