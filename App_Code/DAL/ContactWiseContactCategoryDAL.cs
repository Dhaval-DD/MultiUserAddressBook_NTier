using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ContactWiseContactCategoryDAL
/// </summary>
namespace AddressBook.DAL
{
    public class ContactWiseContactCategoryDAL : DatabaseConfig
    {
        #region constructor
        public ContactWiseContactCategoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region Local Variable
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variable



        #region Insert ContactWiseContactCategory
        public bool InsertContactWiseContactCategory(List<ContactWiseContactCategoryENT> contactWiseContactCategories)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                foreach (var contactWiseContactCategory in contactWiseContactCategories)
                {
                    #region Create Command and Set Parameters
                    SqlCommand objCmd = new SqlCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_ContactWiseContactCategory_Insert";

                    objCmd.Parameters.AddWithValue("@ContactID", contactWiseContactCategory.ContactID);
                    objCmd.Parameters.AddWithValue("@ContactCategoryID", contactWiseContactCategory.ContactCategoryID);
                    objCmd.Parameters.AddWithValue("@UserID", contactWiseContactCategory.UserID);
                    objCmd.ExecuteNonQuery();
                    #endregion Create Command and Set Parameters
                }

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    _Message = "This ContactWiseContactCategory contain some records, So please delete these record, If you want to delete this ContactWiseContactCategory.";
                    return false;
                }
                else
                {
                    _Message = ex.Message;
                    return false;
                }
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Insert ContactWiseContactCategory

        #region Delete ContactWiseContactCategory By ContactID
        public bool DeleteContactWiseContactCategory(SqlInt32 ContactID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        if (objConn.State != ConnectionState.Open)
                            objConn.Open();

                        #region Create Command and Set Parameters
                        //SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_DeleteByContactIDUserID", objConn);

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactWiseContactCategory_DeleteByContactID";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.ExecuteNonQuery();
                        #endregion Create Command and Set Parameters

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        {
                            _Message = "This ContactWiseContactCategory contain some records, So please delete these record, If you want to delete this ContactWiseContactCategory.";
                            return false;
                        }
                        else
                        {
                            _Message = ex.Message;
                            return false;
                        }
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }

        }
        #endregion Delete ContactWiseContactCategory By ContactID


        #region SelectOrNot
        public List<ContactWiseContactCategoryENT> SelectOrNot(SqlInt32 ContactID, SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand("PR_ContactCategory_SelectOrNot", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@UserID", UserID);
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Create Command and Set Parameters

                List<ContactWiseContactCategoryENT> contactWiseContactCategories = new List<ContactWiseContactCategoryENT>();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();

                        if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"].ToString());
                        }
                        /*if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactCategory.ContactCategoryName = objSDR["ContactCategoryName"].ToString();
                        }*/
                        if (!objSDR["SelectOrNot"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.SelecteOrNot = objSDR["SelectOrNot"].ToString();
                        }
                        if (!objSDR["ContactWiseContactCategoryID"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactWiseContactCategoryID = Convert.ToInt32(objSDR["ContactWiseContactCategoryID"].ToString());
                        }

                        contactWiseContactCategories.Add(entContactWiseContactCategory);
                    }
                }


                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                
                return contactWiseContactCategories;

            }
            catch (Exception ex)
            {
                _Message = ex.Message;
                return null;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion SelectOrNot




    }
}