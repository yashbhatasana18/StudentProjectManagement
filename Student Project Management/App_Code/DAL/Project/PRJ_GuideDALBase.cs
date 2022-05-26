using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public abstract class PRJ_GuideDALBase : DataBaseConfig
    {
        #region Properties

        private string _Message;
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

        #endregion Properties

        #region Constructor

        public PRJ_GuideDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(PRJ_GuideENT entPRJ_Guide)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Guide_Insert");

                sqlDB.AddOutParameter(dbCMD, "@GuideID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@GuideName", SqlDbType.VarChar, entPRJ_Guide.GuideName);
                sqlDB.AddInParameter(dbCMD, "@GuideShortName", SqlDbType.VarChar, entPRJ_Guide.GuideShortName);
                sqlDB.AddInParameter(dbCMD, "@IsActive", SqlDbType.Bit, entPRJ_Guide.IsActive);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entPRJ_Guide.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entPRJ_Guide.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entPRJ_Guide.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entPRJ_Guide.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entPRJ_Guide.Modified);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entPRJ_Guide.UserID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entPRJ_Guide.GuideID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@GuideID"].Value);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(PRJ_GuideENT entPRJ_Guide)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Guide_Update");

                sqlDB.AddInParameter(dbCMD, "@GuideID", SqlDbType.Int, entPRJ_Guide.GuideID);
                sqlDB.AddInParameter(dbCMD, "@GuideName", SqlDbType.VarChar, entPRJ_Guide.GuideName);
                sqlDB.AddInParameter(dbCMD, "@GuideShortName", SqlDbType.VarChar, entPRJ_Guide.GuideShortName);
                sqlDB.AddInParameter(dbCMD, "@IsActive", SqlDbType.Bit, entPRJ_Guide.IsActive);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entPRJ_Guide.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entPRJ_Guide.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entPRJ_Guide.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entPRJ_Guide.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entPRJ_Guide.Modified);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entPRJ_Guide.UserID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 GuideID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Guide_Delete");

                sqlDB.AddInParameter(dbCMD, "@GuideID", SqlDbType.Int, GuideID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public PRJ_GuideENT SelectPK(SqlInt32 GuideID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Guide_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@GuideID", SqlDbType.Int, GuideID);

                PRJ_GuideENT entPRJ_Guide = new PRJ_GuideENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["GuideID"].Equals(System.DBNull.Value))
                            entPRJ_Guide.GuideID = Convert.ToInt32(dr["GuideID"]);

                        if (!dr["GuideName"].Equals(System.DBNull.Value))
                            entPRJ_Guide.GuideName = Convert.ToString(dr["GuideName"]);

                        if (!dr["GuideShortName"].Equals(System.DBNull.Value))
                            entPRJ_Guide.GuideShortName = Convert.ToString(dr["GuideShortName"]);

                        if (!dr["IsActive"].Equals(System.DBNull.Value))
                            entPRJ_Guide.IsActive = Convert.ToBoolean(dr["IsActive"]);

                        if (!dr["DepartmentID"].Equals(System.DBNull.Value))
                            entPRJ_Guide.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entPRJ_Guide.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entPRJ_Guide.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entPRJ_Guide.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entPRJ_Guide.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entPRJ_Guide;
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
        public DataTable SelectView(SqlInt32 GuideID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Guide_SelectView");

                sqlDB.AddInParameter(dbCMD, "@GuideID", SqlDbType.Int, GuideID);

                DataTable dtPRJ_Guide = new DataTable("PR_PRJ_Guide_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_Guide);

                return dtPRJ_Guide;
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
        public DataTable SelectAll(SqlString LoginType, SqlInt32 DepartmentID, SqlInt32 InstituteID, SqlInt32 LoginID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Guide_SelectAll");

                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);

                DataTable dtPRJ_Guide = new DataTable("PR_PRJ_Guide_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_Guide);

                return dtPRJ_Guide;
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

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Guide_SelectComboBox");

                DataTable dtPRJ_Guide = new DataTable("PR_PRJ_Guide_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_Guide);

                return dtPRJ_Guide;
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

        #endregion ComboBox

        #region AutoComplete


        #endregion AutoComplete

    }
}