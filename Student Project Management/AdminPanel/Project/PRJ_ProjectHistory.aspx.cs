using DProject.BAL;
using System;
using System.Data;
using System.Data.SqlTypes;

public partial class AdminPanel_Project_PRJ_ProjectHistory : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        try
        {
            if (!IsPostBack)
            {
                Session["FilterQuery"] = null;
                lblPageHeader.Text = "PROJECT HISTORY";
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    #endregion Page Load Event

    #region Show Button Event
    protected void btnShow_Click(object sender, EventArgs e)
    {
        pnlDetails.Visible = true;
        if (txtStudentEnrollmentNo.Text.Trim() != null)
        {
            WRK_WorkAssignedBAL balWRK_WorkAssigned = new WRK_WorkAssignedBAL();
            DataTable dtWRK_WorkAssigned = balWRK_WorkAssigned.SearchStudentByEnrollmentNo(Convert.ToString(txtStudentEnrollmentNo.Text.Trim()));
            if (dtWRK_WorkAssigned != null && dtWRK_WorkAssigned.Rows.Count > 0)
            {
                SqlInt32 StudentID = SqlInt32.Null;
                foreach (DataRow dr in dtWRK_WorkAssigned.Rows)
                {
                    if (!dr["StudentName"].Equals(DBNull.Value))
                    {
                        lblStudentName.Text = Convert.ToString(dr["StudentName"]);
                        Session["StudentID"] = Convert.ToInt32(dr["StudentID"]);
                    }

                    if (!dr["GuideName"].Equals(DBNull.Value))
                    {
                        lblGuideName.Text = Convert.ToString(dr["GuideName"]);
                        Session["GuideID"] = Convert.ToInt32(dr["GuideID"]);
                    }

                    if (!dr["ProjectTitle"].Equals(DBNull.Value))
                    {
                        lblProjectTitle.Text = Convert.ToString(dr["ProjectTitle"]);
                        Session["ProjectID"] = Convert.ToInt32(dr["ProjectID"]);
                    }
                }
            }
            else
            {
                pnlDetails.Visible = false;
                pnlAlert.Visible = true;
                pnlAlert.CssClass = "alert-danger";
                lblErrorMsg.Text = "No Record Found";
            }

            rptProjectHistory.DataSource = balWRK_WorkAssigned.SearchProjectHistoryByEnrollmentNo(Convert.ToString(txtStudentEnrollmentNo.Text.Trim()));
            rptProjectHistory.DataBind();
        }
    }
    #endregion Show Button Event

    #region Clear Button Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["FilterQuery"] = null;
        rptProjectHistory.DataBind();
    }
    #endregion Clear Button Event
}