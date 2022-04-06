using Addressbook.DAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoyBAL
/// </summary>
namespace Addressbook.BAL
{
    public class ContactCategoryBAL
    {
        #region constructor
        public ContactCategoryBAL()
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
        public DataTable SelectAll(SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectByPK
        public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID, SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.SelectByPK(ContactCategoryID, UserID);
        }
        #endregion SelectByPK

        #region InsertContactCategory
        public Boolean InsertContactCategory(ContactCategoryENT entContactCategory)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            if (dalContactCategory.InsertContactCategory(entContactCategory))
            {
                return true;
            }
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }

        }
        #endregion InsertContactCategory

        #region DeleteContactCategory
        public Boolean DeleteContactCategory(SqlInt32 ContactCategoryID, SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            if (dalContactCategory.DeleteContactCategory(ContactCategoryID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }
        }
        #endregion DeleteContactCategory

        #region UpdateContactCategory
        public Boolean UpdateContactCategory(ContactCategoryENT entContactCategory)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            if (dalContactCategory.UpdateContactCategory(entContactCategory))
            {
                return true;
            }
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }
        }
        #endregion UpdateContactCategory
    }
}