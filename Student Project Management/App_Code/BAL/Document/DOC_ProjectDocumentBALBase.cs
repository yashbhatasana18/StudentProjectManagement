using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class DOC_ProjectDocumentBALBase
    {
        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

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

        #endregion Public Properties

        #region Constructor

        public DOC_ProjectDocumentBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(DOC_ProjectDocumentENT entDOC_ProjectDocument)
        {
            DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
            if (dalDOC_ProjectDocument.Insert(entDOC_ProjectDocument))
            {
                return true;
            }
            else
            {
                this.Message = dalDOC_ProjectDocument.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(DOC_ProjectDocumentENT entDOC_ProjectDocument)
        {
            DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
            if (dalDOC_ProjectDocument.Update(entDOC_ProjectDocument))
            {
                return true;
            }
            else
            {
                this.Message = dalDOC_ProjectDocument.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 ProjectDocumentID)
        {
            DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
            if (dalDOC_ProjectDocument.Delete(ProjectDocumentID))
            {
                return true;
            }
            else
            {
                this.Message = dalDOC_ProjectDocument.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public DOC_ProjectDocumentENT SelectPK(SqlInt32 ProjectDocumentID)
        {
            DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
            return dalDOC_ProjectDocument.SelectPK(ProjectDocumentID);
        }
        public DataTable SelectView(SqlInt32 ProjectDocumentID)
        {
            DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
            return dalDOC_ProjectDocument.SelectView(ProjectDocumentID);
        }
        public DataTable SelectAll(SqlString LoginType, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlInt32 LoginID)
        {
            DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
            return dalDOC_ProjectDocument.SelectAll(LoginType, InstituteID, DepartmentID, AcademicYearID, LoginID);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
            return dalDOC_ProjectDocument.SelectComboBox();
        }

        #endregion ComboBox
    }

}