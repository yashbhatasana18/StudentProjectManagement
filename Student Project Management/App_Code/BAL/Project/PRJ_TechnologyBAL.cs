using DProject.DAL;
using System.Data;

namespace DProject.BAL
{
    public class PRJ_TechnologyBAL : PRJ_TechnologyBALBase
    {
        public DataTable TechnologyWiseProjectCount()
        {
            PRJ_TechnologyDAL dalPRJ_Technology = new PRJ_TechnologyDAL();
            return dalPRJ_Technology.TechnologyWiseProjectCount();
        }
    }

}