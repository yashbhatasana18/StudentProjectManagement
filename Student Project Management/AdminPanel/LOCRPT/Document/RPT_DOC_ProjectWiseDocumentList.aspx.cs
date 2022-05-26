using System;
using System.Web.UI;
using System.Data;
using DProject.BAL;
using Microsoft.Reporting.WebForms;
using DProject;

public partial class AdminPanel_LOCRPT_Document_RPT_DOC_ProjectWiseDocumentList : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectWiseDocument;

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
            Session["FilterQuery"] = null;
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
        DOC_ProjectDocumentBAL balDOC_ProjectDocument = new DOC_ProjectDocumentBAL();
        dtProjectWiseDocument = balDOC_ProjectDocument.SelectAllProjectWiseDocumentReport(Convert.ToInt32(Session["InstituteID"]),Convert.ToInt32(Session["AcademicYearID"]),Convert.ToInt32(ddlProjectID.SelectedValue));
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtProjectWiseDocument.Rows)
        {
            dsProject.dtProjectWiseDocumentRow drProjectWiseDocument = objdsProject.dtProjectWiseDocument.NewdtProjectWiseDocumentRow();

            if (!dr["DocumentName"].Equals(System.DBNull.Value))
                drProjectWiseDocument.DocumentName = Convert.ToString(dr["DocumentName"]);

            if (!dr["DocumentTypeName"].Equals(System.DBNull.Value))
                drProjectWiseDocument.DocumentTypeName = Convert.ToString(dr["DocumentTypeName"]);

            if (!dr["AcademicYearName"].Equals(System.DBNull.Value))
                drProjectWiseDocument.AcademicYearName = Convert.ToString(dr["AcademicYearName"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectWiseDocument.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["SubmissionDate"].Equals(System.DBNull.Value))
                drProjectWiseDocument.SubmissionDate = Convert.ToDateTime(Convert.ToString(dr["SubmissionDate"]));

            if (!dr["RowNumber"].Equals(System.DBNull.Value))
                drProjectWiseDocument.RowNumber = Convert.ToInt32(dr["RowNumber"]);


            objdsProject.dtProjectWiseDocument.Rows.Add(drProjectWiseDocument);
        }

        SetReportParameters();
        this.rvProjectWiseDocument.LocalReport.DataSources.Clear();
        this.rvProjectWiseDocument.LocalReport.DataSources.Add(new ReportDataSource("dtProjectWiseDocument", (DataTable)objdsProject.dtProjectWiseDocument));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String ReportTitle = "Project Wise Document List";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();
        ReportParameter rprptTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvProjectWiseDocument.LocalReport.SetParameters(new ReportParameter[] { rprptTitle, rptDepartment, rptSemester, rptAcademicYear });
    }

    #endregion SetReportParameters

    #region ddlProjectID Selected Index Changed Event

    protected void ddlProjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowReport();
    }

    #endregion ddlProjectID Selected Index Changed Event
}