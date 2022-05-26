using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public abstract class MST_DepartmentDALBase : DataBaseConfig
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

        public MST_DepartmentDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_DepartmentENT entMST_Department)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_Insert");

                sqlDB.AddOutParameter(dbCMD, "@DepartmentID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@DepartmentName", SqlDbType.VarChar, entMST_Department.DepartmentName);
                sqlDB.AddInParameter(dbCMD, "@DepartmentCode", SqlDbType.VarChar, entMST_Department.DepartmentCode);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entMST_Department.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Department.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entMST_Department.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Department.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Department.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMST_Department.DepartmentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@DepartmentID"].Value);

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

        public Boolean Update(MST_DepartmentENT entMST_Department)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_Update");

                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entMST_Department.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentName", SqlDbType.VarChar, entMST_Department.DepartmentName);
                sqlDB.AddInParameter(dbCMD, "@DepartmentCode", SqlDbType.VarChar, entMST_Department.DepartmentCode);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entMST_Department.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Department.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entMST_Department.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Department.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Department.Modified);

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

        public Boolean Delete(SqlInt32 DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_Delete");

                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);

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

        public MST_DepartmentENT SelectPK(SqlInt32 DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);

                MST_DepartmentENT entMST_Department = new MST_DepartmentENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["DepartmentID"].Equals(System.DBNull.Value))
                            entMST_Department.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);

                        if (!dr["DepartmentName"].Equals(System.DBNull.Value))
                            entMST_Department.DepartmentName = Convert.ToString(dr["DepartmentName"]);

                        if (!dr["DepartmentCode"].Equals(System.DBNull.Value))
                            entMST_Department.DepartmentCode = Convert.ToString(dr["DepartmentCode"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entMST_Department.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entMST_Department.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMST_Department.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMST_Department.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entMST_Department;
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
        public DataTable SelectView(SqlInt32 DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_SelectView");

                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);

                DataTable dtMST_Department = new DataTable("PR_MST_Department_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Department);

                return dtMST_Department;
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
        public DataTable SelectAll(SqlString LoginType, SqlInt32 InstituteID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_SelectAll");

                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);

                DataTable dtMST_Department = new DataTable("PR_MST_Department_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Department);

                return dtMST_Department;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString DepartmentName)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_SelectPage");

                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@DepartmentName", SqlDbType.NVarChar, DepartmentName);

                DataTable dtMST_Activity = new DataTable("PR_MST_Department_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Activity);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtMST_Activity;
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

        public DataTable SelectComboBox(SqlInt32 InstituteID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_SelectComboBox");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                DataTable dtMST_Department = new DataTable("PR_MST_Department_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Department);

                return dtMST_Department;
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

        #region InsComboBox

        public DataTable SelectInsComboBox(SqlInt32 InstituteID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_SelectComboBox");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                DataTable dtMST_Department = new DataTable("PR_MST_Department_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Department);

                return dtMST_Department;
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

        #endregion InsComboBox

    }
}