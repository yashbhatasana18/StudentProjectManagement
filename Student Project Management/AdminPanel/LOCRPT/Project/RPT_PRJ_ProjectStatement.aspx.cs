using System;
using System.Web.UI;
using System.Data;
using DProject.BAL;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_LOCRPT_Project_RPT_PRJ_ProjectStatement : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtProjectStatement;

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
            if (Request.QueryString["ProjectID"] != null)
            {
                ShowProjectStatement(Convert.ToInt32(Request.QueryString["ProjectID"]));
            }
        }
    }

    #endregion LoadEvent

    #region ShowProjectStatement

    private void ShowProjectStatement(Int32 ProjectID)
    {
        PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
        dtProjectStatement = balPRJ_Project.SelectProjectStatement(ProjectID);
        FillDataSet();
    }

    #endregion ShowProjectStatement

    #region FillDataSet

    private void FillDataSet()
    {
        objdsProject.dtProjectListByTechnology.Clear();

        foreach (DataRow dr in dtProjectStatement.Rows)
        {
            dsProject.dtProjectStatementRow drProjectStatement = objdsProject.dtProjectStatement.NewdtProjectStatementRow();

            if (!dr["ProjectID"].Equals(System.DBNull.Value))
                drProjectStatement.ProjectID = Convert.ToInt32(dr["ProjectID"]);

            if (!dr["FacultyName"].Equals(System.DBNull.Value))
                drProjectStatement.FacultyName = Convert.ToString(dr["FacultyName"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectStatement.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["Student"].Equals(System.DBNull.Value))
                drProjectStatement.Student = Convert.ToString(dr["Student"]);

            if (!dr["InstituteName"].Equals(System.DBNull.Value))
                drProjectStatement.InstituteName = Convert.ToString(dr["InstituteName"]);

            if (!dr["DepartmentName"].Equals(System.DBNull.Value))
                drProjectStatement.DepartmentName = Convert.ToString(dr["DepartmentName"]);

            if (!dr["CompanyName"].Equals(System.DBNull.Value))
                drProjectStatement.CompanyName = Convert.ToString(dr["CompanyName"]);

            if (!dr["CompanyGuideName"].Equals(System.DBNull.Value))
                drProjectStatement.CompanyGuideName = Convert.ToString(dr["CompanyGuideName"]);

            if (!dr["ShortTitle"].Equals(System.DBNull.Value))
                drProjectStatement.ShortTitle = Convert.ToString(dr["ShortTitle"]);

            if (!dr["Description"].Equals(System.DBNull.Value))
                drProjectStatement.Description = Convert.ToString(dr["Description"]);

            if (!dr["ProjectType"].Equals(System.DBNull.Value))
                drProjectStatement.ProjectType = Convert.ToString(dr["ProjectType"]);

            if (!dr["ProblemStatement"].Equals(System.DBNull.Value))
                drProjectStatement.ProblemStatement = Convert.ToString(dr["ProblemStatement"]);

            if (!dr["Abstract"].Equals(System.DBNull.Value))
                drProjectStatement.Abstract = Convert.ToString(dr["Abstract"]);

            if (!dr["GTUTeamNo"].Equals(System.DBNull.Value))
                drProjectStatement.GTUTeamNo = Convert.ToString(dr["GTUTeamNo"]);

            if (!dr["TechnologyName"].Equals(System.DBNull.Value))
                drProjectStatement.TechnologyName = Convert.ToString(dr["TechnologyName"]);

            if (!dr["Semester"].Equals(System.DBNull.Value))
                drProjectStatement.Semester = Convert.ToString(dr["Semester"]);

            if (!dr["Year"].Equals(System.DBNull.Value))
                drProjectStatement.Year = Convert.ToInt32(dr["Year"]);

            if (!dr["ProjectCode"].Equals(System.DBNull.Value))
                drProjectStatement.ProjectCode = Convert.ToString(dr["ProjectCode"]);

            if (!dr["RegistrationDate"].Equals(System.DBNull.Value))
                drProjectStatement.RegistrationDate = Convert.ToDateTime((Convert.ToString(dr["RegistrationDate"])).Trim());

            if (!dr["GroupSize"].Equals(System.DBNull.Value))
                drProjectStatement.GroupSize = Convert.ToInt32(dr["GroupSize"]);

            if (!dr["IsDisiplinary"].Equals(System.DBNull.Value))
            {
                if (Convert.ToBoolean(dr["IsDisiplinary"]) == true)
                {
                    drProjectStatement.IsDisiplinary = "INTER-DICIPLINARY";
                    drProjectStatement.InterDisiplineDepartmentName = Convert.ToString(dr["InterDisiplineDepartmentName"]);
                }
                if (Convert.ToBoolean(dr["IsDisiplinary"]) == false)
                {
                    drProjectStatement.IsDisiplinary = "DICIPLINARY";
                    drProjectStatement.InterDisiplineDepartmentName = Convert.ToString(dr["DepartmentName"]);
                }
            }

            if (!dr["Remarks"].Equals(System.DBNull.Value))
                drProjectStatement.Remarks = Convert.ToString(dr["Remarks"]);

            objdsProject.dtProjectStatement.Rows.Add(drProjectStatement);
        }
        SetReportParameters();

        this.rvProjectStatement.LocalReport.DataSources.Clear();
        this.rvProjectStatement.LocalReport.DataSources.Add(new ReportDataSource("dtProjectStatement", (DataTable)objdsProject.dtProjectStatement));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String ReportHeader = "IDP / UDP Project Statement";
        ReportParameter rpReportHeader = new ReportParameter("ReportHeader", ReportHeader);
        this.rvProjectStatement.LocalReport.SetParameters(new ReportParameter[] { rpReportHeader });
    }

    #endregion SetReportParameters
}