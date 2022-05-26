using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public abstract class WRK_WeeklyWorkdoneBALBase
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

        public WRK_WeeklyWorkdoneBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(WRK_WeeklyWorkdoneENT entWRK_WeeklyWorkdone)
        {
            WRK_WeeklyWorkdoneDAL dalWRK_WeeklyWorkdone = new WRK_WeeklyWorkdoneDAL();
            if (dalWRK_WeeklyWorkdone.Insert(entWRK_WeeklyWorkdone))
            {
                return true;
            }
            else
            {
                this.Message = dalWRK_WeeklyWorkdone.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(WRK_WeeklyWorkdoneENT entWRK_WeeklyWorkdone)
        {
            WRK_WeeklyWorkdoneDAL dalWRK_WeeklyWorkdone = new WRK_WeeklyWorkdoneDAL();
            if (dalWRK_WeeklyWorkdone.Update(entWRK_WeeklyWorkdone))
            {
                return true;
            }
            else
            {
                this.Message = dalWRK_WeeklyWorkdone.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 WorkdoneID)
        {
            WRK_WeeklyWorkdoneDAL dalWRK_WeeklyWorkdone = new WRK_WeeklyWorkdoneDAL();
            if (dalWRK_WeeklyWorkdone.Delete(WorkdoneID))
            {
                return true;
            }
            else
            {
                this.Message = dalWRK_WeeklyWorkdone.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public WRK_WeeklyWorkdoneENT SelectPK(SqlInt32 WorkdoneID)
        {
            WRK_WeeklyWorkdoneDAL dalWRK_WeeklyWorkdone = new WRK_WeeklyWorkdoneDAL();
            return dalWRK_WeeklyWorkdone.SelectPK(WorkdoneID);
        }
        public DataTable SelectView(SqlInt32 WorkdoneID)
        {
            WRK_WeeklyWorkdoneDAL dalWRK_WeeklyWorkdone = new WRK_WeeklyWorkdoneDAL();
            return dalWRK_WeeklyWorkdone.SelectView(WorkdoneID);
        }
        public DataTable SelectAll()
        {
            WRK_WeeklyWorkdoneDAL dalWRK_WeeklyWorkdone = new WRK_WeeklyWorkdoneDAL();
            return dalWRK_WeeklyWorkdone.SelectAll();
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            WRK_WeeklyWorkdoneDAL dalWRK_WeeklyWorkdone = new WRK_WeeklyWorkdoneDAL();
            return dalWRK_WeeklyWorkdone.SelectComboBox();
        }

        #endregion ComboBox
    }

}