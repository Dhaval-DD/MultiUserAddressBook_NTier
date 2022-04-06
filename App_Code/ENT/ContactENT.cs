using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactENT
/// </summary>

namespace Addressbook.ENT
{
    public class ContactENT
    {
        public ContactENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region UserID
        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion UserID

        #region ContactID
        protected SqlInt32 _ContactID;
        public SqlInt32 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }
        #endregion ContactID

        #region CountryID
        protected SqlInt32 _CountryID;
        public SqlInt32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        #endregion CountryID

        #region StateID
        protected SqlInt32 _StateID;
        public SqlInt32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }
        #endregion StateID

        #region CityID
        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        #endregion CityID

        #region ContactCategoryID
        protected SqlInt32 _ContactCategoryID;
        public SqlInt32 ContactCategoryID
        {
            get { return _ContactCategoryID; }
            set { _ContactCategoryID = value; }
        }
        #endregion ContactCategoryID

        #region ContactName
        protected SqlString _ContactName;
        public SqlString ContactName
        {
            get { return _ContactName; }
            set { _ContactName = value; }
        }
        #endregion ContactName

        #region WhatsappNo
        protected SqlString _WhatsappNo;
        public SqlString WhatsappNo
        {
            get { return _WhatsappNo; }
            set { _WhatsappNo = value; }
        }
        #endregion WhatsappNo

        #region BirthDate
        protected SqlDateTime _BirthDate;
        public SqlDateTime BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }
        #endregion BirthDate

        #region Email
        protected SqlString _Email;
        public SqlString Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        #endregion Email

        #region Age
        protected SqlInt32 _Age;
        public SqlInt32 Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        #endregion Age

        #region Address
        protected SqlString _Address;
        public SqlString Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        #endregion Address

        #region BloodGroup
        protected SqlString _BloodGroup;
        public SqlString BloodGroup
        {
            get { return _BloodGroup; }
            set { _BloodGroup = value; }
        }
        #endregion BloodGroup

        #region FacebookID
        protected SqlString _FacebookID;
        public SqlString FacebookID
        {
            get { return _FacebookID; }
            set { _FacebookID = value; }
        }
        #endregion FacebookID

        #region LinkdINID
        protected SqlString _LinkdINID;
        public SqlString LinkdINID
        {
            get { return _LinkdINID; }
            set { _LinkdINID = value; }
        }
        #endregion LinkdINID

        #region CreationDate
        protected SqlDateTime _CreationDate;
        public SqlDateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }
        #endregion CreationDate

        #region ContactFilePath
        protected SqlString _ContactFilePath;
        public SqlString ContactFilePath
        {
            get { return _ContactFilePath; }
            set { _ContactFilePath = value; }
        }
        #endregion ContactFilePath

        #region FileSize
        protected SqlString _FileSize;
        public SqlString FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }
        #endregion FileSize


        #region FileType
        protected SqlInt32 _FileType;
        public SqlInt32 FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }
        #endregion FileType

    }
}