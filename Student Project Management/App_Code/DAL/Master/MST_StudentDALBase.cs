using DProject.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DProject.DAL
{
    public abstract class MST_StudentDALBase : DataBaseConfig
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

        public MST_StudentDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_StudentENT entMST_Student)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_Insert");

                sqlDB.AddOutParameter(dbCMD, "@StudentID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.VarChar, entMST_Student.StudentName);
                sqlDB.AddInParameter(dbCMD, "@EnrollmentNo", SqlDbType.VarChar, entMST_Student.EnrollmentNo);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, entMST_Student.Email);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_Student.DOB);
                sqlDB.AddInParameter(dbCMD, "@SignaturePath", SqlDbType.VarChar, entMST_Student.SignaturePath);
                sqlDB.AddInParameter(dbCMD, "@Mobile", SqlDbType.VarChar, entMST_Student.Mobile);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entMST_Student.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entMST_Student.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Student.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entMST_Student.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Student.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Student.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMST_Student.StudentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@StudentID"].Value);

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

        public Boolean Update(MST_StudentENT entMST_Student)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_Update");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entMST_Student.StudentID);
                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.VarChar, entMST_Student.StudentName);
                sqlDB.AddInParameter(dbCMD, "@EnrollmentNo", SqlDbType.VarChar, entMST_Student.EnrollmentNo);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, entMST_Student.Email);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_Student.DOB);
                sqlDB.AddInParameter(dbCMD, "@SignaturePath", SqlDbType.VarChar, entMST_Student.SignaturePath);
                sqlDB.AddInParameter(dbCMD, "@Mobile", SqlDbType.VarChar, entMST_Student.Mobile);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entMST_Student.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, entMST_Student.InstituteID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Student.UserID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.VarChar, entMST_Student.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Student.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Student.Modified);

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

        public Boolean Delete(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_Delete");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

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

        public MST_StudentENT SelectPK(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

                MST_StudentENT entMST_Student = new MST_StudentENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["StudentID"].Equals(System.DBNull.Value))
                            entMST_Student.StudentID = Convert.ToInt32(dr["StudentID"]);

                        if (!dr["StudentName"].Equals(System.DBNull.Value))
                            entMST_Student.StudentName = Convert.ToString(dr["StudentName"]);

                        if (!dr["EnrollmentNo"].Equals(System.DBNull.Value))
                            entMST_Student.EnrollmentNo = Convert.ToString(dr["EnrollmentNo"]);

                        if (!dr["Email"].Equals(System.DBNull.Value))
                            entMST_Student.Email = Convert.ToString(dr["Email"]);

                        if (!dr["DOB"].Equals(System.DBNull.Value))
                            entMST_Student.DOB = Convert.ToDateTime(dr["DOB"]);

                        if (!dr["SignaturePath"].Equals(System.DBNull.Value))
                            entMST_Student.SignaturePath = Convert.ToString(dr["SignaturePath"]);

                        if (!dr["Mobile"].Equals(System.DBNull.Value))
                            entMST_Student.Mobile = Convert.ToString(dr["Mobile"]);

                        if (!dr["DepartmentID"].Equals(System.DBNull.Value))
                            entMST_Student.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);

                        if (!dr["InstituteID"].Equals(System.DBNull.Value))
                            entMST_Student.InstituteID = Convert.ToInt32(dr["InstituteID"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entMST_Student.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMST_Student.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMST_Student.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entMST_Student;
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
        public DataTable SelectView(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectView");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectAll");

                sqlDB.AddInParameter(dbCMD, "@LoginType", SqlDbType.VarChar, LoginType);
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);

                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectComboBox");

                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
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