using Addressbook.BAL;
using Addressbook.ENT;
using System;
using System.Data.SqlTypes;
using System.Drawing;

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region load event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (RouteData.Values["ContactCategoryID"] != null)
            {
                lblMessageMode.Text = "Contact Category Edit ";
                FillEditControl(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactCategoryID"].ToString())));
            }
            else
            {
                lblMessageMode.Text = "Contact Category Add";
            }
        }
    }
    #endregion load event

    #region Button : save
    protected void btnSave_Click(object sender, EventArgs e)
    {

        SqlString strContactCategoryName = SqlString.Null;



        #region server side validation
        //Server side validation
        string strErrorMessage = "";

        if (txtContactCategoryName.Text.Trim() == "")
            strErrorMessage += " - Please Enter ContactCategory Name<br/>";

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion server side validation


        #region Gather Information
        //Gather Information


        if (txtContactCategoryName.Text.Trim() != "")
        {
            strContactCategoryName = txtContactCategoryName.Text.Trim();
        }

        #endregion Gather Information

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        entContactCategory.ContactCategoryName = strContactCategoryName;
        entContactCategory.UserID = Convert.ToInt32(Session["UserID"]);

        if (RouteData.Values["ContactCategoryID"] != null)
        {
            #region Update Record
            //Edit Mode

            entContactCategory.ContactCategoryID = Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactCategoryID"].ToString()));

            if (balContactCategory.UpdateContactCategory(entContactCategory))
            {

                Response.Redirect("~/AdminPanel/ContactCategory/List", true);
            }
            #endregion Update Record

        }
        else
        {
            #region Insert Record
            //Add Mode

            if (balContactCategory.InsertContactCategory(entContactCategory))
            {

                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "<strong>" + txtContactCategoryName.Text.Trim() + "</strong> Insert Successfully";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
            }

            #endregion Insert Record
        }


    }
    #endregion Button : save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/List", true);
    }
    #endregion Button : Cancel

    #region Fill DropDownList
    protected void FillEditControl(SqlInt32 ContactCategoryID)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        ContactCategoryENT entContactCategory = balContactCategory.SelectByPK(ContactCategoryID, Convert.ToInt32(Session["UserID"]));


        if (entContactCategory != null)
        {
            if (!entContactCategory.ContactCategoryName.IsNull)
            {
                txtContactCategoryName.Text = entContactCategory.ContactCategoryName.ToString().Trim();
            }
        }
    }
    #endregion Fill DropDownList

}