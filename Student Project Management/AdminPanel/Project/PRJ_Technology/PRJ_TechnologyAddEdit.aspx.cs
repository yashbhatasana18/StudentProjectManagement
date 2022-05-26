using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Web.UI;

public partial class AdminPanel_Project_PRJ_Technology_PRJ_TechnologyAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        txtTechnologyName.Focus();
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            lblPageHeader.Text = "Add Technology";

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
        if (Request.QueryString["technologyid"] != null)
        {
            lblPageHeader.Text = "Edit Technology";
            PRJ_TechnologyBAL balPRJ_Technology = new PRJ_TechnologyBAL();
            PRJ_TechnologyENT entPRJ_Technology = new PRJ_TechnologyENT();
            entPRJ_Technology = balPRJ_Technology.SelectPK(Convert.ToInt32(Request.QueryString["technologyid"]));

            if (!entPRJ_Technology.TechnologyName.IsNull)
                txtTechnologyName.Text = entPRJ_Technology.TechnologyName.Value.ToString();

            if (!entPRJ_Technology.DepartmentID.IsNull)
                ddlDepartmentID.SelectedValue = entPRJ_Technology.DepartmentID.Value.ToString();

            if (!entPRJ_Technology.Remarks.IsNull)
                txtRemarks.Text = entPRJ_Technology.Remarks.Value.ToString();

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
                PRJ_TechnologyBAL balPRJ_Technology = new PRJ_TechnologyBAL();
                PRJ_TechnologyENT entPRJ_Technology = new PRJ_TechnologyENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtTechnologyName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - TechnologyName is Required Field  <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion Validate Fields


                if (txtTechnologyName.Text.Trim() != String.Empty)
                    entPRJ_Technology.TechnologyName = txtTechnologyName.Text.Trim();

                if (ddlDepartmentID.SelectedIndex > 0)
                    entPRJ_Technology.DepartmentID = Convert.ToInt32(ddlDepartmentID.SelectedValue);

                if (txtRemarks.Text.Trim() != String.Empty)
                    entPRJ_Technology.Remarks = txtRemarks.Text.Trim();

                entPRJ_Technology.UserID = Convert.ToInt32(Session["UserID"]);

                entPRJ_Technology.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entPRJ_Technology.Created = DateTime.Now;

                entPRJ_Technology.Modified = DateTime.Now;


                #region Insert,Update,Copy

                if (Request.QueryString["technologyid"] != null && Request.QueryString["Copy"] == null)
                {
                    entPRJ_Technology.TechnologyID = Convert.ToInt32(Request.QueryString["technologyid"]);
                    if (balPRJ_Technology.Update(entPRJ_Technology))
                    {
                        Response.Redirect("PRJ_TechnologyList.aspx");
                    }
                    else
                    {
                        lblErrorMsg.Text = balPRJ_Technology.Message;
                        //ucMessage.ShowError(balPRJ_Technology.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["technologyid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balPRJ_Technology.Insert(entPRJ_Technology))
                        {
                            if (Request.QueryString["reference"] != null)
                            {
                                Response.Write("<script language=javascript>if(window.opener != null && !window.opener.closed){window.opener.RefreshTechnology(" + entPRJ_Technology.TechnologyID.ToString() + ");window.close();}</script>");
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
        txtTechnologyName.Text = String.Empty;
        ddlDepartmentID.SelectedIndex = 0;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls 
}