using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DProject.DAL
{
    public abstract class PRJ_AssignProjectDALBase : DataBaseConfig
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

        public PRJ_AssignProjectDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(PRJ_AssignProjectENT entPRJ_AssignProject)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectWiseStudent_Insert");

                sqlDB.AddOutParameter(dbCMD, "@ProjectWiseStudentID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entPRJ_AssignProject.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entPRJ_AssignProject.StudentID);
                sqlDB.AddInParameter(dbCMD, "@IsLeader", SqlDbType.Bit, entPRJ_AssignProject.IsLeader);
                sqlDB.AddInParameter(dbCMD, "@SequenceNo", SqlDbType.Int, entPRJ_AssignProject.SequenceNo);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entPRJ_AssignProject.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entPRJ_AssignProject.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entPRJ_AssignProject.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entPRJ_AssignProject.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entPRJ_AssignProject.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entPRJ_AssignProject.ProjectWiseStudentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@ProjectWiseStudentID"].Value);

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

        public Boolean Update(PRJ_AssignProjectENT entPRJ_AssignProject)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectWiseStudent_Update");

                sqlDB.AddInParameter(dbCMD, "@ProjectWiseStudentID", SqlDbType.Int, entPRJ_AssignProject.ProjectWiseStudentID);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entPRJ_AssignProject.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entPRJ_AssignProject.StudentID);
                sqlDB.AddInParameter(dbCMD, "@IsLeader", SqlDbType.Bit, entPRJ_AssignProject.IsLeader);
                sqlDB.AddInParameter(dbCMD, "@SequenceNo", SqlDbType.Int, entPRJ_AssignProject.SequenceNo);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entPRJ_AssignProject.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entPRJ_AssignProject.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entPRJ_AssignProject.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entPRJ_AssignProject.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entPRJ_AssignProject.Modified);

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

        public Boolean Delete(SqlInt32 ProjectWiseStudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectWiseStudent_Delete");

                sqlDB.AddInParameter(dbCMD, "@ProjectWiseStudentID", SqlDbType.Int, ProjectWiseStudentID);

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

        public PRJ_AssignProjectENT SelectPK(SqlInt32 ProjectWiseStudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectWiseStudent_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@ProjectWiseStudentID", SqlDbType.Int, ProjectWiseStudentID);

                PRJ_AssignProjectENT entPRJ_AssignProject = new PRJ_AssignProjectENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["ProjectWiseStudentID"].Equals(System.DBNull.Value))
                            entPRJ_AssignProject.ProjectWiseStudentID = Convert.ToInt32(dr["ProjectWiseStudentID"]);

                        if (!dr["ProjectID"].Equals(System.DBNull.Value))
                            entPRJ_AssignProject.ProjectID = Convert.ToInt32(dr["ProjectID"]);

                        if (!dr["StudentID"].Equals(System.DBNull.Value))
                            entPRJ_AssignProject.StudentID = Convert.ToInt32(dr["StudentID"]);

                        if (!dr["IsLeader"].Equals(System.DBNull.Value))
                            entPRJ_AssignProject.IsLeader = Convert.ToBoolean(dr["IsLeader"]);

                        if (!dr["SequenceNo"].Equals(System.DBNull.Value))
                            entPRJ_AssignProject.SequenceNo = Convert.ToInt32(dr["SequenceNo"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entPRJ_AssignProject.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entPRJ_AssignProject.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entPRJ_AssignProject.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entPRJ_AssignProject.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entPRJ_AssignProject;
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
        public DataTable SelectView(SqlInt32 ProjectWiseStudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectWiseStudent_SelectView");

                sqlDB.AddInParameter(dbCMD, "@ProjectWiseStudentID", SqlDbType.Int, ProjectWiseStudentID);

                DataTable dtPRJ_ProjectWiseStudent = new DataTable("PR_PRJ_ProjectWiseStudent_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_ProjectWiseStudent);

                return dtPRJ_ProjectWiseStudent;
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
        public DataTable SelectAll(SqlString LoginType, SqlInt32 DepartmentID, SqlInt32 InstituteID, SqlInt32 LoginID, SqlInt32 AcademicYearID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectWiseStudent_SelectAll");

                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);

                DataTable dtPRJ_ProjectWiseStudent = new DataTable("PR_PRJ_ProjectWiseStudent_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_ProjectWiseStudent);

                return dtPRJ_ProjectWiseStudent;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectWiseStudent_SelectComboBox");

                DataTable dtPRJ_ProjectWiseStudent = new DataTable("PR_PRJ_ProjectWiseStudent_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_ProjectWiseStudent);

                return dtPRJ_ProjectWiseStudent;
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