using DProject.DAL;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public class DOC_ProjectDocumentBAL : DOC_ProjectDocumentBALBase
    {
        #region Select Report Project Wise Document List

        public DataTable SelectAllProjectWiseDocumentReport(SqlInt32 InstituteID, SqlInt32 AcademicYearID, SqlInt32 ProjectID)
        {
            DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
            return dalDOC_ProjectDocument.SelectAllProjectWiseDocumentReport(InstituteID, AcademicYearID, ProjectID);
        }

        #endregion Select Report Project Wise Document List

        #region Select Report Project Wise Document List After DeadLine

        public DataTable SelectAllProjectWiseDocumentReportAfterDeadLine(SqlInt32 InstituteID, SqlInt32 AcademicYearID, SqlInt32 DocumentTypeID)
        {
            DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
            return dalDOC_ProjectDocument.SelectAllProjectWiseDocumentReportAfterDeadLine(InstituteID, AcademicYearID, DocumentTypeID);
        }

        #endregion Select Report Project Wise Document List After DeadLine

        #region Select Report Project Wise Document List DeadLine Achived

        public DataTable SelectAllProjectWiseDocumentReportDeadLineAchived(SqlInt32 InstituteID, SqlInt32 AcademicYearID, SqlString LoginType, SqlInt32 DocumentTypeID, SqlInt32 LoginID, SqlInt32 DepartmentID)
        {
            DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
            return dalDOC_ProjectDocument.SelectAllProjectWiseDocumentReportDeadLineAchived(InstituteID, AcademicYearID, LoginType, DocumentTypeID, LoginID, DepartmentID);
        }

        #endregion Select Report Project Wise Document List DeadLine Achived
    }

}