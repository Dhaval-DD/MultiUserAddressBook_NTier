using Addressbook.ENT;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ContactDAL
/// </summary>
namespace Addressbook.DAL
{
    public class ContactDAL : DatabaseConfig
    {

        #region constructor
        public ContactDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region Local Variables : Message
        protected String _Message;
        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variables : Message

        #region SelectAll
        //Get Contact List
        public DataTable SelectAll(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectAllByPK_UserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion Prepared Command

                        #region ReadData & Set Control
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                        return dt;
                        #endregion ReadData & Set Control
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectAll

        #region SelectByPK
        //Get Contact BY ID
        public ContactENT SelectByPK(SqlInt32 ContactID, SqlInt32 UserID)
        {
            //SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepared Command

                        #region ReadData & Set Control
                        ContactENT entContact = new ContactENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactID"].Equals(DBNull.Value))
                                    entContact.ContactID = Convert.ToInt32(objSDR["ContactID"]);
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entContact.UserID = Convert.ToInt32(objSDR["UserID"]);
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entContact.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entContact.StateID = Convert.ToInt32(objSDR["StateID"]);
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entContact.CityID = Convert.ToInt32(objSDR["CityID"]);
                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                    entContact.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);
                                if (!objSDR["ContactName"].Equals(DBNull.Value))
                                    entContact.ContactName = Convert.ToString(objSDR["ContactName"]);
                                if (!objSDR["WhatsappNo"].Equals(DBNull.Value))
                                    entContact.WhatsappNo = Convert.ToString(objSDR["WhatsappNo"]);
                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                    entContact.BirthDate = Convert.ToDateTime(objSDR["BirthDate"]);
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                    entContact.Email = Convert.ToString(objSDR["Email"]);
                                if (!objSDR["Age"].Equals(DBNull.Value))
                                    entContact.Age = Convert.ToInt32(objSDR["Age"]);
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    entContact.Address = Convert.ToString(objSDR["Address"]);
                                if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                                    entContact.BloodGroup = Convert.ToString(objSDR["BloodGroup"]);
                                if (!objSDR["FacebookID"].Equals(DBNull.Value))
                                    entContact.FacebookID = Convert.ToString(objSDR["FacebookID"]);
                                if (!objSDR["LinkdlNID"].Equals(DBNull.Value))
                                    entContact.LinkdINID = Convert.ToString(objSDR["LinkdlNID"]);
                                if (!objSDR["ContactFilePath"].Equals(DBNull.Value))
                                    entContact.ContactFilePath = Convert.ToString(objSDR["ContactFilePath"]);

                            }
                        }

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                        return entContact;
                        #endregion ReadData & Set Control
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectByPK

        #region Insert Contact
        public SqlInt32 InsertContact(ContactENT entContact)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_Insert";
                        objCmd.Parameters.AddWithValue("@UserID", entContact.UserID);
                        objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                        objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                        objCmd.Parameters.AddWithValue("@WhatsappNo", entContact.WhatsappNo);
                        objCmd.Parameters.AddWithValue("@BirthDate", entContact.BirthDate);
                        objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("@Age", entContact.Age);
                        objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                        objCmd.Parameters.AddWithValue("@BloodGroup", entContact.BloodGroup);
                        objCmd.Parameters.AddWithValue("@FacebookID", entContact.FacebookID);
                        objCmd.Parameters.AddWithValue("@LinkdINID", entContact.LinkdINID);

                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                        objCmd.ExecuteNonQuery();



                        #endregion Prepared Command
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        SqlInt32 ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
                        return ContactID;


                    }
                    catch (SqlException sqlex)
                    {

                        Message = sqlex.InnerException.Message.ToString();
                        return 0;

                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return 0;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Insert Contact

        #region Update Contact
        public Boolean UpdateContact(ContactENT entContact, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command & Set Parameters
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_UpdateByPK";

                        if (!UserID.IsNull)
                            objCmd.Parameters.AddWithValue("@UserID", entContact.UserID);
                        objCmd.Parameters.AddWithValue("@ContactID", entContact.ContactID);
                        objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                        objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                        objCmd.Parameters.AddWithValue("@WhatsappNo", entContact.WhatsappNo);
                        objCmd.Parameters.AddWithValue("@BirthDate", entContact.BirthDate);
                        objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("@Age", entContact.Age);
                        objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                        objCmd.Parameters.AddWithValue("@BloodGroup", entContact.BloodGroup);
                        objCmd.Parameters.AddWithValue("@FacebookID", entContact.FacebookID);
                        objCmd.Parameters.AddWithValue("@LinkdINID", entContact.LinkdINID);
                        if (!entContact.ContactID.IsNull)
                            objCmd.Parameters.AddWithValue("@ContactCategoryID", entContact.ContactCategoryID);
                        objCmd.ExecuteNonQuery();

                        #endregion Prepared Command & Set Parameters

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        if (sqlex.Message.Contains("Violation of UNIQUE KEY constraint"))
                        {
                            _Message = "This Contact already exist";
                            return false;
                        }
                        else
                        {
                            Message = sqlex.InnerException.Message.ToString();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Update Contact

        #region Delete Contact
        public Boolean DeleteContact(SqlInt32 ContactID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {

                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command & Set Parameters
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_DeleteByPK";

                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        objCmd.ExecuteNonQuery();

                        #endregion Prepared Command & Set Parameters

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        if (sqlex.Message.Contains("The DELETE Statement conflicted with the REFERENCE constraint"))
                        {
                            _Message = "This Contact contain some records, So please delete these record, If you want to delete this Contact.";
                            return false;
                        }
                        else
                        {
                            _Message = sqlex.Message;
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Delete Contact



        //-------------------------Image----------------------------//
        #region Delete Image

        public Boolean DeleteImage(SqlInt32 ContactID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_DeleteImageByPK";

                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        objCmd.ExecuteNonQuery();

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Delete Image

        #region Update Image

        public Boolean UpdateImage(SqlInt32 UserID, SqlInt32 ContactID, SqlString ContactFilePath, SqlInt32 FileSize, SqlString FileType)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Create Command and Set Parameters

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_UpdateImagePathByPKUserID";

                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmd.Parameters.AddWithValue("@ContactFilePath", ContactFilePath);
                        objCmd.Parameters.AddWithValue("@FileSize", FileSize);
                        objCmd.Parameters.AddWithValue("@FileType", FileType);
                        #endregion Create Command and Set Parameters


                        objCmd.ExecuteNonQuery();

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Update Image
        //-------------------------/Image/---------------------------//


    }
}