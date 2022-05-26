using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Web.UI;

public partial class AdminPanel_Meeting_MET_Meeting_MET_MeetingAddEdit : System.Web.UI.Page
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
            lblPageHeader.Text = "Add Meeting";
            #region DropDown List Fill Section

            FillDropDownList();

            #endregion

            #region Fill Controls

            FillControls();

            #endregion

        }
    }
    #endregion Page Load Event

    #region Fill DropDownList

    private void FillDropDownList()
    {
        //CommonFillMethods.FillDropDownListStudentID(ddlStudentID, Convert.ToInt32(Session["InstituteID"]), Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["AcademicYearID"]));
        CommonFillMethods.FillDropDownListFacultyID(ddlFacultyID, Convert.ToInt32(Session["InstituteID"]));
    }

    #endregion 

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["meetingid"] != null)
        {
            //pnlDetails.Visible = true;

            lblPageHeader.Text = "Edit Meeting";

            MET_MeetingMasterBAL balMET_MeetingMaster = new MET_MeetingMasterBAL();
            MET_MeetingMasterENT entMET_MeetingMaster = new MET_MeetingMasterENT();

            entMET_MeetingMaster = balMET_MeetingMaster.SelectPK(Convert.ToInt32(Request.QueryString["meetingid"]));

            if (!entMET_MeetingMaster.MeetingDate.IsNull)
                txtMeetingDate.Text = entMET_MeetingMaster.MeetingDate.Value.ToString("dd-MM-yyyy");

            if (!entMET_MeetingMaster.NextMeetingDate.IsNull)
                txtNextMeetingDate.Text = entMET_MeetingMaster.NextMeetingDate.Value.ToString("dd-MM-yyyy");

            if (!entMET_MeetingMaster.WorkDone.IsNull)
                txtWorkDone.Text = entMET_MeetingMaster.WorkDone.Value.ToString();

            if (!entMET_MeetingMaster.WorkAssigned.IsNull)
                txtWorkAssigned.Text = entMET_MeetingMaster.WorkAssigned.Value.ToString();

            if (!entMET_MeetingMaster.MeetingDuration.IsNull)
                txtMeetingDuration.Text = entMET_MeetingMaster.MeetingDuration.Value.ToString();

            if (!entMET_MeetingMaster.FacultyRemarks.IsNull)
                txtFacultyRemarks.Text = entMET_MeetingMaster.FacultyRemarks.Value.ToString();

            if (!entMET_MeetingMaster.FacultyID.IsNull)
                ddlFacultyID.SelectedValue = entMET_MeetingMaster.FacultyID.Value.ToString();

        }
    }

    #endregion FillControls By PK 

    #region Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                MET_MeetingMasterBAL balMET_MeetingMaster = new MET_MeetingMasterBAL();
                MET_MeetingMasterENT entMET_MeetingMaster = new MET_MeetingMasterENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;

                if (txtWorkDone.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - WorkDone is Required Field  <br />";
                }
                if (ddlFacultyID.SelectedIndex == 0)
                {
                    ErrorMsg += " - FacultyID is Required Field <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    pnlAlert.Visible = true;
                    pnlAlert.CssClass = "alert-danger";
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    lblErrorMsg.Text = ErrorMsg;
                    return;
                }

                #endregion

                if (Session["StudentID"] != null)
                    entMET_MeetingMaster.StudentID = Convert.ToInt32(Session["StudentID"]);

                if (Session["GuideID"] != null)
                    entMET_MeetingMaster.FacultyID = Convert.ToInt32(Session["GuideID"]);

                if (txtMeetingDate.Text.Trim() != String.Empty)
                    entMET_MeetingMaster.MeetingDate = DateTime.Parse(txtMeetingDate.Text.Trim());

                if (txtNextMeetingDate.Text.Trim() != String.Empty)
                    entMET_MeetingMaster.NextMeetingDate = DateTime.Parse(txtNextMeetingDate.Text.Trim());

                if (txtWorkDone.Text.Trim() != String.Empty)
                    entMET_MeetingMaster.WorkDone = txtWorkDone.Text.Trim();

                if (txtWorkAssigned.Text.Trim() != String.Empty)
                    entMET_MeetingMaster.WorkAssigned = txtWorkAssigned.Text.Trim();

                if (txtMeetingDuration.Text.Trim() != String.Empty)
                    entMET_MeetingMaster.MeetingDuration = Convert.ToDecimal(txtMeetingDuration.Text.Trim());

                if (txtFacultyRemarks.Text.Trim() != String.Empty)
                    entMET_MeetingMaster.FacultyRemarks = txtFacultyRemarks.Text.Trim();

                if (ddlFacultyID.SelectedIndex > 0)
                    entMET_MeetingMaster.FacultyID = Convert.ToInt32(ddlFacultyID.SelectedValue);

                entMET_MeetingMaster.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entMET_MeetingMaster.UserID = Convert.ToInt32(Session["UserID"]);

                entMET_MeetingMaster.Created = DateTime.Now;

                entMET_MeetingMaster.Modified = DateTime.Now;

                #region Insert,Update,Copy

                if (Request.QueryString["meetingid"] != null && Request.QueryString["Copy"] == null)
                {
                    entMET_MeetingMaster.MeetingID = Convert.ToInt32(Request.QueryString["meetingid"]);
                    if (balMET_MeetingMaster.Update(entMET_MeetingMaster))
                    {
                        Response.Redirect("MET_MeetingList.aspx");
                    }
                    else
                    {
                        pnlAlert.Visible = true;
                        pnlAlert.CssClass = "alert-danger";
                        //ucMessage.ShowError(balMET_MeetingMaster.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["meetingid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMET_MeetingMaster.Insert(entMET_MeetingMaster))
                        {
                            pnlAlert.Visible = true;
                            pnlAlert.CssClass = "alert-success";
                            lblErrorMsg.Text = "Record Added Successfully";
                            //ucMessage.ShowSuccess("Record Added Successfully");
                            ClearControls();
                        }
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                pnlAlert.Visible = true;
                pnlAlert.CssClass = "alert-danger";
                lblErrorMsg.Text = ex.Message;
                //ucMessage.ShowError(ex.Message);
            }
        }
    }
    #endregion Save Button Event

    #region Clear Controls

    private void ClearControls()
    {
        txtMeetingDate.Text = String.Empty;
        txtNextMeetingDate.Text = String.Empty;
        txtWorkDone.Text = String.Empty;
        txtWorkAssigned.Text = String.Empty;
        txtMeetingDuration.Text = String.Empty;
        txtFacultyRemarks.Text = String.Empty;
        ddlFacultyID.SelectedIndex = 0;
    }

    #endregion Clear Controls

    #region Show Button Event
    protected void btnShow_Click(object sender, EventArgs e)
    {
        pnlDetails.Visible = true;
        if (txtStudentEnrollmentNo.Text.Trim() != null)
        {
            MET_MeetingMasterBAL balMET_MeetingMaster = new MET_MeetingMasterBAL();

            DataTable dtMET_MeetingMaster = balMET_MeetingMaster.SearchMeetingByStudentEnrollmentNo(Convert.ToString(txtStudentEnrollmentNo.Text.Trim()));
            if (dtMET_MeetingMaster != null && dtMET_MeetingMaster.Rows.Count>0)
            {
                SqlInt32 StudentID = SqlInt32.Null;
                foreach (DataRow dr in dtMET_MeetingMaster.Rows)
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
        }
    }
    #endregion Show Button Event
}