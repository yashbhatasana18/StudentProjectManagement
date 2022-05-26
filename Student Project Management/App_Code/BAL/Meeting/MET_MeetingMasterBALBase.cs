using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class MET_MeetingMasterBALBase
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

        public MET_MeetingMasterBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MET_MeetingMasterENT entMET_MeetingMaster)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            if (dalMET_MeetingMaster.Insert(entMET_MeetingMaster))
            {
                return true;
            }
            else
            {
                this.Message = dalMET_MeetingMaster.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MET_MeetingMasterENT entMET_MeetingMaster)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            if (dalMET_MeetingMaster.Update(entMET_MeetingMaster))
            {
                return true;
            }
            else
            {
                this.Message = dalMET_MeetingMaster.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 MeetingID)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            if (dalMET_MeetingMaster.Delete(MeetingID))
            {
                return true;
            }
            else
            {
                this.Message = dalMET_MeetingMaster.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MET_MeetingMasterENT SelectPK(SqlInt32 MeetingID)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            return dalMET_MeetingMaster.SelectPK(MeetingID);
        }
        public DataTable SelectView(SqlInt32 MeetingID)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            return dalMET_MeetingMaster.SelectView(MeetingID);
        }
        public DataTable SelectAll(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            return dalMET_MeetingMaster.SelectAll(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox(SqlInt32 InstituteID, SqlString LoginType, SqlInt32 LoginID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            return dalMET_MeetingMaster.SelectComboBox(InstituteID, LoginType, LoginID, DepartmentID, AcademicYearID);
        }

        #endregion ComboBox
    }

}