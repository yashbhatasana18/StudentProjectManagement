using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DProject.DAL
{
    public abstract class MST_InstituteDALBase : DataBaseConfig
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

        public MST_InstituteDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_InstituteENT entMST_Institute)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Institute_Insert");

                sqlDB.AddOutParameter(dbCMD, "@InstituteID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@InstituteName", SqlDbType.VarChar, entMST_Institute.InstituteName);
                sqlDB.AddInParameter(dbCMD, "@InstituteShortName", SqlDbType.VarChar, entMST_Institute.InstituteShortName);
                sqlDB.AddInParameter(dbCMD, "@Institutecode", SqlDbType.VarChar, entMST_Institute.Institutecode);
                sqlDB.AddInParameter(dbCMD, "@InstitutePhone", SqlDbType.VarChar, entMST_Institute.InstitutePhone);
                sqlDB.AddInParameter(dbCMD, "@Mobile", SqlDbType.VarChar, entMST_Institute.Mobile);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, entMST_Institute.Address);
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, entMST_Institute.CityID);
                sqlDB.AddInParameter(dbCMD, "@Pincode", SqlDbType.VarChar, entMST_Institute.Pincode);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, entMST_Institute.Email);
                sqlDB.AddInParameter(dbCMD, "@Website", SqlDbType.VarChar, entMST_Institute.Website);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Institute.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entMST_Institute.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Institute.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Institute.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMST_Institute.InstituteID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@InstituteID"].Value);

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

        public Boolean Update(MST_InstituteENT entMST_Institute)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Institute_Update");

                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entMST_Institute.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@InstituteName", SqlDbType.VarChar, entMST_Institute.InstituteName);
                sqlDB.AddInParameter(dbCMD, "@InstituteShortName", SqlDbType.VarChar, entMST_Institute.InstituteShortName);
                sqlDB.AddInParameter(dbCMD, "@Institutecode", SqlDbType.VarChar, entMST_Institute.Institutecode);
                sqlDB.AddInParameter(dbCMD, "@InstitutePhone", SqlDbType.VarChar, entMST_Institute.InstitutePhone);
                sqlDB.AddInParameter(dbCMD, "@Mobile", SqlDbType.VarChar, entMST_Institute.Mobile);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, entMST_Institute.Address);
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, entMST_Institute.CityID);
                sqlDB.AddInParameter(dbCMD, "@Pincode", SqlDbType.VarChar, entMST_Institute.Pincode);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, entMST_Institute.Email);
                sqlDB.AddInParameter(dbCMD, "@Website", SqlDbType.VarChar, entMST_Institute.Website);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Institute.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entMST_Institute.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Institute.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Institute.Modified);

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

        public Boolean Delete(SqlInt32 InstituteID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Institute_Delete");

                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);

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

        public MST_InstituteENT SelectPK(SqlInt32 InstituteID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Institute_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);

                MST_InstituteENT entMST_Institute = new MST_InstituteENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entMST_Institute.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["InstituteName"].Equals(System.DBNull.Value))
                            entMST_Institute.InstituteName = Convert.ToString(dr["InstituteName"]);

                        if (!dr["InstituteShortName"].Equals(System.DBNull.Value))
                            entMST_Institute.InstituteShortName = Convert.ToString(dr["InstituteShortName"]);

                        if (!dr["Institutecode"].Equals(System.DBNull.Value))
                            entMST_Institute.Institutecode = Convert.ToString(dr["Institutecode"]);

                        if (!dr["InstitutePhone"].Equals(System.DBNull.Value))
                            entMST_Institute.InstitutePhone = Convert.ToString(dr["InstitutePhone"]);

                        if (!dr["Mobile"].Equals(System.DBNull.Value))
                            entMST_Institute.Mobile = Convert.ToString(dr["Mobile"]);

                        if (!dr["Address"].Equals(System.DBNull.Value))
                            entMST_Institute.Address = Convert.ToString(dr["Address"]);

                        if (!dr["CityID"].Equals(System.DBNull.Value))
                            entMST_Institute.CityID = Convert.ToInt32(dr["CityID"]);

                        if (!dr["Pincode"].Equals(System.DBNull.Value))
                            entMST_Institute.Pincode = Convert.ToString(dr["Pincode"]);

                        if (!dr["Email"].Equals(System.DBNull.Value))
                            entMST_Institute.Email = Convert.ToString(dr["Email"]);

                        if (!dr["Website"].Equals(System.DBNull.Value))
                            entMST_Institute.Website = Convert.ToString(dr["Website"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entMST_Institute.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMST_Institute.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMST_Institute.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entMST_Institute;
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
        public DataTable SelectView(SqlInt32 InstituteID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Institute_SelectView");

                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);

                DataTable dtMST_Institute = new DataTable("PR_MST_Institute_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Institute);

                return dtMST_Institute;
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
        public DataTable SelectAll(SqlString LoginType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Institute_SelectAll");

                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);

                DataTable dtMST_Institute = new DataTable("PR_MST_Institute_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Institute);

                return dtMST_Institute;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Institute_SelectComboBox");

                DataTable dtMST_Institute = new DataTable("PR_MST_Institute_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Institute);

                return dtMST_Institute;
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