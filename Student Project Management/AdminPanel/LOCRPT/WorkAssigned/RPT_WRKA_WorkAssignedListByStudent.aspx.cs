using System;
using System.Web.UI;
using System.Data;
using DProject;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_WorkAssigned_RPT_WRKA_WorkAssignedListByStudent : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtWorkAssignedListByStudent;

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
        CommonFillMethods.FillDropDownListStudentIDForReport(ddlStudentID, Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["AcademicYearID"]));
    }

    #endregion Fill DropDownList

    #region ShowReport

    protected void ShowReport()
    {
        WRK_WorkAssignedBAL balWRK_WorkAssigned = new WRK_WorkAssignedBAL();

        dtWorkAssignedListByStudent = balWRK_WorkAssigned.SelectAllWorkAssignedByStudent(Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["AcademicYearID"]), Convert.ToInt32(ddlStudentID.SelectedValue));
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtWorkAssignedListByStudent.Rows)
        {
            dsProject.dtWorkAssignedListByStudentRow drWorkAssignedListByStudent = objdsProject.dtWorkAssignedListByStudent.NewdtWorkAssignedListByStudentRow();

            if (!dr["RowNumber"].Equals(System.DBNull.Value))
                drWorkAssignedListByStudent.RowNumber = Convert.ToInt32(dr["RowNumber"]);

            if (!dr["WorkAssignedID"].Equals(System.DBNull.Value))
                drWorkAssignedListByStudent.WorkAssignedID = Convert.ToInt32(dr["WorkAssignedID"]);

            if (!dr["FacultyName"].Equals(System.DBNull.Value))
                drWorkAssignedListByStudent.FacultyName = Convert.ToString(dr["FacultyName"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drWorkAssignedListByStudent.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drWorkAssignedListByStudent.StudentName = Convert.ToString(dr["StudentName"]);

            if (!dr["DeadLine"].Equals(System.DBNull.Value))
                drWorkAssignedListByStudent.DeadLine = Convert.ToDateTime(dr["DeadLine"]);

            if (!dr["WorkTobeDone"].Equals(System.DBNull.Value))
                drWorkAssignedListByStudent.WorkTobeDone = Convert.ToString(dr["WorkTobeDone"]);

            if (!dr["SubmittedDate"].Equals(System.DBNull.Value))
                drWorkAssignedListByStudent.SubmittedDate = Convert.ToDateTime(dr["SubmittedDate"]);

            if (!dr["FacultyRemarks"].Equals(System.DBNull.Value))
                drWorkAssignedListByStudent.FacultyRemarks = Convert.ToString(dr["FacultyRemarks"]);

            objdsProject.dtWorkAssignedListByStudent.Rows.Add(drWorkAssignedListByStudent);
        }

        SetReportParameters();
        this.rvWorkAssignedListByStudent.LocalReport.DataSources.Clear();
        this.rvWorkAssignedListByStudent.LocalReport.DataSources.Add(new ReportDataSource("dtWorkAssignedListByStudent", (DataTable)objdsProject.dtWorkAssignedListByStudent));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String ReportTitle = "Project Wise Work Assigned";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        //String AcademicYear = Session["AcademicYearName"].ToString();

        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        //ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvWorkAssignedListByStudent.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptDepartment, rptSemester });
    }

    #endregion SetReportParameters

    #region ddlStudentID Selected Index Changed

    protected void ddlStudentID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowReport();
    }

    #endregion ddlStudentID Selected Index Changed
}