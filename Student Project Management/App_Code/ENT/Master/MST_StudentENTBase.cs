using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class MST_StudentENTBase
    {
        #region Properties


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

        protected SqlString _StudentName;
        public SqlString StudentName
        {
            get
            {
                return _StudentName;
            }
            set
            {
                _StudentName = value;
            }
        }

        protected SqlString _EnrollmentNo;
        public SqlString EnrollmentNo
        {
            get
            {
                return _EnrollmentNo;
            }
            set
            {
                _EnrollmentNo = value;
            }
        }

        protected SqlString _Email;
        public SqlString Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        protected SqlDateTime _DOB;
        public SqlDateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
            }
        }

        protected SqlString _SignaturePath;
        public SqlString SignaturePath
        {
            get
            {
                return _SignaturePath;
            }
            set
            {
                _SignaturePath = value;
            }
        }

        protected SqlString _Mobile;
        public SqlString Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                _Mobile = value;
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

        public MST_StudentENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MST_StudentENT_String = String.Empty;

            if (!StudentID.IsNull)
                MST_StudentENT_String += " StudentID = " + StudentID.Value.ToString();

            if (!StudentName.IsNull)
                MST_StudentENT_String += "| StudentName = " + StudentName.Value;

            if (!EnrollmentNo.IsNull)
                MST_StudentENT_String += "| EnrollmentNo = " + EnrollmentNo.Value;

            if (!Email.IsNull)
                MST_StudentENT_String += "| Email = " + Email.Value;

            if (!DOB.IsNull)
                MST_StudentENT_String += "| DOB = " + DOB.Value.ToString("dd-MM-yyyy");

            if (!SignaturePath.IsNull)
                MST_StudentENT_String += "| SignaturePath = " + SignaturePath.Value;

            if (!Mobile.IsNull)
                MST_StudentENT_String += "| Mobile = " + Mobile.Value;

            if (!DepartmentID.IsNull)
                MST_StudentENT_String += "| DepartmentID = " + DepartmentID.Value.ToString();

            if (!InstituteID.IsNull)
                MST_StudentENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Remarks.IsNull)
                MST_StudentENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                MST_StudentENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MST_StudentENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            MST_StudentENT_String = MST_StudentENT_String.Trim();

            return MST_StudentENT_String;
        }

        #endregion ToString

    }

}