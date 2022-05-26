using System;
using System.Web.UI;
using System.Data;
using DProject;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_Document_RPT_DOC_DocumentType : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtDocumentType;

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
        CommonFillMethods.FillDropDownListInstDepartment(ddlDepartmentID, Convert.ToInt32(Session["InstituteID"]));
    }

    #endregion Fill DropDownList

    #region ShowReport

    protected void ShowReport()
    {
        DOC_DocumentTypeBAL balDOC_DocumentType = new DOC_DocumentTypeBAL();

        dtDocumentType = balDOC_DocumentType.SelectAllDocumentTypeReport(Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(ddlDepartmentID.SelectedValue), Convert.ToString(Session["UserCatagory"]));
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtDocumentType.Rows)
        {
            dsProject.dtDocumentTypeRow drDocumentType = objdsProject.dtDocumentType.NewdtDocumentTypeRow();

            if (!dr["DocumentTypeID"].Equals(System.DBNull.Value))
                drDocumentType.DocumentTypeID = Convert.ToInt32(dr["DocumentTypeID"]);

            if (!dr["DocumentTypeName"].Equals(System.DBNull.Value))
                drDocumentType.DocumentTypeName = Convert.ToString(dr["DocumentTypeName"]);

            if (!dr["IsInternal"].Equals(System.DBNull.Value))
            {
                if (Convert.ToBoolean(dr["IsInternal"]) == true)
                {
                    drDocumentType.IsInternal = "Yes";
                }
                if (Convert.ToBoolean(dr["IsInternal"]) == false)
                {
                    drDocumentType.IsInternal = "";
                }
            }

            if (!dr["IsGTU"].Equals(System.DBNull.Value))
            {
                if (Convert.ToBoolean(dr["IsGTU"]) == true)
                {
                    drDocumentType.IsGTU = "Yes";
                }
                if (Convert.ToBoolean(dr["IsGTU"]) == false)
                {
                    drDocumentType.IsGTU = "";
                }
            }

            if (!dr["IsGanttChart"].Equals(System.DBNull.Value))
            {
                if (Convert.ToBoolean(dr["IsGanttChart"]) == true)
                {
                    drDocumentType.IsGanttChart = "Yes";
                }
                if (Convert.ToBoolean(dr["IsGanttChart"]) == false)
                {
                    drDocumentType.IsGanttChart = "";
                }
            }

            if (!dr["DeadLine"].Equals(System.DBNull.Value))
                drDocumentType.DeadLine = Convert.ToDateTime(dr["DeadLine"]);

            if (!dr["IsCompulsory"].Equals(System.DBNull.Value))
            {
                if (Convert.ToBoolean(dr["IsCompulsory"]) == true)
                {

                    drDocumentType.IsCompulsory = "Yes";
                }
                if (Convert.ToBoolean(dr["IsCompulsory"]) == false)
                {
                    drDocumentType.IsCompulsory = "";
                }
            }

            if (!dr["DepartmentName"].Equals(System.DBNull.Value))
                drDocumentType.DepartmentName = Convert.ToString(dr["DepartmentName"]);

            objdsProject.dtDocumentType.Rows.Add(drDocumentType);
        }

        SetReportParameters();
        this.rvDocumentType.LocalReport.DataSources.Clear();
        this.rvDocumentType.LocalReport.DataSources.Add(new ReportDataSource("dtDocumentType", (DataTable)objdsProject.dtDocumentType));
        this.rvDocumentType.LocalReport.Refresh();
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        this.rvDocumentType.LocalReport.EnableExternalImages = true;
        String ReportTitle = "Project Wise Document DeadLine Achived";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();
        String DarshanLogoPath = Server.MapPath("~/Images/Report/DarshanLogo.png");
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);
        ReportParameter rptDarshanLogoPath = new ReportParameter("DarshanLogoPath", DarshanLogoPath);

        this.rvDocumentType.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptDepartment, rptSemester, rptAcademicYear, rptDarshanLogoPath });
    }

    #endregion SetReportParameters

    protected void ddlDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowReport();
    }
}