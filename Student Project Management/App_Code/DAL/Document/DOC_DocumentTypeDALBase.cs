using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public abstract class DOC_DocumentTypeDALBase : DataBaseConfig
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

        public DOC_DocumentTypeDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(DOC_DocumentTypeENT entDOC_DocumentType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_DocumentType_Insert");

                sqlDB.AddOutParameter(dbCMD, "@DocumentTypeID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@DocumentTypeName", SqlDbType.VarChar, entDOC_DocumentType.DocumentTypeName);
                sqlDB.AddInParameter(dbCMD, "@IsInternal", SqlDbType.Bit, entDOC_DocumentType.IsInternal);
                sqlDB.AddInParameter(dbCMD, "@IsGTU", SqlDbType.Bit, entDOC_DocumentType.IsGTU);
                sqlDB.AddInParameter(dbCMD, "@DeadLine", SqlDbType.DateTime, entDOC_DocumentType.DeadLine);
                sqlDB.AddInParameter(dbCMD, "@IsCompulsory", SqlDbType.Bit, entDOC_DocumentType.IsCompulsory);
                sqlDB.AddInParameter(dbCMD, "@IsGanttChart", SqlDbType.Bit, entDOC_DocumentType.IsGanttChart);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, entDOC_DocumentType.AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entDOC_DocumentType.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entDOC_DocumentType.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entDOC_DocumentType.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entDOC_DocumentType.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entDOC_DocumentType.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entDOC_DocumentType.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entDOC_DocumentType.DocumentTypeID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@DocumentTypeID"].Value);

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

        public Boolean Update(DOC_DocumentTypeENT entDOC_DocumentType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_DocumentType_Update");

                sqlDB.AddInParameter(dbCMD, "@DocumentTypeID", SqlDbType.Int, entDOC_DocumentType.DocumentTypeID);
                sqlDB.AddInParameter(dbCMD, "@DocumentTypeName", SqlDbType.VarChar, entDOC_DocumentType.DocumentTypeName);
                sqlDB.AddInParameter(dbCMD, "@IsInternal", SqlDbType.Bit, entDOC_DocumentType.IsInternal);
                sqlDB.AddInParameter(dbCMD, "@IsGTU", SqlDbType.Bit, entDOC_DocumentType.IsGTU);
                sqlDB.AddInParameter(dbCMD, "@DeadLine", SqlDbType.DateTime, entDOC_DocumentType.DeadLine);
                sqlDB.AddInParameter(dbCMD, "@IsCompulsory", SqlDbType.Bit, entDOC_DocumentType.IsCompulsory);
                sqlDB.AddInParameter(dbCMD, "@IsGanttChart", SqlDbType.Bit, entDOC_DocumentType.IsGanttChart);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, entDOC_DocumentType.AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entDOC_DocumentType.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entDOC_DocumentType.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entDOC_DocumentType.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entDOC_DocumentType.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entDOC_DocumentType.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entDOC_DocumentType.Modified);

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

        public Boolean Delete(SqlInt32 DocumentTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_DocumentType_Delete");

                sqlDB.AddInParameter(dbCMD, "@DocumentTypeID", SqlDbType.Int, DocumentTypeID);

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

        public DOC_DocumentTypeENT SelectPK(SqlInt32 DocumentTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_DocumentType_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@DocumentTypeID", SqlDbType.Int, DocumentTypeID);

                DOC_DocumentTypeENT entDOC_DocumentType = new DOC_DocumentTypeENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["DocumentTypeID"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.DocumentTypeID = Convert.ToInt32(dr["DocumentTypeID"]);

                        if (!dr["DocumentTypeName"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.DocumentTypeName = Convert.ToString(dr["DocumentTypeName"]);

                        if (!dr["IsInternal"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.IsInternal = Convert.ToBoolean(dr["IsInternal"]);

                        if (!dr["IsGTU"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.IsGTU = Convert.ToBoolean(dr["IsGTU"]);

                        if (!dr["DeadLine"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.DeadLine = Convert.ToDateTime(dr["DeadLine"]);

                        if (!dr["IsCompulsory"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.IsCompulsory = Convert.ToBoolean(dr["IsCompulsory"]);

                        if (!dr["IsGanttChart"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.IsGanttChart = Convert.ToBoolean(dr["IsGanttChart"]);

                        if (!dr["AcademicYearID"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.AcademicYearID = Convert.ToInt32(dr["AcademicYearID"]);

                        if (!dr["DepartmentID"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entDOC_DocumentType.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entDOC_DocumentType;
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
        public DataTable SelectView(SqlInt32 DocumentTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_DocumentType_SelectView");

                sqlDB.AddInParameter(dbCMD, "@DocumentTypeID", SqlDbType.Int, DocumentTypeID);

                DataTable dtDOC_DocumentType = new DataTable("PR_DOC_DocumentType_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtDOC_DocumentType);

                return dtDOC_DocumentType;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_DocumentType_SelectAll");

                DataTable dtDOC_DocumentType = new DataTable("PR_DOC_DocumentType_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtDOC_DocumentType);

                return dtDOC_DocumentType;
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

        public DataTable SelectComboBox(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_DocumentType_SelectComboBox");

                DataTable dtDOC_DocumentType = new DataTable("PR_DOC_DocumentType_SelectComboBox");
                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtDOC_DocumentType);

                return dtDOC_DocumentType;
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