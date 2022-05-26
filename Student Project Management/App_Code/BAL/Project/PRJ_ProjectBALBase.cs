using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class PRJ_ProjectBALBase
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

        public PRJ_ProjectBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(PRJ_ProjectENT entPRJ_Project)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            if (dalPRJ_Project.Insert(entPRJ_Project))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_Project.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(PRJ_ProjectENT entPRJ_Project)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            if (dalPRJ_Project.Update(entPRJ_Project))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_Project.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 ProjectID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            if (dalPRJ_Project.Delete(ProjectID))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_Project.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public PRJ_ProjectENT SelectPK(SqlInt32 ProjectID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectPK(ProjectID);
        }
        public DataTable SelectView(SqlInt32 ProjectID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectView(ProjectID);
        }
        public DataTable SelectAll(SqlString LoginType, SqlInt32 DepartmentID, SqlInt32 InstituteID, SqlInt32 LoginID, SqlInt32 AcademicYearID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectAll(LoginType, DepartmentID, InstituteID, LoginID, AcademicYearID);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox(SqlInt32 InstituteID, SqlString LoginType, SqlInt32 LoginID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectComboBox(InstituteID, LoginType, LoginID, DepartmentID, AcademicYearID);
        }

        #endregion ComboBox
    }

}