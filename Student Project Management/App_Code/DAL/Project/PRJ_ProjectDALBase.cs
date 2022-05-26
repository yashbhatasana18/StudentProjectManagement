using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public abstract class PRJ_ProjectDALBase : DataBaseConfig
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

        public PRJ_ProjectDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(PRJ_ProjectENT entPRJ_Project)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectMaster_Insert");

                sqlDB.AddOutParameter(dbCMD, "@ProjectID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@GuideID", SqlDbType.Int, entPRJ_Project.GuideID);
                sqlDB.AddInParameter(dbCMD, "@ProjectTitle", SqlDbType.VarChar, entPRJ_Project.ProjectTitle);
                sqlDB.AddInParameter(dbCMD, "@ProjectShortTitle", SqlDbType.VarChar, entPRJ_Project.ProjectShortTitle);
                sqlDB.AddInParameter(dbCMD, "@Description", SqlDbType.VarChar, entPRJ_Project.Description);
                sqlDB.AddInParameter(dbCMD, "@TechnologyID", SqlDbType.Int, entPRJ_Project.TechnologyID);
                sqlDB.AddInParameter(dbCMD, "@Semester", SqlDbType.Int, entPRJ_Project.Semester);
                sqlDB.AddInParameter(dbCMD, "@Year", SqlDbType.Int, entPRJ_Project.Year);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entPRJ_Project.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entPRJ_Project.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@ProjectCode", SqlDbType.VarChar, entPRJ_Project.ProjectCode);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entPRJ_Project.UserID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, entPRJ_Project.AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entPRJ_Project.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entPRJ_Project.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entPRJ_Project.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entPRJ_Project.ProjectID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@ProjectID"].Value);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (sqlex.ToString().Contains("Violation of UNIQUE KEY constraint"))
                    Message = "Project Has Already Added";
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

        public Boolean Update(PRJ_ProjectENT entPRJ_Project)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectMaster_Update");

                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, entPRJ_Project.ProjectID);
                sqlDB.AddInParameter(dbCMD, "@GuideID", SqlDbType.Int, entPRJ_Project.GuideID);
                sqlDB.AddInParameter(dbCMD, "@ProjectTitle", SqlDbType.VarChar, entPRJ_Project.ProjectTitle);
                sqlDB.AddInParameter(dbCMD, "@ProjectShortTitle", SqlDbType.VarChar, entPRJ_Project.ProjectShortTitle);
                sqlDB.AddInParameter(dbCMD, "@Description", SqlDbType.VarChar, entPRJ_Project.Description);
                sqlDB.AddInParameter(dbCMD, "@TechnologyID", SqlDbType.Int, entPRJ_Project.TechnologyID);
                sqlDB.AddInParameter(dbCMD, "@Semester", SqlDbType.Int, entPRJ_Project.Semester);
                sqlDB.AddInParameter(dbCMD, "@Year", SqlDbType.Int, entPRJ_Project.Year);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entPRJ_Project.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entPRJ_Project.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@ProjectCode", SqlDbType.VarChar, entPRJ_Project.ProjectCode);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entPRJ_Project.UserID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, entPRJ_Project.AcademicYearID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entPRJ_Project.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entPRJ_Project.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entPRJ_Project.Modified);

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

        public Boolean Delete(SqlInt32 ProjectID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectMaster_Delete");

                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, ProjectID);

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

        public PRJ_ProjectENT SelectPK(SqlInt32 ProjectID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectMaster_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, ProjectID);

                PRJ_ProjectENT entPRJ_Project = new PRJ_ProjectENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["ProjectID"].Equals(System.DBNull.Value))
                            entPRJ_Project.ProjectID = Convert.ToInt32(dr["ProjectID"]);

                        if (!dr["GuideID"].Equals(System.DBNull.Value))
                            entPRJ_Project.GuideID = Convert.ToInt32(dr["GuideID"]);

                        if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                            entPRJ_Project.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

                        if (!dr["ProjectShortTitle"].Equals(System.DBNull.Value))
                            entPRJ_Project.ProjectShortTitle = Convert.ToString(dr["ProjectShortTitle"]);

                        if (!dr["Description"].Equals(System.DBNull.Value))
                            entPRJ_Project.Description = Convert.ToString(dr["Description"]);

                        if (!dr["TechnologyID"].Equals(System.DBNull.Value))
                            entPRJ_Project.TechnologyID = Convert.ToInt32(dr["TechnologyID"]);

                        if (!dr["Semester"].Equals(System.DBNull.Value))
                            entPRJ_Project.Semester = Convert.ToInt32(dr["Semester"]);

                        if (!dr["Year"].Equals(System.DBNull.Value))
                            entPRJ_Project.Year = Convert.ToInt32(dr["Year"]);

                        if (!dr["AcademicYearID"].Equals(System.DBNull.Value))
                            entPRJ_Project.AcademicYearID = Convert.ToInt32(dr["AcademicYearID"]);

                        if (!dr["DepartmentID"].Equals(System.DBNull.Value))
                            entPRJ_Project.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entPRJ_Project.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["ProjectCode"].Equals(System.DBNull.Value))
                            entPRJ_Project.ProjectCode = Convert.ToString(dr["ProjectCode"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entPRJ_Project.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entPRJ_Project.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entPRJ_Project.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entPRJ_Project;
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
        public DataTable SelectView(SqlInt32 ProjectID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectMaster_SelectView");

                sqlDB.AddInParameter(dbCMD, "@ProjectID", SqlDbType.Int, ProjectID);

                DataTable dtPRJ_Project = new DataTable("PR_PRJ_ProjectMaster_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_Project);

                return dtPRJ_Project;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectMaster_SelectAll");

                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);

                DataTable dtPRJ_Project = new DataTable("PR_PRJ_ProjectMaster_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_Project);

                return dtPRJ_Project;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRJ_ProjectMaster_SelectComboBox");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@LoginID", SqlDbType.Int, LoginID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@AcademicYearID", SqlDbType.Int, AcademicYearID);
                DataTable dtPRJ_Project = new DataTable("PR_PRJ_ProjectMaster_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPRJ_Project);

                return dtPRJ_Project;
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