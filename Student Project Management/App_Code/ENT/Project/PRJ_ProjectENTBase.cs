using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class PRJ_ProjectENTBase
    {
        #region Properties


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

        protected SqlInt32 _GuideID;
        public SqlInt32 GuideID
        {
            get
            {
                return _GuideID;
            }
            set
            {
                _GuideID = value;
            }
        }

        protected SqlString _ProjectTitle;
        public SqlString ProjectTitle
        {
            get
            {
                return _ProjectTitle;
            }
            set
            {
                _ProjectTitle = value;
            }
        }

        protected SqlString _ProjectShortTitle;
        public SqlString ProjectShortTitle
        {
            get
            {
                return _ProjectShortTitle;
            }
            set
            {
                _ProjectShortTitle = value;
            }
        }

        protected SqlString _Description;
        public SqlString Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        protected SqlString _ProjectCode;
        public SqlString ProjectCode
        {
            get
            {
                return _ProjectCode;
            }
            set
            {
                _ProjectCode = value;
            }
        }

        protected SqlInt32 _TechnologyID;
        public SqlInt32 TechnologyID
        {
            get
            {
                return _TechnologyID;
            }
            set
            {
                _TechnologyID = value;
            }
        }

        protected SqlInt32 _Semester;
        public SqlInt32 Semester
        {
            get
            {
                return _Semester;
            }
            set
            {
                _Semester = value;
            }
        }

        protected SqlInt32 _Year;
        public SqlInt32 Year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
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

        public PRJ_ProjectENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String PRJ_ProjectENT_String = String.Empty;

            if (!ProjectID.IsNull)
                PRJ_ProjectENT_String += " ProjectID = " + ProjectID.Value.ToString();

            if (!GuideID.IsNull)
                PRJ_ProjectENT_String += " GuideID = " + GuideID.Value.ToString();

            if (!ProjectTitle.IsNull)
                PRJ_ProjectENT_String += "| ProjectTitle = " + ProjectTitle.Value;

            if (!ProjectShortTitle.IsNull)
                PRJ_ProjectENT_String += "| ProjectShortTitle = " + ProjectShortTitle.Value;

            if (!Description.IsNull)
                PRJ_ProjectENT_String += "| Description = " + Description.Value;

            if (!ProjectCode.IsNull)
                PRJ_ProjectENT_String += "| ProjectCode = " + ProjectCode.Value;

            if (!Semester.IsNull)
                PRJ_ProjectENT_String += "| Semester = " + Semester.Value.ToString();

            if (!Year.IsNull)
                PRJ_ProjectENT_String += "| Year = " + Year.Value.ToString();

            if (!AcademicYearID.IsNull)
                PRJ_ProjectENT_String += "| AcademicYearID = " + AcademicYearID.Value.ToString();

            if (!DepartmentID.IsNull)
                PRJ_ProjectENT_String += "| DepartmentID = " + DepartmentID.Value.ToString();

            if (!InstituteID.IsNull)
                PRJ_ProjectENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Remarks.IsNull)
                PRJ_ProjectENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                PRJ_ProjectENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                PRJ_ProjectENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            PRJ_ProjectENT_String = PRJ_ProjectENT_String.Trim();

            return PRJ_ProjectENT_String;
        }

        #endregion ToString

    }

}