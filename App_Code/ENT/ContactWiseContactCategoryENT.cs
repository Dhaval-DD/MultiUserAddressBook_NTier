using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactCategoryENT
/// </summary>

namespace AddressBook.ENT
{
    public class ContactWiseContactCategoryENT
    {
        #region constructor
        public ContactWiseContactCategoryENT()
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

        #region ContactID
        protected SqlInt32 _ContactID;

        public SqlInt32 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }
        #endregion ContactID

        #region ContactCategoryID
        protected SqlInt32 _ContactCategoryID;

        public SqlInt32 ContactCategoryID
        {
            get { return _ContactCategoryID; }
            set { _ContactCategoryID = value; }
        }
        #endregion ContactCategoryID

        #region ContactWiseContactCategoryID
        protected SqlInt32 _ContactWiseContactCategoryID;

        public SqlInt32 ContactWiseContactCategoryID
        {
            get { return _ContactWiseContactCategoryID; }
            set { _ContactWiseContactCategoryID = value; }
        }
        #endregion ContactWiseContactCategoryID

        #region CreationDate
        protected SqlDateTime _CreationDate;

        public SqlDateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }
        #endregion CreationDate

        protected ContactCategoryENT _ContactCategory;
        public ContactCategoryENT ContactCategory
        {
            get { return _ContactCategory; }
            set { _ContactCategory = value; }
        }

        protected SqlString _SelecteOrNot;
        public SqlString SelecteOrNot
        {
            get { return _SelecteOrNot; }
            set { _SelecteOrNot = value; }
        }
    }
}
