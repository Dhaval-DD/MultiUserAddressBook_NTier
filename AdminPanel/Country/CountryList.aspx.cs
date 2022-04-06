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
    #region Load event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridViewCountry();
        }




    }
    #endregion Load event

    #region Fill GrideView Country
    private void FillGridViewCountry()
    {
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();

        if (Session["UserID"] != null)
        {
            dtCountry = balCountry.SelectAll(Convert.ToInt32(Session["UserID"]));
        }
        else
        {
            lblMessage.Text = balCountry.Message;
        }

        if (dtCountry.Rows.Count > 0 && dtCountry != null)
        {
            gvCountry.DataSource = dtCountry;
            gvCountry.DataBind();
        }

    }
    #endregion Fill GrideView Country

    #region gvCountry : RowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Which command button is clicked | e.CommandName
        //Which Row is Clicked | Get Id of row | e.CommandArgument

        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != null)
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }

    }
    #endregion gvCountry : RowCommand

    #region Delete Country
    private void DeleteCountry(SqlInt32 CountryID)
    {
        CountryBAL balCountry = new CountryBAL();
        if (balCountry.DeleteCountry(CountryID, Convert.ToInt32(Session["UserID"])))
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Country deleted successfully";
            FillGridViewCountry();
        }
        else
        {
            lblMessage.Text = balCountry.Message;
        }

    }
    #endregion Delete Country

}