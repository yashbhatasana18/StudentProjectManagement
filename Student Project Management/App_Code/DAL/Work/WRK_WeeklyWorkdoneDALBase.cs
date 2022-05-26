using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DProject.DAL
{
    public abstract class WRK_WeeklyWorkdoneDALBase : DataBaseConfig
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

        public WRK_WeeklyWorkdoneDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(WRK_WeeklyWorkdoneENT entWRK_WeeklyWorkdone)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WeeklyWorkdone_Insert");

                sqlDB.AddOutParameter(dbCMD, "@WorkdoneID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entWRK_WeeklyWorkdone.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entWRK_WeeklyWorkdone.StudentID);
                sqlDB.AddInParameter(dbCMD, "@EntryDate", SqlDbType.DateTime, entWRK_WeeklyWorkdone.EntryDate);
                sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, entWRK_WeeklyWorkdone.FromDate);
                sqlDB.AddInParameter(dbCMD, "@Todate", SqlDbType.DateTime, entWRK_WeeklyWorkdone.Todate);
                sqlDB.AddInParameter(dbCMD, "@Workdone", SqlDbType.VarChar, entWRK_WeeklyWorkdone.Workdone);
                sqlDB.AddInParameter(dbCMD, "@FacultyRemarks", SqlDbType.VarChar, entWRK_WeeklyWorkdone.FacultyRemarks);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entWRK_WeeklyWorkdone.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entWRK_WeeklyWorkdone.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entWRK_WeeklyWorkdone.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entWRK_WeeklyWorkdone.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entWRK_WeeklyWorkdone.WorkdoneID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@WorkdoneID"].Value);

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

        public Boolean Update(WRK_WeeklyWorkdoneENT entWRK_WeeklyWorkdone)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WeeklyWorkdone_Update");

                sqlDB.AddInParameter(dbCMD, "@WorkdoneID", SqlDbType.Int, entWRK_WeeklyWorkdone.WorkdoneID);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entWRK_WeeklyWorkdone.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entWRK_WeeklyWorkdone.StudentID);
                sqlDB.AddInParameter(dbCMD, "@EntryDate", SqlDbType.DateTime, entWRK_WeeklyWorkdone.EntryDate);
                sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, entWRK_WeeklyWorkdone.FromDate);
                sqlDB.AddInParameter(dbCMD, "@Todate", SqlDbType.DateTime, entWRK_WeeklyWorkdone.Todate);
                sqlDB.AddInParameter(dbCMD, "@Workdone", SqlDbType.VarChar, entWRK_WeeklyWorkdone.Workdone);
                sqlDB.AddInParameter(dbCMD, "@FacultyRemarks", SqlDbType.VarChar, entWRK_WeeklyWorkdone.FacultyRemarks);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entWRK_WeeklyWorkdone.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entWRK_WeeklyWorkdone.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entWRK_WeeklyWorkdone.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entWRK_WeeklyWorkdone.Modified);

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

        public Boolean Delete(SqlInt32 WorkdoneID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WeeklyWorkdone_Delete");

                sqlDB.AddInParameter(dbCMD, "@WorkdoneID", SqlDbType.Int, WorkdoneID);

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

        public WRK_WeeklyWorkdoneENT SelectPK(SqlInt32 WorkdoneID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WeeklyWorkdone_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@WorkdoneID", SqlDbType.Int, WorkdoneID);

                WRK_WeeklyWorkdoneENT entWRK_WeeklyWorkdone = new WRK_WeeklyWorkdoneENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["WorkdoneID"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.WorkdoneID = Convert.ToInt32(dr["WorkdoneID"]);

                        if (!dr["ProjectID"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.ProjectID = Convert.ToInt32(dr["ProjectID"]);

                        if (!dr["StudentID"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.StudentID = Convert.ToInt32(dr["StudentID"]);

                        if (!dr["EntryDate"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        if (!dr["FromDate"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.FromDate = Convert.ToDateTime(dr["FromDate"]);

                        if (!dr["Todate"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.Todate = Convert.ToDateTime(dr["Todate"]);

                        if (!dr["Workdone"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.Workdone = Convert.ToString(dr["Workdone"]);

                        if (!dr["FacultyRemarks"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.FacultyRemarks = Convert.ToString(dr["FacultyRemarks"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entWRK_WeeklyWorkdone.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entWRK_WeeklyWorkdone;
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
        public DataTable SelectView(SqlInt32 WorkdoneID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WeeklyWorkdone_SelectView");

                sqlDB.AddInParameter(dbCMD, "@WorkdoneID", SqlDbType.Int, WorkdoneID);

                DataTable dtWRK_WeeklyWorkdone = new DataTable("PR_WRK_WeeklyWorkdone_SelectView");

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
        public DataTable SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WeeklyWorkdone_SelectAll");

                DataTable dtWRK_WeeklyWorkdone = new DataTable("PR_WRK_WeeklyWorkdone_SelectAll");

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

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WeeklyWorkdone_SelectComboBox");

                DataTable dtWRK_WeeklyWorkdone = new DataTable("PR_WRK_WeeklyWorkdone_SelectComboBox");

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

        #endregion ComboBox

        #region AutoComplete


        #endregion AutoComplete

    }
}