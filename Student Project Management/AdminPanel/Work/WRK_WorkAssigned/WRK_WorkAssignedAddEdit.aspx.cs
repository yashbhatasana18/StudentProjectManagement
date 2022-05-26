using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Web.UI;

public partial class AdminPanel_Work_WRK_WorkAssigned_WRK_WorkAssignedAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //ddlProjectID.Focus();
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            lblPageHeader.Text = "Add Work Assigned";

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
        CommonFillMethods.FillDropDownListStatusID(ddlStatusID);
    }

    #endregion 

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["workassignedid"] != null)
        {
            lblPageHeader.Text = "Edit Work Assigned";

            WRK_WorkAssignedBAL balWRK_WorkAssigned = new WRK_WorkAssignedBAL();
            WRK_WorkAssignedENT entWRK_WorkAssigned = new WRK_WorkAssignedENT();
            entWRK_WorkAssigned = balWRK_WorkAssigned.SelectPK(Convert.ToInt32(Request.QueryString["workassignedid"]));

            if (!entWRK_WorkAssigned.DeadLine.IsNull)
                txtDeadLine.Text = entWRK_WorkAssigned.DeadLine.Value.ToString("dd-MM-yyyy");

            if (!entWRK_WorkAssigned.WorkTobeDone.IsNull)
                txtWorkToBeDone.Text = entWRK_WorkAssigned.WorkTobeDone.Value.ToString();

            if (!entWRK_WorkAssigned.SubmittedDate.IsNull)
                txtSubmitDate.Text = entWRK_WorkAssigned.SubmittedDate.Value.ToString("dd-MM-yyyy");

            if (!entWRK_WorkAssigned.FacultyRemarks.IsNull)
                txtFacultyRemarks.Text = entWRK_WorkAssigned.FacultyRemarks.Value.ToString();

            if (!entWRK_WorkAssigned.StatusID.IsNull)
                ddlStatusID.SelectedValue = entWRK_WorkAssigned.StatusID.Value.ToString();

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
                WRK_WorkAssignedBAL balWRK_WorkAssigned = new WRK_WorkAssignedBAL();
                WRK_WorkAssignedENT entWRK_WorkAssigned = new WRK_WorkAssignedENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;

                if (ddlStatusID.SelectedIndex == 0)
                {
                    ErrorMsg += " - DepartmentID is Required Field <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion

                if (Session["StudentID"] != null)
                    entWRK_WorkAssigned.StudentID = Convert.ToInt32(Session["StudentID"]);

                if (Session["GuideID"] != null)
                    entWRK_WorkAssigned.FacultyID = Convert.ToInt32(Session["GuideID"]);

                if (Session["ProjectID"] != null)
                    entWRK_WorkAssigned.ProjectID = Convert.ToInt32(Session["ProjectID"]);

                entWRK_WorkAssigned.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entWRK_WorkAssigned.UserID = Convert.ToInt32(Session["UserID"]);

                if (txtDeadLine.Text.Trim() != String.Empty)
                    entWRK_WorkAssigned.DeadLine = DateTime.Parse(txtDeadLine.Text.Trim());

                if (txtWorkToBeDone.Text.Trim() != String.Empty)
                    entWRK_WorkAssigned.WorkTobeDone = txtWorkToBeDone.Text.Trim();

                if (txtSubmitDate.Text.Trim() != String.Empty)
                    entWRK_WorkAssigned.SubmittedDate = DateTime.Parse(txtSubmitDate.Text.Trim());

                if (txtFacultyRemarks.Text.Trim() != String.Empty)
                    entWRK_WorkAssigned.FacultyRemarks = txtFacultyRemarks.Text.Trim();

                if (ddlStatusID.SelectedIndex > 0)
                    entWRK_WorkAssigned.StatusID = Convert.ToInt32(ddlStatusID.SelectedValue);

                entWRK_WorkAssigned.Created = DateTime.Now;

                entWRK_WorkAssigned.Modified = DateTime.Now;


                #region Insert,Update,Copy

                if (Request.QueryString["workassignedid"] != null && Request.QueryString["Copy"] == null)
                {
                    entWRK_WorkAssigned.WorkAssignedID = Convert.ToInt32(Request.QueryString["workassignedid"]);
                    if (balWRK_WorkAssigned.Update(entWRK_WorkAssigned))
                    {
                        Response.Redirect("WRK_WorkAssignedList.aspx");
                    }
                    else
                    {
                        //ucMessage.ShowError(balWRK_WorkAssigned.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["workassignedid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balWRK_WorkAssigned.Insert(entWRK_WorkAssigned))
                        {
                            pnlAlert.Visible = true;
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
                lblErrorMsg.Text = ex.Message;
                //ucMessage.ShowError(ex.Message);
            }
        }
    }
    #endregion Save Button Event

    #region Clear Controls

    private void ClearControls()
    {
        txtDeadLine.Text = String.Empty;
        txtWorkToBeDone.Text = String.Empty;
        txtSubmitDate.Text = String.Empty;
        txtFacultyRemarks.Text = String.Empty;
        txtStudentEnrollmentNo.Text = String.Empty;
        ddlStatusID.SelectedIndex = 0;
    }

    #endregion Clear Controls 

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
        }
    }
    #endregion Show Button Event
}