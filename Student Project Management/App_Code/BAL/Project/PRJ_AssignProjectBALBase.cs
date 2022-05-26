using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class PRJ_AssignProjectBALBase
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

        public PRJ_AssignProjectBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(PRJ_AssignProjectENT entPRJ_ProjectWiseStudent)
        {
            PRJ_AssignProjectDAL dalPRJ_AssignProject = new PRJ_AssignProjectDAL();
            if (dalPRJ_AssignProject.Insert(entPRJ_ProjectWiseStudent))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_AssignProject.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(PRJ_AssignProjectENT entPRJ_ProjectWiseStudent)
        {
            PRJ_AssignProjectDAL dalPRJ_AssignProject = new PRJ_AssignProjectDAL();
            if (dalPRJ_AssignProject.Update(entPRJ_ProjectWiseStudent))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_AssignProject.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 ProjectWiseStudentID)
        {
            PRJ_AssignProjectDAL dalPRJ_AssignProject = new PRJ_AssignProjectDAL();
            if (dalPRJ_AssignProject.Delete(ProjectWiseStudentID))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_AssignProject.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public PRJ_AssignProjectENT SelectPK(SqlInt32 ProjectWiseStudentID)
        {
            PRJ_AssignProjectDAL dalPRJ_AssignProject = new PRJ_AssignProjectDAL();
            return dalPRJ_AssignProject.SelectPK(ProjectWiseStudentID);
        }
        public DataTable SelectView(SqlInt32 ProjectWiseStudentID)
        {
            PRJ_AssignProjectDAL dalPRJ_AssignProject = new PRJ_AssignProjectDAL();
            return dalPRJ_AssignProject.SelectView(ProjectWiseStudentID);
        }
        public DataTable SelectAll(SqlString LoginType, SqlInt32 DepartmentID, SqlInt32 InstituteID, SqlInt32 LoginID, SqlInt32 AcademicYearID)
        {
            PRJ_AssignProjectDAL dalPRJ_AssignProject = new PRJ_AssignProjectDAL();
            return dalPRJ_AssignProject.SelectAll(LoginType, DepartmentID, InstituteID, LoginID, AcademicYearID);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            PRJ_AssignProjectDAL dalPRJ_AssignProject = new PRJ_AssignProjectDAL();
            return dalPRJ_AssignProject.SelectComboBox();
        }

        #endregion ComboBox
    }

}