using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;

namespace DProject.DAL
{
    public class DataBaseHelper
    {
        public DataBaseHelper()
        {

        }

        public Int32 ExecuteNonQuery(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            return sqlDB.ExecuteNonQuery(dbCMD);
        }

        public DataTable LoadDataTable(SqlDatabase sqlDB, DbCommand dbCMD, DataTable dt)
        {
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return dt;
        }

        public IDataReader ExecuteReader(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            return sqlDB.ExecuteReader(dbCMD);
        }

    }
}
