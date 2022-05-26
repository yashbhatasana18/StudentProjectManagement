using System;
using System.Data.SqlTypes;

namespace DProject.ENT
{
    public abstract class MST_InstituteENTBase
    {
        #region Properties


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

        protected SqlString _InstituteName;
        public SqlString InstituteName
        {
            get
            {
                return _InstituteName;
            }
            set
            {
                _InstituteName = value;
            }
        }

        protected SqlString _InstituteShortName;
        public SqlString InstituteShortName
        {
            get
            {
                return _InstituteShortName;
            }
            set
            {
                _InstituteShortName = value;
            }
        }

        protected SqlString _Institutecode;
        public SqlString Institutecode
        {
            get
            {
                return _Institutecode;
            }
            set
            {
                _Institutecode = value;
            }
        }

        protected SqlString _InstitutePhone;
        public SqlString InstitutePhone
        {
            get
            {
                return _InstitutePhone;
            }
            set
            {
                _InstitutePhone = value;
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

        public MST_InstituteENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MST_InstituteENT_String = String.Empty;

            if (!InstituteID.IsNull)
                MST_InstituteENT_String += " InstituteID = " + InstituteID.Value.ToString();

            if (!InstituteName.IsNull)
                MST_InstituteENT_String += "| InstituteName = " + InstituteName.Value;

            if (!Institutecode.IsNull)
                MST_InstituteENT_String += "| Institutecode = " + Institutecode.Value;

            if (!InstitutePhone.IsNull)
                MST_InstituteENT_String += "| InstitutePhone = " + InstitutePhone.Value;

            if (!Mobile.IsNull)
                MST_InstituteENT_String += "| Mobile = " + Mobile.Value;

            if (!Address.IsNull)
                MST_InstituteENT_String += "| Address = " + Address.Value;

            if (!CityID.IsNull)
                MST_InstituteENT_String += "| CityID = " + CityID.Value.ToString();

            if (!Pincode.IsNull)
                MST_InstituteENT_String += "| Pincode = " + Pincode.Value;

            if (!Email.IsNull)
                MST_InstituteENT_String += "| Email = " + Email.Value;

            if (!Website.IsNull)
                MST_InstituteENT_String += "| Website = " + Website.Value;

            if (!Remarks.IsNull)
                MST_InstituteENT_String += "| Remarks = " + Remarks.Value;

            if (!Created.IsNull)
                MST_InstituteENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MST_InstituteENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            MST_InstituteENT_String = MST_InstituteENT_String.Trim();

            return MST_InstituteENT_String;
        }

        #endregion ToString

    }

}