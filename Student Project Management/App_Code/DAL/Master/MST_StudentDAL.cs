using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DProject.DAL
{
    public class MST_StudentDAL : MST_StudentDALBase
    {
        #region Get Student For AutoComplete Extender

        public DataTable GetStudent(SqlString Student, SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectAuto");

                sqlDB.AddInParameter(dbCMD, "@Student", SqlDbType.VarChar, Student);
                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);

                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectAuto");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
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

        #endregion Get Student For AutoComplete Extender

        #region ComboBoxByMeetingID

        public DataTable SelectComboBox(SqlInt32 ProjectID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectComboBoxByMeetingID");
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, ProjectID);
                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectComboBoxByMeetingID");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
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
        #endregion

        #region SelectComboBoxByInstituteID
        public DataTable SelectComboBoxByInstituteID(SqlInt32 InstituteID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectComboBoxByInstituteID");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectComboBoxByInstituteID");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
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
        #endregion SelectComboBoxByProject

        #region SelectComboBoxProject
        public DataTable SelectComboBoxProject(SqlInt32 ProjectID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectComboBoxProjectID");
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, ProjectID);
                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectComboBoxProjectID");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
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
        #endregion SelectComboBoxProject

        #region SelectComboBoxByProject
        public DataTable SelectComboBoxByProject(SqlInt32 InstituteID, SqlInt32 DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectComboBoxByProjectID");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectComboBoxByProjectID");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
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
        #endregion SelectComboBoxByProject

        #region SelectComboBoxByFacultyID
        public DataTable SelectComboBoxByFacultyID(SqlInt32 FacultyID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectComboBoxByFacultyID");
                sqlDB.AddInParameter(dbCMD, "@FacultyID", SqlDbType.Int, FacultyID);
                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectComboBoxByFacultyID");

                DataBaseHelper DBH = new DataBaseHelper();

                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
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
        #endregion SelectComboBoxByFacultyID

        //#region SelectComboBoxByStudentID
        //public DataTable SelectComboBoxByStudentID(SqlInt32 InstituteID, SqlString LoginType, SqlInt32 LoginID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        //{
        //    try
        //    {
        //        SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
        //        DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectComboBoxByStudentID");

        //        sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
        //        sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
        //        sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
        //        sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
        //        sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);

        //        DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectComboBoxByStudentID");

        //        DataBaseHelper DBH = new DataBaseHelper();

        //        DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

        //        return dtMST_Student;
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        Message = SQLDataExceptionMessage(sqlex);
        //        if (SQLDataExceptionHandler(sqlex))
        //            throw;
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ExceptionMessage(ex);
        //        if (ExceptionHandler(ex))
        //            throw;
        //        return null;
        //    }
        //}
        //#endregion SelectComboBoxByStudentID

        #region ComboBox For Student Wise Meeting Report

        public DataTable SelectComboBoxForReport(SqlString LoginType, SqlInt32 LoginID, SqlInt32 DepartmentID, SqlInt32 InstituteID, SqlInt32 AcademicYearID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_MST_Student_SelectComboBox");
                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);
                DataTable dtMST_Student = new DataTable("PP_MST_Student_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
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

        #endregion ComboBox For Student Wise Meeting Report
    }

}