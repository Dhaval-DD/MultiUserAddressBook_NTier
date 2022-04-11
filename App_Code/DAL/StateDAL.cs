using Addressbook.ENT;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for StateDAL
/// </summary>
namespace Addressbook.DAL
{
    public class StateDAL : DatabaseConfig
    {
        #region constructor
        public StateDAL()
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
        //Get State List
        public DataTable SelectAll(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_State_SelectAllByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion Prepared Command

                        #region ReadData & Set Control
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
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

        #region Get State For DropDown
        public DataTable GetStateDropDown(SqlInt32 UserID, SqlInt32 CountryID)
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

                        if (!CountryID.IsNull)
                        {

                            objCmd.CommandText = "PR_State_SelectByCountryID";
                            objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        }
                        //else
                        //{
                        //    objCmd.CommandText = "PR_State_SelectForDropDownList";
                        //}

                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        dt.Load(objSDR);

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                        return dt;

                        #endregion Create Command and Bind Data

                    }
                    catch (Exception ex)
                    {
                        _Message = ex.ToString();
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
        #endregion Get State For DropDown


        #region SelectByPK
        //Get State BY ID
        public StateENT SelectByPK(SqlInt32 StateID, SqlInt32 UserID)
        {
            //SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_SelectByPK";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepared Command

                        #region ReadData & Set Control
                        StateENT entState = new StateENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entState.StateID = Convert.ToInt32(objSDR["StateID"]);
                                if (!objSDR["StateName"].Equals(DBNull.Value))
                                    entState.StateName = Convert.ToString(objSDR["StateName"]);
                                if (!objSDR["StateCode"].Equals(DBNull.Value))
                                    entState.StateCode = Convert.ToString(objSDR["StateCode"]);
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entState.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                               
                                break;
                            }
                        }
                        return entState;
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

        #region Insert State
        public Boolean InsertState(StateENT entState)
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
                        objCmd.CommandText = "PR_State_Insert";
                        objCmd.Parameters.AddWithValue("@UserID", entState.UserID);
                        objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                        objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                        objCmd.Parameters.AddWithValue("@StateCode", entState.StateCode);

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
                            _Message = "This State already exist";
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
        #endregion Insert State

        #region Update State
        public Boolean UpdateState(StateENT entState)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command & Set Parameters
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_UpdateByPK";

                        objCmd.Parameters.AddWithValue("@StateID", entState.StateID);
                        objCmd.Parameters.AddWithValue("@UserID", entState.UserID);
                        objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                        objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                        objCmd.Parameters.AddWithValue("@StateCode", entState.StateCode);

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
                            _Message = "This State already exist";
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
        #endregion Update State

        #region Delete State
        public Boolean DeleteState(SqlInt32 StateID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command & Set Parameters
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_DeleteByPK";

                        objCmd.Parameters.AddWithValue("@StateID", StateID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        objCmd.ExecuteNonQuery();

                        #endregion Prepared Command & Set Parameters

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        if (sqlex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        {
                            _Message = "This State contain some records, So please delete these record, If you want to delete this State.";
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
        #endregion Delete State

        /* #region Fill Country
         public DataTable FillCountry(SqlInt32 UserID)
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
                         objCmd.CommandText = "PR_Country_SelectForDropDownList";
                         objCmd.Parameters.AddWithValue("@UserID", UserID);
                         #endregion Prepared Command & Set Parameters

                         #region ReadData & Set Control
                         DataTable dt = new DataTable();
                         using (SqlDataReader objSDR = objCmd.ExecuteReader())
                         {
                             dt.Load(objSDR);
                         }
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
         #endregion Fill Country
 */

    }
}