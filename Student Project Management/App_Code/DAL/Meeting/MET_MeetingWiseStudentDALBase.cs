using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public abstract class MET_MeetingWiseStudentDALBase : DataBaseConfig
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

        public MET_MeetingWiseStudentDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MET_MeetingWiseStudentENT entMET_MeetingWiseStudent)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingWiseStudent_Insert");

                sqlDB.AddOutParameter(dbCMD, "@MeetingWiseStudentID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entMET_MeetingWiseStudent.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@MeetingID", SqlDbType.Int, entMET_MeetingWiseStudent.MeetingID);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entMET_MeetingWiseStudent.StudentID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMET_MeetingWiseStudent.UserID);
                sqlDB.AddInParameter(dbCMD, "@FacultyRemarks", SqlDbType.VarChar, entMET_MeetingWiseStudent.FacultyRemarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMET_MeetingWiseStudent.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMET_MeetingWiseStudent.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMET_MeetingWiseStudent.MeetingWiseStudentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@MeetingWiseStudentID"].Value);

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

        public Boolean Update(MET_MeetingWiseStudentENT entMET_MeetingWiseStudent)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingWiseStudent_Update");

                sqlDB.AddInParameter(dbCMD, "@MeetingWiseStudentID", SqlDbType.Int, entMET_MeetingWiseStudent.MeetingWiseStudentID);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entMET_MeetingWiseStudent.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@MeetingID", SqlDbType.Int, entMET_MeetingWiseStudent.MeetingID);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entMET_MeetingWiseStudent.StudentID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMET_MeetingWiseStudent.UserID);
                sqlDB.AddInParameter(dbCMD, "@FacultyRemarks", SqlDbType.VarChar, entMET_MeetingWiseStudent.FacultyRemarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMET_MeetingWiseStudent.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMET_MeetingWiseStudent.Modified);

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

        public Boolean Delete(SqlInt32 MeetingWiseStudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingWiseStudent_Delete");

                sqlDB.AddInParameter(dbCMD, "@MeetingWiseStudentID", SqlDbType.Int, MeetingWiseStudentID);

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

        public MET_MeetingWiseStudentENT SelectPK(SqlInt32 MeetingWiseStudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingWiseStudent_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@MeetingWiseStudentID", SqlDbType.Int, MeetingWiseStudentID);

                MET_MeetingWiseStudentENT entMET_MeetingWiseStudent = new MET_MeetingWiseStudentENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["MeetingWiseStudentID"].Equals(System.DBNull.Value))
                            entMET_MeetingWiseStudent.MeetingWiseStudentID = Convert.ToInt32(dr["MeetingWiseStudentID"]);

                        if (!dr["ProjectID"].Equals(System.DBNull.Value))
                            entMET_MeetingWiseStudent.ProjectID = Convert.ToInt32(dr["ProjectID"]);

                        if (!dr["MeetingID"].Equals(System.DBNull.Value))
                            entMET_MeetingWiseStudent.MeetingID = Convert.ToInt32(dr["MeetingID"]);

                        if (!dr["StudentID"].Equals(System.DBNull.Value))
                            entMET_MeetingWiseStudent.StudentID = Convert.ToInt32(dr["StudentID"]);

                        if (!dr["FacultyRemarks"].Equals(System.DBNull.Value))
                            entMET_MeetingWiseStudent.FacultyRemarks = Convert.ToString(dr["FacultyRemarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMET_MeetingWiseStudent.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMET_MeetingWiseStudent.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entMET_MeetingWiseStudent;
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
        public DataTable SelectView(SqlInt32 MeetingWiseStudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingWiseStudent_SelectView");

                sqlDB.AddInParameter(dbCMD, "@MeetingWiseStudentID", SqlDbType.Int, MeetingWiseStudentID);

                DataTable dtMET_MeetingWiseStudent = new DataTable("PR_MET_MeetingWiseStudent_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMET_MeetingWiseStudent);

                return dtMET_MeetingWiseStudent;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingWiseStudent_SelectAll");

                DataTable dtMET_MeetingWiseStudent = new DataTable("PR_MET_MeetingWiseStudent_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMET_MeetingWiseStudent);

                return dtMET_MeetingWiseStudent;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingWiseStudent_SelectComboBox");

                DataTable dtMET_MeetingWiseStudent = new DataTable("PR_MET_MeetingWiseStudent_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMET_MeetingWiseStudent);

                return dtMET_MeetingWiseStudent;
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