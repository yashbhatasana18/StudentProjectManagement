using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public class DOC_DocumentTypeDAL : DOC_DocumentTypeDALBase
    {
        #region Select Report DocumentType List

        public DataTable SelectAllDocumentTypeReport(SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlString LoginType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_DOC_DocumentType_SelectAll");
                sqlDB.AddInParameter(dbCMD, "@InstituteID", SqlDbType.Int, InstituteID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@UserCatagory", SqlDbType.VarChar, LoginType);
                DataTable dtDOC_DocumentType = new DataTable("PP_DOC_DocumentType_SelectAll");

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

        #endregion Select Report Project Wise Document List
    }

}