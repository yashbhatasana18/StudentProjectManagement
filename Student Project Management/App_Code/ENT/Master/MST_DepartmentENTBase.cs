using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class MST_DepartmentENTBase
    {
        #region Properties


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

        protected SqlString _DepartmentName;
        public SqlString DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }

        protected SqlString _DepartmentCode;
        public SqlString DepartmentCode
        {
            get
            {
                return _DepartmentCode;
            }
            set
            {
                _DepartmentCode = value;
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

        public MST_DepartmentENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MST_DepartmentENT_String = String.Empty;

            if (!DepartmentID.IsNull)
                MST_DepartmentENT_String += " DepartmentID = " + DepartmentID.Value.ToString();

            if (!DepartmentName.IsNull)
                MST_DepartmentENT_String += "| DepartmentName = " + DepartmentName.Value;

            if (!InstituteID.IsNull)
                MST_DepartmentENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Remarks.IsNull)
                MST_DepartmentENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                MST_DepartmentENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MST_DepartmentENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            MST_DepartmentENT_String = MST_DepartmentENT_String.Trim();

            return MST_DepartmentENT_String;
        }

        #endregion ToString

    }

}