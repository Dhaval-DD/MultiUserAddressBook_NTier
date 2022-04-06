using Addressbook.BAL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Web.UI.WebControls;


public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            FillGridView();
        }

    }
    #endregion Load Event 

    #region FillGridview 
    private void FillGridView()
    {
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();

        if (Session["UserID"] != null)
        {
            dtCity = balCity.SelectAll(Convert.ToInt32(Session["UserID"]));
        }
        else
        {
            lblMessage.Text = balCity.Message;
        }

        if (dtCity.Rows.Count > 0 && dtCity != null)
        {
            gvCity.DataSource = dtCity;
            gvCity.DataBind();
        }
        
    }
    #endregion FillGridview 

    #region Delete record
    private void DeleteCity(SqlInt32 CityID)
    {
        CityBAL balCity = new CityBAL();
        if (balCity.DeleteCity(CityID, Convert.ToInt32(Session["UserID"])))
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "City deleted successfully";
            FillGridView();
        }
        else
        {
            lblMessage.Text = balCity.Message;
        }

    }
    #endregion Delete record

    #region gvCity RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != null)
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion gvCity RowCommand

}