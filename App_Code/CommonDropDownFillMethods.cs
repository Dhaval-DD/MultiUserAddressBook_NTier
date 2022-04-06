using Addressbook.BAL;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownFillMethods
/// </summary>
public static class CommonDropDownFillMethods
{

    #region FillDropDownListCountry
    public static void FillDropDownListCountry(DropDownList ddlCountry, SqlInt32 UserID) //Pass DropDownList for Argument
    {
        CountryBAL balCountry = new CountryBAL();
        ddlCountry.DataSource = balCountry.SelectForDropDown(UserID);

        ddlCountry.DataValueField = "CountryID";
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataBind();
        ddlCountry.Items.Insert(0, new ListItem("- Select Country -", "-1"));
    }
    #endregion FillDropDownListCountry

    //#region FillDropDownListState
    //public static void FillDropDownListState(DropDownList ddlState, SqlInt32 UserID)
    //{
    //    //StateBAL balState = new StateBAL();
    //    //ddlState.DataSource = balState.GetStateDropDown(StateID, user);

    //    StateBAL balState = new StateBAL();
    //    DataTable dt = balState.SelectForDropDownList(userID);

    //    if (dt.Rows.Count > 0)
    //    {
    //        ddlState.DataSource = dt;
    //        ddlState.DataValueField = "StateID";
    //        ddlState.DataTextField = "StateName";
    //        ddlState.DataBind();
    //    }

    //    ddlState.Items.Insert(0, new ListItem("Select State", "-1"));

    //    //#region Local Variables
    //    //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
    //    //#endregion Local Variables
    //    //try
    //    //{
    //    //    #region Set Connection & Command Object
    //    //    if (objConn.State != ConnectionState.Open)
    //    //        objConn.Open();

    //    //    SqlCommand objCmd = objConn.CreateCommand();
    //    //    objCmd.CommandType = CommandType.StoredProcedure;
    //    //    if (user != null)
    //    //        objCmd.Parameters.AddWithValue("@UserID", user);
    //    //    objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownList]";
    //    //    SqlDataReader objSDR = objCmd.ExecuteReader();
    //    //    #endregion Set Connection & Command Object

    //    //    if (objSDR.HasRows == true)
    //    //    {
    //    //        ddlState.DataSource = objSDR;
    //    //        ddlState.DataValueField = "StateID";
    //    //        ddlState.DataTextField = "StateName";
    //    //        ddlState.DataBind();
    //    //    }

    //    //    ddlState.Items.Insert(0, new ListItem("- Select State -", "-1"));

    //    //    if (objConn.State == ConnectionState.Open)
    //    //        objConn.Close();
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    //lblMessage.Text = ex.Message;
    //    //}
    //    //finally
    //    //{
    //    //    if (objConn.State == ConnectionState.Open)
    //    //        objConn.Close();
    //    //}
    //}
    //#endregion FillDropDownListState

    #region FillDropDownListStateByCountryID
    public static void FillDropDownListStateByCountryID(DropDownList ddlStateID, SqlInt32 UserID, SqlInt32 CountryID)
    {
        StateBAL balState = new StateBAL();
        ddlStateID.DataSource = balState.GetStateDropDown(UserID, CountryID);

        ddlStateID.DataValueField = "StateID";
        ddlStateID.DataTextField = "StateName";
        ddlStateID.DataBind();
        ddlStateID.Items.Insert(0, new ListItem("- Select State -", "-1"));

    }
    #endregion FillDropDownListStateByCountryID

    #region FillDropDownListCitySelectByStateID
    public static void FillDropDownListCitySelectByStateID(DropDownList ddlCityID, SqlInt32 StateID, SqlInt32 UserID)
    {
        CityBAL balCity = new CityBAL();
        ddlCityID.DataSource = balCity.SelectForDropDownByStateID(UserID, StateID);

        ddlCityID.DataValueField = "CityID";
        ddlCityID.DataTextField = "CityName";
        ddlCityID.DataBind();
        ddlCityID.Items.Insert(0, new ListItem("- Select City -", "-1"));


    }
    #endregion FillDropDownListCitySelectByStateID

    #region Fill CBLContactCategoryList
    public static void FillCBLContactCategoryList(CheckBoxList cblContactCategoryID, SqlInt32 UserID)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        cblContactCategoryID.DataSource = balContactCategory.GetContactCategoryDropDown(UserID);

        cblContactCategoryID.DataValueField = "ContactCategoryID";
        cblContactCategoryID.DataTextField = "ContactCategoryName";
        cblContactCategoryID.DataBind();
        //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //    try
        //    {
        //        #region Set Connection & Command Object
        //        if (objConn.State != ConnectionState.Open)
        //            objConn.Open();

        //        SqlCommand objCmd = objConn.CreateCommand();
        //        objCmd.CommandType = CommandType.StoredProcedure;

        //        if (user != null)
        //            objCmd.Parameters.AddWithValue("@UserID", user);

        //        objCmd.CommandText = "[PR_ContactCategory_SelectForDropDownList]";

        //        SqlDataReader objSDR = objCmd.ExecuteReader();
        //        #endregion Set Connection & Command Object

        //        if (objSDR.HasRows)
        //        {
        //            cblContactCategoryID.DataValueField = "ContactCategoryID";
        //            cblContactCategoryID.DataTextField = "ContactCategoryName";
        //            cblContactCategoryID.DataSource = objSDR;
        //            cblContactCategoryID.DataBind();
        //        }

        //        if (objConn.State == ConnectionState.Open)
        //            objConn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //lblMessage.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        if (objConn.State == ConnectionState.Open)
        //            objConn.Close();
        //    }
    }
    #endregion Fill CBLContactCategoryList

}