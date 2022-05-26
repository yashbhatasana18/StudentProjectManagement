using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class MST_AcademicYearENTBase
    {
        #region Properties


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

        protected SqlString _AcademicYearName;
        public SqlString AcademicYearName
        {
            get
            {
                return _AcademicYearName;
            }
            set
            {
                _AcademicYearName = value;
            }
        }

        protected SqlDateTime _FromDate;
        public SqlDateTime FromDate
        {
            get
            {
                return _FromDate;
            }
            set
            {
                _FromDate = value;
            }
        }

        protected SqlDateTime _ToDate;
        public SqlDateTime ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                _ToDate = value;
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

        public MST_AcademicYearENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MST_AcademicYearENT_String = String.Empty;

            if (!AcademicYearID.IsNull)
                MST_AcademicYearENT_String += " AcademicYearID = " + AcademicYearID.Value.ToString();

            if (!AcademicYearName.IsNull)
                MST_AcademicYearENT_String += "| AcademicYearName = " + AcademicYearName.Value;

            if (!FromDate.IsNull)
                MST_AcademicYearENT_String += "| FromDate = " + FromDate.Value.ToString("dd-MM-yyyy");

            if (!ToDate.IsNull)
                MST_AcademicYearENT_String += "| ToDate = " + ToDate.Value.ToString("dd-MM-yyyy");

            if (!InstituteID.IsNull)
                MST_AcademicYearENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Remarks.IsNull)
                MST_AcademicYearENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                MST_AcademicYearENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MST_AcademicYearENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            MST_AcademicYearENT_String = MST_AcademicYearENT_String.Trim();

            return MST_AcademicYearENT_String;
        }

        #endregion ToString

    }

}