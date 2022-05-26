using System;
using System.Web.UI;
using System.Data;
using DProject;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_WorkAssigned_RPT_WRKA_WorkAssigedListByProject : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtWorkAssignedListByProject;

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
        WRK_WorkAssignedBAL balWRK_WorkAssigned = new WRK_WorkAssignedBAL();

        dtWorkAssignedListByProject = balWRK_WorkAssigned.SelectAllWorkAssignedByProject(Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["AcademicYearID"]), Convert.ToInt32(ddlProjectID.SelectedValue));
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtWorkAssignedListByProject.Rows)
        {
            dsProject.dtWorkAssignedListByProjectRow drWorkAssignedListByProject = objdsProject.dtWorkAssignedListByProject.NewdtWorkAssignedListByProjectRow();

            if (!dr["RowNumber"].Equals(System.DBNull.Value))
                drWorkAssignedListByProject.RowNumber = Convert.ToInt32(dr["RowNumber"]);

            if (!dr["WorkAssignedID"].Equals(System.DBNull.Value))
                drWorkAssignedListByProject.WorkAssignedID = Convert.ToInt32(dr["WorkAssignedID"]);

            if (!dr["FacultyName"].Equals(System.DBNull.Value))
                drWorkAssignedListByProject.FacultyName = Convert.ToString(dr["FacultyName"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drWorkAssignedListByProject.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drWorkAssignedListByProject.StudentName = Convert.ToString(dr["StudentName"]);

            if (!dr["DeadLine"].Equals(System.DBNull.Value))
                drWorkAssignedListByProject.DeadLine = Convert.ToDateTime(dr["DeadLine"]);

            if (!dr["WorkTobeDone"].Equals(System.DBNull.Value))
                drWorkAssignedListByProject.WorkTobeDone = Convert.ToString(dr["WorkTobeDone"]);

            if (!dr["SubmittedDate"].Equals(System.DBNull.Value))
                drWorkAssignedListByProject.SubmittedDate = Convert.ToDateTime(dr["SubmittedDate"]);

            if (!dr["FacultyRemarks"].Equals(System.DBNull.Value))
                drWorkAssignedListByProject.FacultyRemarks = Convert.ToString(dr["FacultyRemarks"]);

            objdsProject.dtWorkAssignedListByProject.Rows.Add(drWorkAssignedListByProject);
        }

        SetReportParameters();
        this.rvWorkAssignedListByProject.LocalReport.DataSources.Clear();
        this.rvWorkAssignedListByProject.LocalReport.DataSources.Add(new ReportDataSource("dtWorkAssignedListByProject", (DataTable)objdsProject.dtWorkAssignedListByProject));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String ReportTitle = "Project Wise Work Assigned";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();

        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvWorkAssignedListByProject.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptDepartment, rptSemester, rptAcademicYear });
    }

    #endregion SetReportParameters
    
    #region ddlProjectID Selected Index Changed

    protected void ddlProjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowReport();
    }

    #endregion ddlProjectID Selected Index Changed
}