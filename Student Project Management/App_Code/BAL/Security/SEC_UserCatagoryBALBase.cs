using DProject.DAL;
using System.Data;

namespace DProject.BAL
{
    public abstract class SEC_UserCatagoryBALBase
    {
        #region Constructor

        /* public SEC_UserCatagoryBALBase()
         {

         }
         */
        #endregion Constructor

        #region ComboBox

        public DataTable SelectComboBox()
        {
            SEC_UserCatagoryDAL dalSEC_UserCatagory = new SEC_UserCatagoryDAL();
            return dalSEC_UserCatagory.SelectComboBox();
        }

        #endregion ComboBox
    }
}
