using DProject.DAL;
using System.Data;

namespace DProject.BAL
{
    public abstract class DSB_DashboardBALBase
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

        public DSB_DashboardBALBase()
        {

        }

        #endregion Constructor

        #region Student Count
        public DataTable StudentCount()
        {
            DSB_DashboardDAL dalDSB_Dashboard = new DSB_DashboardDAL();
            return dalDSB_Dashboard.StudentCount();
        }
        #endregion Student Count

        #region Project Count
        public DataTable ProjectCount()
        {
            DSB_DashboardDAL dalDSB_Dashboard = new DSB_DashboardDAL();
            return dalDSB_Dashboard.ProjectCount();
        }
        #endregion Project Count
    }
}