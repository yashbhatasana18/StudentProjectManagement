using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class MST_CityENTBase
    {
        #region Properties


        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }

        protected SqlString _CityName;
        public SqlString CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                _CityName = value;
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

        public MST_CityENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MST_CityENT_String = String.Empty;

            if (!CityID.IsNull)
                MST_CityENT_String += " CityID = " + CityID.Value.ToString();

            if (!CityName.IsNull)
                MST_CityENT_String += "| CityName = " + CityName.Value;

            if (!Remarks.IsNull)
                MST_CityENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                MST_CityENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MST_CityENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            MST_CityENT_String = MST_CityENT_String.Trim();

            return MST_CityENT_String;
        }

        #endregion ToString

    }

}