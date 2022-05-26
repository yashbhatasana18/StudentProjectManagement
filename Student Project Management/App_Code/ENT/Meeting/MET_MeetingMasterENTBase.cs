using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class MET_MeetingMasterENTBase
    {
        #region Properties


        protected SqlInt32 _MeetingID;
        public SqlInt32 MeetingID
        {
            get
            {
                return _MeetingID;
            }
            set
            {
                _MeetingID = value;
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

        protected SqlDateTime _MeetingDate;
        public SqlDateTime MeetingDate
        {
            get
            {
                return _MeetingDate;
            }
            set
            {
                _MeetingDate = value;
            }
        }

        protected SqlDateTime _NextMeetingDate;
        public SqlDateTime NextMeetingDate
        {
            get
            {
                return _NextMeetingDate;
            }
            set
            {
                _NextMeetingDate = value;
            }
        }

        protected SqlString _WorkDone;
        public SqlString WorkDone
        {
            get
            {
                return _WorkDone;
            }
            set
            {
                _WorkDone = value;
            }
        }

        protected SqlString _WorkAssigned;
        public SqlString WorkAssigned
        {
            get
            {
                return _WorkAssigned;
            }
            set
            {
                _WorkAssigned = value;
            }
        }

        protected SqlDecimal _MeetingDuration;
        public SqlDecimal MeetingDuration
        {
            get
            {
                return _MeetingDuration;
            }
            set
            {
                _MeetingDuration = value;
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

        public MET_MeetingMasterENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MET_MeetingMasterENT_String = String.Empty;

            if (!MeetingID.IsNull)
                MET_MeetingMasterENT_String += " MeetingID = " + MeetingID.Value.ToString();

            if (!StudentID.IsNull)
                MET_MeetingMasterENT_String += "| ProjectID = " + StudentID.Value.ToString();

            if (!MeetingDate.IsNull)
                MET_MeetingMasterENT_String += "| MeetingDate = " + MeetingDate.Value.ToString("dd-MM-yyyy");

            if (!NextMeetingDate.IsNull)
                MET_MeetingMasterENT_String += "| NextMeetingDate = " + NextMeetingDate.Value.ToString("dd-MM-yyyy");

            if (!WorkDone.IsNull)
                MET_MeetingMasterENT_String += "| WorkDone = " + WorkDone.Value;

            if (!WorkAssigned.IsNull)
                MET_MeetingMasterENT_String += "| WorkAssigned = " + WorkAssigned.Value;

            if (!MeetingDuration.IsNull)
                MET_MeetingMasterENT_String += "| MeetingDuration = " + MeetingDuration.Value.ToString();

            if (!FacultyRemarks.IsNull)
                MET_MeetingMasterENT_String += "| FacultyRemarks = " + FacultyRemarks.Value;

            if (!FacultyID.IsNull)
                MET_MeetingMasterENT_String += "| FacultyID = " + FacultyID.Value.ToString();

            if (!InstituteID.IsNull)
                MET_MeetingMasterENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Created.IsNull)
                MET_MeetingMasterENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MET_MeetingMasterENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            MET_MeetingMasterENT_String = MET_MeetingMasterENT_String.Trim();

            return MET_MeetingMasterENT_String;
        }

        #endregion ToString

    }
}