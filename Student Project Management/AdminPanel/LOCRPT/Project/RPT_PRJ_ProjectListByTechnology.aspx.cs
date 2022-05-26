using System;
using System.Web.UI;
using System.Data;
using DProject;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_Project_RPT_PRJ_ProjectListByTechnology : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectListByTechnology;

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
            Session["FilterQuery"] = null;
            FillDropDownList();
            ShowRepport(Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(ddlTechnology.SelectedValue));
        }
    }

    #endregion LoadEvent

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListTechnologyID(ddlTechnology);
    }

    #endregion FillDropDownList

    #region ShowReport

    protected void ShowRepport(String UserCatagory, Int32 InstituteID, Int32 DepartmentID, Int32 TechnologyID)
    {
        PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
        dtProjectListByTechnology = balPRJ_Project.SelectProjectStatementListByTechnology(UserCatagory, InstituteID, DepartmentID, TechnologyID);
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtProjectListByTechnology.Rows)
        {
            dsProject.dtProjectListByTechnologyRow drProjectListByTechnology = objdsProject.dtProjectListByTechnology.NewdtProjectListByTechnologyRow();

            if (!dr["RowNumber"].Equals(System.DBNull.Value))
                drProjectListByTechnology.RowNumber = Convert.ToInt32(dr["RowNumber"]);

            if (!dr["GTUTeamNo"].Equals(System.DBNull.Value))
                drProjectListByTechnology.GTUTeamNo = Convert.ToString(dr["GTUTeamNo"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drProjectListByTechnology.StudentName = Convert.ToString(dr["StudentName"]);

            if (!dr["EnrollmentNo"].Equals(System.DBNull.Value))
                drProjectListByTechnology.EnrollmentNo = Convert.ToString(dr["EnrollmentNo"]);

            if (!dr["Semester"].Equals(System.DBNull.Value))
                drProjectListByTechnology.Semester = Convert.ToString(dr["Semester"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectListByTechnology.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["TechnologyName"].Equals(System.DBNull.Value))
                drProjectListByTechnology.TechnologyName = Convert.ToString(dr["TechnologyName"]);

            if (!dr["FacultyName"].Equals(System.DBNull.Value))
                drProjectListByTechnology.FacultyName = Convert.ToString(dr["FacultyName"]);

            if (!dr["ProjectCode"].Equals(System.DBNull.Value))
                drProjectListByTechnology.ProjectCode = Convert.ToString(dr["ProjectCode"]);

            if (!dr["DepartmentName"].Equals(System.DBNull.Value))
                drProjectListByTechnology.DepartmentName = Convert.ToString(dr["DepartmentName"]);


            objdsProject.dtProjectListByTechnology.Rows.Add(drProjectListByTechnology);
        }

        SetReportParameters();
        this.rvProjectListByTechnology.LocalReport.DataSources.Clear();
        this.rvProjectListByTechnology.LocalReport.DataSources.Add(new ReportDataSource("dtProjectListByTechnology", (DataTable)objdsProject.dtProjectListByTechnology));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String InstituteName = Session["InstituteName"].ToString();
        String rptTitle = "Project List By Technology";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();
        ReportParameter rpInstituteName = new ReportParameter("InstituteName", InstituteName);
        ReportParameter rprptTitle = new ReportParameter("ReportTitle", rptTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvProjectListByTechnology.LocalReport.SetParameters(new ReportParameter[] { rpInstituteName, rprptTitle, rptDepartment, rptSemester ,rptAcademicYear});
    }

    #endregion SetReportParameters

    #region ddlTechnology Selected Indexed Changed

    protected void ddlTechnology_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowRepport(Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(ddlTechnology.SelectedValue));
    }

    #endregion ddlTechnology Selected Indexed Changed
}