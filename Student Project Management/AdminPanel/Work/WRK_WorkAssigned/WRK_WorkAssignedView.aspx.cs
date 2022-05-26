using DProject.BAL;
using System;
using System.Data;
using System.Web.UI;

public partial class AdminPanel_Work_WRK_WorkAssigned_WRK_WorkAssignedView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "WorkAssigned View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["workassignedid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["workassignedid"] != null)
        {
            WRK_WorkAssignedBAL balWRK_WorkAssigned = new WRK_WorkAssignedBAL();
            DataTable dtWRK_WorkAssigned = balWRK_WorkAssigned.SelectView(Convert.ToInt32(Request.QueryString["workassignedid"]));
            if (dtWRK_WorkAssigned != null)
            {
                foreach (DataRow dr in dtWRK_WorkAssigned.Rows)
                {

                    if (!dr["WorkAssignedID"].Equals(DBNull.Value))
                        lblWorkAssignedID.Text = Convert.ToString(dr["WorkAssignedID"]);

                    if (!dr["GuideName"].Equals(DBNull.Value))
                        lblGuideName.Text = Convert.ToString(dr["GuideName"]);

                    if (!dr["ProjectCode"].Equals(DBNull.Value))
                        lblProjectCode.Text = Convert.ToString(dr["ProjectCode"]);

                    if (!dr["ProjectTitle"].Equals(DBNull.Value))
                        lblProjectTitle.Text = Convert.ToString(dr["ProjectTitle"]);

                    if (!dr["StudentName"].Equals(DBNull.Value))
                        lblStudentName.Text = Convert.ToString(dr["StudentName"]);

                    if (!dr["EnrollmentNo"].Equals(DBNull.Value))
                        lblEnrollmentNo.Text = Convert.ToString(dr["EnrollmentNo"]);

                    if (!dr["DeadLine"].Equals(DBNull.Value))
                        lblDeadLine.Text = Convert.ToString(dr["DeadLine"]);

                    if (!dr["WorkTobeDone"].Equals(DBNull.Value))
                        lblWorkTobeDone.Text = Convert.ToString(dr["WorkTobeDone"]);

                    if (!dr["SubmittedDate"].Equals(DBNull.Value))
                        lblSubmittedDate.Text = Convert.ToString(dr["SubmittedDate"]);

                    if (!dr["FacultyRemarks"].Equals(DBNull.Value))
                        lblFacultyRemarks.Text = Convert.ToString(dr["FacultyRemarks"]);

                    if (!dr["InstituteName"].Equals(DBNull.Value))
                        lblInstituteName.Text = Convert.ToString(dr["InstituteName"]);

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