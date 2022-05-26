using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class DOC_ProjectDocumentENTBase
    {
        #region Properties


        protected SqlInt32 _ProjectDocumentID;
        public SqlInt32 ProjectDocumentID
        {
            get
            {
                return _ProjectDocumentID;
            }
            set
            {
                _ProjectDocumentID = value;
            }
        }

        protected SqlInt32 _DocumentTypeID;
        public SqlInt32 DocumentTypeID
        {
            get
            {
                return _DocumentTypeID;
            }
            set
            {
                _DocumentTypeID = value;
            }
        }

        protected SqlDateTime _SubmissionDate;
        public SqlDateTime SubmissionDate
        {
            get
            {
                return _SubmissionDate;
            }
            set
            {
                _SubmissionDate = value;
            }
        }

        protected SqlInt32 _ProjectID;
        public SqlInt32 ProjectID
        {
            get
            {
                return _ProjectID;
            }
            set
            {
                _ProjectID = value;
            }
        }

        protected SqlString _DocumentName;
        public SqlString DocumentName
        {
            get
            {
                return _DocumentName;
            }
            set
            {
                _DocumentName = value;
            }
        }

        protected SqlString _DocumentPath;
        public SqlString DocumentPath
        {
            get
            {
                return _DocumentPath;
            }
            set
            {
                _DocumentPath = value;
            }
        }

        protected SqlString _Remarks;
        public SqlString Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }

        protected SqlInt32 _AcademicYearID;
        public SqlInt32 AcademicYearID
        {
            get
            {
                return _AcademicYearID;
            }
            set
            {
                _AcademicYearID = value;
            }
        }

        protected SqlInt32 _InstituteID;
        public SqlInt32 InstituteID
        {
            get
            {
                return _InstituteID;
            }
            set
            {
                _InstituteID = value;
            }
        }

        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        protected SqlDateTime _Created;
        public SqlDateTime Created
        {
            get
            {
                return _Created;
            }
            set
            {
                _Created = value;
            }
        }

        protected SqlDateTime _Modified;
        public SqlDateTime Modified
        {
            get
            {
                return _Modified;
            }
            set
            {
                _Modified = value;
            }
        }

        #endregion Properties

        #region Constructor

        public DOC_ProjectDocumentENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String DOC_ProjectDocumentENT_String = String.Empty;

            if (!ProjectDocumentID.IsNull)
                DOC_ProjectDocumentENT_String += " ProjectDocumentID = " + ProjectDocumentID.Value.ToString();

            if (!DocumentTypeID.IsNull)
                DOC_ProjectDocumentENT_String += "| DocumentTypeID = " + DocumentTypeID.Value.ToString();

            if (!SubmissionDate.IsNull)
                DOC_ProjectDocumentENT_String += "| SubmissionDate = " + SubmissionDate.Value.ToString("dd-MM-yyyy");

            if (!ProjectID.IsNull)
                DOC_ProjectDocumentENT_String += "| ProjectID = " + ProjectID.Value.ToString();

            if (!DocumentName.IsNull)
                DOC_ProjectDocumentENT_String += "| DocumentName = " + DocumentName.Value;

            if (!DocumentPath.IsNull)
                DOC_ProjectDocumentENT_String += "| DocumentPath = " + DocumentPath.Value;

            if (!Remarks.IsNull)
                DOC_ProjectDocumentENT_String += "| Remarks = " + Remarks.Value;

            if (!AcademicYearID.IsNull)
                DOC_ProjectDocumentENT_String += "| AcademicYearID = " + AcademicYearID.Value.ToString();

            if (!InstituteID.IsNull)
                DOC_ProjectDocumentENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Created.IsNull)
                DOC_ProjectDocumentENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                DOC_ProjectDocumentENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            DOC_ProjectDocumentENT_String = DOC_ProjectDocumentENT_String.Trim();

            return DOC_ProjectDocumentENT_String;
        }

        #endregion ToString

    }

}