using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public abstract class MST_FacultyDALBase : DataBaseConfig
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

        public MST_FacultyDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_FacultyENT entMST_Faculty)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Faculty_Insert");

                sqlDB.AddOutParameter(dbCMD, "@FacultyID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@FacultyName", SqlDbType.VarChar, entMST_Faculty.FacultyName);
                sqlDB.AddInParameter(dbCMD, "@FacultyShortName", SqlDbType.VarChar, entMST_Faculty.FacultyShortName);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entMST_Faculty.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, entMST_Faculty.Address);
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, entMST_Faculty.CityID);
                sqlDB.AddInParameter(dbCMD, "@Pincode", SqlDbType.VarChar, entMST_Faculty.Pincode);
                sqlDB.AddInParameter(dbCMD, "@Phone", SqlDbType.VarChar, entMST_Faculty.Phone);
                sqlDB.AddInParameter(dbCMD, "@Mobile", SqlDbType.VarChar, entMST_Faculty.Mobile);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, entMST_Faculty.Email);
                sqlDB.AddInParameter(dbCMD, "@Website", SqlDbType.VarChar, entMST_Faculty.Website);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entMST_Faculty.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Faculty.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entMST_Faculty.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Faculty.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Faculty.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMST_Faculty.FacultyID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@FacultyID"].Value);

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

        public Boolean Update(MST_FacultyENT entMST_Faculty)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Faculty_Update");

                sqlDB.AddInParameter(dbCMD, "@FacultyID", SqlDbType.Int, entMST_Faculty.FacultyID);
                sqlDB.AddInParameter(dbCMD, "@FacultyName", SqlDbType.VarChar, entMST_Faculty.FacultyName);
                sqlDB.AddInParameter(dbCMD, "@FacultyShortName", SqlDbType.VarChar, entMST_Faculty.FacultyShortName);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entMST_Faculty.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, entMST_Faculty.Address);
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, entMST_Faculty.CityID);
                sqlDB.AddInParameter(dbCMD, "@Pincode", SqlDbType.VarChar, entMST_Faculty.Pincode);
                sqlDB.AddInParameter(dbCMD, "@Phone", SqlDbType.VarChar, entMST_Faculty.Phone);
                sqlDB.AddInParameter(dbCMD, "@Mobile", SqlDbType.VarChar, entMST_Faculty.Mobile);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, entMST_Faculty.Email);
                sqlDB.AddInParameter(dbCMD, "@Website", SqlDbType.VarChar, entMST_Faculty.Website);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entMST_Faculty.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Faculty.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entMST_Faculty.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Faculty.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Faculty.Modified);

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

        public Boolean Delete(SqlInt32 FacultyID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Faculty_Delete");

                sqlDB.AddInParameter(dbCMD, "@FacultyID", SqlDbType.Int, FacultyID);

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

        public MST_FacultyENT SelectPK(SqlInt32 FacultyID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Faculty_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@FacultyID", SqlDbType.Int, FacultyID);

                MST_FacultyENT entMST_Faculty = new MST_FacultyENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["FacultyID"].Equals(System.DBNull.Value))
                            entMST_Faculty.FacultyID = Convert.ToInt32(dr["FacultyID"]);

                        if (!dr["FacultyName"].Equals(System.DBNull.Value))
                            entMST_Faculty.FacultyName = Convert.ToString(dr["FacultyName"]);

                        if (!dr["FacultyShortName"].Equals(System.DBNull.Value))
                            entMST_Faculty.FacultyShortName = Convert.ToString(dr["FacultyShortName"]);

                        if (!dr["DepartmentID"].Equals(System.DBNull.Value))
                            entMST_Faculty.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);

                        if (!dr["Address"].Equals(System.DBNull.Value))
                            entMST_Faculty.Address = Convert.ToString(dr["Address"]);

                        if (!dr["CityID"].Equals(System.DBNull.Value))
                            entMST_Faculty.CityID = Convert.ToInt32(dr["CityID"]);

                        if (!dr["Pincode"].Equals(System.DBNull.Value))
                            entMST_Faculty.Pincode = Convert.ToString(dr["Pincode"]);

                        if (!dr["Phone"].Equals(System.DBNull.Value))
                            entMST_Faculty.Phone = Convert.ToString(dr["Phone"]);

                        if (!dr["Mobile"].Equals(System.DBNull.Value))
                            entMST_Faculty.Mobile = Convert.ToString(dr["Mobile"]);

                        if (!dr["Email"].Equals(System.DBNull.Value))
                            entMST_Faculty.Email = Convert.ToString(dr["Email"]);

                        if (!dr["Website"].Equals(System.DBNull.Value))
                            entMST_Faculty.Website = Convert.ToString(dr["Website"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entMST_Faculty.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entMST_Faculty.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMST_Faculty.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMST_Faculty.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entMST_Faculty;
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
        public DataTable SelectView(SqlInt32 FacultyID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Faculty_SelectView");

                sqlDB.AddInParameter(dbCMD, "@FacultyID", SqlDbType.Int, FacultyID);

                DataTable dtMST_Faculty = new DataTable("PR_MST_Faculty_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Faculty);

                return dtMST_Faculty;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Faculty_SelectAll");

                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);

                DataTable dtMST_Faculty = new DataTable("PR_MST_Faculty_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Faculty);

                return dtMST_Faculty;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString FacultyName)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Faculty_SelectPage");

                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@FacultyName", SqlDbType.NVarChar, FacultyName);

                DataTable dtMST_Activity = new DataTable("PR_MST_Faculty_SelectPage");

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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Faculty_SelectComboBox");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                DataTable dtMST_Faculty = new DataTable("PR_MST_Faculty_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Faculty);

                return dtMST_Faculty;
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