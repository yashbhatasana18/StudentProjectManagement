using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_MST_Department_MST_DepartmentAddEdit : System.Web.UI.Page
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
            lblPageHeader.Text = "Add Department";
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
        CommonFillMethods.FillDropDownListInstituteID(ddlInstituteID);
    }

    #endregion 

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["departmentid"] != null)
        {
            lblPageHeader.Text = "Edit Department";
            int id = 0;
            if (int.TryParse(CommonFunctions.Decrypt(Request.QueryString["departmentid"].ToString()), out id))
            {
                MST_DepartmentBAL balMST_Department = new MST_DepartmentBAL();
                MST_DepartmentENT entMST_Department = new MST_DepartmentENT();
                entMST_Department = balMST_Department.SelectPK(Convert.ToInt32(CommonFunctions.Decrypt(Request.QueryString["departmentid"])));

                if (!entMST_Department.DepartmentName.IsNull)
                    txtDepartmentName.Text = entMST_Department.DepartmentName.Value.ToString();

                if (!entMST_Department.DepartmentCode.IsNull)
                    txtDepartmentCode.Text = entMST_Department.DepartmentCode.Value.ToString();

                if (!entMST_Department.InstituteID.IsNull)
                    ddlInstituteID.SelectedValue = entMST_Department.InstituteID.Value.ToString();

                if (!entMST_Department.Remarks.IsNull)
                    txtRemarks.Text = entMST_Department.Remarks.Value.ToString();
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
                MST_DepartmentBAL balMST_Department = new MST_DepartmentBAL();
                MST_DepartmentENT entMST_Department = new MST_DepartmentENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtDepartmentName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - DepartmentName is Required Field  <br />";
                }
                if (txtDepartmentCode.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - DepartmentCode is Required Field <br />";
                }
                if (ddlInstituteID.SelectedIndex == 0)
                {
                    ErrorMsg += " - InstituteID is Required Field <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion

                if (txtDepartmentName.Text.Trim() != String.Empty)
                    entMST_Department.DepartmentName = txtDepartmentName.Text.Trim();

                if (txtDepartmentCode.Text.Trim() != String.Empty)
                    entMST_Department.DepartmentCode = txtDepartmentCode.Text.Trim();

                entMST_Department.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entMST_Department.UserID = Convert.ToInt32(Session["UserID"]);

                if (txtRemarks.Text.Trim() != String.Empty)
                    entMST_Department.Remarks = txtRemarks.Text.Trim();

                entMST_Department.Created = DateTime.Now;

                entMST_Department.Modified = DateTime.Now;


                #region Insert,Update,Copy
                int id = 0;
                if (Request.QueryString["departmentid"] != null && Request.QueryString["Copy"] == null)
                {
                    if (int.TryParse(CommonFunctions.Decrypt(Request.QueryString["departmentid"].ToString()), out id))
                    {
                        entMST_Department.DepartmentID = Convert.ToInt32(CommonFunctions.Decrypt(Request.QueryString["departmentid"]));
                        if (balMST_Department.Update(entMST_Department))
                        {
                            Response.Redirect("MST_DepartmentList.aspx");
                        }
                        else
                        {
                            //ucMessage.ShowError(balMST_Department.Message);
                        }
                    }
                }
                else
                {
                    if (Request.QueryString["departmentid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMST_Department.Insert(entMST_Department))
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
        txtDepartmentName.Text = String.Empty;
        txtDepartmentCode.Text = String.Empty;
        ddlInstituteID.SelectedIndex = 0;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls 
}