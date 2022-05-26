using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Web.UI;

public partial class AdminPanel_Project_PRJ_Guide_PRJ_GuideAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        txtGuideName.Focus();
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            lblPageHeader.Text = "Add Guide";

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
    }

    #endregion

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["guideid"] != null)
        {
            lblPageHeader.Text = "Edit Guide";
            PRJ_GuideBAL balPRJ_Guide = new PRJ_GuideBAL();
            PRJ_GuideENT entPRJ_Guide = new PRJ_GuideENT();
            entPRJ_Guide = balPRJ_Guide.SelectPK(Convert.ToInt32(Request.QueryString["guideid"]));

            if (!entPRJ_Guide.GuideName.IsNull)
                txtGuideName.Text = entPRJ_Guide.GuideName.Value.ToString();

            if (!entPRJ_Guide.GuideShortName.IsNull)
                txtGuideShortName.Text = entPRJ_Guide.GuideShortName.Value.ToString();

            if (!entPRJ_Guide.IsActive.IsNull)
            {
                if (entPRJ_Guide.IsActive == true)
                {
                    rbYesActive.Checked = true;
                    rbNoActive.Checked = false;
                }
                if (entPRJ_Guide.IsActive == false)
                {
                    rbNoActive.Checked = true;
                    rbYesActive.Checked = false;
                }
            }

            if (!entPRJ_Guide.DepartmentID.IsNull)
                ddlDepartmentID.SelectedValue = entPRJ_Guide.DepartmentID.Value.ToString();

            if (!entPRJ_Guide.Remarks.IsNull)
                txtRemarks.Text = entPRJ_Guide.Remarks.Value.ToString();

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
                PRJ_GuideBAL balPRJ_Guide = new PRJ_GuideBAL();
                PRJ_GuideENT entPRJ_Guide = new PRJ_GuideENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtGuideName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - GuideName is Required Field  <br />";
                }
                if (txtGuideShortName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - GuideShortName is Required Field  <br />";
                }
                if (ddlDepartmentID.SelectedIndex == 0)
                {
                    ErrorMsg += " - DepartmentID is Required Field <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion Validate Fields


                if (txtGuideName.Text.Trim() != String.Empty)
                    entPRJ_Guide.GuideName = txtGuideName.Text.Trim();

                if (txtGuideShortName.Text.Trim() != String.Empty)
                    entPRJ_Guide.GuideShortName = txtGuideShortName.Text.Trim();

                if (rbYesActive.Checked == true)
                    entPRJ_Guide.IsActive = true;

                if (rbNoActive.Checked == true)
                    entPRJ_Guide.IsActive = false;

                if (ddlDepartmentID.SelectedIndex > 0)
                    entPRJ_Guide.DepartmentID = Convert.ToInt32(ddlDepartmentID.SelectedValue);

                if (txtRemarks.Text.Trim() != String.Empty)
                    entPRJ_Guide.Remarks = txtRemarks.Text.Trim();

                entPRJ_Guide.UserID = Convert.ToInt32(Session["UserID"]);

                entPRJ_Guide.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entPRJ_Guide.Created = DateTime.Now;

                entPRJ_Guide.Modified = DateTime.Now;


                #region Insert,Update,Copy

                if (Request.QueryString["guideid"] != null && Request.QueryString["Copy"] == null)
                {
                    entPRJ_Guide.GuideID = Convert.ToInt32(Request.QueryString["guideid"]);
                    if (balPRJ_Guide.Update(entPRJ_Guide))
                    {
                        Response.Redirect("PRJ_GuideList.aspx");
                    }
                    else
                    {
                        lblErrorMsg.Text = balPRJ_Guide.Message;
                        //ucMessage.ShowError(balPRJ_Guide.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["guideid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balPRJ_Guide.Insert(entPRJ_Guide))
                        {
                            if (Request.QueryString["reference"] != null)
                            {
                                Response.Write("<script language=javascript>if(window.opener != null && !window.opener.closed){window.opener.RefreshGuide(" + entPRJ_Guide.GuideID.ToString() + ");window.close();}</script>");
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
        txtGuideName.Text = String.Empty;
        txtGuideShortName.Text = String.Empty;
        rbYesActive.Checked = true;
        rbNoActive.Checked = false;
        ddlDepartmentID.SelectedIndex = 0;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls 
}