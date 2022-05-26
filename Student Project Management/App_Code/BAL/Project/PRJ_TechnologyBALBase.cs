using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class PRJ_TechnologyBALBase
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

        public PRJ_TechnologyBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(PRJ_TechnologyENT entPRJ_Technology)
        {
            PRJ_TechnologyDAL dalPRJ_Technology = new PRJ_TechnologyDAL();
            if (dalPRJ_Technology.Insert(entPRJ_Technology))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_Technology.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(PRJ_TechnologyENT entPRJ_Technology)
        {
            PRJ_TechnologyDAL dalPRJ_Technology = new PRJ_TechnologyDAL();
            if (dalPRJ_Technology.Update(entPRJ_Technology))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_Technology.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 TechnologyID)
        {
            PRJ_TechnologyDAL dalPRJ_Technology = new PRJ_TechnologyDAL();
            if (dalPRJ_Technology.Delete(TechnologyID))
            {
                return true;
            }
            else
            {
                this.Message = dalPRJ_Technology.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public PRJ_TechnologyENT SelectPK(SqlInt32 TechnologyID)
        {
            PRJ_TechnologyDAL dalPRJ_Technology = new PRJ_TechnologyDAL();
            return dalPRJ_Technology.SelectPK(TechnologyID);
        }
        public DataTable SelectView(SqlInt32 TechnologyID)
        {
            PRJ_TechnologyDAL dalPRJ_Technology = new PRJ_TechnologyDAL();
            return dalPRJ_Technology.SelectView(TechnologyID);
        }
        public DataTable SelectAll()
        {
            PRJ_TechnologyDAL dalPRJ_Technology = new PRJ_TechnologyDAL();
            return dalPRJ_Technology.SelectAll();
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            PRJ_TechnologyDAL dalPRJ_Technology = new PRJ_TechnologyDAL();
            return dalPRJ_Technology.SelectComboBox();
        }

        #endregion ComboBox
    }

}