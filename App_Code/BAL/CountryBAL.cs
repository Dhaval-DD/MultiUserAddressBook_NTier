using Addressbook.DAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryBAL
/// </summary>
namespace Addressbook.BAL
{
    public class CountryBAL
    {
        #region constructor
        public CountryBAL()
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
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectByPK
        public CountryENT SelectByPK(SqlInt32 CountryID, SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectByPK(CountryID, UserID);
        }
        #endregion SelectByPK

        #region InsertCountry
        public Boolean InsertCountry(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.InsertCountry(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }

        }
        #endregion InsertCountry

        #region DeleteCountry
        public Boolean DeleteCountry(SqlInt32 CountryID, SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.DeleteCountry(CountryID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion DeleteCountry

        #region UpdateCountry
        public Boolean UpdateCountry(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.UpdateCountry(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion UpdateCountry

        #region Select For DropDown
        public DataTable SelectForDropDown(SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.GetCountryDropDown(UserID);
        }
        #endregion Select For DropDown
    }
}