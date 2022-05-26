using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class DOC_DocumentTypeENTBase
    {
        #region Properties


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

        protected SqlString _DocumentTypeName;
        public SqlString DocumentTypeName
        {
            get
            {
                return _DocumentTypeName;
            }
            set
            {
                _DocumentTypeName = value;
            }
        }

        protected SqlBoolean _IsInternal;
        public SqlBoolean IsInternal
        {
            get
            {
                return _IsInternal;
            }
            set
            {
                _IsInternal = value;
            }
        }

        protected SqlBoolean _IsGTU;
        public SqlBoolean IsGTU
        {
            get
            {
                return _IsGTU;
            }
            set
            {
                _IsGTU = value;
            }
        }

        protected SqlDateTime _DeadLine;
        public SqlDateTime DeadLine
        {
            get
            {
                return _DeadLine;
            }
            set
            {
                _DeadLine = value;
            }
        }

        protected SqlBoolean _IsCompulsory;
        public SqlBoolean IsCompulsory
        {
            get
            {
                return _IsCompulsory;
            }
            set
            {
                _IsCompulsory = value;
            }
        }

        protected SqlBoolean _IsGanttChart;
        public SqlBoolean IsGanttChart
        {
            get
            {
                return _IsGanttChart;
            }
            set
            {
                _IsGanttChart = value;
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

        protected SqlInt32 _DepartmentID;
        public SqlInt32 DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                _DepartmentID = value;
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

        public DOC_DocumentTypeENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String DOC_DocumentTypeENT_String = String.Empty;

            if (!DocumentTypeID.IsNull)
                DOC_DocumentTypeENT_String += " DocumentTypeID = " + DocumentTypeID.Value.ToString();

            if (!DocumentTypeName.IsNull)
                DOC_DocumentTypeENT_String += "| DocumentTypeName = " + DocumentTypeName.Value;

            if (!IsInternal.IsNull)
                DOC_DocumentTypeENT_String += "| IsInternal = " + IsInternal.Value;

            if (!IsGTU.IsNull)
                DOC_DocumentTypeENT_String += "| IsGTU = " + IsGTU.Value;

            if (!DeadLine.IsNull)
                DOC_DocumentTypeENT_String += "| DeadLine = " + DeadLine.Value.ToString("dd-MM-yyyy");

            if (!IsCompulsory.IsNull)
                DOC_DocumentTypeENT_String += "| IsCompulsory = " + IsCompulsory.Value;

            if (!IsGanttChart.IsNull)
                DOC_DocumentTypeENT_String += "| IsGanttChart = " + IsGanttChart.Value;

            if (!AcademicYearID.IsNull)
                DOC_DocumentTypeENT_String += "| AcademicYearID = " + AcademicYearID.Value.ToString();

            if (!DepartmentID.IsNull)
                DOC_DocumentTypeENT_String += "| DepartmentID = " + DepartmentID.Value.ToString();

            if (!InstituteID.IsNull)
                DOC_DocumentTypeENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Remarks.IsNull)
                DOC_DocumentTypeENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                DOC_DocumentTypeENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                DOC_DocumentTypeENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            DOC_DocumentTypeENT_String = DOC_DocumentTypeENT_String.Trim();

            return DOC_DocumentTypeENT_String;
        }

        #endregion ToString

    }

}