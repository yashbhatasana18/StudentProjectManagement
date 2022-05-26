using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class MST_DepartmentBALBase
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

        public MST_DepartmentBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_DepartmentENT entMST_Department)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            if (dalMST_Department.Insert(entMST_Department))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Department.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_DepartmentENT entMST_Department)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            if (dalMST_Department.Update(entMST_Department))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Department.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 DepartmentID)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            if (dalMST_Department.Delete(DepartmentID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Department.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MST_DepartmentENT SelectPK(SqlInt32 DepartmentID)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            return dalMST_Department.SelectPK(DepartmentID);
        }
        public DataTable SelectView(SqlInt32 DepartmentID)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            return dalMST_Department.SelectView(DepartmentID);
        }
        public DataTable SelectAll(SqlString LoginType, SqlInt32 InstituteID)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            return dalMST_Department.SelectAll(LoginType, InstituteID);
        }

        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString DepartmentName)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            return dalMST_Department.SelectPage(PageOffset, PageSize, out TotalRecords, DepartmentName);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox(SqlInt32 InstituteID)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            return dalMST_Department.SelectComboBox(InstituteID);
        }
        public DataTable SelectInsComboBox(SqlInt32 InstituteID)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            return dalMST_Department.SelectInsComboBox(InstituteID);
        }

        #endregion ComboBox
    }

}