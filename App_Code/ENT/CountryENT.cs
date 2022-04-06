using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryENT
/// </summary>

namespace Addressbook.ENT
{
    public class CountryENT
    {
        #region constructor
        public CountryENT()
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



        #region CountryID
        protected SqlInt32 _CountryID;
        public SqlInt32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        #endregion CountryID


        #region CountryName
        protected SqlString _CountryName;
        public SqlString CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }
        #endregion CountryName


        #region CountryCode
        protected SqlString _CountryCode;
        public SqlString CountryCode
        {
            get { return _CountryCode; }
            set { _CountryCode = value; }
        }
        #endregion CountryCode



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