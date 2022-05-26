using DProject.BAL;
using System;
using System.Data;
using System.Web.UI;

public partial class AdminPanel_Project_PRJ_Technology_PRJ_TechnologyView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "Tecnology View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["technologyid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["technologyid"] != null)
        {
            PRJ_TechnologyBAL balPRJ_Technology = new PRJ_TechnologyBAL();
            DataTable dtPRJ_Technology = balPRJ_Technology.SelectView(Convert.ToInt32(Request.QueryString["technologyid"]));
            if (dtPRJ_Technology != null)
            {
                foreach (DataRow dr in dtPRJ_Technology.Rows)
                {

                    if (!dr["TechnologyID"].Equals(DBNull.Value))
                        lblTechnologyID.Text = Convert.ToString(dr["TechnologyID"]);

                    if (!dr["TechnologyName"].Equals(DBNull.Value))
                        lblTechnologyName.Text = Convert.ToString(dr["TechnologyName"]);

                    if (!dr["DepartmentName"].Equals(DBNull.Value))
                        lblDepartmentID.Text = Convert.ToString(dr["DepartmentName"]);

                    if (!dr["InstituteName"].Equals(DBNull.Value))
                        lblInstituteID.Text = Convert.ToString(dr["InstituteName"]);

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