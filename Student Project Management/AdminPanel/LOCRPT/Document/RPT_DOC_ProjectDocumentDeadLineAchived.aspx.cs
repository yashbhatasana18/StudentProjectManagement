using System;
using System.Web.UI;
using System.Data;
using DProject;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_Document_RPT_DOC_ProjectDocumentDeadLineAchived : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectWiseDocumentDeadLineAchived;

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
        CommonFillMethods.FillDropDownListDocumentTypeID(ddlDocumentTypeID, Session["UserCatagory"].ToString(), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]));
    }

    #endregion Fill DropDownList

    #region ShowReport

    protected void ShowReport()
    {
        DOC_ProjectDocumentBAL balDOC_ProjectDocument = new DOC_ProjectDocumentBAL();

        dtProjectWiseDocumentDeadLineAchived = balDOC_ProjectDocument.SelectAllProjectWiseDocumentReportDeadLineAchived(Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["AcademicYearID"]),Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(ddlDocumentTypeID.SelectedValue),Convert.ToInt32(Session["LoginID"]),Convert.ToInt32(Session["DepartmentID"]));
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtProjectWiseDocumentDeadLineAchived.Rows)
        {
            dsProject.dtProjectDocumentDeadLineAchivedRow drProjectDocumentDeadLineAchived = objdsProject.dtProjectDocumentDeadLineAchived.NewdtProjectDocumentDeadLineAchivedRow();

            if (!dr["DocumentName"].Equals(System.DBNull.Value))
                drProjectDocumentDeadLineAchived.DocumentName = Convert.ToString(dr["DocumentName"]);

            if (!dr["DocumentTypeName"].Equals(System.DBNull.Value))
                drProjectDocumentDeadLineAchived.DocumentTypeName = Convert.ToString(dr["DocumentTypeName"]);

            if (!dr["ProjectDocumentID"].Equals(System.DBNull.Value))
                drProjectDocumentDeadLineAchived.ProjectDocumentID = Convert.ToInt32(dr["ProjectDocumentID"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectDocumentDeadLineAchived.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["SubmissionDate"].Equals(System.DBNull.Value))
                drProjectDocumentDeadLineAchived.SubmissionDate = Convert.ToDateTime(Convert.ToString(dr["SubmissionDate"]));

            if (!dr["DeadLine"].Equals(System.DBNull.Value))
                drProjectDocumentDeadLineAchived.DeadLine = Convert.ToDateTime(Convert.ToString(dr["DeadLine"]));

            if (!dr["RowNumber"].Equals(System.DBNull.Value))
                drProjectDocumentDeadLineAchived.RowNumber = Convert.ToInt32(dr["RowNumber"]);


            objdsProject.dtProjectDocumentDeadLineAchived.Rows.Add(drProjectDocumentDeadLineAchived);
        }

        SetReportParameters();
        this.rvProjectDocumentDeadLineAchived.LocalReport.DataSources.Clear();
        this.rvProjectDocumentDeadLineAchived.LocalReport.DataSources.Add(new ReportDataSource("dtProjectDocumentDeadLineAchived", (DataTable)objdsProject.dtProjectDocumentDeadLineAchived));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String ReportTitle = "Project Wise Document DeadLine Achived";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvProjectDocumentDeadLineAchived.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptDepartment, rptSemester, rptAcademicYear });
    }

    #endregion SetReportParameters

    #region ddlDocumentTypeID Selected Index Changed Event

    protected void ddlDocumentTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowReport();
    }

    #endregion ddlDocumentTypeID Selected Index Changed Event
}