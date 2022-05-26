using System;
using System.Web.UI;
using System.Data;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_WeeklyWork_RPT_WRK_WeeklyWork : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtWeeklyWorkDone;

    private dsProject objdsProject = new dsProject();

    #endregion Private Variables

    #region LoadEvent

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["WorkDoneID"] != null)
            {
                ShowProjectStatement(Convert.ToInt32(Request.QueryString["WorkDoneID"]));
            }
        }
    }

    #endregion LoadEvent

    #region ShowProjectStatement

    private void ShowProjectStatement(Int32 WorkDoneID)
    {
        WRK_WeeklyWorkdoneBAL balWRK_WeeklyWorkdone = new WRK_WeeklyWorkdoneBAL();
        dtWeeklyWorkDone = balWRK_WeeklyWorkdone.SelectWeeklyWorkDone(WorkDoneID, Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["AcademicYearID"]));
        FillDataSet();
    }

    #endregion ShowProjectStatement

    #region FillDataSet

    private void FillDataSet()
    {
        objdsProject.dtWeeklyWorkDone.Clear();

        foreach (DataRow dr in dtWeeklyWorkDone.Rows)
        {
            dsProject.dtWeeklyWorkDoneRow drWeeklyWorkDone = objdsProject.dtWeeklyWorkDone.NewdtWeeklyWorkDoneRow();

            if (!dr["WorkdoneID"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.WorkdoneID = Convert.ToInt32(dr["WorkdoneID"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["GTUTeamNo"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.GTUTeamNo = Convert.ToString(dr["GTUTeamNo"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.StudentName = Convert.ToString(dr["StudentName"]);

            if (!dr["WorkDone"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.WorkDone = Convert.ToString(dr["WorkDone"]);

            if (!dr["EntryDate"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

            if (!dr["FromDate"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.FromDate = Convert.ToDateTime(dr["FromDate"]);

            if (!dr["ToDate"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.Todate = Convert.ToDateTime(dr["ToDate"]);

            if (!dr["WeeklyWork"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.WeeklyWork = Convert.ToString(dr["WeeklyWork"]);

            if (!dr["FacultyRemarks"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.FacultyRemarks = Convert.ToString(dr["FacultyRemarks"]);

            if (!dr["InstituteName"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.InstituteName = Convert.ToString(dr["InstituteName"]);

            if (!dr["DepartmentName"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.DepartmentName = Convert.ToString(dr["DepartmentName"]);

            if (!dr["AcademicYearName"].Equals(System.DBNull.Value))
                drWeeklyWorkDone.AcademicYearName = Convert.ToString(dr["AcademicYearName"]);

            objdsProject.dtWeeklyWorkDone.Rows.Add(drWeeklyWorkDone);
        }
        

        this.rvWeeklyWorkDone.LocalReport.DataSources.Clear();
        this.rvWeeklyWorkDone.LocalReport.DataSources.Add(new ReportDataSource("dtWeeklyWorkDone", (DataTable)objdsProject.dtWeeklyWorkDone));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
    }

    #endregion SetReportParameters
}