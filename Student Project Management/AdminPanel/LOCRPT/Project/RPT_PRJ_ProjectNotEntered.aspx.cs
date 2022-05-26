using System;
using System.Web.UI;
using System.Data;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_Project_RPT_PRJ_ProjectNotEntered : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectNotEntered;

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
            ShowRepport(Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]));
        }
    }

    #endregion LoadEvent

    #region FillDropDownList

    private void FillDropDownList()
    {
       
    }

    #endregion FillDropDownList

    #region ShowReport

    protected void ShowRepport(Int32 InstituteID,Int32 DepartmentID)
    {
        PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
        dtProjectNotEntered = balPRJ_Project.SelectProjectNotEntered(InstituteID, DepartmentID);
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtProjectNotEntered.Rows)
        {
            dsProject.dtProjectNotEnteredRow drProjectNotEntered = objdsProject.dtProjectNotEntered.NewdtProjectNotEnteredRow();

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drProjectNotEntered.StudentName = Convert.ToString(dr["StudentName"]);

            if (!dr["EnrollmentNo"].Equals(System.DBNull.Value))
                drProjectNotEntered.EnrollmentNo = Convert.ToString(dr["EnrollmentNo"]);

            if (!dr["Email"].Equals(System.DBNull.Value))
                drProjectNotEntered.Email = Convert.ToString(dr["Email"]);

            if (!dr["DOB"].Equals(System.DBNull.Value))
                drProjectNotEntered.DOB = Convert.ToString(dr["DOB"]);

            if (!dr["DepartmentName"].Equals(System.DBNull.Value))
                drProjectNotEntered.DepartmentName = Convert.ToString(dr["DepartmentName"]);

            if (!dr["Mobile"].Equals(System.DBNull.Value))
                drProjectNotEntered.Mobile = Convert.ToString(dr["Mobile"]);


            objdsProject.dtProjectNotEntered.Rows.Add(drProjectNotEntered);
        }

        SetReportParameters();
        this.rvProjctNotEntered.LocalReport.DataSources.Clear();
        this.rvProjctNotEntered.LocalReport.DataSources.Add(new ReportDataSource("dtProjectNotEntered", (DataTable)objdsProject.dtProjectNotEntered));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String InstituteName = Session["InstituteName"].ToString();
        String rptTitle = "Project Not Registered";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();
        ReportParameter rpInstituteName = new ReportParameter("InstituteName", InstituteName);
        ReportParameter rprptTitle = new ReportParameter("ReportTitle", rptTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvProjctNotEntered.LocalReport.SetParameters(new ReportParameter[] { rpInstituteName, rprptTitle, rptDepartment, rptSemester , rptAcademicYear});
    }

    #endregion SetReportParameters
}