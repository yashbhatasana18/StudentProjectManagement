using DProject.DAL;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public class WRK_WeeklyWorkdoneBAL : WRK_WeeklyWorkdoneBALBase
    {
        #region Select WeeklyWorkDone

        public DataTable SelectWeeklyWorkDone(SqlInt32 WorkDoneID, SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            WRK_WeeklyWorkdoneDAL dalWRK_WeeklyWorkdone = new WRK_WeeklyWorkdoneDAL();
            return dalWRK_WeeklyWorkdone.SelectWeeklyWorkDone(WorkDoneID, LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID);
        }

        #endregion Select WeeklyWorkDone
    }

}