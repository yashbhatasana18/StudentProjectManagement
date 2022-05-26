using DProject.DAL;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public class WRK_WorkAssignedBAL : WRK_WorkAssignedBALBase
    {
        #region Select Report WorkAssigned List By Project 

        public DataTable SelectAllWorkAssignedByProject(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlInt32 ProjectID)
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            return dalWRK_WorkAssigned.SelectAllWorkAssignedByProject(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID, ProjectID);
        }

        #endregion Select Report WorkAssigned List By Project

        #region Select Report WorkAssigned List By Student

        public DataTable SelectAllWorkAssignedByStudent(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlInt32 StudentID)
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            return dalWRK_WorkAssigned.SelectAllWorkAssignedByStudent(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID, StudentID);
        }

        #endregion Select Report WorkAssigned List By Student

        #region Search Student By EnrollmentNo 

        public DataTable SearchStudentByEnrollmentNo(SqlString EnrollmentNo)
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            return dalWRK_WorkAssigned.SearchStudentByEnrollmentNo(EnrollmentNo);
        }

        #endregion Search Student By EnrollmentNo 

        #region Search Project History By EnrollmentNo 

        public DataTable SearchProjectHistoryByEnrollmentNo(SqlString EnrollmentNo)
        {
            WRK_WorkAssignedDAL dalWRK_WorkAssigned = new WRK_WorkAssignedDAL();
            return dalWRK_WorkAssigned.SearchProjectHistoryByEnrollmentNo(EnrollmentNo);
        }

        #endregion Search Project History By EnrollmentNo 
    }

}