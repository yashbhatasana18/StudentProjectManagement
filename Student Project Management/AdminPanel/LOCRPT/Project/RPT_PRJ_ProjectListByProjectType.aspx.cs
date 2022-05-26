using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_Project_RPT_PRJ_ProjectListByProjectType : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectListByProjectType;

    private dsProject objdsProject = new dsProject();

    #endregion Private Variables

    #region Load Event

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
            ShowRepport();
        }
    }

    #endregion Load Event

    #region FillDropDownList

    private void FillDropDownList()
    {
        #region Fill Project Type

        ListItem liSelectprotype = new ListItem(" Select One ", "-99");
        ddlProjectType.Items.Add(liSelectprotype);
        ListItem liUDP = new ListItem("UDP", "UDP");
        ddlProjectType.Items.Add(liUDP);
        ListItem liIDP = new ListItem("IDP", "IDP");
        ddlProjectType.Items.Add(liIDP);

        #endregion Fill Project Type
    }

    #endregion FillDropDownList

    #region ShowReport

    protected void ShowRepport()
    {
        PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
        dtProjectListByProjectType = balPRJ_Project.SelectProjectStatementListByProjectType(Convert.ToString(Session["UserCatagory"]),Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]),Convert.ToInt32(Session["AcademicYearID"]), Convert.ToString(ddlProjectType.SelectedValue));
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtProjectListByProjectType.Rows)
        {
            dsProject.dtProjectListByProjectTypeRow drProjectListByProjectType = objdsProject.dtProjectListByProjectType.NewdtProjectListByProjectTypeRow();

            if (!dr["RowNumber"].Equals(System.DBNull.Value))
                drProjectListByProjectType.RowNumber = Convert.ToInt32(dr["RowNumber"]);

            if (!dr["Mobile"].Equals(System.DBNull.Value))
                drProjectListByProjectType.Mobile = Convert.ToString(dr["Mobile"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drProjectListByProjectType.StudentName = Convert.ToString(dr["StudentName"]);

            if (!dr["EnrollmentNo"].Equals(System.DBNull.Value))
                drProjectListByProjectType.EnrollmentNo = Convert.ToString(dr["EnrollmentNo"]);

            if (!dr["Phone"].Equals(System.DBNull.Value))
                drProjectListByProjectType.Phone = Convert.ToString(dr["Phone"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectListByProjectType.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["TechnologyName"].Equals(System.DBNull.Value))
                drProjectListByProjectType.TechnologyName = Convert.ToString(dr["TechnologyName"]);

            if (!dr["FacultyName"].Equals(System.DBNull.Value))
                drProjectListByProjectType.FacultyName = Convert.ToString(dr["FacultyName"]);

            //if (!dr["ProjectType"].Equals(System.DBNull.Value))
            //    drProjectListByProjectType.ProjectType = Convert.ToString(dr["ProjectType"]);


            objdsProject.dtProjectListByProjectType.Rows.Add(drProjectListByProjectType);
        }

        SetReportParameters();
        this.rvProjectListByProjectType.LocalReport.DataSources.Clear();
        this.rvProjectListByProjectType.LocalReport.DataSources.Add(new ReportDataSource("dtProjectListByProjectType", (DataTable)objdsProject.dtProjectListByProjectType));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String InstituteName = Session["InstituteName"].ToString();
        String rptTitle = "Project List By Project Type";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();
        ReportParameter rpInstituteName = new ReportParameter("InstituteName", InstituteName);
        ReportParameter rprptTitle = new ReportParameter("ReportTitle", rptTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvProjectListByProjectType.LocalReport.SetParameters(new ReportParameter[] { rpInstituteName, rprptTitle, rptDepartment, rptSemester , rptAcademicYear});
    }

    #endregion SetReportParameters

    #region ddlProjectType Selected Index Changed

    protected void ddlProjectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowRepport();
    }

    #endregion ddlProjectType Selected Index Changed
}