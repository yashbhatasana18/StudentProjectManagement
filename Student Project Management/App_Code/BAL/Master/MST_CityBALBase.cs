using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class MST_CityBALBase
    {
        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Public Properties

        #region Constructor

        public MST_CityBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_CityENT entMST_City)
        {
            MST_CityDAL dalMST_City = new MST_CityDAL();
            if (dalMST_City.Insert(entMST_City))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_City.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_CityENT entMST_City)
        {
            MST_CityDAL dalMST_City = new MST_CityDAL();
            if (dalMST_City.Update(entMST_City))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_City.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 CityID)
        {
            MST_CityDAL dalMST_City = new MST_CityDAL();
            if (dalMST_City.Delete(CityID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_City.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MST_CityENT SelectPK(SqlInt32 CityID)
        {
            MST_CityDAL dalMST_City = new MST_CityDAL();
            return dalMST_City.SelectPK(CityID);
        }
        public DataTable SelectView(SqlInt32 CityID)
        {
            MST_CityDAL dalMST_City = new MST_CityDAL();
            return dalMST_City.SelectView(CityID);
        }
        public DataTable SelectAll(SqlString LoginType)
        {
            MST_CityDAL dalMST_City = new MST_CityDAL();
            return dalMST_City.SelectAll(LoginType);
        }
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString CityName)
        {
            MST_CityDAL dalMST_City = new MST_CityDAL();
            return dalMST_City.SelectPage(PageOffset, PageSize, out TotalRecords, CityName);
        }
        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            MST_CityDAL dalMST_City = new MST_CityDAL();
            return dalMST_City.SelectComboBox();
        }

        #endregion ComboBox
    }
}