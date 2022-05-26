using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Web.UI;

public partial class AdminPanel_Document_DOC_DocumentType_DOC_DocumentTypeAddEdit : System.Web.UI.Page
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
            lblPageHeader.Text = "Add Student";
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
        CommonFillMethods.FillDropDownListAcademicYearID(ddlAcademicYearID);
    }

    #endregion 

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["documenttypeid"] != null)
        {
            lblPageHeader.Text = "Edit Student";
            DOC_DocumentTypeBAL balDOC_DocumentType = new DOC_DocumentTypeBAL();
            DOC_DocumentTypeENT entDOC_DocumentType = new DOC_DocumentTypeENT();
            entDOC_DocumentType = balDOC_DocumentType.SelectPK(Convert.ToInt32(Request.QueryString["documenttypeid"]));

            if (!entDOC_DocumentType.DocumentTypeName.IsNull)
                txtDocumentTypeName.Text = entDOC_DocumentType.DocumentTypeName.Value.ToString();

            if (!entDOC_DocumentType.IsInternal.IsNull)
            {
                if (entDOC_DocumentType.IsInternal == true)
                {
                    rbYesinternal.Checked = true;
                    rbNointernal.Checked = false;
                }
                if (entDOC_DocumentType.IsInternal == false)
                {
                    rbNointernal.Checked = true;
                    rbYesinternal.Checked = false;
                }
            }
            if (!entDOC_DocumentType.IsGTU.IsNull)
            {
                if (entDOC_DocumentType.IsGTU == true)
                {
                    rbYesgtu.Checked = true;
                    rbNogtu.Checked = false;
                }
                if (entDOC_DocumentType.IsGTU == false)
                {
                    rbYesgtu.Checked = false;
                    rbNogtu.Checked = true;
                }
            }

            if (!entDOC_DocumentType.IsCompulsory.IsNull)
            {
                if (entDOC_DocumentType.IsCompulsory == true)
                {
                    rbNocompulsory.Checked = false;
                    rbYescompulsory.Checked = true;
                }
                if (entDOC_DocumentType.IsCompulsory == false)
                {
                    rbYescompulsory.Checked = false;
                    rbNocompulsory.Checked = true;
                }
            }

            if (!entDOC_DocumentType.IsGanttChart.IsNull)
            {
                if (entDOC_DocumentType.IsGanttChart == true)
                {
                    rbYesgantchart.Checked = true;
                    rbNogantchart.Checked = false;
                }
                if (entDOC_DocumentType.IsGanttChart == false)
                {
                    rbYesgantchart.Checked = false;
                    rbNogantchart.Checked = true;
                }
            }

            if (!entDOC_DocumentType.DeadLine.IsNull)
                txtDeadLine.Text = entDOC_DocumentType.DeadLine.Value.ToString("dd-MM-yyyy");

            if (!entDOC_DocumentType.DepartmentID.IsNull)
                ddlDepartmentID.SelectedValue = entDOC_DocumentType.DepartmentID.Value.ToString();

            if (!entDOC_DocumentType.AcademicYearID.IsNull)
                ddlAcademicYearID.SelectedValue = entDOC_DocumentType.AcademicYearID.Value.ToString();

            if (!entDOC_DocumentType.Remarks.IsNull)
                txtRemarks.Text = entDOC_DocumentType.Remarks.Value.ToString();
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
                DOC_DocumentTypeBAL balDOC_DocumentType = new DOC_DocumentTypeBAL();
                DOC_DocumentTypeENT entDOC_DocumentType = new DOC_DocumentTypeENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtDocumentTypeName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - DocumentTypeName is Required Field  <br />";
                }
                if (ddlAcademicYearID.SelectedIndex == 0)
                {
                    ErrorMsg += " - AcademicYearID is Required Field <br />";
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

                #endregion

                if (txtDocumentTypeName.Text.Trim() != String.Empty)
                    entDOC_DocumentType.DocumentTypeName = txtDocumentTypeName.Text.Trim();

                if (txtDeadLine.Text.Trim() != String.Empty)
                    entDOC_DocumentType.DeadLine = Convert.ToDateTime(txtDeadLine.Text.Trim());

                if (rbYesinternal.Checked == true)
                    entDOC_DocumentType.IsInternal = true;

                if (rbNointernal.Checked == true)
                    entDOC_DocumentType.IsInternal = false;

                if (rbYesgtu.Checked == true)
                    entDOC_DocumentType.IsGTU = true;

                if (rbNogtu.Checked == true)
                    entDOC_DocumentType.IsGTU = false;

                if (rbYescompulsory.Checked == true)
                    entDOC_DocumentType.IsCompulsory = true;

                if (rbNocompulsory.Checked == true)
                    entDOC_DocumentType.IsCompulsory = false;

                if (rbYesgantchart.Checked == true)
                    entDOC_DocumentType.IsGanttChart = true;

                if (rbNogantchart.Checked == true)
                    entDOC_DocumentType.IsGanttChart = false;

                if (ddlDepartmentID.SelectedIndex > 0)
                    entDOC_DocumentType.DepartmentID = Convert.ToInt32(ddlDepartmentID.SelectedValue);

                if (ddlAcademicYearID.SelectedIndex > 0)
                    entDOC_DocumentType.AcademicYearID = Convert.ToInt32(ddlAcademicYearID.SelectedValue);

                entDOC_DocumentType.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entDOC_DocumentType.UserID = Convert.ToInt32(Session["UserID"]);

                if (txtRemarks.Text.Trim() != String.Empty)
                    entDOC_DocumentType.Remarks = txtRemarks.Text.Trim();

                entDOC_DocumentType.Created = DateTime.Now;

                entDOC_DocumentType.Modified = DateTime.Now;

                #region Insert,Update,Copy

                if (Request.QueryString["documenttypeid"] != null && Request.QueryString["Copy"] == null)
                {
                    entDOC_DocumentType.DocumentTypeID = Convert.ToInt32(Request.QueryString["documenttypeid"]);
                    if (balDOC_DocumentType.Update(entDOC_DocumentType))
                    {
                        Response.Redirect("DOC_DocumentTypeList.aspx");
                    }
                    else
                    {
                        //ucMessage.ShowError(balDOC_DocumentType.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["documenttypeid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balDOC_DocumentType.Insert(entDOC_DocumentType))
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
        txtDocumentTypeName.Text = String.Empty;
        rbYesinternal.Checked = true;
        rbNointernal.Checked = false;
        rbYesgtu.Checked = true;
        rbNogtu.Checked = false;
        rbYescompulsory.Checked = true;
        rbNocompulsory.Checked = false;
        rbYesgantchart.Checked = true;
        rbNogantchart.Checked = false;
        ddlAcademicYearID.SelectedIndex = 0;
        ddlDepartmentID.SelectedIndex = 0;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls
}