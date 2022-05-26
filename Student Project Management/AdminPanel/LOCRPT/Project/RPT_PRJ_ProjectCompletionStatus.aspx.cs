using System;
using System.Web.UI;
using System.Data;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_Project_RPT_PRJ_ProjectCompletionStatus : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectCompletionStatus;

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
            Session["FilterQuery"] = null;
            ShowRepport();
        }
    }

    #endregion Load

    #region ShowReport

    protected void ShowRepport()
    {
        PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
        dtProjectCompletionStatus = balPRJ_Project.SelectProjectCompletionStatus();
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtProjectCompletionStatus.Rows)
        {
            dsProject.dtProjectCompletionStatusRow drProjectCompletionStatus = objdsProject.dtProjectCompletionStatus.NewdtProjectCompletionStatusRow();

            if (!dr["RowNumber"].Equals(System.DBNull.Value))
                drProjectCompletionStatus.RowNumber = Convert.ToInt32(dr["RowNumber"]);

            if (!dr["FacultyName"].Equals(System.DBNull.Value))
                drProjectCompletionStatus.FacultyName = Convert.ToString(dr["FacultyName"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectCompletionStatus.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);


            objdsProject.dtProjectCompletionStatus.Rows.Add(drProjectCompletionStatus);
        }

        SetReportParameters();
        this.rvProjectCompletionStatus.LocalReport.DataSources.Clear();
        this.rvProjectCompletionStatus.LocalReport.DataSources.Add(new ReportDataSource("dtProjectCompletionStatus", (DataTable)objdsProject.dtProjectCompletionStatus));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String rptTitle = "Project Completion Status";
        String Department = Session["DepartmentName"].ToString();
        ReportParameter rprptTitle = new ReportParameter("ReportTitle", rptTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);

        this.rvProjectCompletionStatus.LocalReport.SetParameters(new ReportParameter[] { rprptTitle, rptDepartment});
    }

    #endregion SetReportParameters
}