using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class SEC_AdminENTBase
    {
        #region Properties


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

        protected SqlInt32 _UserCatagoryID;
        public SqlInt32 UserCatagoryID
        {
            get
            {
                return _UserCatagoryID;
            }
            set
            {
                _UserCatagoryID = value;
            }
        }

        protected SqlString _AdminName;
        public SqlString AdminName
        {
            get
            {
                return _AdminName;
            }
            set
            {
                _AdminName = value;
            }
        }

        protected SqlString _AdminPassword;
        public SqlString AdminPassword
        {
            get
            {
                return _AdminPassword;
            }
            set
            {
                _AdminPassword = value;
            }
        }

        protected SqlInt32 _LoginID;
        public SqlInt32 LoginID
        {
            get
            {
                return _LoginID;
            }
            set
            {
                _LoginID = value;
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

        protected SqlBoolean _IsActive;
        public SqlBoolean IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
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

        public SEC_AdminENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String SEC_AdminENT_String = String.Empty;

            if (!UserID.IsNull)
                SEC_AdminENT_String += " UserID = " + UserID.Value.ToString();

            if (!AdminName.IsNull)
                SEC_AdminENT_String += "| AdminName = " + AdminName.Value;

            if (!IsActive.IsNull)
                SEC_AdminENT_String += "| IsActive = " + IsActive.Value;

            if (!Remarks.IsNull)
                SEC_AdminENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                SEC_AdminENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                SEC_AdminENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            SEC_AdminENT_String = SEC_AdminENT_String.Trim();

            return SEC_AdminENT_String;
        }

        #endregion ToString

    }

}