using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;

namespace DProject.DAL
{
    public class MET_MeetingWiseStudentDAL : MET_MeetingWiseStudentDALBase
    {
        #region SelectProjectIDByMeetingID

        public Int32 SelectProjectIDByMeetingID(SqlInt32 MeetingID)
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MET_MeetingProject_SelectByMeetingID");

            sqlDB.AddInParameter(dbCMD, "@MeetingID", SqlDbType.Int, MeetingID);
            Int32 i = 0;
            DataBaseHelper DBH = new DataBaseHelper();
            using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
            {
                while (dr.Read())
                {
                    if (!dr["ProjectID"].Equals(System.DBNull.Value))
                        i = Convert.ToInt32(dr["ProjectID"]);
                }
            }
            return i;
        }

        #endregion SelectProjectIDByMeetingID
    }

}