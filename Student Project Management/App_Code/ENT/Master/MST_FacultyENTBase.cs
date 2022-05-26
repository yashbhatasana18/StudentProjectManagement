using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class MST_FacultyENTBase
    {
        #region Properties


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

        protected SqlString _FacultyName;
        public SqlString FacultyName
        {
            get
            {
                return _FacultyName;
            }
            set
            {
                _FacultyName = value;
            }
        }

        protected SqlString _FacultyShortName;
        public SqlString FacultyShortName
        {
            get
            {
                return _FacultyShortName;
            }
            set
            {
                _FacultyShortName = value;
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

        protected SqlString _Address;
        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

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

        protected SqlString _Pincode;
        public SqlString Pincode
        {
            get
            {
                return _Pincode;
            }
            set
            {
                _Pincode = value;
            }
        }

        protected SqlString _Phone;
        public SqlString Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
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

        protected SqlString _Website;
        public SqlString Website
        {
            get
            {
                return _Website;
            }
            set
            {
                _Website = value;
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

        public MST_FacultyENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MST_FacultyENT_String = String.Empty;

            if (!FacultyID.IsNull)
                MST_FacultyENT_String += " FacultyID = " + FacultyID.Value.ToString();

            if (!FacultyName.IsNull)
                MST_FacultyENT_String += "| FacultyName = " + FacultyName.Value;

            if (!DepartmentID.IsNull)
                MST_FacultyENT_String += "| DepartmentID = " + DepartmentID.Value.ToString();

            if (!Address.IsNull)
                MST_FacultyENT_String += "| Address = " + Address.Value;

            if (!CityID.IsNull)
                MST_FacultyENT_String += "| CityID = " + CityID.Value.ToString();

            if (!Pincode.IsNull)
                MST_FacultyENT_String += "| Pincode = " + Pincode.Value;

            if (!Phone.IsNull)
                MST_FacultyENT_String += "| Phone = " + Phone.Value;

            if (!Mobile.IsNull)
                MST_FacultyENT_String += "| Mobile = " + Mobile.Value;

            if (!Email.IsNull)
                MST_FacultyENT_String += "| Email = " + Email.Value;

            if (!Website.IsNull)
                MST_FacultyENT_String += "| Website = " + Website.Value;

            if (!InstituteID.IsNull)
                MST_FacultyENT_String += "| InstituteID = " + InstituteID.Value.ToString();

            if (!Remarks.IsNull)
                MST_FacultyENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                MST_FacultyENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MST_FacultyENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            MST_FacultyENT_String = MST_FacultyENT_String.Trim();

            return MST_FacultyENT_String;
        }

        #endregion ToString

    }

}