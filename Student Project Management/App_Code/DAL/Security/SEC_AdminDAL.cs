using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public class SEC_AdminDAL : SEC_AdminDALBase
    {
        #region Check Password

        public DataTable CheckPassword(SqlInt32 UserID, SqlString UserName, SqlString UserPassword)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_CheckPassword");

                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);
                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "@UserPassword", SqlDbType.VarChar, UserPassword);

                DataTable dtSEC_Admin = new DataTable("PR_SEC_User_CheckPassword");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_Admin);

                return dtSEC_Admin;
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

        #endregion Check Password

        #region Select Login

        public DataTable SelectLogin(SqlString UserName, SqlString UserPassword)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_Select_Login");

                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "@UserPassword", SqlDbType.VarChar, UserPassword);

                DataTable dtSEC_User = new DataTable("PR_SEC_User_Select_Login");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_User);

                return dtSEC_User;
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

        #endregion Select Login
    }

}