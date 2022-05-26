using System;
using System.Web.UI;
using System.Data;
using DProject;
using Microsoft.Reporting.WebForms;
using DProject.BAL;

public partial class AdminPanel_LOCRPT_Meeting_RPT_MET_ProjectWiseMeeting : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectWiseMeeting;

    private dsProject objdsProject = new dsProject();

    #endregion Private Variables

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }

        if (!Page.IsPostBack)
        {
            FillDropDownList();
            ShowReport();
        }
    }

    #endregion Page Load Event

    #region Fill DropDownList

    protected void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListProjectID(ddlProjectID, Convert.ToInt32(Session["InstituteID"]), Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["AcademicYearID"]));
    }

    #endregion Fill DropDownList

    #region ShowReport

    protected void ShowReport()
    {
        MET_MeetingMasterBAL balMeetingMaster = new MET_MeetingMasterBAL();

        dtProjectWiseMeeting = balMeetingMaster.SelectAllProjectWiseMeeting(Convert.ToString(Session["UserCatagory"]),Convert.ToInt32(Session["LoginID"]),Convert.ToInt32(Session["InstituteID"]),Convert.ToInt32(Session["DepartmentID"]),Convert.ToInt32(Session["AcademicYearID"]),Convert.ToInt32(ddlProjectID.SelectedValue));
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtProjectWiseMeeting.Rows)
        {
            dsProject.dtProjectWiseMeetingRow drProjectWiseMeeting = objdsProject.dtProjectWiseMeeting.NewdtProjectWiseMeetingRow();

            if (!dr["MeetingID"].Equals(System.DBNull.Value))
                drProjectWiseMeeting.MeetingID = Convert.ToInt32(dr["MeetingID"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectWiseMeeting.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["MeetingDate"].Equals(System.DBNull.Value))
                drProjectWiseMeeting.MeetingDate = Convert.ToDateTime(dr["MeetingDate"]);

            if (!dr["NextMeetingDate"].Equals(System.DBNull.Value))
                drProjectWiseMeeting.NextMeetingDate = Convert.ToDateTime(dr["NextMeetingDate"]);

            if (!dr["WorkDone"].Equals(System.DBNull.Value))
                drProjectWiseMeeting.WorkDone = Convert.ToString(dr["WorkDone"]);

            if (!dr["WorkAssigned"].Equals(System.DBNull.Value))
                drProjectWiseMeeting.WorkAssigned = Convert.ToString(dr["WorkAssigned"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drProjectWiseMeeting.StudentName = Convert.ToString(dr["StudentName"]);

            objdsProject.dtProjectWiseMeeting.Rows.Add(drProjectWiseMeeting);
        }

        SetReportParameters();
        this.rvProjectWiseMeeting.LocalReport.DataSources.Clear();
        this.rvProjectWiseMeeting.LocalReport.DataSources.Add(new ReportDataSource("dtProjectWiseMeeting", (DataTable)objdsProject.dtProjectWiseMeeting));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        this.rvProjectWiseMeeting.LocalReport.EnableExternalImages = true;
        String ReportTitle = "Project Wise Meeting";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();
        
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvProjectWiseMeeting.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptDepartment, rptSemester, rptAcademicYear});
    }

    #endregion SetReportParameters

    #region ddlProject Selected Index Changed

    protected void ddlProjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowReport();
    }

    #endregion ddlProject Selected Index Changed
}