using System;
using System.Web.UI;
using System.Data;
using DProject;
using Microsoft.Reporting.WebForms;
using DProject.BAL;

public partial class AdminPanel_LOCRPT_Document_RPT_DOC_ProjectWiseDocumentListAfterDeadLine : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectWiseDocumentAfterDeadLine;

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
        CommonFillMethods.FillDropDownListDocumentTypeID(ddlDocumentTypeID, Session["UserCatagory"].ToString(), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]));   
    }

    #endregion Fill DropDownList

    #region ShowReport

    protected void ShowReport()
    {
        DOC_ProjectDocumentBAL balDOC_ProjectDocument = new DOC_ProjectDocumentBAL();

        dtProjectWiseDocumentAfterDeadLine = balDOC_ProjectDocument.SelectAllProjectWiseDocumentReportAfterDeadLine(Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["AcademicYearID"]),Convert.ToInt32(ddlDocumentTypeID.SelectedValue));
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtProjectWiseDocumentAfterDeadLine.Rows)
        {
            dsProject.dtProjectDocumentAfterDeadLineRow drProjectDocumentAfterDeadLine = objdsProject.dtProjectDocumentAfterDeadLine.NewdtProjectDocumentAfterDeadLineRow();

            if (!dr["DocumentName"].Equals(System.DBNull.Value))
                drProjectDocumentAfterDeadLine.DocumentName = Convert.ToString(dr["DocumentName"]);

            if (!dr["DocumentTypeName"].Equals(System.DBNull.Value))
                drProjectDocumentAfterDeadLine.DocumentTypeName = Convert.ToString(dr["DocumentTypeName"]);

            if (!dr["ProjectDocumentID"].Equals(System.DBNull.Value))
                drProjectDocumentAfterDeadLine.ProjectDocumentID = Convert.ToString(dr["ProjectDocumentID"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectDocumentAfterDeadLine.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["SubmissionDate"].Equals(System.DBNull.Value))
                drProjectDocumentAfterDeadLine.SubmissionDate = Convert.ToDateTime(Convert.ToString(dr["SubmissionDate"]));

            if (!dr["DeadLine"].Equals(System.DBNull.Value))
                drProjectDocumentAfterDeadLine.DeadLine = Convert.ToDateTime(Convert.ToString(dr["DeadLine"]));

            if (!dr["RowNumber"].Equals(System.DBNull.Value))
                drProjectDocumentAfterDeadLine.RowNumber = Convert.ToInt32(dr["RowNumber"]);


            objdsProject.dtProjectDocumentAfterDeadLine.Rows.Add(drProjectDocumentAfterDeadLine);
        }

        SetReportParameters();
        this.rvProjectDocumentListAfterDeadLine.LocalReport.DataSources.Clear();
        this.rvProjectDocumentListAfterDeadLine.LocalReport.DataSources.Add(new ReportDataSource("dtProjectDocumentAfterDeadLine", (DataTable)objdsProject.dtProjectDocumentAfterDeadLine));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String ReportTitle = "Project Wise Document After DeadLine";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvProjectDocumentListAfterDeadLine.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptDepartment, rptSemester, rptAcademicYear });
    }

    #endregion SetReportParameters

    #region ddlDocumentTypeID Selected Index Changed Event

    protected void ddlDocumentTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowReport();
    }

    #endregion ddlDocumentTypeID Selected Index Changed Event
}