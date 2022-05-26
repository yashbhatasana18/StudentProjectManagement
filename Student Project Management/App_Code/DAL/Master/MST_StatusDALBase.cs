using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public abstract class MST_StatusDALBase : DataBaseConfig
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

        public MST_StatusDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_StatusENT entMST_Status)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Status_Insert");

                sqlDB.AddOutParameter(dbCMD, "@StatusID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@StatusName", SqlDbType.VarChar, entMST_Status.StatusName);
                sqlDB.AddInParameter(dbCMD, "@IsWaitingforStudent", SqlDbType.Bit, entMST_Status.IsWaitingforStudent);
                sqlDB.AddInParameter(dbCMD, "@IsWaitingforGuide", SqlDbType.Bit, entMST_Status.IsWaitingforGuide);
                sqlDB.AddInParameter(dbCMD, "@SequenceNo", SqlDbType.Decimal, entMST_Status.SequenceNo);
                sqlDB.AddInParameter(dbCMD, "@PreviousStatusID", SqlDbType.Int, entMST_Status.PreviousStatusID);
                sqlDB.AddInParameter(dbCMD, "@NextStatusID", SqlDbType.Int, entMST_Status.NextStatusID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Status.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Status.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Status.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMST_Status.StatusID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@StatusID"].Value);

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

        public Boolean Update(MST_StatusENT entMST_Status)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Status_Update");

                sqlDB.AddInParameter(dbCMD, "@StatusID", SqlDbType.Int, entMST_Status.StatusID);
                sqlDB.AddInParameter(dbCMD, "@StatusName", SqlDbType.VarChar, entMST_Status.StatusName);
                sqlDB.AddInParameter(dbCMD, "@IsWaitingforStudent", SqlDbType.Bit, entMST_Status.IsWaitingforStudent);
                sqlDB.AddInParameter(dbCMD, "@IsWaitingforGuide", SqlDbType.Bit, entMST_Status.IsWaitingforGuide);
                sqlDB.AddInParameter(dbCMD, "@SequenceNo", SqlDbType.Decimal, entMST_Status.SequenceNo);
                sqlDB.AddInParameter(dbCMD, "@PreviousStatusID", SqlDbType.Int, entMST_Status.PreviousStatusID);
                sqlDB.AddInParameter(dbCMD, "@NextStatusID", SqlDbType.Int, entMST_Status.NextStatusID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Status.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Status.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Status.Modified);

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

        public Boolean Delete(SqlInt32 StatusID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Status_Delete");

                sqlDB.AddInParameter(dbCMD, "@StatusID", SqlDbType.Int, StatusID);

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

        public MST_StatusENT SelectPK(SqlInt32 StatusID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Status_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@StatusID", SqlDbType.Int, StatusID);

                MST_StatusENT entMST_Status = new MST_StatusENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["StatusID"].Equals(System.DBNull.Value))
                            entMST_Status.StatusID = Convert.ToInt32(dr["StatusID"]);

                        if (!dr["StatusName"].Equals(System.DBNull.Value))
                            entMST_Status.StatusName = Convert.ToString(dr["StatusName"]);

                        //if (!dr["IsWaitingforStudent"].Equals(System.DBNull.Value))
                        //    entMST_Status.IsWaitingforStudent = Convert.ToBoolean(dr["IsWaitingforStudent"]);

                        //if (!dr["IsWaitingforFaculty"].Equals(System.DBNull.Value))
                        //    entMST_Status.IsWaitingforGuide = Convert.ToBoolean(dr["IsWaitingforGuide"]);

                        if (!dr["SequenceNo"].Equals(System.DBNull.Value))
                            entMST_Status.SequenceNo = Convert.ToDecimal(dr["SequenceNo"]);

                        //if (!dr["PreviousStatusID"].Equals(System.DBNull.Value))
                        //    entMST_Status.PreviousStatusID = Convert.ToInt32(dr["PreviousStatusID"]);

                        //if (!dr["NextStatusID"].Equals(System.DBNull.Value))
                        //    entMST_Status.NextStatusID = Convert.ToInt32(dr["NextStatusID"]);

                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entMST_Status.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMST_Status.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMST_Status.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entMST_Status;
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
        public DataTable SelectView(SqlInt32 StatusID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Status_SelectView");

                sqlDB.AddInParameter(dbCMD, "@StatusID", SqlDbType.Int, StatusID);

                DataTable dtMST_Status = new DataTable("PR_MST_Status_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Status);

                return dtMST_Status;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Status_SelectAll");

                DataTable dtMST_Status = new DataTable("PR_MST_Status_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Status);

                return dtMST_Status;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Status_SelectComboBox");

                DataTable dtRES_StudentResume = new DataTable("PR_MST_Status_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtRES_StudentResume);

                return dtRES_StudentResume;
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