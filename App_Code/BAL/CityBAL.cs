using Addressbook.DAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityBAL
/// </summary>
namespace Addressbook.BAL
{
    public class CityBAL
    {
        #region constructor
        public CityBAL()
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
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectByPK
        public CityENT SelectByPK(SqlInt32 CityID, SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectByPK(CityID,UserID);
        }
        #endregion SelectByPK
        /*
        #region SelectForDropDownListCountry
        public DataTable SelectForDropDownListCountry(SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropDownListCountry(UserID);
        }
        #endregion SelectForDropDownListCountry

        #region SelectForDropDownListStateByCountryID
        public DataTable SelectForDropDownListStateByCountryID(SqlInt32 UserID, SqlInt32 CountryID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropDownListStateByCountryID(UserID, CountryID);
        }
        #endregion SelectForDropDownListStateByCountryID*/

        #region InsertCity
        public Boolean InsertCity(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.InsertCity(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
           
        }
        #endregion InsertCity

        #region DeleteCity
        public Boolean DeleteCity(SqlInt32 CityID, SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.DeleteCity(CityID,UserID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion DeleteCity

        #region UpdateCity
        public Boolean UpdateCity(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.UpdateCity(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion UpdateCity

        #region Select for DropDown
        public DataTable SelectForDropDown(SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.GetCityDropDown(UserID, SqlInt32.Null);
        }
        #endregion Select for DropDown

        #region Select for DropDown
        public DataTable SelectForDropDownByStateID(SqlInt32 UserID, SqlInt32 StateID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.GetCityDropDown(UserID, StateID);
        }
        #endregion Select for DropDown
    }
}