using DProject.BAL;
using System;
using System.Data;
using System.Web.UI;

public partial class AdminPanel_Project_PRJ_AssignProject_PRJ_AssignProjectView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "Project Wise Student View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["projectwisestudentid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["projectwisestudentid"] != null)
        {
            PRJ_AssignProjectBAL balPRJ_AssignProject = new PRJ_AssignProjectBAL();
            DataTable dtPRJ_AssignProject = balPRJ_AssignProject.SelectView(Convert.ToInt32(Request.QueryString["projectwisestudentid"]));
            if (dtPRJ_AssignProject != null)
            {
                foreach (DataRow dr in dtPRJ_AssignProject.Rows)
                {

                    if (!dr["ProjectWiseStudentID"].Equals(DBNull.Value))
                        lblProjectWiseStudentID.Text = Convert.ToString(dr["ProjectWiseStudentID"]);

                    if (!dr["ProjectCode"].Equals(DBNull.Value))
                        lblProjectID.Text = Convert.ToString(dr["ProjectTitle"]);

                    if (!dr["StudentName"].Equals(DBNull.Value))
                        lblStudentID.Text = Convert.ToString(dr["StudentName"]);

                    if (!dr["IsLeader"].Equals(DBNull.Value))
                        lblIsLeader.Text = Convert.ToString(dr["IsLeader"]);

                    if (!dr["SequenceNo"].Equals(DBNull.Value))
                        lblSequenceNo.Text = Convert.ToString(dr["SequenceNo"]);

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