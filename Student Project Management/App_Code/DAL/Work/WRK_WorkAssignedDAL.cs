using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DProject.DAL
{
    public class WRK_WorkAssignedDAL : WRK_WorkAssignedDALBase
    {
        #region Select Report WorkAssiged List By Project

        public DataTable SelectAllWorkAssignedByProject(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlInt32 ProjectID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_WRK_WorkAssigned_SelectAllByProject");
                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, ProjectID);
                DataTable dtMET_WorkAssignedListByProject = new DataTable("PP_WRK_WorkAssigned_SelectAllByProject");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMET_WorkAssignedListByProject);

                return dtMET_WorkAssignedListByProject;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        #endregion Select Report WorkAssiged List By Project

        #region Select Report WorkAssiged List By Student

        public DataTable SelectAllWorkAssignedByStudent(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_WRK_WorkAssigned_SelectAllByStudent");
                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);
                DataTable dtMET_WorkAssignedListByStudent = new DataTable("PP_WRK_WorkAssigned_SelectAllByStudent");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMET_WorkAssignedListByStudent);

                return dtMET_WorkAssignedListByStudent;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        #endregion Select Report WorkAssiged List By Student

        #region Search Student By EnrollmentNo 

        public DataTable SearchStudentByEnrollmentNo(SqlString EnrollmentNo)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WorkAssigned_StudentByEnrollmentNo");
                sqlDB.AddInParameter(dbCMD, "@EnrollmentNo", SqlDbType.VarChar, EnrollmentNo);
                DataTable dtMET_StudentByEnrollmentNo = new DataTable("PR_WRK_WorkAssigned_StudentByEnrollmentNo");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMET_StudentByEnrollmentNo);

                return dtMET_StudentByEnrollmentNo;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        #endregion Search Student By EnrollmentNo 

        #region Search Project History By EnrollmentNo 

        public DataTable SearchProjectHistoryByEnrollmentNo(SqlString EnrollmentNo)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectHistoryByEnrollmentNo");
                sqlDB.AddInParameter(dbCMD, "@EnrollmentNo", SqlDbType.VarChar, EnrollmentNo);
                DataTable dtMET_StudentByEnrollmentNo = new DataTable("PR_PRJ_ProjectHistoryByEnrollmentNo");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMET_StudentByEnrollmentNo);

                return dtMET_StudentByEnrollmentNo;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        #endregion Search Project History By EnrollmentNo 
    }

}