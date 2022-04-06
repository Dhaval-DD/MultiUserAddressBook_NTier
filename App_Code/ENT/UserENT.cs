using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;


/// <summary>
/// Summary description for UserENT
/// </summary>
namespace Addressbook.ENT
{
    public class UserENT
    {
        #region constructor
        public UserENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region UserID
        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion UserID

        #region Password
        protected SqlString _Password;

        public SqlString Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        #endregion Password

        #region UserName
        protected SqlString _UserName;

        public SqlString UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        #endregion UserName


        #region DisplayName
        protected SqlString _DisplayName;

        public SqlString DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }
        #endregion DisplayName

        #region MobileNo
        protected SqlString _MobileNo;

        public SqlString MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }
        #endregion MobileNo

        #region Email
        protected SqlString _Email;

        public SqlString Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        #endregion Email

        #region CreationDate
        protected SqlDateTime _CreationDate;

        public SqlDateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }
        #endregion CreationDate


    }
}