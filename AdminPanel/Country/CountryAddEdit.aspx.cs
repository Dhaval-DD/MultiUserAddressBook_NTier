using Addressbook.BAL;
using Addressbook.ENT;
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

            CountryENT entCountry = new CountryENT();

            if (txtCountryName.Text.Trim() != "")
            {
                 entCountry.CountryName= txtCountryName.Text.Trim();
            }
            if (txtCountryCode.Text.Trim() != "")
            {
                entCountry.CountryCode = txtCountryCode.Text.Trim();
            }

        entCountry.UserID = Convert.ToInt32(Session["UserID"]);

        #endregion server side Validation

        

        //save the country data
        //Establish the connection

        #region Set Connection & Command Object

        CountryBAL balCountry = new CountryBAL();

    
            #endregion Set Connection & Command Object

            if (RouteData.Values["CountryID"] != null)
            {
                #region Edit Mode
                entCountry.CountryID = Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CountryID"].ToString()));
            if (balCountry.UpdateCountry(entCountry)){
                Response.Redirect("~/AdminPanel/Country/List", true);

            }
                #endregion Edit Mode
            }
            else
            {
            #region Add Mode

            if (balCountry.InsertCountry(entCountry)) {

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = txtCountryName.Text.Trim() + " : " + txtCountryCode.Text.Trim() + " - " + "Insert Successfully";
                txtCountryName.Text = txtCountryCode.Text = "";
                txtCountryName.Focus();
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
                     
                #endregion Add Mode
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
        CountryBAL balCountry = new CountryBAL();
        CountryENT entCountry = balCountry.SelectByPK(CountryID, Convert.ToInt32(Session["UserID"]));

        if (!entCountry.CountryName.IsNull)
        {
            txtCountryName.Text = entCountry.CountryName.Value.ToString();
        }
        if (!entCountry.CountryCode.IsNull)
        {
            txtCountryCode.Text = entCountry.CountryCode.Value.ToString();
        }

    }
    #endregion Fill Edit Control
}