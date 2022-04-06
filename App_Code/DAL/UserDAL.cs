using Addressbook.ENT;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for UserDAL
/// </summary>
namespace Addressbook.DAL
{
    public class UserDAL : DatabaseConfig
    {
        #region constructor
        public UserDAL()
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

        #region Insert User
        public Boolean InsertUser(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_Insert";
                        objCmd.Parameters.AddWithValue("@UserName", entUser.UserName);
                        objCmd.Parameters.AddWithValue("@Password", entUser.Password);
                        objCmd.Parameters.AddWithValue("@DispalyName", entUser.DisplayName);
                        objCmd.Parameters.AddWithValue("@MobileNo", entUser.MobileNo);
                        objCmd.Parameters.AddWithValue("@Email", entUser.Email);

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
                            _Message = "This UserName already exist";
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
        #endregion Insert User

        #region ValidateUser
        //Get User BY ID
        public UserENT ValidateUser(SqlString UserName, SqlString Password)
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
                        objCmd.CommandText = "PR_User_SelectByUserNamePassword";
                        objCmd.Parameters.AddWithValue("@UserName", UserName);
                        objCmd.Parameters.AddWithValue("@Password", Password);
                        #endregion Prepared Command

                        #region ReadData & Set Control
                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (!objSDR["UserID"].Equals(DBNull.Value))
                                entUser.UserID= Convert.ToInt32(objSDR["UserID"]);
                            if (!objSDR["UserName"].Equals(DBNull.Value))
                                entUser.UserName = Convert.ToString(objSDR["UserName"]);
                            if (!objSDR["Password"].Equals(DBNull.Value))
                                entUser.Password = Convert.ToString(objSDR["Password"]);
                            if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                entUser.DisplayName = Convert.ToString(objSDR["DisplayName"]);
                            if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                entUser.MobileNo = Convert.ToString(objSDR["MobileNo"]);
                            if (!objSDR["Email"].Equals(DBNull.Value))
                                entUser.Email = Convert.ToString(objSDR["Email"]);
                        }
                        return entUser;
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
        #endregion ValidateUser
    }
}