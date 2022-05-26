using System;
using System.Web.UI;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Data.SqlTypes;
using DProject.BAL;

public partial class AdminPanel_LOCRPT_Meeting_RPT_MET_DateWiseMeeting : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtDateWiseMeeting;

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

    }

    #endregion Fill DropDownList

    #region ShowReport

    protected void ShowReport()
    {
        MET_MeetingMasterBAL balMET_Meeting = new MET_MeetingMasterBAL();
        if (txtCal.Text != String.Empty)
            dtDateWiseMeeting = balMET_Meeting.SelectAllDateWiseMeeting(Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["AcademicYearID"]), Convert.ToDateTime(txtCal.Text));
        else
            dtDateWiseMeeting = balMET_Meeting.SelectAllDateWiseMeeting(Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["AcademicYearID"]), SqlDateTime.Null);
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtDateWiseMeeting.Rows)
        {
            dsProject.dtDateWiseMeetingRow drDateWiseMeeting = objdsProject.dtDateWiseMeeting.NewdtDateWiseMeetingRow();

            if (!dr["MeetingID"].Equals(System.DBNull.Value))
                drDateWiseMeeting.MeetingID = Convert.ToInt32(dr["MeetingID"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drDateWiseMeeting.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["MeetingDate"].Equals(System.DBNull.Value))
                drDateWiseMeeting.MeetingDate = Convert.ToDateTime(dr["MeetingDate"]);

            if (!dr["NextMeetingDate"].Equals(System.DBNull.Value))
                drDateWiseMeeting.NextMeetingDate = Convert.ToDateTime(dr["NextMeetingDate"]);

            if (!dr["WorkDone"].Equals(System.DBNull.Value))
                drDateWiseMeeting.WorkDone = Convert.ToString(dr["WorkDone"]);

            if (!dr["WorkAssigned"].Equals(System.DBNull.Value))
                drDateWiseMeeting.WorkAssigned = Convert.ToString(dr["WorkAssigned"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drDateWiseMeeting.StudentName = Convert.ToString(dr["StudentName"]);

            objdsProject.dtDateWiseMeeting.Rows.Add(drDateWiseMeeting);
        }

        SetReportParameters();
        this.rvDateWiseMeeting.LocalReport.DataSources.Clear();
        this.rvDateWiseMeeting.LocalReport.DataSources.Add(new ReportDataSource("dtDateWiseMeeting", (DataTable)objdsProject.dtDateWiseMeeting));

    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String ReportTitle = "Date Wise Meeting";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();

        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvDateWiseMeeting.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptDepartment, rptSemester, rptAcademicYear });
    }

    #endregion SetReportParameters
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ShowReport();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        txtCal.Text = "";
        ShowReport();
    }
}