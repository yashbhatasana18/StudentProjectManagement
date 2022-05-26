using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public abstract class MET_MeetingMasterDALBase : DataBaseConfig
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

        public MET_MeetingMasterDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MET_MeetingMasterENT entMET_MeetingMaster)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingMaster_Insert");

                sqlDB.AddOutParameter(dbCMD, "@MeetingID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entMET_MeetingMaster.StudentID);
                sqlDB.AddInParameter(dbCMD, "@MeetingDate", SqlDbType.DateTime, entMET_MeetingMaster.MeetingDate);
                sqlDB.AddInParameter(dbCMD, "@NextMeetingDate", SqlDbType.DateTime, entMET_MeetingMaster.NextMeetingDate);
                sqlDB.AddInParameter(dbCMD, "@WorkDone", SqlDbType.VarChar, entMET_MeetingMaster.WorkDone);
                sqlDB.AddInParameter(dbCMD, "@WorkAssigned", SqlDbType.VarChar, entMET_MeetingMaster.WorkAssigned);
                sqlDB.AddInParameter(dbCMD, "@MeetingDuration", SqlDbType.Decimal, entMET_MeetingMaster.MeetingDuration);
                sqlDB.AddInParameter(dbCMD, "@FacultyRemarks", SqlDbType.VarChar, entMET_MeetingMaster.FacultyRemarks);
                sqlDB.AddInParameter(dbCMD, "@FacultyID", SqlDbType.Int, entMET_MeetingMaster.FacultyID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entMET_MeetingMaster.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMET_MeetingMaster.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMET_MeetingMaster.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMET_MeetingMaster.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMET_MeetingMaster.MeetingID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@MeetingID"].Value);

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

        public Boolean Update(MET_MeetingMasterENT entMET_MeetingMaster)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingMaster_Update");

                sqlDB.AddInParameter(dbCMD, "@MeetingID", SqlDbType.Int, entMET_MeetingMaster.MeetingID);
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entMET_MeetingMaster.StudentID);
                sqlDB.AddInParameter(dbCMD, "@MeetingDate", SqlDbType.DateTime, entMET_MeetingMaster.MeetingDate);
                sqlDB.AddInParameter(dbCMD, "@NextMeetingDate", SqlDbType.DateTime, entMET_MeetingMaster.NextMeetingDate);
                sqlDB.AddInParameter(dbCMD, "@WorkDone", SqlDbType.VarChar, entMET_MeetingMaster.WorkDone);
                sqlDB.AddInParameter(dbCMD, "@WorkAssigned", SqlDbType.VarChar, entMET_MeetingMaster.WorkAssigned);
                sqlDB.AddInParameter(dbCMD, "@MeetingDuration", SqlDbType.Decimal, entMET_MeetingMaster.MeetingDuration);
                sqlDB.AddInParameter(dbCMD, "@FacultyRemarks", SqlDbType.VarChar, entMET_MeetingMaster.FacultyRemarks);
                sqlDB.AddInParameter(dbCMD, "@FacultyID", SqlDbType.Int, entMET_MeetingMaster.FacultyID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entMET_MeetingMaster.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMET_MeetingMaster.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMET_MeetingMaster.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMET_MeetingMaster.Modified);

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

        public Boolean Delete(SqlInt32 MeetingID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingMaster_Delete");

                sqlDB.AddInParameter(dbCMD, "@MeetingID", SqlDbType.Int, MeetingID);

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

        public MET_MeetingMasterENT SelectPK(SqlInt32 MeetingID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingMaster_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@MeetingID", SqlDbType.Int, MeetingID);

                MET_MeetingMasterENT entMET_MeetingMaster = new MET_MeetingMasterENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["MeetingID"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.MeetingID = Convert.ToInt32(dr["MeetingID"]);

                        if (!dr["StudentID"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.StudentID = Convert.ToInt32(dr["StudentID"]);

                        if (!dr["MeetingDate"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.MeetingDate = Convert.ToDateTime(dr["MeetingDate"]);

                        if (!dr["NextMeetingDate"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.NextMeetingDate = Convert.ToDateTime(dr["NextMeetingDate"]);

                        if (!dr["WorkDone"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.WorkDone = Convert.ToString(dr["WorkDone"]);

                        if (!dr["WorkAssigned"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.WorkAssigned = Convert.ToString(dr["WorkAssigned"]);

                        if (!dr["MeetingDuration"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.MeetingDuration = Convert.ToDecimal(dr["MeetingDuration"]);

                        if (!dr["FacultyRemarks"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.FacultyRemarks = Convert.ToString(dr["FacultyRemarks"]);

                        if (!dr["FacultyID"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.FacultyID = Convert.ToInt32(dr["FacultyID"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMET_MeetingMaster.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entMET_MeetingMaster;
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
        public DataTable SelectView(SqlInt32 MeetingID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingMaster_SelectView");

                sqlDB.AddInParameter(dbCMD, "@MeetingID", SqlDbType.Int, MeetingID);

                DataTable dtMET_MeetingMaster = new DataTable("PR_MET_MeetingMaster_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMET_MeetingMaster);

                return dtMET_MeetingMaster;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingMaster_SelectAll");

                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);

                DataTable dtMET_MeetingMaster = new DataTable("PR_MET_MeetingMaster_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMET_MeetingMaster);

                return dtMET_MeetingMaster;
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

        public DataTable SelectComboBox(SqlInt32 InstituteID, SqlString LoginType, SqlInt32 LoginID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingMaster_SelectComboBox");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);
                DataTable dtMET_MeetingMaster = new DataTable("PR_MET_MeetingMaster_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMET_MeetingMaster);

                return dtMET_MeetingMaster;
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