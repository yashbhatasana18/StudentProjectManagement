using DProject;
using DProject.BAL;
using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.IO;
using System.Web.UI;

public partial class AdminPanel_Document_DOC_ProjectDocument_DOC_ProjectDocumentAddEdit : System.Web.UI.Page
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
            lblPageHeader.Text = "Add Project Document";
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
        CommonFillMethods.FillDropDownListDocumentTypeID(ddlDocumentTypeID, Session["UserCatagory"].ToString(), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]));
        CommonFillMethods.FillDropDownListProjectID(ddlProjectID, Convert.ToInt32(Session["InstituteID"]), Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["AcademicYearID"]));
    }

    #endregion 

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["projectdocumentid"] != null)
        {
            lblPageHeader.Text = "Edit Project Document";
            DOC_ProjectDocumentBAL balDOC_ProjectDocument = new DOC_ProjectDocumentBAL();
            DOC_ProjectDocumentENT entDOC_ProjectDocument = new DOC_ProjectDocumentENT();
            entDOC_ProjectDocument = balDOC_ProjectDocument.SelectPK(Convert.ToInt32(Request.QueryString["ProjectDocumentid"]));

            if (!entDOC_ProjectDocument.DocumentTypeID.IsNull)
                ddlDocumentTypeID.SelectedValue = entDOC_ProjectDocument.DocumentTypeID.Value.ToString();

            if (!entDOC_ProjectDocument.ProjectID.IsNull)
                ddlProjectID.SelectedValue = entDOC_ProjectDocument.ProjectID.Value.ToString();

            if (!entDOC_ProjectDocument.DocumentName.IsNull)
                txtDocumentName.Text = entDOC_ProjectDocument.DocumentName.Value.ToString();

            if (!entDOC_ProjectDocument.DocumentPath.IsNull)
                lblDocumentPath.Text = entDOC_ProjectDocument.DocumentPath.Value.ToString();

            if (!entDOC_ProjectDocument.SubmissionDate.IsNull)
                txtSubmissionDate.Text = entDOC_ProjectDocument.SubmissionDate.Value.ToString("dd-MM-yyyy");

            if (!entDOC_ProjectDocument.Remarks.IsNull)
                txtRemarks.Text = entDOC_ProjectDocument.Remarks.Value.ToString();

            if (Request.QueryString["Copy"] != null)
            {
                lblDocumentPath.Text = "";
            }
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
                DOC_ProjectDocumentBAL balDOC_ProjectDocument = new DOC_ProjectDocumentBAL();
                DOC_ProjectDocumentENT entDOC_ProjectDocument = new DOC_ProjectDocumentENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (ddlDocumentTypeID.SelectedIndex == 0)
                {
                    ErrorMsg += " - DocumentTypeID is Required Field <br />";
                }
                if (ddlProjectID.SelectedIndex == 0)
                {
                    ErrorMsg += " - ProjectID is Required Field <br />";
                }
                if (txtDocumentName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - DocumentName is Required Field  <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion

                if (ddlDocumentTypeID.SelectedIndex > 0)
                    entDOC_ProjectDocument.DocumentTypeID = Convert.ToInt32(ddlDocumentTypeID.SelectedValue);

                if (ddlProjectID.SelectedIndex > 0)
                    entDOC_ProjectDocument.ProjectID = Convert.ToInt32(ddlProjectID.SelectedValue);

                if (fuDocument.FileName != String.Empty)
                {
                    if (lblDocumentPath.Text != String.Empty)
                    {
                        FileInfo file = new FileInfo(lblDocumentPath.Text);
                        file.Delete();
                    }
                    DOC_ProjectDocumentDAL dalDOC_ProjectDocument = new DOC_ProjectDocumentDAL();
                    DataTable DocumentName = dalDOC_ProjectDocument.SelectGTUTeamNoByProjectID(Convert.ToInt32(ddlProjectID.SelectedValue));
                    string name = "";
                    string GTUTeamNo = "";
                    if (DocumentName.Rows.Count > 0)
                    {
                        foreach (DataRow dr in DocumentName.Rows)
                        {
                            name = dr["DepartmentCode"].ToString() + "_" + dr["AcademicYearName"].ToString() + "_" + dr["GTUTeamNo"].ToString() + "_" + ddlDocumentTypeID.SelectedItem.ToString();
                            GTUTeamNo = dr["GTUTeamNo"].ToString();
                        }
                    }
                    string directoryPath = Server.MapPath(string.Format("~/UploadDocument/" + Session["AcademicYearName"]).ToString() + "/" + (Session["DepartmentCode"]).ToString() + "/" + GTUTeamNo);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    String extension = Path.GetExtension(fuDocument.PostedFile.FileName);
                    fuDocument.SaveAs(Path.Combine(directoryPath, name + extension));
                    entDOC_ProjectDocument.DocumentPath = Path.Combine(directoryPath, name + extension);
                    if (txtDocumentName.Text.Trim() != String.Empty)
                        entDOC_ProjectDocument.DocumentName = name + extension;
                }
                else
                {
                    entDOC_ProjectDocument.DocumentPath = lblDocumentPath.Text;
                }

                if (txtSubmissionDate.Text.Trim() != String.Empty)
                    entDOC_ProjectDocument.SubmissionDate = Convert.ToDateTime(txtSubmissionDate.Text.Trim());

                if (txtRemarks.Text.Trim() != String.Empty)
                    entDOC_ProjectDocument.Remarks = txtRemarks.Text.Trim();

                entDOC_ProjectDocument.AcademicYearID = Convert.ToInt32(Session["AcademicYearID"]);

                entDOC_ProjectDocument.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entDOC_ProjectDocument.UserID = Convert.ToInt32(Session["UserID"]);

                entDOC_ProjectDocument.Created = DateTime.Now;

                entDOC_ProjectDocument.Modified = DateTime.Now;

                #region Insert,Update,Copy

                if (Request.QueryString["projectdocumentid"] != null && Request.QueryString["Copy"] == null)
                {
                    entDOC_ProjectDocument.ProjectDocumentID = Convert.ToInt32(Request.QueryString["projectdocumentid"]);
                    if (balDOC_ProjectDocument.Update(entDOC_ProjectDocument))
                    {
                        Response.Redirect("DOC_ProjectDocumentList.aspx");
                    }
                    else
                    {
                        //ucMessage.ShowError(balDOC_ProjectDocument.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["projectdocumentid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balDOC_ProjectDocument.Insert(entDOC_ProjectDocument))
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
        ddlDocumentTypeID.SelectedIndex = 0;
        ddlProjectID.SelectedIndex = 0;
        txtDocumentName.Text = String.Empty;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls
}