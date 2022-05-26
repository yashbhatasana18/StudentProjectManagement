using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Web.UI;

public partial class AdminPanel_Project_PRJ_AssignProject_PRJ_AssignProjectAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        ddlProjectID.Focus();
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            lblPageHeader.Text = "Add Assign Project";

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
        CommonFillMethods.FillDropDownListProjectID(ddlProjectID, Convert.ToInt32(Session["InstituteID"]), Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["AcademicYearID"]));
        CommonFillMethods.FillDropDownListStudentID(ddlStudentID);
        //if (Request.QueryString["projectwisestudentid"] != null && Request.QueryString["Copy"] == null)
        //{
            
        //}
        //else
        //{
        //    CommonFillMethods.FillDropDownListStudentIDByProjectID(ddlStudentID, Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]));
        //}
    }

    #endregion

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["projectwisestudentid"] != null)
        {
            lblPageHeader.Text = "Edit Assign Project";
            PRJ_AssignProjectBAL balPRJ_AssignProject = new PRJ_AssignProjectBAL();
            PRJ_AssignProjectENT entPRJ_AssignProject = new PRJ_AssignProjectENT();
            entPRJ_AssignProject = balPRJ_AssignProject.SelectPK(Convert.ToInt32(Request.QueryString["projectwisestudentid"]));

            if (!entPRJ_AssignProject.ProjectID.IsNull)
            {
                ddlProjectID.SelectedValue = entPRJ_AssignProject.ProjectID.Value.ToString();
                if (Request.QueryString["projectwisestudentid"] != null && Request.QueryString["Copy"] == null)
                {
                    CommonFillMethods.FillDropDownListStudentIDProjectID(ddlStudentID, Convert.ToInt32(ddlProjectID.SelectedValue));
                }
            }

            if (!entPRJ_AssignProject.StudentID.IsNull)
                ddlStudentID.SelectedValue = entPRJ_AssignProject.StudentID.Value.ToString();

            if (!entPRJ_AssignProject.IsLeader.IsNull)
            {
                if (entPRJ_AssignProject.IsLeader.Value == true)
                {
                    rbNoisleader.Checked = false;
                    rbYesisleader.Checked = true;
                }
                if (entPRJ_AssignProject.IsLeader.Value == false)
                {
                    rbYesisleader.Checked = false;
                    rbNoisleader.Checked = true;
                }
            }

            if (!entPRJ_AssignProject.SequenceNo.IsNull)
                txtSequenceNo.Text = entPRJ_AssignProject.SequenceNo.Value.ToString();

            if (!entPRJ_AssignProject.InstituteID.IsNull)
                //ddlInstituteID.SelectedValue = entPRJ_AssignProject.InstituteID.Value.ToString();

                if (!entPRJ_AssignProject.Remarks.IsNull)
                    txtRemarks.Text = entPRJ_AssignProject.Remarks.Value.ToString();

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
                PRJ_AssignProjectBAL balPRJ_AssignProject = new PRJ_AssignProjectBAL();
                PRJ_AssignProjectENT entPRJ_AssignProject = new PRJ_AssignProjectENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (ddlProjectID.SelectedIndex == 0)
                {
                    ErrorMsg += " - ProjectID is Required Field <br />";
                }
                if (ddlStudentID.SelectedIndex == 0)
                {
                    ErrorMsg += " - StudentID is Required Field <br />";
                }
                if (txtSequenceNo.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - SequenceNo is Required Field  <br />";
                }
                
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion


                if (ddlProjectID.SelectedIndex > 0)
                    entPRJ_AssignProject.ProjectID = Convert.ToInt32(ddlProjectID.SelectedValue);

                if (ddlStudentID.SelectedIndex > 0)
                    entPRJ_AssignProject.StudentID = Convert.ToInt32(ddlStudentID.SelectedValue);

                if (rbYesisleader.Checked == true)
                    entPRJ_AssignProject.IsLeader = true;

                if (rbNoisleader.Checked == true)
                    entPRJ_AssignProject.IsLeader = false;

                if (txtSequenceNo.Text.Trim() != String.Empty)
                    entPRJ_AssignProject.SequenceNo = Convert.ToInt32(txtSequenceNo.Text.Trim());

                //if (ddlInstituteID.SelectedIndex > 0)
                entPRJ_AssignProject.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entPRJ_AssignProject.UserID = Convert.ToInt32(Session["UserID"]);

                if (txtRemarks.Text.Trim() != String.Empty)
                    entPRJ_AssignProject.Remarks = txtRemarks.Text.Trim();

                entPRJ_AssignProject.Created = DateTime.Now;

                entPRJ_AssignProject.Modified = DateTime.Now;


                #region Insert,Update,Copy

                if (Request.QueryString["projectwisestudentid"] != null && Request.QueryString["Copy"] == null)
                {
                    entPRJ_AssignProject.ProjectWiseStudentID = Convert.ToInt32(Request.QueryString["projectwisestudentid"]);
                    if (balPRJ_AssignProject.Update(entPRJ_AssignProject))
                    {
                        Response.Redirect("PRJ_AssignProjectList.aspx");
                    }
                    else
                    {
                        pnlAlert.Visible = true;
                        lblErrorMsg.Text = balPRJ_AssignProject.Message;
                        //ucMessage.ShowError(balPRJ_AssignProject.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["projectwisestudentid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balPRJ_AssignProject.Insert(entPRJ_AssignProject))
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
                pnlAlert.Visible = true;
                lblErrorMsg.Text = ex.Message;
                //ucMessage.ShowError(ex.Message);
            }
        }
    }
    #endregion Save Button Event

    #region Clear Controls

    private void ClearControls()
    {
        ddlProjectID.SelectedIndex = 0;
        ddlStudentID.SelectedIndex = 0;
        rbNoisleader.Checked = false;
        rbYesisleader.Checked = false;
        txtSequenceNo.Text = String.Empty;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls 
}