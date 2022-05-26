using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class WRK_WorkAssignedENTBase
    {
        #region Properties


        protected SqlInt32 _WorkAssignedID;
        public SqlInt32 WorkAssignedID
        {
            get
            {
                return _WorkAssignedID;
            }
            set
            {
                _WorkAssignedID = value;
            }
        }

        protected SqlInt32 _FacultyID;
        public SqlInt32 FacultyID
        {
            get
            {
                return _FacultyID;
            }
            set
            {
                _FacultyID = value;
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

        protected SqlString _WorkTobeDone;
        public SqlString WorkTobeDone
        {
            get
            {
                return _WorkTobeDone;
            }
            set
            {
                _WorkTobeDone = value;
            }
        }

        protected SqlDateTime _SubmittedDate;
        public SqlDateTime SubmittedDate
        {
            get
            {
                return _SubmittedDate;
            }
            set
            {
                _SubmittedDate = value;
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

        protected SqlInt32 _StatusID;
        public SqlInt32 StatusID
        {
            get
            {
                return _StatusID;
            }
            set
            {
                _StatusID = value;
            }
        }

        protected SqlDateTime _StatusDate;
        public SqlDateTime StatusDate
        {
            get
            {
                return _StatusDate;
            }
            set
            {
                _StatusDate = value;
            }
        }

        protected SqlInt32 _StatusUserID;
        public SqlInt32 StatusUserID
        {
            get
            {
                return _StatusUserID;
            }
            set
            {
                _StatusUserID = value;
            }
        }

        #endregion Properties

        #region Constructor

        public WRK_WorkAssignedENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String WRK_WorkAssignedENT_String = String.Empty;

            if (!WorkAssignedID.IsNull)
                WRK_WorkAssignedENT_String += " WorkAssignedID = " + WorkAssignedID.Value.ToString();

            if (!FacultyID.IsNull)
                WRK_WorkAssignedENT_String += "| FacultyID = " + FacultyID.Value.ToString();

            if (!ProjectID.IsNull)
                WRK_WorkAssignedENT_String += "| ProjectID = " + ProjectID.Value.ToString();

            if (!StudentID.IsNull)
                WRK_WorkAssignedENT_String += "| StudentID = " + StudentID.Value.ToString();

            if (!DeadLine.IsNull)
                WRK_WorkAssignedENT_String += "| DeadLine = " + DeadLine.Value.ToString("dd-MM-yyyy");

            if (!WorkTobeDone.IsNull)
                WRK_WorkAssignedENT_String += "| WorkTobeDone = " + WorkTobeDone.Value;

            if (!SubmittedDate.IsNull)
                WRK_WorkAssignedENT_String += "| SubmittedDate = " + SubmittedDate.Value.ToString("dd-MM-yyyy");

            if (!FacultyRemarks.IsNull)
                WRK_WorkAssignedENT_String += "| FacultyRemarks = " + FacultyRemarks.Value;

            if (!InstituteID.IsNull)
                WRK_WorkAssignedENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Created.IsNull)
                WRK_WorkAssignedENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                WRK_WorkAssignedENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            WRK_WorkAssignedENT_String = WRK_WorkAssignedENT_String.Trim();

            return WRK_WorkAssignedENT_String;
        }

        #endregion ToString

    }

}