using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class PRJ_AssignProjectENTBase
    {
        #region Properties


        protected SqlInt32 _ProjectWiseStudentID;
        public SqlInt32 ProjectWiseStudentID
        {
            get
            {
                return _ProjectWiseStudentID;
            }
            set
            {
                _ProjectWiseStudentID = value;
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

        protected SqlBoolean _IsLeader;
        public SqlBoolean IsLeader
        {
            get
            {
                return _IsLeader;
            }
            set
            {
                _IsLeader = value;
            }
        }

        protected SqlInt32 _SequenceNo;
        public SqlInt32 SequenceNo
        {
            get
            {
                return _SequenceNo;
            }
            set
            {
                _SequenceNo = value;
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

        public PRJ_AssignProjectENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String PRJ_AssignProjectENTBase_String = String.Empty;

            if (!ProjectWiseStudentID.IsNull)
                PRJ_AssignProjectENTBase_String += " ProjectWiseStudentID = " + ProjectWiseStudentID.Value.ToString();

            if (!ProjectID.IsNull)
                PRJ_AssignProjectENTBase_String += "| ProjectID = " + ProjectID.Value.ToString();

            if (!StudentID.IsNull)
                PRJ_AssignProjectENTBase_String += "| StudentID = " + StudentID.Value.ToString();

            if (!IsLeader.IsNull)
                PRJ_AssignProjectENTBase_String += "| IsLeader = " + IsLeader.Value;

            if (!SequenceNo.IsNull)
                PRJ_AssignProjectENTBase_String += "| SequenceNo = " + SequenceNo.Value.ToString();

            if (!InstituteID.IsNull)
                PRJ_AssignProjectENTBase_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Remarks.IsNull)
                PRJ_AssignProjectENTBase_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                PRJ_AssignProjectENTBase_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                PRJ_AssignProjectENTBase_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            PRJ_AssignProjectENTBase_String = PRJ_AssignProjectENTBase_String.Trim();

            return PRJ_AssignProjectENTBase_String;
        }

        #endregion ToString

    }

}