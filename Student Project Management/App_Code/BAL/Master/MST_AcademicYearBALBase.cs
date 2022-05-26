using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class MST_AcademicYearBALBase
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

        public MST_AcademicYearBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_AcademicYearENT entMST_AcademicYear)
        {
            MST_AcademicYearDAL dalMST_AcademicYear = new MST_AcademicYearDAL();
            if (dalMST_AcademicYear.Insert(entMST_AcademicYear))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_AcademicYear.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_AcademicYearENT entMST_AcademicYear)
        {
            MST_AcademicYearDAL dalMST_AcademicYear = new MST_AcademicYearDAL();
            if (dalMST_AcademicYear.Update(entMST_AcademicYear))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_AcademicYear.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 AcademicYearID)
        {
            MST_AcademicYearDAL dalMST_AcademicYear = new MST_AcademicYearDAL();
            if (dalMST_AcademicYear.Delete(AcademicYearID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_AcademicYear.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MST_AcademicYearENT SelectPK(SqlInt32 AcademicYearID)
        {
            MST_AcademicYearDAL dalMST_AcademicYear = new MST_AcademicYearDAL();
            return dalMST_AcademicYear.SelectPK(AcademicYearID);
        }
        public DataTable SelectView(SqlInt32 AcademicYearID)
        {
            MST_AcademicYearDAL dalMST_AcademicYear = new MST_AcademicYearDAL();
            return dalMST_AcademicYear.SelectView(AcademicYearID);
        }
        public DataTable SelectAll(SqlString LoginType, SqlInt32 InstituteID)
        {
            MST_AcademicYearDAL dalMST_AcademicYear = new MST_AcademicYearDAL();
            return dalMST_AcademicYear.SelectAll(LoginType, InstituteID);
        }
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString AcademicYearName)
        {
            MST_AcademicYearDAL dalMST_AcademicYear = new MST_AcademicYearDAL();
            return dalMST_AcademicYear.SelectPage(PageOffset, PageSize, out TotalRecords, AcademicYearName);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            MST_AcademicYearDAL dalMST_AcademicYear = new MST_AcademicYearDAL();
            return dalMST_AcademicYear.SelectComboBox();
        }

        #endregion ComboBox
    }

}