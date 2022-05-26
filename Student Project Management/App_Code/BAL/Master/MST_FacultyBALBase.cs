using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class MST_FacultyBALBase
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

        public MST_FacultyBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_FacultyENT entMST_Faculty)
        {
            MST_FacultyDAL dalMST_Faculty = new MST_FacultyDAL();
            if (dalMST_Faculty.Insert(entMST_Faculty))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Faculty.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_FacultyENT entMST_Faculty)
        {
            MST_FacultyDAL dalMST_Faculty = new MST_FacultyDAL();
            if (dalMST_Faculty.Update(entMST_Faculty))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Faculty.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 FacultyID)
        {
            MST_FacultyDAL dalMST_Faculty = new MST_FacultyDAL();
            if (dalMST_Faculty.Delete(FacultyID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Faculty.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MST_FacultyENT SelectPK(SqlInt32 FacultyID)
        {
            MST_FacultyDAL dalMST_Faculty = new MST_FacultyDAL();
            return dalMST_Faculty.SelectPK(FacultyID);
        }
        public DataTable SelectView(SqlInt32 FacultyID)
        {
            MST_FacultyDAL dalMST_Faculty = new MST_FacultyDAL();
            return dalMST_Faculty.SelectView(FacultyID);
        }
        public DataTable SelectAll(SqlString LoginType, SqlInt32 InstituteID)
        {
            MST_FacultyDAL dalMST_Faculty = new MST_FacultyDAL();
            return dalMST_Faculty.SelectAll(LoginType, InstituteID);
        }
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString FacultyName)
        {
            MST_FacultyDAL dalMST_Faculty = new MST_FacultyDAL();
            return dalMST_Faculty.SelectPage(PageOffset, PageSize, out TotalRecords, FacultyName);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox(SqlInt32 InstituteID)
        {
            MST_FacultyDAL dalMST_Faculty = new MST_FacultyDAL();
            return dalMST_Faculty.SelectComboBox(InstituteID);
        }

        #endregion ComboBox
    }

}