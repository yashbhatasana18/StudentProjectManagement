using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class MST_InstituteBALBase
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

        public MST_InstituteBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_InstituteENT entMST_Institute)
        {
            MST_InstituteDAL dalMST_Institute = new MST_InstituteDAL();
            if (dalMST_Institute.Insert(entMST_Institute))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Institute.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_InstituteENT entMST_Institute)
        {
            MST_InstituteDAL dalMST_Institute = new MST_InstituteDAL();
            if (dalMST_Institute.Update(entMST_Institute))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Institute.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 InstituteID)
        {
            MST_InstituteDAL dalMST_Institute = new MST_InstituteDAL();
            if (dalMST_Institute.Delete(InstituteID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Institute.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MST_InstituteENT SelectPK(SqlInt32 InstituteID)
        {
            MST_InstituteDAL dalMST_Institute = new MST_InstituteDAL();
            return dalMST_Institute.SelectPK(InstituteID);
        }
        public DataTable SelectView(SqlInt32 InstituteID)
        {
            MST_InstituteDAL dalMST_Institute = new MST_InstituteDAL();
            return dalMST_Institute.SelectView(InstituteID);
        }
        public DataTable SelectAll(SqlString LoginType)
        {
            MST_InstituteDAL dalMST_Institute = new MST_InstituteDAL();
            return dalMST_Institute.SelectAll(LoginType);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            MST_InstituteDAL dalMST_Institute = new MST_InstituteDAL();
            return dalMST_Institute.SelectComboBox();
        }

        #endregion ComboBox
    }

}