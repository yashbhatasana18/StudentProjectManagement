using System;
using System.Web.UI;
using DProject;
using DProject.BAL;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_Project_RPT_PRJ_ProjectStatementListByGuide : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectStatementListByGuide;

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
            ShowProjectStatementListByGuide();
        }
    }

    #endregion LoadEvent

    #region Fill DropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListFacultyID(ddlGuide, Convert.ToInt32(Session["InstituteID"]));
    }

    #endregion Fill DropDownList
    
    #region ShowProjectStatementListByGuide

    private void ShowProjectStatementListByGuide()
    {
        PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
        dtProjectStatementListByGuide = balPRJ_Project.SelectProjectStatementListByGuide(Convert.ToString(Session["UserCatagory"]),Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]),Convert.ToInt32(Session["AcademicYearID"]), Convert.ToInt32(ddlGuide.SelectedValue));
        FillDataSet();
    }

    #endregion ShowProjectStatementListByGuide

    #region FillDataSet

    private void FillDataSet()
    {
        objdsProject.dtProjectStatementListByGuide.Clear();

        foreach (DataRow dr in dtProjectStatementListByGuide.Rows)
        {
            dsProject.dtProjectStatementListByGuideRow drProjectStatementListByGuide = objdsProject.dtProjectStatementListByGuide.NewdtProjectStatementListByGuideRow();

            if (!dr["EnrollmentNo"].Equals(System.DBNull.Value))
                drProjectStatementListByGuide.EnrollmentNo = Convert.ToString(dr["EnrollmentNo"]);

            if (!dr["RowNumber"].Equals(System.DBNull.Value))
                drProjectStatementListByGuide.RowNumber = Convert.ToInt32(dr["RowNumber"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drProjectStatementListByGuide.StudentName = Convert.ToString(dr["StudentName"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectStatementListByGuide.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["TechnologyName"].Equals(System.DBNull.Value))
                drProjectStatementListByGuide.TechnologyName = Convert.ToString(dr["TechnologyName"]);

            if (!dr["ProjectCode"].Equals(System.DBNull.Value))
                drProjectStatementListByGuide.ProjectCode = Convert.ToString(dr["ProjectCode"]);

            if (!dr["GTUTeamNo"].Equals(System.DBNull.Value))
                drProjectStatementListByGuide.GTUTeamNo = Convert.ToString(dr["GTUTeamNo"]);

            if (!dr["DepartmentName"].Equals(System.DBNull.Value))
                drProjectStatementListByGuide.DepartmentName = Convert.ToString(dr["DepartmentName"]);

            if (!dr["FacultyName"].Equals(System.DBNull.Value))
                drProjectStatementListByGuide.FacultyName = Convert.ToString(dr["FacultyName"]);

            objdsProject.dtProjectStatementListByGuide.Rows.Add(drProjectStatementListByGuide);
        }
        SetReportParameters();
    
        this.rvProjectStatementListByGuide.LocalReport.DataSources.Clear();
        this.rvProjectStatementListByGuide.LocalReport.DataSources.Add(new ReportDataSource("dtProjectStatementListByGuide",(DataTable)objdsProject.dtProjectStatementListByGuide));

    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String InstituteName = Session["InstituteName"].ToString();
        String rptTitle = "Project Statement List By Guide";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();
        ReportParameter rpInstituteName = new ReportParameter("InstituteName", InstituteName);
        ReportParameter rprptTitle = new ReportParameter("rptTitle", rptTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvProjectStatementListByGuide.LocalReport.SetParameters(new ReportParameter[] { rpInstituteName, rprptTitle, rptDepartment, rptSemester, rptAcademicYear });
    }

    #endregion SetReportParameters

    #region ddlGuide Selected Index Changed

    protected void ddlGuide_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowProjectStatementListByGuide();
    }

    #endregion ddlGuide Selected Index Changed
}