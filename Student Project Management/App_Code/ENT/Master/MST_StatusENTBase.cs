using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class MST_StatusENTBase
    {
        #region Properties


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

        protected SqlString _StatusName;
        public SqlString StatusName
        {
            get
            {
                return _StatusName;
            }
            set
            {
                _StatusName = value;
            }
        }

        protected SqlBoolean _IsWaitingforStudent;
        public SqlBoolean IsWaitingforStudent
        {
            get
            {
                return _IsWaitingforStudent;
            }
            set
            {
                _IsWaitingforStudent = value;
            }
        }

        protected SqlBoolean _IsWaitingforGuide;
        public SqlBoolean IsWaitingforGuide
        {
            get
            {
                return _IsWaitingforGuide;
            }
            set
            {
                _IsWaitingforGuide = value;
            }
        }

        protected SqlDecimal _SequenceNo;
        public SqlDecimal SequenceNo
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

        protected SqlInt32 _PreviousStatusID;
        public SqlInt32 PreviousStatusID
        {
            get
            {
                return _PreviousStatusID;
            }
            set
            {
                _PreviousStatusID = value;
            }
        }

        protected SqlInt32 _NextStatusID;
        public SqlInt32 NextStatusID
        {
            get
            {
                return _NextStatusID;
            }
            set
            {
                _NextStatusID = value;
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

        public MST_StatusENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MST_StatusENT_String = String.Empty;

            if (!StatusID.IsNull)
                MST_StatusENT_String += " StatusID = " + StatusID.Value.ToString();

            if (!StatusName.IsNull)
                MST_StatusENT_String += "| StatusName = " + StatusName.Value;

            if (!IsWaitingforStudent.IsNull)
                MST_StatusENT_String += "| IsWaitingforStudent = " + IsWaitingforStudent.Value;

            if (!IsWaitingforGuide.IsNull)
                MST_StatusENT_String += "| IsWaitingforGuide = " + IsWaitingforGuide.Value;

            if (!SequenceNo.IsNull)
                MST_StatusENT_String += "| SequenceNo = " + SequenceNo.Value.ToString();

            if (!PreviousStatusID.IsNull)
                MST_StatusENT_String += "| PreviousStatusID = " + PreviousStatusID.Value.ToString();

            if (!NextStatusID.IsNull)
                MST_StatusENT_String += "| NextStatusID = " + NextStatusID.Value.ToString();

            if (!UserID.IsNull)
                MST_StatusENT_String += "| UserID = " + UserID.Value.ToString();

            if (!Created.IsNull)
                MST_StatusENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MST_StatusENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            MST_StatusENT_String = MST_StatusENT_String.Trim();

            return MST_StatusENT_String;
        }

        #endregion ToString

    }

}