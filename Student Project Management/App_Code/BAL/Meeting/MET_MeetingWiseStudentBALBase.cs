using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class MET_MeetingWiseStudentBALBase
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

        public MET_MeetingWiseStudentBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MET_MeetingWiseStudentENT entMET_MeetingWiseStudent)
        {
            MET_MeetingWiseStudentDAL dalMET_MeetingWiseStudent = new MET_MeetingWiseStudentDAL();
            if (dalMET_MeetingWiseStudent.Insert(entMET_MeetingWiseStudent))
            {
                return true;
            }
            else
            {
                this.Message = dalMET_MeetingWiseStudent.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MET_MeetingWiseStudentENT entMET_MeetingWiseStudent)
        {
            MET_MeetingWiseStudentDAL dalMET_MeetingWiseStudent = new MET_MeetingWiseStudentDAL();
            if (dalMET_MeetingWiseStudent.Update(entMET_MeetingWiseStudent))
            {
                return true;
            }
            else
            {
                this.Message = dalMET_MeetingWiseStudent.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 MeetingWiseStudentID)
        {
            MET_MeetingWiseStudentDAL dalMET_MeetingWiseStudent = new MET_MeetingWiseStudentDAL();
            if (dalMET_MeetingWiseStudent.Delete(MeetingWiseStudentID))
            {
                return true;
            }
            else
            {
                this.Message = dalMET_MeetingWiseStudent.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MET_MeetingWiseStudentENT SelectPK(SqlInt32 MeetingWiseStudentID)
        {
            MET_MeetingWiseStudentDAL dalMET_MeetingWiseStudent = new MET_MeetingWiseStudentDAL();
            return dalMET_MeetingWiseStudent.SelectPK(MeetingWiseStudentID);
        }
        public DataTable SelectView(SqlInt32 MeetingWiseStudentID)
        {
            MET_MeetingWiseStudentDAL dalMET_MeetingWiseStudent = new MET_MeetingWiseStudentDAL();
            return dalMET_MeetingWiseStudent.SelectView(MeetingWiseStudentID);
        }
        public DataTable SelectAll()
        {
            MET_MeetingWiseStudentDAL dalMET_MeetingWiseStudent = new MET_MeetingWiseStudentDAL();
            return dalMET_MeetingWiseStudent.SelectAll();
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            MET_MeetingWiseStudentDAL dalMET_MeetingWiseStudent = new MET_MeetingWiseStudentDAL();
            return dalMET_MeetingWiseStudent.SelectComboBox();
        }

        #endregion ComboBox
    }

}