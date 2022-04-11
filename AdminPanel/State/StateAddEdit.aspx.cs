using Addressbook.BAL;
using Addressbook.ENT;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;


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

        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        #endregion Local Variable


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

        

            StateBAL balState = new StateBAL();
            StateENT entState = new StateENT();
            entState.CountryID = strCountryID;
            entState.StateName = strStateName;
            entState.StateCode = strStateCode;
            entState.UserID = Convert.ToInt32(Session["UserID"]);

            if (RouteData.Values["StateID"] != null)
            {
                //Edit Mode
                #region Update Record

                entState.StateID = Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["StateID"].ToString()));
                if (balState.UpdateState(entState))
                {
                    lblMessage.Text = "Updated";
                    Response.Redirect("~/AdminPanel/State/List", true);
                }
                else
                {
                    if (balState.Message.Contains("Violation of UNIQUE KEY constraint"))
                    {
                        lblMessage.Text = "This State already exist";

                    }
                    else
                    {
                        lblMessage.Text = balState.Message;

                    }
                }
            #endregion Update Record


        }
        else
            {
                #region Insert Record
                //Add Mode

                if (balState.InsertState(entState))
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "<strong>" + txtStateName.Text.Trim() + "</strong> Insert Successfully";
                    txtStateName.Text = "";
                    txtStateCode.Text = "";
                    ddlCountryID.SelectedIndex = 0;
                    ddlCountryID.Focus();
                }
              
               
                #endregion Insert Record

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

        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID, Convert.ToInt32(Session["UserID"]));


    }
    #endregion Fill DropDownList

    #region Fill Edit Control
    private void FillEditControl(SqlInt32 StateID)
    {

        StateBAL balState = new StateBAL();
        StateENT entState = balState.SelectByPK(StateID, Convert.ToInt32(Session["UserID"]));

        if(entState != null)
        {
            if (!entState.StateName.IsNull)
            {
                txtStateName.Text = entState.StateName.ToString().Trim();
            }
            if (!entState.StateCode.IsNull)
            {
                txtStateCode.Text = entState.StateCode.ToString().Trim();
            }
            if (!entState.CountryID.IsNull)
            {
                ddlCountryID.Text = entState.CountryID.ToString().Trim();
            }
           
        }

       
      
    }
    #endregion Fill Edit Control

}