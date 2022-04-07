    using Addressbook.ENT;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;

/// <summary>
/// Summary description for CountryDAL
/// </summary>
namespace Addressbook.DAL
{
    public class CountryDAL : DatabaseConfig
    {
        #region constructor
        public CountryDAL()
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
        //Get Country List
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
                        objCmd.CommandText = "PR_Country_SelectAllByUserID";
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



        #region Get Country For DropDown
        public DataTable GetCountryDropDown(SqlInt32 UserId)
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
                        DataTable dt = new DataTable();
                        #region Create Command and Bind Data

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectForDropDownList";
                        objCmd.Parameters.AddWithValue("@UserID", UserId);

                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        dt.Load(objSDR);

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return dt;
                        #endregion Create Command and Bind Data

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
        #endregion Get Country For DropDown

        #region SelectByPK
        //Get Country BY ID
        public CountryENT SelectByPK(SqlInt32 CountryID, SqlInt32 UserID)
        {
            //SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Closed)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepared Command

                        #region ReadData & Set Control
                        CountryENT entCountry = new CountryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (!objSDR["CountryID"].Equals(DBNull.Value))
                                entCountry.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                            if (!objSDR["CountryName"].Equals(DBNull.Value))
                                entCountry.CountryName = Convert.ToString(objSDR["CountryName"]);
                            if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                entCountry.CountryCode = Convert.ToString(objSDR["CountryCode"]);
                            if (!objSDR["CountryID"].Equals(DBNull.Value))
                                entCountry.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                            if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                entCountry.CreationDate = Convert.ToDateTime(objSDR["CreationDate"].ToString());
                        }
                        return entCountry;
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



        #region Insert Country
        public Boolean InsertCountry(CountryENT entCountry)
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
                        objCmd.CommandText = "PR_Country_Insert";
                        objCmd.Parameters.AddWithValue("@UserID", entCountry.UserID);
                        objCmd.Parameters.AddWithValue("@CountryID", entCountry.CountryID);
                        objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);

                        objCmd.ExecuteNonQuery();

                        #endregion Prepared Command
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        if (sqlex.Message.Contains("Violation of UNIQUE KEY constraint "))
                        {
                            _Message = "This Country already exist";
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
        #endregion Insert Country

        #region Update Country
        public Boolean UpdateCountry(CountryENT entCountry)
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
                        objCmd.CommandText = "PR_Country_UpdateByPK";

                        objCmd.Parameters.AddWithValue("@CountryD", entCountry.CountryID);
                        objCmd.Parameters.AddWithValue("@UserID", entCountry.UserID);
                        objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);

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
                            _Message = "This Country already exist";
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
        #endregion Update Country

        #region Delete Country
        public Boolean DeleteCountry(SqlInt32 CountryID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Country_DeleteByPK";

                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
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
                            _Message = "This Country contain some records, So please delete these record, If you want to delete this Country.";
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
        #endregion Delete Country

    }
}