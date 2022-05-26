using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Project_PRJ_Guide_PRJ_GuideView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "Guide View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["guideid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["guideid"] != null)
        {
            PRJ_GuideBAL balPRJ_Guide = new PRJ_GuideBAL();
            DataTable dtPRJ_Guide = balPRJ_Guide.SelectView(Convert.ToInt32(Request.QueryString["guideid"]));
            if (dtPRJ_Guide != null)
            {
                foreach (DataRow dr in dtPRJ_Guide.Rows)
                {

                    if (!dr["GuideID"].Equals(DBNull.Value))
                        lblGuideID.Text = Convert.ToString(dr["GuideID"]);

                    if (!dr["GuideName"].Equals(DBNull.Value))
                        lblGuideName.Text = Convert.ToString(dr["GuideName"]);

                    if (!dr["GuideShortName"].Equals(DBNull.Value))
                        lblGuideShortName.Text = Convert.ToString(dr["GuideShortName"]);

                    if (!dr["IsActive"].Equals(DBNull.Value))
                        lblIsActive.Text = Convert.ToString(dr["IsActive"]);

                    if (!dr["DepartmentName"].Equals(DBNull.Value))
                        lblDepartmentID.Text = Convert.ToString(dr["DepartmentName"]);

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