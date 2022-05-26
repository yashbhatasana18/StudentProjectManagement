using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class MET_MeetingWiseStudentENTBase
    {
        #region Properties


        protected SqlInt32 _MeetingWiseStudentID;
        public SqlInt32 MeetingWiseStudentID
        {
            get
            {
                return _MeetingWiseStudentID;
            }
            set
            {
                _MeetingWiseStudentID = value;
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

        public MET_MeetingWiseStudentENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MET_MeetingWiseStudentENT_String = String.Empty;

            if (!MeetingWiseStudentID.IsNull)
                MET_MeetingWiseStudentENT_String += " MeetingWiseStudentID = " + MeetingWiseStudentID.Value.ToString();

            if (!MeetingID.IsNull)
                MET_MeetingWiseStudentENT_String += "| MeetingID = " + MeetingID.Value.ToString();

            if (!StudentID.IsNull)
                MET_MeetingWiseStudentENT_String += "| StudentID = " + StudentID.Value.ToString();

            if (!FacultyRemarks.IsNull)
                MET_MeetingWiseStudentENT_String += "| FacultyRemarks = " + FacultyRemarks.Value;

            if (!Created.IsNull)
                MET_MeetingWiseStudentENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MET_MeetingWiseStudentENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            MET_MeetingWiseStudentENT_String = MET_MeetingWiseStudentENT_String.Trim();

            return MET_MeetingWiseStudentENT_String;
        }

        #endregion ToString

    }
}