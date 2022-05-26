using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class MST_StatusBALBase
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

        public MST_StatusBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_StatusENT entMST_Status)
        {
            MST_StatusDAL dalMST_Status = new MST_StatusDAL();
            if (dalMST_Status.Insert(entMST_Status))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Status.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_StatusENT entMST_Status)
        {
            MST_StatusDAL dalMST_Status = new MST_StatusDAL();
            if (dalMST_Status.Update(entMST_Status))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Status.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 StatusID)
        {
            MST_StatusDAL dalMST_Status = new MST_StatusDAL();
            if (dalMST_Status.Delete(StatusID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Status.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MST_StatusENT SelectPK(SqlInt32 StatusID)
        {
            MST_StatusDAL dalMST_Status = new MST_StatusDAL();
            return dalMST_Status.SelectPK(StatusID);
        }
        public DataTable SelectView(SqlInt32 StatusID)
        {
            MST_StatusDAL dalMST_Status = new MST_StatusDAL();
            return dalMST_Status.SelectView(StatusID);
        }
        public DataTable SelectAll()
        {
            MST_StatusDAL dalMST_Status = new MST_StatusDAL();
            return dalMST_Status.SelectAll();
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            MST_StatusDAL dalMST_Status = new MST_StatusDAL();
            return dalMST_Status.SelectComboBox();
        }

        #endregion ComboBox
    }

}