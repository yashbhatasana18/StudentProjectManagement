using DProject.DAL;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public class DOC_DocumentTypeBAL : DOC_DocumentTypeBALBase
    {
        #region Select Report Document Type List

        public DataTable SelectAllDocumentTypeReport(SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlString LoginType)
        {
            DOC_DocumentTypeDAL dalDOC_DocumentType = new DOC_DocumentTypeDAL();
            return dalDOC_DocumentType.SelectAllDocumentTypeReport(InstituteID, DepartmentID, LoginType);
        }

        #endregion Select Report Project Wise Document List
    }

}