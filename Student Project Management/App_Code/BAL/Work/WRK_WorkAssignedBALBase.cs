using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class WRK_WorkAssignedBALBase
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

        public WRK_WorkAssignedBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(WRK_WorkAssignedENT entWRK_WorkAssigned)
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            if (dalWRK_WorkAssigned.Insert(entWRK_WorkAssigned))
            {
                return true;
            }
            else
            {
                this.Message = dalWRK_WorkAssigned.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(WRK_WorkAssignedENT entWRK_WorkAssigned)
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            if (dalWRK_WorkAssigned.Update(entWRK_WorkAssigned))
            {
                return true;
            }
            else
            {
                this.Message = dalWRK_WorkAssigned.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 WorkAssignedID)
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            if (dalWRK_WorkAssigned.Delete(WorkAssignedID))
            {
                return true;
            }
            else
            {
                this.Message = dalWRK_WorkAssigned.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public WRK_WorkAssignedENT SelectPK(SqlInt32 WorkAssignedID)
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            return dalWRK_WorkAssigned.SelectPK(WorkAssignedID);
        }
        public DataTable SelectView(SqlInt32 WorkAssignedID)
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            return dalWRK_WorkAssigned.SelectView(WorkAssignedID);
        }
        public DataTable SelectAll(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            return dalWRK_WorkAssigned.SelectAll(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            return dalWRK_WorkAssigned.SelectComboBox();
        }

        #endregion ComboBox
    }

}