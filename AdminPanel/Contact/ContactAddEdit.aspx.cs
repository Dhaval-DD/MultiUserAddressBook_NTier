using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        SqlInt32 ContactID = SqlInt32.Null;

        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactcategoryID = SqlInt32.Null;

        SqlString strContactName = SqlString.Null;
        SqlString strWhatsappNo = SqlString.Null;
        SqlString strBirthdate = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAge = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFacebookID = SqlString.Null;
        SqlString strLinkdINID = SqlString.Null;
        //string ContactFilePath = "";



        #endregion Local variable




        try
        {
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

                strBirthdate = txtBirthdate.Text.Trim();
            }
            if (txtAge.Text.Trim() != "")
            {
                strAge = txtAge.Text.Trim();
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

            #region Set Connection & Command Object

            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityID", strCityID);
            //objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactcategoryID);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@WhatsappNo", strWhatsappNo);
            objCmd.Parameters.AddWithValue("@Birthdate", strBirthdate);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("@FacebookID", strFacebookID);
            objCmd.Parameters.AddWithValue("@LinkdINID", strLinkdINID);

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));

            #endregion Set Connection & Command  Object


            if (RouteData.Values["ContactID"] != null) //RouteData.Values...
            {
                #region Update Record  
                objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactcategoryID);

                //Edit Mode
                //objCmd.Parameters.AddWithValue("@ContactID", RouteData.Values["ContactID"].ToString().Trim());
                objCmd.Parameters.AddWithValue("@ContactID", Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())));
                objCmd.CommandText = "[PR_Contact_UpdateByPK]";

                objCmd.ExecuteNonQuery();

                ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                string FileType = Path.GetExtension(fuFile.FileName).ToLower();

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

                //Add Mode
                objCmd.CommandText = "[PR_Contact_Insert]";
                //we need contactid (pk) after insertion of record
                //it is needed to inserted records  in the table in contact table 
                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                objCmd.ExecuteNonQuery();

                ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);



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

                AddContactCategory(ContactID);


                ClearControls();


                #endregion Insert Record
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion Button : Save

    #region Fill ContactCategory
    private void FillContactCategory(SqlInt32 ID)
    {

        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        #endregion Set Connection
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[PR_ContactCategory_SelectOrNot]";

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.Parameters.AddWithValue("@ContactID", ID);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["SelectOrNot"].ToString() == "Selected")
                    {
                        cblContactCategoryID.Items.FindByValue(objSDR["ContactCategoryID"].ToString()).Selected = true;
                    }
                }
            }


            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            //lblMessage.Text = ex.Message + ex ;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }


    }
    #endregion Fill ContactCategory

    #region Add ContactCategory
    private void AddContactCategory(SqlInt32 ID)
    {

        //We need ContactID (PK) after insertion of the record
        //It is needed to insert record in the table ContactWiseContactCategory


        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        #endregion Set Connection
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();



            foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
            {
                if (liContactCategoryID.Selected)
                {
                    SqlCommand objCmdContactCategory = objConn.CreateCommand();
                    objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                    objCmdContactCategory.CommandText = "[PR_ContactWiseContactCategoery_Insert]";
                    objCmdContactCategory.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    objCmdContactCategory.Parameters.AddWithValue("@ContactID", ID.ToString());
                    objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.Value.ToString());
                    objCmdContactCategory.ExecuteNonQuery();
                }
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message + ex;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
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
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set connection & command object

            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand("PR_Contact_SelectByPK", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", ContactID);

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);


            #endregion Set connection & command object

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString();
                    }
                    //if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    //{
                    //    ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString();
                    //}
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString();
                    }

                    if (!objSDR["WhatsappNo"].Equals(DBNull.Value))
                    {
                        txtWhatsappNo.Text = objSDR["WhatsappNo"].ToString();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {

                        //DateTime.Dat bd = Convert.ToDateTime.Date(objSDR["BirthDate"].ToString());
                        //txtBirthdate.Text = bd.ToShortDateString();

                        //DateTime dt = DateTime.ParseExact(objSDR["BirthDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        //txtBirthdate.Text = dt.ToString();

                        txtBirthdate.Text = Convert.ToDateTime(objSDR["BirthDate"].ToString().Trim()).ToString("yyyy/MM/dd");
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString();
                    }
                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString();
                    }
                    if (!objSDR["FacebookID"].Equals(DBNull.Value))
                    {
                        txtFacebookID.Text = objSDR["FacebookID"].ToString();
                    }
                    if (!objSDR["LinkdlNID"].Equals(DBNull.Value))
                    {
                        txtLinkdINID.Text = objSDR["LinkdlNID"].ToString();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString();
                    }

                    if (!objSDR["ContactFilePath"].Equals(DBNull.Value))
                    {
                        imgContactFilePath.ImageUrl = objSDR["ContactFilePath"].ToString();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "Contact Not Found!";
            }

            FillContactCategory(ContactID);
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
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
    private void UploadImage(SqlInt32 Id, string FileExtention)
    {

        SqlString strFilePath = SqlString.Null;

        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        #endregion Set Connection
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Image Upload

            strFilePath = "~/UserContent/" + Id + ".jpg";

            //Folder creation
            if (!Directory.Exists(Server.MapPath("~/UserContent/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/UserContent/"));
            }

            fuFile.SaveAs(Server.MapPath("~/UserContent/" + Id + ".jpg"));
            //File Size--
            long length = new FileInfo(Server.MapPath(strFilePath.ToString())).Length;
            #endregion Image Upload

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_Contact_UpdateImagePathByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", Id);
            objCmd.Parameters.AddWithValue("@ContactFilePath", strFilePath);
            objCmd.Parameters.AddWithValue("@FileType", Convert.ToString(FileExtention));
            objCmd.Parameters.AddWithValue("@FileSize", Convert.ToString(length));
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));

            objCmd.ExecuteNonQuery();
            #endregion Create Command and Set Parameters

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message + ex;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Upload Image

    protected void FillcblContactCategoryList()
    {

        CommonDropDownFillMethods.FillCBLContactCategoryList(cblContactCategoryID, Convert.ToInt32(Session["UserID"]));

        //#region Connection String
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //#endregion Connection String

        //try
        //{
        //    #region Set Connection & command object

        //    if (ConnectionState.Open != objConn.State)
        //        objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    if (Session["UserID"] != null)
        //        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

        //    objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";

        //    #endregion Set Connection & command object

        //    SqlDataReader objSDR = objCmd.ExecuteReader();

        //    if (objSDR.HasRows == true)
        //    {
        //        cblContactCategoryID.DataSource = objSDR;
        //        cblContactCategoryID.DataValueField = "ContactCategoryID";
        //        cblContactCategoryID.DataTextField = "ContactCategoryName";
        //        cblContactCategoryID.DataBind();
        //    }


        //    if (ConnectionState.Closed != objConn.State)
        //        objConn.Close();
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message;
        //}
        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}

    }

    #region Delete ContactCategory
    private void DeleteContactCategory(SqlInt32 ContactID)
    {
        #region Connection String
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Connection String

        try
        {

            if (ConnectionState.Open != objConn.State)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand("[PR_ContactWiseContactCategory_DeleteByContactID]", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", ContactID);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion Delete ContactCategory



    //#region Fill DropDown ContactCatagory
    //protected void FillDropDownContactCategoryList()
    //{
    //    #region Connection String
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
    //    #endregion Connection String

    //    try
    //    {
    //        #region Set Connection & command object

    //        if (ConnectionState.Open != objConn.State)
    //            objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        if (Session["UserID"] != null)
    //            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

    //        objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";

    //        #endregion Set Connection & command object

    //        SqlDataReader objSDR = objCmd.ExecuteReader();

    //        if (objSDR.HasRows == true)
    //        {
    //            ddlContactCategoryID.DataSource = objSDR;
    //            ddlContactCategoryID.DataValueField = "ContactCategoryID";
    //            ddlContactCategoryID.DataTextField = "ContactCategoryName";
    //            ddlContactCategoryID.DataBind();
    //        }

    //        ddlContactCategoryID.Items.Insert(0, new ListItem("- Select Contact Category -", "-1"));

    //        if (ConnectionState.Closed != objConn.State)
    //            objConn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();
    //    }

    //}
    //#endregion Fill DropDown ContactCatagory

}