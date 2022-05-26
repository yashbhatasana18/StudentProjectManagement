using DProject.BAL;
using System;
using System.Data;
using System.Web.UI;

public partial class AdminPanel_Project_PRJ_Project_PRJ_ProjectView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "Project View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["projectid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["projectid"] != null)
        {
            PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
            DataTable dtPRJ_Project = balPRJ_Project.SelectView(Convert.ToInt32(Request.QueryString["projectid"]));
            if (dtPRJ_Project != null)
            {
                foreach (DataRow dr in dtPRJ_Project.Rows)
                {

                    if (!dr["ProjectID"].Equals(DBNull.Value))
                        lblProjectID.Text = Convert.ToString(dr["ProjectID"]);

                    if (!dr["ProjectTitle"].Equals(DBNull.Value))
                        lblProjectName.Text = Convert.ToString(dr["ProjectTitle"]);

                    if (!dr["ProjectShortTitle"].Equals(DBNull.Value))
                        lblProjectShortName.Text = Convert.ToString(dr["ProjectShortTitle"]);
                    
                    if (!dr["ProjectCode"].Equals(DBNull.Value))
                        lblProjectCode.Text = Convert.ToString(dr["ProjectCode"]);

                    if (!dr["Description"].Equals(DBNull.Value))
                        lblDescription.Text = Convert.ToString(dr["Description"]);

                    if (!dr["GuideName"].Equals(DBNull.Value))
                        lblGuideName.Text = Convert.ToString(dr["GuideName"]);

                    if (!dr["TechnologyName"].Equals(DBNull.Value))
                        lblTechnologyName.Text = Convert.ToString(dr["TechnologyName"]);

                    if (!dr["Semester"].Equals(DBNull.Value))
                        lblSemester.Text = Convert.ToString(dr["Semester"]);

                    if (!dr["Year"].Equals(DBNull.Value))
                        lblYear.Text = Convert.ToString(dr["Year"]);

                    if (!dr["DepartmentName"].Equals(DBNull.Value))
                        lblDepartmentName.Text = Convert.ToString(dr["DepartmentName"]);

                    if (!dr["AcademicYearName"].Equals(DBNull.Value))
                        lblAcademicYearName.Text = Convert.ToString(dr["AcademicYearName"]);

                    if (!dr["InstituteName"].Equals(DBNull.Value))
                        lblInstituteName.Text = Convert.ToString(dr["InstituteName"]);

                    if (!dr["Remarks"].Equals(DBNull.Value))
                        lblRemarks.Text = Convert.ToString(dr["Remarks"]);

                    if (!dr["Created"].Equals(DBNull.Value))
                        lblCreated.Text = Convert.ToString(dr["Created"]);

                    if (!dr["Modified"].Equals(DBNull.Value))
                        lblModified.Text = Convert.ToString(dr["Modified"]);

                }
            }
        }
    }
    #endregion FillControls
}