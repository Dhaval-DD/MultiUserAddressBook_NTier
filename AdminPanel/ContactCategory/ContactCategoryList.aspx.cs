using Addressbook.BAL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Web.UI.WebControls;


public partial class AdminPanel_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillGrideView();
        }


    }
    #endregion Load Event

    #region FillGrideview 
    private void FillGrideView()
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        DataTable dtContactCategory = new DataTable();

        if (Session["UserID"] != null)
        {
            dtContactCategory = balContactCategory.SelectAll(Convert.ToInt32(Session["UserID"]));
        }
        else
        {
            lblMessage.Text = balContactCategory.Message;
        }

        if (dtContactCategory.Rows.Count > 0 && dtContactCategory != null)
        {
            gvContactCategory.DataSource = dtContactCategory;
            gvContactCategory.DataBind();
        }
    }
    #endregion FillGrideview 

    #region gvContactcotagory
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //Which command button is clicked | e.CommandName
        //Which Row is Clicked | Get Id of row | e.CommandArgument

        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != null)
            {
                DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion gvContactcotagory

    #region Delete Records
    private void DeleteContactCategory(SqlInt32 ContactCategoryID)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        if (balContactCategory.DeleteContactCategory(ContactCategoryID, Convert.ToInt32(Session["UserID"])))
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "ContactCategory deleted successfully";
            FillGrideView();
        }
        else
        {
            lblMessage.Text = balContactCategory.Message;
        }

    }
    #endregion Delete Records

}