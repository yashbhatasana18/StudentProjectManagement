using DProject.DAL;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public class MET_MeetingMasterBAL : MET_MeetingMasterBALBase
    {
        #region Select Report Project Wise Meeting

        public DataTable SelectAllProjectWiseMeeting(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlInt32 ProjectID)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            return dalMET_MeetingMaster.SelectAllProjectWiseMeeting(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID, ProjectID);
        }

        #endregion Select Report Project Wise Meeting

        #region Select Report Student Wise Meeting

        public DataTable SelectAllStudentWiseMeeting(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlInt32 StudentID)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            return dalMET_MeetingMaster.SelectAllStudentWiseMeeting(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID, StudentID);
        }

        #endregion Select Report Student Wise Meeting

        #region Select Report Date Wise Meeting

        public DataTable SelectAllDateWiseMeeting(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlDateTime MeetingDate)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            return dalMET_MeetingMaster.SelectAllDateWiseMeeting(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID, MeetingDate);
        }

        #endregion Select Report Date Wise Meeting

        #region Search Meeting By Student EnrollmentNo 

        public DataTable SearchMeetingByStudentEnrollmentNo(SqlString EnrollmentNo)
        {
            MET_MeetingMasterDAL dalMET_MeetingMaster = new MET_MeetingMasterDAL();
            return dalMET_MeetingMaster.SearchMeetingByStudentEnrollmentNo(EnrollmentNo);
        }

        #endregion Search Meeting By Student EnrollmentNo 
    }

}