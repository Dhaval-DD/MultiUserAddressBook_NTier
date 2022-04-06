using Addressbook.DAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactCategoryBAL
/// </summary>
namespace Addressbook.BAL
{
    public class ContactWiseContactCategoryBAL
    {
        #region constructor
        public ContactWiseContactCategoryBAL()
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

        #region InsertContactWiseContactCategory
        public Boolean InsertContactWiseContactCategory(List<ContactWiseContactCategoryENT> contactWiseContactCategories)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
            if (dalContactWiseContactCategory.InsertContactWiseContactCategory(contactWiseContactCategories))
            {
                return true;
            }
            else
            {
                Message = dalContactWiseContactCategory.Message;
                return false;
            }

        }
        #endregion InsertContactWiseContactCategory

        #region DeleteContactWiseContactCategory
        public Boolean DeleteContactWiseContactCategory(SqlInt32 ContactID, SqlInt32 UserID)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
            if (dalContactWiseContactCategory.DeleteContactWiseContactCategory(ContactID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContactWiseContactCategory.Message;
                return false;
            }
        }
        #endregion DeleteContactWiseContactCategory

        #region SelectOrNot
        public List<ContactWiseContactCategoryENT> SelectOrNot(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
            List<ContactWiseContactCategoryENT> contactWiseContactCategories = dalContactWiseContactCategory.SelectOrNot(ContactId, UserId);

            if (contactWiseContactCategories != null)
            {
                return contactWiseContactCategories;
            }
            else
            {
                _Message = Message;
                return null;
            }
        }
        #endregion SelectOrNot
    }

}