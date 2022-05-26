using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class SEC_AdminBALBase
    {
        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Public Properties

        #region Constructor

        public SEC_AdminBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(SEC_AdminENT entSEC_Admin)
        {
            SEC_AdminDAL dalSEC_Admin = new SEC_AdminDAL();
            if (dalSEC_Admin.Insert(entSEC_Admin))
            {
                return true;
            }
            else
            {
                this.Message = dalSEC_Admin.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(SEC_AdminENT entSEC_Admin)
        {
            SEC_AdminDAL dalSEC_Admin = new SEC_AdminDAL();
            if (dalSEC_Admin.Update(entSEC_Admin))
            {
                return true;
            }
            else
            {
                this.Message = dalSEC_Admin.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 UserID)
        {
            SEC_AdminDAL dalSEC_Admin = new SEC_AdminDAL();
            if (dalSEC_Admin.Delete(UserID))
            {
                return true;
            }
            else
            {
                this.Message = dalSEC_Admin.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public SEC_AdminENT SelectPK(SqlInt32 UserID)
        {
            SEC_AdminDAL dalSEC_Admin = new SEC_AdminDAL();
            return dalSEC_Admin.SelectPK(UserID);
        }
        public DataTable SelectView(SqlInt32 UserID)
        {
            SEC_AdminDAL dalSEC_Admin = new SEC_AdminDAL();
            return dalSEC_Admin.SelectView(UserID);
        }
        public DataTable SelectAll()
        {
            SEC_AdminDAL dalSEC_Admin = new SEC_AdminDAL();
            return dalSEC_Admin.SelectAll();
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            SEC_AdminDAL dalSEC_Admin = new SEC_AdminDAL();
            return dalSEC_Admin.SelectComboBox();
        }

        #endregion ComboBox
    }

}