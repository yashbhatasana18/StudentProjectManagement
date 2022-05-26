using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DProject.DAL
{
    public class WRK_WeeklyWorkdoneDAL : WRK_WeeklyWorkdoneDALBase
    {
        public DateTime SelectTodateFromWeeklyWorkDone(SqlInt32 ProjectID, SqlInt32 LoginID, SqlString LoginType)
        {
            DateTime Todate = DateTime.Now;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WeeklyWorkDone_SelectLastToDate");

                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, ProjectID);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID); ;
                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);

                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["Todate"].Equals(System.DBNull.Value))
                            Todate = Convert.ToDateTime(dr["Todate"]);
                    }
                }
                return Todate;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return DateTime.Now;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return DateTime.Now;
            }
        }

        #region Select WeeklyWorkDone

        public DataTable SelectWeeklyWorkDone(SqlInt32 WorkDoneID, SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_WRK_WeeklyWorkdone_SelectAllByProject");

                sqlDB.AddInParameter(dbCMD, "@WorkDoneID", SqlDbType.Int, WorkDoneID);
                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);

                DataTable dtWRK_WeeklyWorkdone = new DataTable("PP_WRK_WeeklyWorkdone_SelectAllByProject");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtWRK_WeeklyWorkdone);

                return dtWRK_WeeklyWorkdone;
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

        #endregion Select WeeklyWorkDone
    }

}