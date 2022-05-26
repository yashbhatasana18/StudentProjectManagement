using System;
using System.Web.UI;
using System.Data;
using DProject.BAL;
using Microsoft.Reporting.WebForms;
using DProject;

public partial class AdminPanel_LOCRPT_Project_RPT_PRJ_ProjectStatementList : System.Web.UI.Page
{

    #region Private Variables

    private DataTable dtProjectStatementList;

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
            ShowProjectStatement(Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]),Convert.ToInt32(ddlDepartment.SelectedValue),Convert.ToInt32(ddlTechnology.SelectedValue));
        }
    }

    #endregion LoadEvent

    #region Fill DropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListTechnologyID(ddlTechnology);
        CommonFillMethods.FillDropDownListDepartmentID(ddlDepartment, Convert.ToInt32(Session["InstituteID"]));
    }

    #endregion Fill DropDownList

    #region ShowProjectStatement

    private void ShowProjectStatement(String UserCatagory,Int32 LoginID,Int32 InstituteID,Int32 DepartmentID,Int32 TechnologyID)
    {
        PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
        dtProjectStatementList = balPRJ_Project.SelectProjectStatementList(UserCatagory, LoginID, InstituteID, DepartmentID, TechnologyID);
        FillDataSet();
    }
    
    #endregion ShowProjectStatement

    #region FillDataSet

    private void FillDataSet()
    {
        objdsProject.dtProjectListByTechnology.Clear();

        foreach (DataRow dr in dtProjectStatementList.Rows)
        {
            dsProject.dtProjectStatementListRow drProjectStatementList = objdsProject.dtProjectStatementList.NewdtProjectStatementListRow();

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drProjectStatementList.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["GTUTeamNo"].Equals(System.DBNull.Value))
                drProjectStatementList.GTUTeamNo = Convert.ToString(dr["GTUTeamNo"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drProjectStatementList.StudentName = Convert.ToString(dr["StudentName"]);

            if (!dr["TechnologyName"].Equals(System.DBNull.Value))
                drProjectStatementList.TechnologyName = Convert.ToString(dr["TechnologyName"]);

            if (!dr["ProjectCode"].Equals(System.DBNull.Value))
                drProjectStatementList.ProjectCode = Convert.ToString(dr["ProjectCode"]);

            if (!dr["DepartmentName"].Equals(System.DBNull.Value))
                drProjectStatementList.DepartmentName = Convert.ToString(dr["DepartmentName"]);

            objdsProject.dtProjectStatementList.Rows.Add(drProjectStatementList);
        }
        SetReportParameters();

        this.rvProjectStatementList.LocalReport.DataSources.Clear();
        this.rvProjectStatementList.LocalReport.DataSources.Add(new ReportDataSource("dtProjectStatementList", (DataTable)objdsProject.dtProjectStatementList));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        String InstituteName = Session["InstituteName"].ToString();
        String rptTitle = "Project Statement List";
        ReportParameter rpInstituteName = new ReportParameter("InstituteName", InstituteName);
        ReportParameter rprptTitle = new ReportParameter("rptTitle", rptTitle);
        this.rvProjectStatementList.LocalReport.SetParameters(new ReportParameter[] { rpInstituteName, rprptTitle });
    }

    #endregion SetReportParameters
}