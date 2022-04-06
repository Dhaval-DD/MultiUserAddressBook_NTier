using Addressbook.DAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateBAL
/// </summary>
namespace Addressbook.BAL
{
    public class StateBAL
    {
        #region constructor
        public StateBAL()
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

        #region InsertState
        public Boolean InsertState(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.InsertState(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }

        }
        #endregion InsertState

        #region DeleteState
        public Boolean DeleteState(SqlInt32 StateID, SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.DeleteState(StateID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion DeleteState

        #region UpdateState
        public Boolean UpdateState(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.UpdateState(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion UpdateState

        #region Get State DropDown
        public DataTable GetStateDropDown(SqlInt32 UserID, SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.GetStateDropDown(UserID, StateID);
           
        }
        #endregion Get State DropDown

        public DataTable SelectAll(SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectAll(UserID);
        }

    }
}