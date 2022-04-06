using Addressbook.DAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBAL
/// </summary>
namespace Addressbook.BAL
{
    public class UserBAL
    {
        #region constructor
        public UserBAL()
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

        #region InsertUser
        public Boolean InsertUser(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.InsertUser(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion InsertUser

        #region InsertUser
        public UserENT ValidateUser(SqlString UserName, SqlString Password)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.ValidateUser(UserName,Password);
        }
        #endregion InsertUser
    }
}