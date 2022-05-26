using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class PRJ_GuideBALBase
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

        public PRJ_GuideBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(PRJ_GuideENT entPRJ_Guide)
        {
            PRJ_GuideDAL dalPRJ_Guide = new PRJ_GuideDAL();
            if (dalPRJ_Guide.Insert(entPRJ_Guide))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_Guide.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(PRJ_GuideENT entPRJ_Guide)
        {
            PRJ_GuideDAL dalPRJ_Guide = new PRJ_GuideDAL();
            if (dalPRJ_Guide.Update(entPRJ_Guide))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_Guide.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 GuideID)
        {
            PRJ_GuideDAL dalPRJ_Guide = new PRJ_GuideDAL();
            if (dalPRJ_Guide.Delete(GuideID))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_Guide.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public PRJ_GuideENT SelectPK(SqlInt32 GuideID)
        {
            PRJ_GuideDAL dalPRJ_Guide = new PRJ_GuideDAL();
            return dalPRJ_Guide.SelectPK(GuideID);
        }
        public DataTable SelectView(SqlInt32 GuideID)
        {
            PRJ_GuideDAL dalPRJ_Guide = new PRJ_GuideDAL();
            return dalPRJ_Guide.SelectView(GuideID);
        }
        public DataTable SelectAll(SqlString LoginType, SqlInt32 DepartmentID, SqlInt32 InstituteID, SqlInt32 LoginID)
        {
            PRJ_GuideDAL dalPRJ_Guide = new PRJ_GuideDAL();
            return dalPRJ_Guide.SelectAll(LoginType, DepartmentID, InstituteID, LoginID);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            PRJ_GuideDAL dalPRJ_Guide = new PRJ_GuideDAL();
            return dalPRJ_Guide.SelectComboBox();
        }

        #endregion ComboBox
    }

}