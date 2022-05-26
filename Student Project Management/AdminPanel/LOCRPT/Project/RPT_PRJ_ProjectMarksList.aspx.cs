using System;
using System.Web.UI;
using System.Data;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_Project_RPT_PRJ_ProjectMarksList : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectMarksList;

    private dsProject objdsProject = new dsProject();

    #endregion Private Variables

    #region Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }

        if (!Page.IsPostBack)
        {
            ShowReport();
        }
    }

    #endregion Load

    #region Show Report

    private void ShowReport()
    {
        PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
        dtProjectMarksList = balPRJ_Project.SelectProjectMarksList();
        FillDataSet();
    }

    #endregion show Report

    #region FillDataSet

    private void FillDataSet()
    {
        foreach (DataRow dr in dtProjectMarksList.Rows)
        {
            dsProject.dtProjectMarksListRow drProjectMarksList = objdsProject.dtProjectMarksList.NewdtProjectMarksListRow();

            if (!dr["RowNumber"].Equals(System.DBNull.Value))
                drProjectMarksList.RowNumber = Convert.ToInt32(dr["RowNumber"]);

            if (!dr["FacultyName"].Equals(System.DBNull.Value))
                drProjectMarksList.FacultyName = Convert.ToString(dr["FacultyName"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectMarksList.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drProjectMarksList.StudentName = Convert.ToString(dr["StudentName"]);

            objdsProject.dtProjectMarksList.Rows.Add(drProjectMarksList);
        }

        SetReportParameters();

        this.rvProjectMarksList.LocalReport.DataSources.Clear();
        this.rvProjectMarksList.LocalReport.DataSources.Add(new ReportDataSource("dtProjectMarksList", (DataTable)objdsProject.dtProjectMarksList));
    }

    #endregion FillDataSet

    #region ShowReportParameteres

    private void SetReportParameters()
    {
        String rptTitle = "Project Marks List";
        String Department = Session["DepartmentName"].ToString();
        ReportParameter rprptTitle = new ReportParameter("ReportTitle", rptTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);

        this.rvProjectMarksList.LocalReport.SetParameters(new ReportParameter[] { rprptTitle, rptDepartment });
    }

    #endregion ShowReportParameteres
}