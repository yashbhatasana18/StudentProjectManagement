using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace DProject.DAL
{
    public abstract class DOC_ProjectDocumentDALBase : DataBaseConfig
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

        public DOC_ProjectDocumentDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(DOC_ProjectDocumentENT entDOC_ProjectDocument)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_ProjectDocument_Insert");

                sqlDB.AddOutParameter(dbCMD, "@ProjectDocumentID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@DocumentTypeID", SqlDbType.Int, entDOC_ProjectDocument.DocumentTypeID);
                sqlDB.AddInParameter(dbCMD, "@SubmissionDate", SqlDbType.DateTime, entDOC_ProjectDocument.SubmissionDate);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entDOC_ProjectDocument.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@DocumentName", SqlDbType.VarChar, entDOC_ProjectDocument.DocumentName);
                sqlDB.AddInParameter(dbCMD, "@DocumentPath", SqlDbType.VarChar, entDOC_ProjectDocument.DocumentPath);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entDOC_ProjectDocument.Remarks);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, entDOC_ProjectDocument.AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entDOC_ProjectDocument.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entDOC_ProjectDocument.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entDOC_ProjectDocument.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entDOC_ProjectDocument.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entDOC_ProjectDocument.ProjectDocumentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@ProjectDocumentID"].Value);

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

        public Boolean Update(DOC_ProjectDocumentENT entDOC_ProjectDocument)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_ProjectDocument_Update");

                sqlDB.AddInParameter(dbCMD, "@ProjectDocumentID", SqlDbType.Int, entDOC_ProjectDocument.ProjectDocumentID);
                sqlDB.AddInParameter(dbCMD, "@DocumentTypeID", SqlDbType.Int, entDOC_ProjectDocument.DocumentTypeID);
                sqlDB.AddInParameter(dbCMD, "@SubmissionDate", SqlDbType.DateTime, entDOC_ProjectDocument.SubmissionDate);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entDOC_ProjectDocument.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@DocumentName", SqlDbType.VarChar, entDOC_ProjectDocument.DocumentName);
                sqlDB.AddInParameter(dbCMD, "@DocumentPath", SqlDbType.VarChar, entDOC_ProjectDocument.DocumentPath);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entDOC_ProjectDocument.Remarks);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, entDOC_ProjectDocument.AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entDOC_ProjectDocument.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entDOC_ProjectDocument.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entDOC_ProjectDocument.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entDOC_ProjectDocument.Modified);

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

        public Boolean Delete(SqlInt32 ProjectDocumentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_ProjectDocument_Delete");

                sqlDB.AddInParameter(dbCMD, "@ProjectDocumentID", SqlDbType.Int, ProjectDocumentID);

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

        public DOC_ProjectDocumentENT SelectPK(SqlInt32 ProjectDocumentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_ProjectDocument_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@ProjectDocumentID", SqlDbType.Int, ProjectDocumentID);

                DOC_ProjectDocumentENT entDOC_ProjectDocument = new DOC_ProjectDocumentENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["ProjectDocumentID"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.ProjectDocumentID = Convert.ToInt32(dr["ProjectDocumentID"]);

                        if (!dr["DocumentTypeID"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.DocumentTypeID = Convert.ToInt32(dr["DocumentTypeID"]);

                        if (!dr["SubmissionDate"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.SubmissionDate = Convert.ToDateTime(dr["SubmissionDate"]);

                        if (!dr["ProjectID"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.ProjectID = Convert.ToInt32(dr["ProjectID"]);

                        if (!dr["DocumentName"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.DocumentName = Convert.ToString(dr["DocumentName"]);

                        if (!dr["DocumentPath"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.DocumentPath = Convert.ToString(dr["DocumentPath"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["AcademicYearID"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.AcademicYearID = Convert.ToInt32(dr["AcademicYearID"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entDOC_ProjectDocument.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entDOC_ProjectDocument;
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
        public DataTable SelectView(SqlInt32 ProjectDocumentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_ProjectDocument_SelectView");

                sqlDB.AddInParameter(dbCMD, "@ProjectDocumentID", SqlDbType.Int, ProjectDocumentID);

                DataTable dtDOC_ProjectDocument = new DataTable("PR_DOC_ProjectDocument_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtDOC_ProjectDocument);

                return dtDOC_ProjectDocument;
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
        public DataTable SelectAll(SqlString LoginType, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlInt32 LoginID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_ProjectDocument_SelectAll");

                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);

                DataTable dtDOC_ProjectDocument = new DataTable("PR_DOC_ProjectDocument_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtDOC_ProjectDocument);

                return dtDOC_ProjectDocument;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DOC_ProjectDocument_SelectComboBox");

                DataTable dtDOC_ProjectDocument = new DataTable("PR_DOC_ProjectDocument_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtDOC_ProjectDocument);

                return dtDOC_ProjectDocument;
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