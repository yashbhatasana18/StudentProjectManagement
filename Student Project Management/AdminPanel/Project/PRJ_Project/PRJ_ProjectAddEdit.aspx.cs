using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Web.UI;

public partial class AdminPanel_Project_PRJ_Project_PRJ_ProjectAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        txtProjectTitle.Focus();
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            lblPageHeader.Text = "Add Project";

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
        CommonFillMethods.FillDropDownListInstDepartment(ddlDepartmentID, Convert.ToInt32(Session["InstituteID"]));
        CommonFillMethods.FillDropDownListTechnologyID(ddlTechnologyID);
        CommonFillMethods.FillDropDownListGuideID(ddlGuideID);
    }

    #endregion

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["projectid"] != null)
        {
            lblPageHeader.Text = "Edit Project";
            PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
            PRJ_ProjectENT entPRJ_Project = new PRJ_ProjectENT();
            entPRJ_Project = balPRJ_Project.SelectPK(Convert.ToInt32(Request.QueryString["projectid"]));

            if (!entPRJ_Project.ProjectTitle.IsNull)
                txtProjectTitle.Text = entPRJ_Project.ProjectTitle.Value.ToString();

            if (!entPRJ_Project.ProjectShortTitle.IsNull)
                txtProjectShortTitle.Text = entPRJ_Project.ProjectShortTitle.Value.ToString();

            if (!entPRJ_Project.ProjectCode.IsNull)
                txtProjectCode.Text = entPRJ_Project.ProjectCode.Value.ToString();

            if (!entPRJ_Project.GuideID.IsNull)
                ddlGuideID.SelectedValue = entPRJ_Project.GuideID.Value.ToString();

            if (!entPRJ_Project.Description.IsNull)
                txtDescription.Text = entPRJ_Project.Description.Value.ToString();

            if (!entPRJ_Project.DepartmentID.IsNull)
                ddlDepartmentID.SelectedValue = entPRJ_Project.DepartmentID.Value.ToString();

            //if (!entPRJ_Project.Semester.IsNull)
            //    txtSemester.Text = entPRJ_Project.Semester.Value.ToString();

            //if (!entPRJ_Project.Year.IsNull)
            //    txtYear.Text = entPRJ_Project.Year.Value.ToString();

            if (!entPRJ_Project.TechnologyID.IsNull)
                ddlTechnologyID.SelectedValue = entPRJ_Project.TechnologyID.Value.ToString();

            if (!entPRJ_Project.Remarks.IsNull)
                txtRemarks.Text = entPRJ_Project.Remarks.Value.ToString();

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
                PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
                PRJ_ProjectENT entPRJ_Project = new PRJ_ProjectENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtProjectTitle.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - ProjectTitle is Required Field  <br />";
                }
                if (txtProjectShortTitle.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - ProjectShortTitle is Required Field  <br />";
                }
                if (txtProjectCode.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - ProjectCode is Required Field  <br />";
                }
                //if (txtSemester.Text.Trim() == String.Empty)
                //{
                //    ErrorMsg += " - Semester is Required Field  <br />";
                //}
                //if (txtYear.Text.Trim() == String.Empty)
                //{
                //    ErrorMsg += " - Year is Required Field  <br />";
                //}
                if (ddlDepartmentID.SelectedIndex == 0)
                {
                    ErrorMsg += " - DepartmentID is Required Field <br />";
                }
                if (ddlGuideID.SelectedIndex == 0)
                {
                    ErrorMsg += " - GuideID is Required Field <br />";
                }
                if (ddlTechnologyID.SelectedIndex == 0)
                {
                    ErrorMsg += " - TechnologyID is Required Field <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion Validate Fields

                if (txtProjectTitle.Text.Trim() != String.Empty)
                    entPRJ_Project.ProjectTitle = txtProjectTitle.Text.Trim();

                if (txtProjectShortTitle.Text.Trim() != String.Empty)
                    entPRJ_Project.ProjectShortTitle = txtProjectShortTitle.Text.Trim();

                if (txtProjectCode.Text.Trim() != String.Empty)
                    entPRJ_Project.ProjectCode = txtProjectCode.Text.Trim();

                if (ddlGuideID.SelectedIndex > 0)
                    entPRJ_Project.GuideID = Convert.ToInt32(ddlGuideID.SelectedValue);

                if (txtDescription.Text.Trim() != String.Empty)
                    entPRJ_Project.Description = txtDescription.Text.Trim();

                if (ddlDepartmentID.SelectedIndex > 0)
                    entPRJ_Project.DepartmentID = Convert.ToInt32(ddlDepartmentID.SelectedValue);

                //if (txtSemester.Text.Trim() != String.Empty)
                //    entPRJ_Project.Semester = Convert.ToInt32(txtSemester.Text.Trim());

                //if (txtYear.Text.Trim() != String.Empty)
                //    entPRJ_Project.Year = Convert.ToInt32(txtYear.Text.Trim());

                if (ddlTechnologyID.SelectedIndex > 0)
                    entPRJ_Project.TechnologyID = Convert.ToInt32(ddlTechnologyID.SelectedValue);

                if (txtRemarks.Text.Trim() != String.Empty)
                    entPRJ_Project.Remarks = txtRemarks.Text.Trim();

                entPRJ_Project.UserID = Convert.ToInt32(Session["UserID"]);

                entPRJ_Project.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entPRJ_Project.AcademicYearID = Convert.ToInt32(Session["AcademicYearID"]);

                entPRJ_Project.Created = DateTime.Now;

                entPRJ_Project.Modified = DateTime.Now;


                #region Insert,Update,Copy

                if (Request.QueryString["projectid"] != null && Request.QueryString["Copy"] == null)
                {
                    entPRJ_Project.ProjectID = Convert.ToInt32(Request.QueryString["projectid"]);
                    if (balPRJ_Project.Update(entPRJ_Project))
                    {
                        Response.Redirect("PRJ_ProjectList.aspx");
                    }
                    else
                    {
                        lblErrorMsg.Text = balPRJ_Project.Message;
                        //ucMessage.ShowError(balPRJ_Project.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["projectid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balPRJ_Project.Insert(entPRJ_Project))
                        {
                            if (Request.QueryString["reference"] != null)
                            {
                                Response.Write("<script language=javascript>if(window.opener != null && !window.opener.closed){window.opener.RefreshGuide(" + entPRJ_Project.ProjectID.ToString() + ");window.close();}</script>");
                                //Response.Write("<script>window.opener.location.reload(true);window.close();</" + "script>");
                                Response.End();
                            }
                            pnlAlert.Visible = true;
                            lblErrorMsg.Text = "Record Added Successfully";
                            //ucMessage.ShowSuccess("Record Added Successfully");
                            ClearControls();
                        }
                    }
                }

                #endregion Insert,Update,Copy

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
        txtProjectTitle.Text = String.Empty;
        txtProjectShortTitle.Text = String.Empty;
        txtProjectCode.Text = String.Empty;
        ddlGuideID.SelectedIndex = 0;
        txtDescription.Text = String.Empty;
        ddlDepartmentID.SelectedIndex = 0;
        //txtSemester.Text = String.Empty;
        //txtYear.Text = String.Empty;
        ddlTechnologyID.SelectedIndex = 0;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls 
}