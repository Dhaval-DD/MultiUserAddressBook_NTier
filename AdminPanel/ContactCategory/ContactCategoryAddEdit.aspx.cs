using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        SqlString strContactCategoryName = SqlString.Null;

        #endregion Local Variable

        try
        {
            #region server side validation
            //Server side validation
            string strErrorMessage = "";

            if (txtContactCategoryName.Text.Trim() == "")
                strErrorMessage += " - Please Enter state Name<br/>";

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


            #region Set Connection & Command Object
            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            #endregion Set Connection & Command Object


            if (RouteData.Values["ContactCategoryID"] != null)
            {
                #region Update Record
                //Edit Mode
                objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(EncryptDecrypt.Base64Encode(RouteData.Values["ContactCategoryID"].ToString())));
                objCmd.CommandText = "[PR_ContactCategory_UpdateByPK]";
                objCmd.ExecuteNonQuery();

                Response.Redirect("~/AdminPanel/ContactCategory/List", true);
                #endregion Update Record

            }
            else
            {
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "PR_ContactCategory_Insert";
                objCmd.ExecuteNonQuery();

                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "<strong>" + txtContactCategoryName.Text.Trim() + "</strong> Insert Successfully";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();



                #endregion Insert Record
            }

            if (objConn.State != ConnectionState.Closed)
                objConn.Close();

        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Violation of UNIQUE KEY constraint "))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "This Contact Category already exist!";
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
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        if (objConn.State != ConnectionState.Open)
            objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_ContactCategory_SelectByPK]";

        if (Session["UserID"] != null)
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

        objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());

        SqlDataReader objSDR = objCmd.ExecuteReader();

        if (objSDR.HasRows)
        {
            while (objSDR.Read())
            {
                //if (objSDR["StateName"].Equals(DBNull.Value) != true)
                if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                {
                    txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                }

                break;
            }
        }
        else
        {
            lblMessage.Text = "No Data available for the ContactCategory";
        }
    }
    #endregion Fill DropDownList












































    /* protected void btnSave_Click(object sender, EventArgs e)
 {

     #region //OLD Method//
     *//*
         //Declare Local variables to insert the data

         SqlString strContactCategory = SqlString.Null;

         //Validation | Server side validation
         String strErrorMessage = "";

         if (txtContactCategory.Text.Trim() == "" )
             strErrorMessage += " - Enter Contact Category ";


         if (strErrorMessage != "")
         {
             lblMessage.Text = strErrorMessage;
             return;
         }




         //save the country data
         //Establish the connection

         //SqlConnection objConn = new SqlConnection();
         //objConn.ConnectionString = "data source=ELECTRO;initial catalog=AddressBook; Integrated Security=True;";
         SqlConnection objConn = new SqlConnection("data source = ELECTRO; initial catalog = AddressBook; Integrated Security = True;");

         objConn.Open();

         //prepare the command

         //SqlCommand objCmd = new SqlCommand();
         //objCmd.Connection = objConn;
         SqlCommand objCmd = objConn.CreateCommand();
         objCmd.CommandType = CommandType.StoredProcedure;
         objCmd.CommandText = "[dbo].[PR_ContactCategory_Insert]";



         strContactCategory = txtContactCategory.Text.Trim();
         objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategory);


         objCmd.ExecuteNonQuery();

         objConn.Close();

         lblMessage.Text = "Data Insert Successfully!";
         txtContactCategory.Text = "";
         txtContactCategory.Focus();
        *//*
         #endregion //OLD Method//
       
     } */





}