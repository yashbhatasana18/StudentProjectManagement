using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public class DOC_ProjectDocumentDAL : DOC_ProjectDocumentDALBase
    {
        #region SelectGTUTeamNoByProjectID

        public DataTable SelectGTUTeamNoByProjectID(SqlInt32 ProjectID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_GTUTeamNo_SelectByProjectID");
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, ProjectID);
                DataTable dtDOC_ProjectDocumentName = new DataTable("PR_DOC_GTUTeamNo_SelectByProjectID");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtDOC_ProjectDocumentName);

                return dtDOC_ProjectDocumentName;
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

        #endregion SelectGTUTeamNoByProjectID

        #region Select Report Project Wise Document List

        public DataTable SelectAllProjectWiseDocumentReport(SqlInt32 InstituteID, SqlInt32 AcademicYearID, SqlInt32 ProjectID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_DOC_ProjectDocument_SelectAll");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, ProjectID);
                DataTable dtPRJ_ProjectDocument = new DataTable("PP_DOC_ProjectDocument_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_ProjectDocument);

                return dtPRJ_ProjectDocument;
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

        #endregion Select Report Project Wise Document List

        #region Select Report Project Wise Document List After DeadLine

        public DataTable SelectAllProjectWiseDocumentReportAfterDeadLine(SqlInt32 InstituteID, SqlInt32 AcademicYearID, SqlInt32 DocumentTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_DOC_ProjectDocument_SelectAllByAfterDeadLine");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@DocumentTypeID", SqlDbType.Int, DocumentTypeID);
                DataTable dtPRJ_ProjectDocumentAfterDeadLine = new DataTable("PP_DOC_ProjectDocument_SelectAllByAfterDeadLine");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_ProjectDocumentAfterDeadLine);

                return dtPRJ_ProjectDocumentAfterDeadLine;
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

        #endregion Select Report Project Wise Document List After DeadLine

        #region Select Report Project Wise Document List After DeadLine

        public DataTable SelectAllProjectWiseDocumentReportDeadLineAchived(SqlInt32 InstituteID, SqlInt32 AcademicYearID, SqlString LoginType, SqlInt32 DocumentTypeID, SqlInt32 LoginID, SqlInt32 DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_DOC_ProjectDocument_SelectAllByDeadLineAchived");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@DocumentTypeID", SqlDbType.Int, DocumentTypeID);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                DataTable dtPRJ_ProjectDocumentDeadLineAchived = new DataTable("PP_DOC_ProjectDocument_SelectAllByDeadLineAchived");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_ProjectDocumentDeadLineAchived);

                return dtPRJ_ProjectDocumentDeadLineAchived;
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

        #endregion Select Report Project Wise Document List After DeadLine
    }

}