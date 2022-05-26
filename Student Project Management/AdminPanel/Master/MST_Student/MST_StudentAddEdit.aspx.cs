using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.IO;
using System.Web.UI;

public partial class AdminPanel_Master_MST_Student_MST_StudentAddEdit : System.Web.UI.Page
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
    }

    #endregion 

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["studentid"] != null)
        {
            lblPageHeader.Text = "Edit Student";
            MST_StudentBAL balMST_Student = new MST_StudentBAL();
            MST_StudentENT entMST_Student = new MST_StudentENT();

            entMST_Student = balMST_Student.SelectPK(Convert.ToInt32(Request.QueryString["studentid"]));

            if (!entMST_Student.StudentName.IsNull)
                txtStudentName.Text = entMST_Student.StudentName.Value.ToString();

            if (!entMST_Student.EnrollmentNo.IsNull)
                txtEnrollmentNo.Text = entMST_Student.EnrollmentNo.Value.ToString();

            if (!entMST_Student.Email.IsNull)
                txtEmail.Text = entMST_Student.Email.Value.ToString();

            if (!entMST_Student.DOB.IsNull)
                txtDOB.Text = entMST_Student.DOB.Value.ToString("dd-MM-yyyy");

            if (!entMST_Student.SignaturePath.IsNull)
            {
                ViewState["SignaturePath"] = entMST_Student.SignaturePath.Value;
                imgPhotoPath.ImageUrl = entMST_Student.SignaturePath.Value.ToString();
            }
            //if (!entMST_Student.SignaturePath.IsNull)
            //    lblSignaturePath.Text = entMST_Student.SignaturePath.Value.ToString();

            if (!entMST_Student.Mobile.IsNull)
                txtMobile.Text = entMST_Student.Mobile.Value.ToString();

            if (!entMST_Student.DepartmentID.IsNull)
                ddlDepartmentID.SelectedValue = entMST_Student.DepartmentID.Value.ToString();

            if (!entMST_Student.Remarks.IsNull)
                txtRemarks.Text = entMST_Student.Remarks.Value.ToString();

            //if (Request.QueryString["Copy"] != null)
            //{
            //    lblSignaturePath.Text = "";
            //}
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
                MST_StudentBAL balMST_Student = new MST_StudentBAL();
                MST_StudentENT entMST_Student = new MST_StudentENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtStudentName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - StudentName is Required Field  <br />";
                }
                if (txtEnrollmentNo.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - EnrollmentNo is Required Field  <br />";
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

                if (txtStudentName.Text.Trim() != String.Empty)
                    entMST_Student.StudentName = txtStudentName.Text.Trim();

                if (txtEnrollmentNo.Text.Trim() != String.Empty)
                    entMST_Student.EnrollmentNo = txtEnrollmentNo.Text.Trim();

                if (txtEmail.Text.Trim() != String.Empty)
                    entMST_Student.Email = txtEmail.Text.Trim();

                if (txtDOB.Text.Trim() != String.Empty)
                    entMST_Student.DOB = DateTime.Parse(txtDOB.Text.Trim());

                //if (fuSignature.FileName != String.Empty)
                //{
                //    if (lblSignaturePath.Text != String.Empty)
                //    {
                //        FileInfo file = new FileInfo(Server.MapPath(lblSignaturePath.Text));
                //        file.Delete();
                //    }

                //    fuSignature.SaveAs(Server.MapPath("~/StudentSignature/" + fuSignature.FileName));
                //    entMST_Student.SignaturePath = "~/StudentSignature/" + fuSignature.FileName;
                //}
                //else
                //{
                //    entMST_Student.SignaturePath = lblSignaturePath.Text;
                //}

                #region Upload PhotoPath
                if (fuSignature.HasFile)
                {
                    #region Create File Path
                    string strFileName = "", strFileExt = "", strFilePath = "";
                    strFileExt = System.IO.Path.GetExtension(fuSignature.PostedFile.FileName);
                    strFileName = fuSignature.PostedFile.FileName;
                    strFilePath = "~/StudentSignature/" + DateTime.Now.Year.ToString();

                    if (!Directory.Exists(Server.MapPath(strFilePath)))
                        Directory.CreateDirectory(Server.MapPath(strFilePath));
                    #endregion Create File Path

                    #region Upload File
                    if (ViewState["SignaturePath"] != null)
                    {
                        if (File.Exists(Server.MapPath(ViewState["SignaturePath"].ToString())))
                            File.Delete(Server.MapPath(ViewState["SignaturePath"].ToString()));
                    }

                    entMST_Student.SignaturePath = strFilePath + "/" + strFileName;
                    fuSignature.SaveAs(Server.MapPath(entMST_Student.SignaturePath.Value));
                    #endregion Upload File
                }
                else
                {
                    if (ViewState["SignaturePath"] != null)
                        entMST_Student.SignaturePath = ViewState["SignaturePath"].ToString();
                }
                #endregion Upload PhotoPath

                if (txtMobile.Text.Trim() != String.Empty)
                    entMST_Student.Mobile = txtMobile.Text.Trim();

                if (ddlDepartmentID.SelectedIndex > 0)
                    entMST_Student.DepartmentID = Convert.ToInt32(ddlDepartmentID.SelectedValue);

                entMST_Student.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entMST_Student.UserID = Convert.ToInt32(Session["UserID"]);

                if (txtRemarks.Text.Trim() != String.Empty)
                    entMST_Student.Remarks = txtRemarks.Text.Trim();

                entMST_Student.Created = DateTime.Now;

                entMST_Student.Modified = DateTime.Now;


                #region Insert,Update,Copy

                if (Request.QueryString["studentid"] != null && Request.QueryString["Copy"] == null)
                {
                    entMST_Student.StudentID = Convert.ToInt32(Request.QueryString["studentid"]);
                    if (balMST_Student.Update(entMST_Student))
                    {
                        Response.Redirect("MST_StudentList.aspx");
                    }
                    else
                    {
                        //ucMessage.ShowError(balMST_Student.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["studentid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMST_Student.Insert(entMST_Student))
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
        txtStudentName.Text = String.Empty;
        txtEnrollmentNo.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtDOB.Text = String.Empty;
        txtMobile.Text = String.Empty;
        ddlDepartmentID.SelectedIndex = 0;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls
}