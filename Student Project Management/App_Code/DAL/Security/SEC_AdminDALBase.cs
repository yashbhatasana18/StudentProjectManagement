using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DProject.DAL
{
    public abstract class SEC_AdminDALBase : DataBaseConfig
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

        public SEC_AdminDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(SEC_AdminENT entSEC_Admin)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_Insert");

                sqlDB.AddOutParameter(dbCMD, "@UserID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@UserCatagoryID", SqlDbType.Int, (SqlInt32)(entSEC_Admin.UserCatagoryID));
                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.VarChar, entSEC_Admin.AdminName);
                sqlDB.AddInParameter(dbCMD, "@UserPassword", SqlDbType.VarChar, entSEC_Admin.AdminPassword);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, entSEC_Admin.LoginID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entSEC_Admin.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entSEC_Admin.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@IsActive", SqlDbType.Bit, entSEC_Admin.IsActive);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entSEC_Admin.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entSEC_Admin.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entSEC_Admin.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entSEC_Admin.UserID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@UserID"].Value);

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

        public Boolean Update(SEC_AdminENT entSEC_Admin)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_Update");

                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entSEC_Admin.UserID);
                sqlDB.AddInParameter(dbCMD, "@UserCatagoryID", SqlDbType.Int, entSEC_Admin.UserCatagoryID);
                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.VarChar, entSEC_Admin.AdminName);
                sqlDB.AddInParameter(dbCMD, "@UserPassword", SqlDbType.VarChar, entSEC_Admin.AdminPassword);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, entSEC_Admin.LoginID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entSEC_Admin.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entSEC_Admin.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@IsActive", SqlDbType.Bit, entSEC_Admin.IsActive);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entSEC_Admin.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entSEC_Admin.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entSEC_Admin.Modified);

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

        public Boolean Delete(SqlInt32 UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_Delete");

                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);

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

        public SEC_AdminENT SelectPK(SqlInt32 UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);

                SEC_AdminENT entSEC_Admin = new SEC_AdminENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entSEC_Admin.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["UserCatagoryID"].Equals(System.DBNull.Value))
                            entSEC_Admin.UserCatagoryID = Convert.ToInt32(dr["UserCatagoryID"]);

                        if (!dr["UserName"].Equals(System.DBNull.Value))
                            entSEC_Admin.AdminName = Convert.ToString(dr["UserName"]);

                        if (!dr["UserPassword"].Equals(System.DBNull.Value))
                            entSEC_Admin.AdminPassword = Convert.ToString(dr["UserPassword"]);

                        if (!dr["LoginID"].Equals(System.DBNull.Value))
                            entSEC_Admin.LoginID = Convert.ToInt32(dr["LoginID"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entSEC_Admin.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["DepartmentID"].Equals(System.DBNull.Value))
                            entSEC_Admin.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);

                        if (!dr["IsActive"].Equals(System.DBNull.Value))
                            entSEC_Admin.IsActive = Convert.ToBoolean(dr["IsActive"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entSEC_Admin.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entSEC_Admin.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entSEC_Admin.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entSEC_Admin;
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
        public DataTable SelectView(SqlInt32 UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectView");

                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);

                DataTable dtSEC_Admin = new DataTable("PR_SEC_User_SelectView");

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
        public DataTable SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectAll");

                DataTable dtSEC_Admin = new DataTable("PR_SEC_User_SelectAll");

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

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_Admin_SelectComboBox");

                DataTable dtSEC_Admin = new DataTable("PR_SEC_Admin_SelectComboBox");

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

        #endregion ComboBox

        #region AutoComplete


        #endregion AutoComplete

    }
}