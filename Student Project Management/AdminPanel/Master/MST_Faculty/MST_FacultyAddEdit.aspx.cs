using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Faculty_MST_FacultyAddEdit : System.Web.UI.Page
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
            lblPageHeader.Text = "Add Faculty";
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
        CommonFillMethods.FillDropDownListCityID(ddlCityID);
    }

    #endregion 

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["facultyid"] != null)
        {
            lblPageHeader.Text = "Edit Faculty";
            MST_FacultyBAL balMST_Faculty = new MST_FacultyBAL();
            MST_FacultyENT entMST_Faculty = new MST_FacultyENT();
            entMST_Faculty = balMST_Faculty.SelectPK(Convert.ToInt32(Request.QueryString["facultyid"]));

            if (!entMST_Faculty.FacultyName.IsNull)
                txtFacultyName.Text = entMST_Faculty.FacultyName.Value.ToString();

            if (!entMST_Faculty.FacultyShortName.IsNull)
                txtFacultyShortName.Text = entMST_Faculty.FacultyShortName.Value.ToString();

            if (!entMST_Faculty.DepartmentID.IsNull)
                ddlDepartmentID.SelectedValue = entMST_Faculty.DepartmentID.Value.ToString();

            if (!entMST_Faculty.Address.IsNull)
                txtAddress.Text = entMST_Faculty.Address.Value.ToString();

            if (!entMST_Faculty.CityID.IsNull)
                ddlCityID.SelectedValue = entMST_Faculty.CityID.Value.ToString();

            if (!entMST_Faculty.Pincode.IsNull)
                txtPincode.Text = entMST_Faculty.Pincode.Value.ToString();

            if (!entMST_Faculty.Phone.IsNull)
                txtPhone.Text = entMST_Faculty.Phone.Value.ToString();

            if (!entMST_Faculty.Mobile.IsNull)
                txtMobile.Text = entMST_Faculty.Mobile.Value.ToString();

            if (!entMST_Faculty.Email.IsNull)
                txtEmail.Text = entMST_Faculty.Email.Value.ToString();

            if (!entMST_Faculty.Website.IsNull)
                txtWebsite.Text = entMST_Faculty.Website.Value.ToString();

            if (!entMST_Faculty.Remarks.IsNull)
                txtRemarks.Text = entMST_Faculty.Remarks.Value.ToString();
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
                MST_FacultyBAL balMST_Faculty = new MST_FacultyBAL();
                MST_FacultyENT entMST_Faculty = new MST_FacultyENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtFacultyName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - FacultyName is Required Field  <br />";
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

                if (txtFacultyName.Text.Trim() != String.Empty)
                    entMST_Faculty.FacultyName = txtFacultyName.Text.Trim();

                if (txtFacultyShortName.Text.Trim() != String.Empty)
                    entMST_Faculty.FacultyShortName = txtFacultyShortName.Text.Trim();

                if (ddlDepartmentID.SelectedIndex > 0)
                    entMST_Faculty.DepartmentID = Convert.ToInt32(ddlDepartmentID.SelectedValue);

                if (txtAddress.Text.Trim() != String.Empty)
                    entMST_Faculty.Address = txtAddress.Text.Trim();

                if (ddlCityID.SelectedIndex > 0)
                    entMST_Faculty.CityID = Convert.ToInt32(ddlCityID.SelectedValue);

                if (txtPincode.Text.Trim() != String.Empty)
                    entMST_Faculty.Pincode = txtPincode.Text.Trim();

                if (txtPhone.Text.Trim() != String.Empty)
                    entMST_Faculty.Phone = txtPhone.Text.Trim();

                if (txtMobile.Text.Trim() != String.Empty)
                    entMST_Faculty.Mobile = txtMobile.Text.Trim();

                if (txtEmail.Text.Trim() != String.Empty)
                    entMST_Faculty.Email = txtEmail.Text.Trim();

                if (txtWebsite.Text.Trim() != String.Empty)
                    entMST_Faculty.Website = txtWebsite.Text.Trim();

                entMST_Faculty.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entMST_Faculty.UserID = Convert.ToInt32(Session["UserID"]);

                if (txtRemarks.Text.Trim() != String.Empty)
                    entMST_Faculty.Remarks = txtRemarks.Text.Trim();

                entMST_Faculty.Created = DateTime.Now;

                entMST_Faculty.Modified = DateTime.Now;


                #region Insert,Update,Copy

                if (Request.QueryString["facultyid"] != null && Request.QueryString["Copy"] == null)
                {
                    entMST_Faculty.FacultyID = Convert.ToInt32(Request.QueryString["facultyid"]);
                    if (balMST_Faculty.Update(entMST_Faculty))
                    {
                        Response.Redirect("MST_FacultyList.aspx");
                    }
                    else
                    {
                        //ucMessage.ShowError(balMST_Faculty.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["facultyid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMST_Faculty.Insert(entMST_Faculty))
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
        txtFacultyName.Text = String.Empty;
        txtFacultyShortName.Text = String.Empty;
        ddlDepartmentID.SelectedIndex = 0;
        txtAddress.Text = String.Empty;
        ddlCityID.SelectedIndex = 0;
        txtPincode.Text = String.Empty;
        txtPhone.Text = String.Empty;
        txtMobile.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtWebsite.Text = String.Empty;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls
}