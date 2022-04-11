using Addressbook.BAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Web.UI.WebControls;


public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillDropDownCountryList();
            FillcblContactCategoryList();

            //FillDropDownContactCategoryList();

            if (RouteData.Values["ContactID"] != null)
            {
                lblMessageMode.Text = "Edit Country  ";

                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())));
                FillDropDownStateList();
                FillDropDownCityList();
            }
            else
            {
                lblMessageMode.Text = "Add Country";
            }
        }
    }
    #endregion Load event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local variable

        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        SqlInt32 ContactID = SqlInt32.Null;

        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactcategoryID = SqlInt32.Null;

        SqlString strContactName = SqlString.Null;
        SqlString strWhatsappNo = SqlString.Null;
        SqlDateTime strBirthdate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlInt32 strAge = SqlInt32.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFacebookID = SqlString.Null;
        SqlString strLinkdINID = SqlString.Null;
        //string ContactFilePath = "";

        #endregion Local variable

        #region server side validation

        //Server side validation
        string strErrorMessage = "";

        if (ddlCountryID.SelectedIndex == 0)
            strErrorMessage += " Select Country <br/>";
        if (ddlStateID.SelectedIndex == 0)
            strErrorMessage += " Select State <br/>";
        if (ddlCityID.SelectedIndex == 0)
            strErrorMessage += " Select City <br/>";
        //if (ddlContactCategoryID.SelectedIndex == 0)
        //    strErrorMessage += " Select Contact Category <br/>";

        if (cblContactCategoryID.SelectedValue == "")
            strErrorMessage += "Please select one contact category <br/>";

        if (txtContactName.Text.Trim() == "")
            strErrorMessage += " - Please Enter Contact Name<br/>";
        if (txtWhatsappNo.Text.Trim() == "")
            strErrorMessage += " - Please Enter WhatsApp Number<br/>";
        if (txtEmail.Text.Trim() == "")
            strErrorMessage += " - Please Enter Email<br/>";

        //if (txtStateCode.Text.Trim() == "")
        //    strErrorMessage += " - Please Enter state Code, Ex:AA<br/>";
        //if (txtPINCode.Text.Trim() == "")
        //    strErrorMessage += " - Please Enter PIN Code, Ex:AA<br/>";

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = strErrorMessage;
            return;
        }

        #endregion server slide validation


        #region Gather Information  
        //Gather Information

        if (ddlCountryID.SelectedIndex > 0)
        {
            strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (ddlCityID.SelectedIndex > 0)
        {
            strCityID = Convert.ToInt32(ddlCityID.SelectedValue);
        }
        if (ddlStateID.SelectedIndex > 0)
        {
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        //if (ddlContactCategoryID.SelectedIndex > 0)
        //{
        //strContactcategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
        //}

        strContactcategoryID = Convert.ToInt32(cblContactCategoryID.SelectedValue);

        if (txtContactName.Text.Trim() != "")
        {
            strContactName = txtContactName.Text.Trim();
        }
        if (txtBirthdate.Text.Trim() != "")
        {

            strBirthdate = Convert.ToDateTime(txtBirthdate.Text.Trim());
        }
        if (txtAge.Text.Trim() != "")
        {
            strAge = Convert.ToInt32(txtAge.Text.Trim());
        }
        if (txtWhatsappNo.Text.Trim() != "")
        {
            strWhatsappNo = txtWhatsappNo.Text.Trim();
        }
        if (txtEmail.Text.Trim() != "")
        {
            strEmail = txtEmail.Text.Trim();
        }
        if (txtAddress.Text.Trim() != "")
        {
            strAddress = txtAddress.Text.Trim();
        }
        if (txtBloodGroup.Text.Trim() != "")
        {
            strBloodGroup = txtBloodGroup.Text.Trim();
        }
        if (txtFacebookID.Text.Trim() != "")
        {
            strFacebookID = txtFacebookID.Text.Trim();
        }
        if (txtLinkdINID.Text.Trim() != "")
        {
            strLinkdINID = txtLinkdINID.Text.Trim();
        }

        //if (txtStateCode.Text.Trim() != "")
        //{
        //    strStateCode = txtStateCode.Text.Trim();
        //}
        //if (txtPINCode.Text.Trim() != "")
        //{
        //    strPINCode = txtPINCode.Text.Trim();
        //}
        #endregion Gather Information  

        ContactBAL balContact = new ContactBAL();
        ContactENT entContact = new ContactENT()
        {
            ContactName = strContactName,
            CountryID = strCountryID,
            StateID = strStateID,
            CityID = strCityID,
            WhatsappNo = strWhatsappNo,
            BirthDate = strBirthdate,
            Email = strEmail,
            Age = strAge,
            BloodGroup = strBloodGroup,
            FacebookID = strFacebookID,
            LinkdINID = strLinkdINID,
            Address = strAddress,
            UserID = Convert.ToInt32(Session["UserID"])
        };


        if (RouteData.Values["ContactID"] != null) //RouteData.Values...
        {
            #region Update Record  
            //Edit Mode

            //ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
            entContact.ContactID = Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString().Trim()));

            string FileType = Path.GetExtension(fuFile.FileName).ToLower();

            if (balContact.UpdateContact(entContact, Convert.ToInt32(Session["UserID"])))
                if (fuFile.HasFile)
                {
                    if (FileType == ".jpge" || FileType == ".jpg" || FileType == ".png" || FileType == ".gif")
                    {
                        UploadImage(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())), FileType);
                    }
                    else
                    {
                        lblMessage.Text = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                        return;
                    }
                }

            DeleteContactCategory(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())));
            AddContactCategory(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())));

            Response.Redirect("~/AdminPanel/Contact/List", true);

            #endregion Update Record
        }
        else
        {
            #region Insert Record

            ////Add Mode

            ContactID = balContact.InsertContact(entContact);
            string FileType = Path.GetExtension(fuFile.FileName).ToLower();

            if (fuFile.HasFile)
            {
                if (FileType == ".jpge" || FileType == ".jpg" || FileType == ".png" || FileType == ".gif")
                {
                    UploadImage(ContactID, FileType);
                    //UploadImage(ContactID, "Image");
                }
                else
                {
                    lblMessage.Text = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                    return;
                }
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }

            AddContactCategory(ContactID);
            ClearControls();
            lblMessage.Text = "<strong>" + strContactName.Value + "</strong>&nbsp;" + " Add successfully";
            #endregion Insert Record
        }
    }
    #endregion Button : Save

    #region Fill ContactCategory
    private void FillContactCategory(SqlInt32 ContactID)
    {
        ContactWiseContactCategoryBAL contactWiseContactCategoryBAL = new ContactWiseContactCategoryBAL();
        List<ContactWiseContactCategoryENT> contactWiseContactCategories = contactWiseContactCategoryBAL.SelectOrNot(ContactID, Convert.ToInt32(Session["UserID"]));

        if (contactWiseContactCategories != null)
        {
            foreach (var contactWiseContactCategory in contactWiseContactCategories)
            {
                if (contactWiseContactCategory.SelectOrNot.Value.ToString() == "Selected")
                {
                    cblContactCategoryID.Items.FindByValue(contactWiseContactCategory.ContactCategoryID.ToString()).Selected = true;
                }
            }
        }
        else
        {
            lblMessage.Text = contactWiseContactCategoryBAL.Message;
        }

    }
    #endregion Fill ContactCategory

    #region Add ContactCategory
    private void AddContactCategory(SqlInt32 ID)
    {

        //We need ContactID (PK) after insertion of the record
        //It is needed to insert record in the table ContactWiseContactCategory

        ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
        List<ContactWiseContactCategoryENT> contactWiseContactCategories = new List<ContactWiseContactCategoryENT>();

        foreach (ListItem item in cblContactCategoryID.Items)
        {
            if (item.Selected)
            {
                ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT()
                {
                    ContactID = ID,
                    ContactCategoryID = Convert.ToInt32(item.Value),
                    UserID = Convert.ToInt32(Session["UserID"])
                };
                contactWiseContactCategories.Add(entContactWiseContactCategory);
            }
        }
        if (!balContactWiseContactCategory.InsertContactWiseContactCategory(contactWiseContactCategories))
        {
            lblMessage.Text = balContactWiseContactCategory.Message;
        }


    }
    #endregion Add ContactCategory

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/List", true);
    }
    #endregion Button: Cancel

    #region Fill Edit Controls
    private void FillControls(SqlInt32 ContactID)
    {
        ContactBAL balContact = new ContactBAL();
        ContactENT entContact = balContact.SelectByPK(ContactID, Convert.ToInt32(Session["UserID"]));


        if (entContact != null)
        {
            if (!entContact.CountryID.IsNull)
            {
                ddlCountryID.SelectedValue = entContact.CountryID.Value.ToString();
            }
            if (!entContact.StateID.IsNull)
            {
                ddlStateID.SelectedValue = entContact.StateID.Value.ToString();
            }
            if (!entContact.CityID.IsNull)
            {
                ddlCityID.SelectedValue = entContact.CityID.Value.ToString();
            }
            if (!entContact.ContactName.IsNull)
            {
                txtContactName.Text = entContact.ContactName.Value.ToString();
            }
            if (!entContact.WhatsappNo.IsNull)
            {
                txtWhatsappNo.Text = entContact.WhatsappNo.Value.ToString();
            }
            if (!entContact.BirthDate.IsNull)
            {
                DateTime dt = entContact.BirthDate.Value;
                txtBirthdate.Text = dt.ToString("yyyy-MM-dd");
            }
            if (!entContact.Email.IsNull)
            {
                txtEmail.Text = entContact.Email.Value.ToString();
            }
            if (!entContact.Age.IsNull)
            {
                txtAge.Text = entContact.Age.Value.ToString();
            }
            if (!entContact.Address.IsNull)
            {
                txtAddress.Text = entContact.Address.Value.ToString();
            }
            if (!entContact.BloodGroup.IsNull)
            {
                txtBloodGroup.Text = entContact.BloodGroup.Value.ToString();
            }
            if (!entContact.FacebookID.IsNull)
            {
                txtFacebookID.Text = entContact.FacebookID.Value.ToString();
            }
            if (!entContact.LinkdINID.IsNull)
            {
                txtLinkdINID.Text = entContact.LinkdINID.Value.ToString();
            }
            if (!entContact.ContactFilePath.IsNull)
            {
                imgContactFilePath.ImageUrl = entContact.ContactFilePath.Value.ToString();
                imgContactFilePath.Visible = true;
                //btnDeleteImage.Visible = true;
            }
            FillContactCategory(ContactID);
        }
        else
        {
            lblMessage.Text = balContact.Message;
        }
    }
    #endregion Fill Edit Controls 

    #region Fill DropDown Country
    protected void FillDropDownCountryList()
    {
        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID, Convert.ToInt32(Session["UserID"]));
    }
    #endregion Fill DropDown Country

    #region Fill DropDown State
    protected void FillDropDownStateList()
    {
        CommonDropDownFillMethods.FillDropDownListStateByCountryID(ddlStateID, Convert.ToInt32(Session["UserID"]), Convert.ToInt32(ddlCountryID.SelectedValue));
    }
    #endregion Fill DropDown State

    #region Fill DropDown City
    protected void FillDropDownCityList()
    {
        CommonDropDownFillMethods.FillDropDownListCitySelectByStateID(ddlCityID, Convert.ToInt32(ddlStateID.SelectedValue), Convert.ToInt32(Session["UserID"]));
    }
    #endregion Fill DropDown City

    # region ddl Country Index Changed
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountryID.SelectedIndex != -1)
        {
            ddlCityID.Items.Clear();
            ddlStateID.Items.Clear();
            FillDropDownStateList();
        }
        else
        {
            ddlStateID.Items.Clear();
            ddlCityID.Items.Clear();
        }
    }
    # endregion Country Index Changed

    # region ddl State Index Changed
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateID.SelectedIndex != -1)
        {
            ddlCityID.Items.Clear();
            FillDropDownCityList();
        }
        else
        {
            ddlCityID.Items.Clear();
        }
    }
    #endregion ddl State Index Changed

    #region Upload Image
    private void UploadImage(SqlInt32 ContactID, string FileType)
    {

        SqlString strFilePath = SqlString.Null;
        #region Image Upload
        strFilePath = "~/UserContent/" + ContactID + ".jpg";

        //Folder creation
        if (!Directory.Exists(Server.MapPath("~/UserContent/")))
        {
            Directory.CreateDirectory(Server.MapPath("~/UserContent/"));
        }
        fuFile.SaveAs(Server.MapPath("~/UserContent/" + ContactID + ".jpg"));
        //File Size--
        long length = new FileInfo(Server.MapPath(strFilePath.ToString())).Length;
        #endregion Image Upload

        ContactBAL balContact = new ContactBAL();
        if (!balContact.UpdateImage(Convert.ToInt32(Session["UserID"]), ContactID, strFilePath, Convert.ToInt32(length), FileType))
        {
            lblMessage.Text = balContact.Message;
        }

    }
    #endregion Upload Image

    #region FillcblContactCategoryList
    protected void FillcblContactCategoryList()
    {

        CommonDropDownFillMethods.FillCBLContactCategoryList(cblContactCategoryID, Convert.ToInt32(Session["UserID"]));
    }
    #endregion FillcblContactCategoryList

    #region Delete ContactCategory
    private void DeleteContactCategory(SqlInt32 ContactID)
    {
        ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
        if (!balContactWiseContactCategory.DeleteContactWiseContactCategory(ContactID, Convert.ToInt32(Session["UserID"])))
        {
            lblMessage.Text = balContactWiseContactCategory.Message;
        }
    }
    #endregion Delete ContactCategory

    #region Fill DropDown ContactCatagory
    protected void FillCBLContactCategoryList()
    {
        CommonDropDownFillMethods.FillCBLContactCategoryList(cblContactCategoryID, Convert.ToInt32(Session["UserID"]));

    }
    #endregion Fill DropDown ContactCatagory

    #region Clear Controls
    private void ClearControls()
    {
        lblMessage.ForeColor = Color.Green;
        lblMessage.Text = "<strong>" + txtContactName.Text.Trim() + " </strong> &nbsp;  Insert Successfully";

        txtContactName.Text = "";
        txtWhatsappNo.Text = "";
        txtBirthdate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtAddress.Text = "";
        txtBloodGroup.Text = "";
        txtFacebookID.Text = "";
        txtLinkdINID.Text = "";
        ddlCountryID.SelectedIndex = 0;
        ddlStateID.SelectedIndex = 0;
        ddlCityID.SelectedIndex = 0;
        //ddlContactCategoryID.SelectedIndex = 0;
        txtContactName.Focus();
        cblContactCategoryID.ClearSelection();


    }
    # endregion Clear Controls
}
