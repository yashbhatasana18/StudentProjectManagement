using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class PRJ_TechnologyENTBase
    {
        #region Properties


        protected SqlInt32 _TechnologyID;
        public SqlInt32 TechnologyID
        {
            get
            {
                return _TechnologyID;
            }
            set
            {
                _TechnologyID = value;
            }
        }

        protected SqlString _TechnologyName;
        public SqlString TechnologyName
        {
            get
            {
                return _TechnologyName;
            }
            set
            {
                _TechnologyName = value;
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

        public PRJ_TechnologyENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String PRJ_TechnologyENT_String = String.Empty;

            if (!TechnologyID.IsNull)
                PRJ_TechnologyENT_String += " TechnologyID = " + TechnologyID.Value.ToString();

            if (!TechnologyName.IsNull)
                PRJ_TechnologyENT_String += "| TechnologyName = " + TechnologyName.Value;

            if (!DepartmentID.IsNull)
                PRJ_TechnologyENT_String += "| DepartmentID = " + DepartmentID.Value.ToString();

            if (!InstituteID.IsNull)
                PRJ_TechnologyENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Remarks.IsNull)
                PRJ_TechnologyENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                PRJ_TechnologyENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                PRJ_TechnologyENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            PRJ_TechnologyENT_String = PRJ_TechnologyENT_String.Trim();

            return PRJ_TechnologyENT_String;
        }

        #endregion ToString

    }

}