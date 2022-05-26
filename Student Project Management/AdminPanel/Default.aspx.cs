using System;
using System.Data;
using System.Web.UI;
using DProject.BAL;

public partial class AdminPanel_Default : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            Count();
            RepeaterFill();
        }
    }
    #endregion Page Load Event

    #region Count
    private void Count() 
    {
        DSB_DashboardBAL balDSB_Dashboard = new DSB_DashboardBAL();
        
        DataTable dtStudentCount = balDSB_Dashboard.StudentCount();
        if (dtStudentCount != null && dtStudentCount.Rows.Count > 0)
        {
            foreach (DataRow dr in dtStudentCount.Rows)
            {
                if (!dr["StudentCount"].Equals(DBNull.Value))
                {
                    lblStudents.Text = Convert.ToString(dr["StudentCount"]);
                }
            }
        }

        DataTable dtProjectCount = balDSB_Dashboard.ProjectCount();
        if (dtProjectCount != null && dtProjectCount.Rows.Count > 0)
        {
            foreach (DataRow dr in dtProjectCount.Rows)
            {
                if (!dr["ProjectCount"].Equals(DBNull.Value))
                {
                    lblProjects.Text = Convert.ToString(dr["ProjectCount"]);
                }
            }
        }
    }
    #endregion Count

    #region Repeater Fill Event
    private void RepeaterFill()
    {
        PRJ_TechnologyBAL balPRJ_Technology = new PRJ_TechnologyBAL();
        rptTechnology.DataSource = balPRJ_Technology.TechnologyWiseProjectCount();
        rptTechnology.DataBind();
    }
    #endregion Repeater Fill Event
}