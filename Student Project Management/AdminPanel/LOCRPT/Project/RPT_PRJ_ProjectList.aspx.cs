using System;
using System.Web.UI;
using System.Data;
using Microsoft.Reporting.WebForms;
using DProject;
using DProject.BAL;

public partial class AdminPanel_LOCRPT_Project_RPT_PRJ_ProjectList : System.Web.UI.Page
{

    #region Private Variables

    private DataTable dtProjectList;

    private dsProject objdsProject = new dsProject();

    #endregion Private Variables

    #region PageLoad

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //if (Session["UserCatagory"].ToString() != "Admin")
        //{
        //    ddlDepartment.Visible = false;
        //    lblColun.Visible = false;
        //    lblDepartment.Visible = false;
        //}
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            FillDropDownList();
            if (Convert.ToString(Session["UserCatagory"]) == "Faculty")
            {
                ddlGuide.SelectedValue = Convert.ToString(Session["LoginID"]);
                ddlDepartment.SelectedValue = Convert.ToString(Session["DepartmentID"]);
                ddlGuide.Enabled = false;
                ddlDepartment.Enabled = false;
            }
            if (Convert.ToString(Session["UserCatagory"]) == "Head/DepartmentCoordinator")
            {
                ddlDepartment.SelectedValue = Convert.ToString(Session["DepartmentID"]);
                ddlDepartment.Enabled = false;
            }
            if (Convert.ToString(Session["UserCatagory"]) == "Student")
            {
                ddlDepartment.SelectedValue = Convert.ToString(Session["DepartmentID"]);
                ddlDepartment.Enabled = false;
                ddlGuide.Enabled = false;
                ddlTechnology.Enabled = false;
            }

            ShowRepport();
        }
    }

    #endregion PageLoad

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListTechnologyID(ddlTechnology);
        CommonFillMethods.FillDropDownListFacultyID(ddlGuide,Convert.ToInt32(Session["InstituteID"]));
        CommonFillMethods.FillDropDownListDepartmentID(ddlDepartment, Convert.ToInt32(Session["InstituteID"]));
    }

    #endregion FillDropDownList

    #region ShowReport

    protected void ShowRepport()
    {
        PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
        dtProjectList = balPRJ_Project.SelectAllReport(Convert.ToString(Session["UserCatagory"]),Convert.ToInt32(Session["LoginID"]),Convert.ToInt32(Session["InstituteID"]),Convert.ToInt32(Session["DepartmentID"]),Convert.ToInt32(Session["AcademicYearID"]),Convert.ToInt32(ddlTechnology.SelectedValue),Convert.ToInt32(ddlGuide.SelectedValue));
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach(DataRow dr in dtProjectList.Rows)
        {
            dsProject.dtProjectListRow drProjectList = objdsProject.dtProjectList.NewdtProjectListRow();

            if (!dr["GTUTeamNo"].Equals(System.DBNull.Value))
                drProjectList.GTUTeamNo = Convert.ToString(dr["GTUTeamNo"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drProjectList.StudentName = Convert.ToString(dr["StudentName"]);

            if (!dr["EnrollmentNo"].Equals(System.DBNull.Value))
                drProjectList.EnrollmentNo = Convert.ToString(dr["EnrollmentNo"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectList.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["FacultyName"].Equals(System.DBNull.Value))
                drProjectList.FacultyName = Convert.ToString(dr["FacultyName"]);

            //if (!dr["Phone"].Equals(System.DBNull.Value))
            //    drProjectList.Phone = Convert.ToString(dr["Phone"]);

            if (!dr["Email"].Equals(System.DBNull.Value))
                drProjectList.Email = Convert.ToString(dr["Email"]);

            if (!dr["TechnologyName"].Equals(System.DBNull.Value))
                drProjectList.TechnologyName = Convert.ToString(dr["TechnologyName"]);

            objdsProject.dtProjectList.Rows.Add(drProjectList);
        }

        SetReportParameters();
        this.rvProjectList.LocalReport.DataSources.Clear();
        this.rvProjectList.LocalReport.DataSources.Add(new ReportDataSource("dsProjectList", (DataTable)objdsProject.dtProjectList));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String DepartmentName = "Computer Engineering";
        String ReportTitle = "Project List";
        String AcademicYear = Session["AcademicYearName"].ToString();
        String Semester = "8";
        ReportParameter rpDepartmentName = new ReportParameter("DepartmentName", DepartmentName);
        ReportParameter rpReportName = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rpAcademicYear = new ReportParameter("AcademicYear", AcademicYear);
        ReportParameter rpSemester = new ReportParameter("Semester", Semester);

        this.rvProjectList.LocalReport.SetParameters(new ReportParameter[] { rpDepartmentName, rpReportName, rpAcademicYear, rpSemester });
    }

    #endregion SetReportParameters

    #region Show Button Event

    protected void btnShow_Click(object sender, EventArgs e)
    {
        ShowRepport();
    }

    #endregion Show Button Event

}