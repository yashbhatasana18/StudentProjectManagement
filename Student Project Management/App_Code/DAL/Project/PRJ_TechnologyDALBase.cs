using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public abstract class PRJ_TechnologyDALBase : DataBaseConfig
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

        public PRJ_TechnologyDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(PRJ_TechnologyENT entPRJ_Technology)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Technology_Insert");

                sqlDB.AddOutParameter(dbCMD, "@TechnologyID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@TechnologyName", SqlDbType.VarChar, entPRJ_Technology.TechnologyName);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entPRJ_Technology.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entPRJ_Technology.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entPRJ_Technology.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entPRJ_Technology.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entPRJ_Technology.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entPRJ_Technology.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entPRJ_Technology.TechnologyID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@TechnologyID"].Value);

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

        public Boolean Update(PRJ_TechnologyENT entPRJ_Technology)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Technology_Update");

                sqlDB.AddInParameter(dbCMD, "@TechnologyID", SqlDbType.Int, entPRJ_Technology.TechnologyID);
                sqlDB.AddInParameter(dbCMD, "@TechnologyName", SqlDbType.VarChar, entPRJ_Technology.TechnologyName);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entPRJ_Technology.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entPRJ_Technology.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entPRJ_Technology.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entPRJ_Technology.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entPRJ_Technology.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entPRJ_Technology.Modified);

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

        public Boolean Delete(SqlInt32 TechnologyID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Technology_Delete");

                sqlDB.AddInParameter(dbCMD, "@TechnologyID", SqlDbType.Int, TechnologyID);

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

        public PRJ_TechnologyENT SelectPK(SqlInt32 TechnologyID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Technology_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@TechnologyID", SqlDbType.Int, TechnologyID);

                PRJ_TechnologyENT entPRJ_Technology = new PRJ_TechnologyENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["TechnologyID"].Equals(System.DBNull.Value))
                            entPRJ_Technology.TechnologyID = Convert.ToInt32(dr["TechnologyID"]);

                        if (!dr["TechnologyName"].Equals(System.DBNull.Value))
                            entPRJ_Technology.TechnologyName = Convert.ToString(dr["TechnologyName"]);

                        if (!dr["DepartmentID"].Equals(System.DBNull.Value))
                            entPRJ_Technology.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entPRJ_Technology.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entPRJ_Technology.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entPRJ_Technology.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entPRJ_Technology.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entPRJ_Technology;
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
        public DataTable SelectView(SqlInt32 TechnologyID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Technology_SelectView");

                sqlDB.AddInParameter(dbCMD, "@TechnologyID", SqlDbType.Int, TechnologyID);

                DataTable dtPRJ_Technology = new DataTable("PR_PRJ_Technology_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_Technology);

                return dtPRJ_Technology;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Technology_SelectAll");

                DataTable dtPRJ_Technology = new DataTable("PR_PRJ_Technology_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_Technology);

                return dtPRJ_Technology;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_Technology_SelectComboBox");

                DataTable dtPRJ_Technology = new DataTable("PR_PRJ_Technology_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_Technology);

                return dtPRJ_Technology;
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