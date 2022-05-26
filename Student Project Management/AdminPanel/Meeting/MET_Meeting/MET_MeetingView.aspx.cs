using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Meeting_MET_Meeting_MET_MeetingView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["meetingid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["meetingid"] != null)
        {
            MET_MeetingMasterBAL balMET_MeetingMaster = new MET_MeetingMasterBAL();
            DataTable dtMET_MeetingMaster = balMET_MeetingMaster.SelectView(Convert.ToInt32(Request.QueryString["meetingid"]));
            if (dtMET_MeetingMaster != null)
            {
                foreach (DataRow dr in dtMET_MeetingMaster.Rows)
                {

                    if (!dr["MeetingID"].Equals(DBNull.Value))
                        lblMeetingID.Text = Convert.ToString(dr["MeetingID"]);

                    if (!dr["ProjectCode"].Equals(DBNull.Value))
                        lblProjectID.Text = Convert.ToString(dr["ProjectCode"]);

                    if (!dr["MeetingDate"].Equals(DBNull.Value))
                        lblMeetingDate.Text = Convert.ToString(dr["MeetingDate"]);

                    if (!dr["NextMeetingDate"].Equals(DBNull.Value))
                        lblNextMeetingDate.Text = Convert.ToString(dr["NextMeetingDate"]);

                    if (!dr["WorkDone"].Equals(DBNull.Value))
                        lblWorkDone.Text = Convert.ToString(dr["WorkDone"]);

                    if (!dr["WorkAssigned"].Equals(DBNull.Value))
                        lblWorkAssigned.Text = Convert.ToString(dr["WorkAssigned"]);

                    if (!dr["MeetingDuration"].Equals(DBNull.Value))
                        lblMeetingDuration.Text = Convert.ToString(dr["MeetingDuration"]);

                    if (!dr["FacultyRemarks"].Equals(DBNull.Value))
                        lblFacultyRemarks.Text = Convert.ToString(dr["FacultyRemarks"]);

                    if (!dr["FacultyName"].Equals(DBNull.Value))
                        lblFacultyID.Text = Convert.ToString(dr["FacultyName"]);

                    if (!dr["InstituteName"].Equals(DBNull.Value))
                        lblInstituteID.Text = Convert.ToString(dr["InstituteName"]);

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