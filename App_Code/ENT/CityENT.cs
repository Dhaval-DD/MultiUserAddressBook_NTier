using System.Data.SqlTypes;

/// <summary>
/// Summary description for CityENT
/// </summary>

namespace AddressBook.ENT
{
    public class CityENT
    {
        #region constructor
        public CityENT()
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

        #region CityID
        protected SqlInt32 _CityID;

        public SqlInt32 CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        #endregion CityID

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

        #region CityName
        protected SqlString _CityName;
        public SqlString CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
        #endregion CityName

        #region STDCode
        protected SqlString _STDCode;
        public SqlString STDCode
        {
            get { return _STDCode; }
            set { _STDCode = value; }
        }
        #endregion STDCode

        #region PINCode
        protected SqlString _PINCode;
        public SqlString PINCode
        {
            get { return _PINCode; }
            set { _PINCode = value; }
        }
        #endregion PINCode

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
