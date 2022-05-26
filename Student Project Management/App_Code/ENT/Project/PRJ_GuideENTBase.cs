using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class PRJ_GuideENTBase
    {
        #region Properties
        protected SqlInt32 _GuideID;
        public SqlInt32 GuideID
        {
            get
            {
                return _GuideID;
            }
            set
            {
                _GuideID = value;
            }
        }

        protected SqlString _GuideName;
        public SqlString GuideName
        {
            get
            {
                return _GuideName;
            }
            set
            {
                _GuideName = value;
            }
        }

        protected SqlString _GuideShortName;
        public SqlString GuideShortName
        {
            get
            {
                return _GuideShortName;
            }
            set
            {
                _GuideShortName = value;
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

        #endregion Properties

        #region Constructor

        public PRJ_GuideENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String PRJ_GuideENT_String = String.Empty;

            if (!GuideID.IsNull)
                PRJ_GuideENT_String += " GuideID = " + GuideID.Value.ToString();

            if (!GuideName.IsNull)
                PRJ_GuideENT_String += " GuideName = " + GuideName.Value;

            if (!GuideShortName.IsNull)
                PRJ_GuideENT_String += " GuideShortName = " + GuideShortName.Value;

            if (!IsActive.IsNull)
                PRJ_GuideENT_String += "| IsActive = " + IsActive.Value;

            if (!DepartmentID.IsNull)
                PRJ_GuideENT_String += "| DepartmentID = " + DepartmentID.Value.ToString();

            if (!Remarks.IsNull)
                PRJ_GuideENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                PRJ_GuideENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                PRJ_GuideENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");

            PRJ_GuideENT_String = PRJ_GuideENT_String.Trim();

            return PRJ_GuideENT_String;
        }

        #endregion ToString

    }

}