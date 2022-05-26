using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class DOC_DocumentTypeBALBase
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

        public DOC_DocumentTypeBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(DOC_DocumentTypeENT entDOC_DocumentType)
        {
            DOC_DocumentTypeDAL dalDOC_DocumentType = new DOC_DocumentTypeDAL();
            if (dalDOC_DocumentType.Insert(entDOC_DocumentType))
            {
                return true;
            }
            else
            {
                this.Message = dalDOC_DocumentType.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(DOC_DocumentTypeENT entDOC_DocumentType)
        {
            DOC_DocumentTypeDAL dalDOC_DocumentType = new DOC_DocumentTypeDAL();
            if (dalDOC_DocumentType.Update(entDOC_DocumentType))
            {
                return true;
            }
            else
            {
                this.Message = dalDOC_DocumentType.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 DocumentTypeID)
        {
            DOC_DocumentTypeDAL dalDOC_DocumentType = new DOC_DocumentTypeDAL();
            if (dalDOC_DocumentType.Delete(DocumentTypeID))
            {
                return true;
            }
            else
            {
                this.Message = dalDOC_DocumentType.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public DOC_DocumentTypeENT SelectPK(SqlInt32 DocumentTypeID)
        {
            DOC_DocumentTypeDAL dalDOC_DocumentType = new DOC_DocumentTypeDAL();
            return dalDOC_DocumentType.SelectPK(DocumentTypeID);
        }
        public DataTable SelectView(SqlInt32 DocumentTypeID)
        {
            DOC_DocumentTypeDAL dalDOC_DocumentType = new DOC_DocumentTypeDAL();
            return dalDOC_DocumentType.SelectView(DocumentTypeID);
        }
        public DataTable SelectAll()
        {
            DOC_DocumentTypeDAL dalDOC_DocumentType = new DOC_DocumentTypeDAL();
            return dalDOC_DocumentType.SelectAll();
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID)
        {
            DOC_DocumentTypeDAL dalDOC_DocumentType = new DOC_DocumentTypeDAL();
            return dalDOC_DocumentType.SelectComboBox(LoginType, LoginID, InstituteID, DepartmentID);
        }

        #endregion ComboBox
    }

}