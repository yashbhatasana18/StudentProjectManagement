using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DProject.DAL
{
    public abstract class WRK_WorkAssignedDALBase : DataBaseConfig
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

        public WRK_WorkAssignedDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(WRK_WorkAssignedENT entWRK_WorkAssigned)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WorkAssigned_Insert");

                sqlDB.AddOutParameter(dbCMD, "@WorkAssignedID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@FacultyID", SqlDbType.Int, entWRK_WorkAssigned.FacultyID);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entWRK_WorkAssigned.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entWRK_WorkAssigned.StudentID);
                sqlDB.AddInParameter(dbCMD, "@DeadLine", SqlDbType.DateTime, entWRK_WorkAssigned.DeadLine);
                sqlDB.AddInParameter(dbCMD, "@WorkTobeDone", SqlDbType.VarChar, entWRK_WorkAssigned.WorkTobeDone);
                sqlDB.AddInParameter(dbCMD, "@SubmittedDate", SqlDbType.DateTime, entWRK_WorkAssigned.SubmittedDate);
                sqlDB.AddInParameter(dbCMD, "@FacultyRemarks", SqlDbType.VarChar, entWRK_WorkAssigned.FacultyRemarks);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entWRK_WorkAssigned.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entWRK_WorkAssigned.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entWRK_WorkAssigned.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entWRK_WorkAssigned.Modified);
                sqlDB.AddInParameter(dbCMD, "@StatusID", SqlDbType.Int, entWRK_WorkAssigned.StatusID);
                sqlDB.AddInParameter(dbCMD, "@StatusDate", SqlDbType.DateTime, entWRK_WorkAssigned.StatusDate);
                sqlDB.AddInParameter(dbCMD, "@StatusUserID", SqlDbType.Int, entWRK_WorkAssigned.StatusUserID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entWRK_WorkAssigned.WorkAssignedID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@WorkAssignedID"].Value);

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

        public Boolean Update(WRK_WorkAssignedENT entWRK_WorkAssigned)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WorkAssigned_Update");

                sqlDB.AddInParameter(dbCMD, "@WorkAssignedID", SqlDbType.Int, entWRK_WorkAssigned.WorkAssignedID);
                sqlDB.AddInParameter(dbCMD, "@FacultyID", SqlDbType.Int, entWRK_WorkAssigned.FacultyID);
                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entWRK_WorkAssigned.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entWRK_WorkAssigned.StudentID);
                sqlDB.AddInParameter(dbCMD, "@DeadLine", SqlDbType.DateTime, entWRK_WorkAssigned.DeadLine);
                sqlDB.AddInParameter(dbCMD, "@WorkTobeDone", SqlDbType.VarChar, entWRK_WorkAssigned.WorkTobeDone);
                sqlDB.AddInParameter(dbCMD, "@SubmittedDate", SqlDbType.DateTime, entWRK_WorkAssigned.SubmittedDate);
                sqlDB.AddInParameter(dbCMD, "@FacultyRemarks", SqlDbType.VarChar, entWRK_WorkAssigned.FacultyRemarks);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entWRK_WorkAssigned.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entWRK_WorkAssigned.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entWRK_WorkAssigned.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entWRK_WorkAssigned.Modified);
                sqlDB.AddInParameter(dbCMD, "@StatusID", SqlDbType.Int, entWRK_WorkAssigned.StatusID);
                sqlDB.AddInParameter(dbCMD, "@StatusDate", SqlDbType.DateTime, entWRK_WorkAssigned.StatusDate);
                sqlDB.AddInParameter(dbCMD, "@StatusUserID", SqlDbType.Int, entWRK_WorkAssigned.StatusUserID);

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

        public Boolean Delete(SqlInt32 WorkAssignedID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WorkAssigned_Delete");

                sqlDB.AddInParameter(dbCMD, "@WorkAssignedID", SqlDbType.Int, WorkAssignedID);

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

        public WRK_WorkAssignedENT SelectPK(SqlInt32 WorkAssignedID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WorkAssigned_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@WorkAssignedID", SqlDbType.Int, WorkAssignedID);

                WRK_WorkAssignedENT entWRK_WorkAssigned = new WRK_WorkAssignedENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["WorkAssignedID"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.WorkAssignedID = Convert.ToInt32(dr["WorkAssignedID"]);

                        if (!dr["FacultyID"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.FacultyID = Convert.ToInt32(dr["FacultyID"]);

                        if (!dr["ProjectID"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.ProjectID = Convert.ToInt32(dr["ProjectID"]);

                        if (!dr["StudentID"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.StudentID = Convert.ToInt32(dr["StudentID"]);

                        if (!dr["DeadLine"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.DeadLine = Convert.ToDateTime(dr["DeadLine"]);

                        if (!dr["WorkTobeDone"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.WorkTobeDone = Convert.ToString(dr["WorkTobeDone"]);

                        if (!dr["SubmittedDate"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.SubmittedDate = Convert.ToDateTime(dr["SubmittedDate"]);

                        if (!dr["FacultyRemarks"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.FacultyRemarks = Convert.ToString(dr["FacultyRemarks"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.Modified = Convert.ToDateTime(dr["Modified"]);

                        if (!dr["StatusID"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.StatusID = Convert.ToInt32(dr["StatusID"]);

                        if (!dr["StatusDate"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.StatusDate = Convert.ToDateTime(dr["StatusDate"]);

                        if (!dr["StatusUserID"].Equals(System.DBNull.Value))
                            entWRK_WorkAssigned.StatusUserID = Convert.ToInt32(dr["StatusUserID"]);
                    }
                }
                return entWRK_WorkAssigned;
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
        public DataTable SelectView(SqlInt32 WorkAssignedID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WorkAssigned_SelectView");

                sqlDB.AddInParameter(dbCMD, "@WorkAssignedID", SqlDbType.Int, WorkAssignedID);

                DataTable dtWRK_WorkAssigned = new DataTable("PR_WRK_WorkAssigned_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtWRK_WorkAssigned);

                return dtWRK_WorkAssigned;
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
        public DataTable SelectAll(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WorkAssigned_SelectAll");

                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);

                DataTable dtWRK_WorkAssigned = new DataTable("PR_WRK_WorkAssigned_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtWRK_WorkAssigned);

                return dtWRK_WorkAssigned;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_WRK_WorkAssigned_SelectComboBox");

                DataTable dtWRK_WorkAssigned = new DataTable("PR_WRK_WorkAssigned_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtWRK_WorkAssigned);

                return dtWRK_WorkAssigned;
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