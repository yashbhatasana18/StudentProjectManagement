using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class WRK_WeeklyWorkdoneENTBase
    {
        #region Properties


        protected SqlInt32 _WorkdoneID;
        public SqlInt32 WorkdoneID
        {
            get
            {
                return _WorkdoneID;
            }
            set
            {
                _WorkdoneID = value;
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

        protected SqlInt32 _StudentID;
        public SqlInt32 StudentID
        {
            get
            {
                return _StudentID;
            }
            set
            {
                _StudentID = value;
            }
        }

        protected SqlDateTime _EntryDate;
        public SqlDateTime EntryDate
        {
            get
            {
                return _EntryDate;
            }
            set
            {
                _EntryDate = value;
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

        protected SqlDateTime _Todate;
        public SqlDateTime Todate
        {
            get
            {
                return _Todate;
            }
            set
            {
                _Todate = value;
            }
        }

        protected SqlString _Workdone;
        public SqlString Workdone
        {
            get
            {
                return _Workdone;
            }
            set
            {
                _Workdone = value;
            }
        }

        protected SqlString _FacultyRemarks;
        public SqlString FacultyRemarks
        {
            get
            {
                return _FacultyRemarks;
            }
            set
            {
                _FacultyRemarks = value;
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

        public WRK_WeeklyWorkdoneENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String WRK_WeeklyWorkdoneENT_String = String.Empty;

            if (!WorkdoneID.IsNull)
                WRK_WeeklyWorkdoneENT_String += " WorkdoneID = " + WorkdoneID.Value.ToString();

            if (!ProjectID.IsNull)
                WRK_WeeklyWorkdoneENT_String += "| ProjectID = " + ProjectID.Value.ToString();

            if (!StudentID.IsNull)
                WRK_WeeklyWorkdoneENT_String += "| StudentID = " + StudentID.Value.ToString();

            if (!EntryDate.IsNull)
                WRK_WeeklyWorkdoneENT_String += "| EntryDate = " + EntryDate.Value.ToString("dd-MM-yyyy");

            if (!FromDate.IsNull)
                WRK_WeeklyWorkdoneENT_String += "| FromDate = " + FromDate.Value.ToString("dd-MM-yyyy");

            if (!Todate.IsNull)
                WRK_WeeklyWorkdoneENT_String += "| Todate = " + Todate.Value.ToString("dd-MM-yyyy");

            if (!Workdone.IsNull)
                WRK_WeeklyWorkdoneENT_String += "| Workdone = " + Workdone.Value;

            if (!FacultyRemarks.IsNull)
                WRK_WeeklyWorkdoneENT_String += "| FacultyRemarks = " + FacultyRemarks.Value;

            if (!InstituteID.IsNull)
                WRK_WeeklyWorkdoneENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Created.IsNull)
                WRK_WeeklyWorkdoneENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                WRK_WeeklyWorkdoneENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            WRK_WeeklyWorkdoneENT_String = WRK_WeeklyWorkdoneENT_String.Trim();

            return WRK_WeeklyWorkdoneENT_String;
        }

        #endregion ToString

    }

}