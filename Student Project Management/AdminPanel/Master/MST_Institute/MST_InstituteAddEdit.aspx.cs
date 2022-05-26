using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Institute_MST_InstituteAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        txtInstituteName.Focus();
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            lblPageHeader.Text = "Add Institute";
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
        CommonFillMethods.FillDropDownListCityID(ddlCityID);
    }

    #endregion 

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["instituteid"] != null)
        {
            lblPageHeader.Text = "Edit Institute";
            MST_InstituteBAL balMST_Institute = new MST_InstituteBAL();
            MST_InstituteENT entMST_Institute = new MST_InstituteENT();
            entMST_Institute = balMST_Institute.SelectPK(Convert.ToInt32(Request.QueryString["instituteid"]));

            if (!entMST_Institute.InstituteName.IsNull)
                txtInstituteName.Text = entMST_Institute.InstituteName.Value.ToString();

            if (!entMST_Institute.InstituteShortName.IsNull)
                txtInstituteShortName.Text = entMST_Institute.InstituteShortName.Value.ToString();

            if (!entMST_Institute.Institutecode.IsNull)
                txtInstitutecode.Text = entMST_Institute.Institutecode.Value.ToString();

            if (!entMST_Institute.InstitutePhone.IsNull)
                txtInstitutePhone.Text = entMST_Institute.InstitutePhone.Value.ToString();

            if (!entMST_Institute.Mobile.IsNull)
                txtMobile.Text = entMST_Institute.Mobile.Value.ToString();

            if (!entMST_Institute.Address.IsNull)
                txtAddress.Text = entMST_Institute.Address.Value.ToString();

            if (!entMST_Institute.CityID.IsNull)
                ddlCityID.SelectedValue = entMST_Institute.CityID.Value.ToString();

            if (!entMST_Institute.Pincode.IsNull)
                txtPincode.Text = entMST_Institute.Pincode.Value.ToString();

            if (!entMST_Institute.Email.IsNull)
                txtEmail.Text = entMST_Institute.Email.Value.ToString();

            if (!entMST_Institute.Website.IsNull)
                txtWebsite.Text = entMST_Institute.Website.Value.ToString();

            if (!entMST_Institute.Remarks.IsNull)
                txtRemarks.Text = entMST_Institute.Remarks.Value.ToString();

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
                MST_InstituteBAL balMST_Institute = new MST_InstituteBAL();
                MST_InstituteENT entMST_Institute = new MST_InstituteENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtInstituteName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - InstituteName is Required Field  <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion


                if (txtInstituteName.Text.Trim() != String.Empty)
                    entMST_Institute.InstituteName = txtInstituteName.Text.Trim();

                if (txtInstituteShortName.Text.Trim() != String.Empty)
                    entMST_Institute.InstituteShortName = txtInstituteShortName.Text.Trim();

                if (txtInstitutecode.Text.Trim() != String.Empty)
                    entMST_Institute.Institutecode = txtInstitutecode.Text.Trim();

                if (txtInstitutePhone.Text.Trim() != String.Empty)
                    entMST_Institute.InstitutePhone = txtInstitutePhone.Text.Trim();

                if (txtMobile.Text.Trim() != String.Empty)
                    entMST_Institute.Mobile = txtMobile.Text.Trim();

                if (txtAddress.Text.Trim() != String.Empty)
                    entMST_Institute.Address = txtAddress.Text.Trim();

                if (ddlCityID.SelectedIndex > 0)
                    entMST_Institute.CityID = Convert.ToInt32(ddlCityID.SelectedValue);

                if (txtPincode.Text.Trim() != String.Empty)
                    entMST_Institute.Pincode = txtPincode.Text.Trim();

                if (txtEmail.Text.Trim() != String.Empty)
                    entMST_Institute.Email = txtEmail.Text.Trim();

                if (txtWebsite.Text.Trim() != String.Empty)
                    entMST_Institute.Website = txtWebsite.Text.Trim();

                entMST_Institute.UserID = Convert.ToInt32(Session["UserID"]);

                if (txtRemarks.Text.Trim() != String.Empty)
                    entMST_Institute.Remarks = txtRemarks.Text.Trim();

                entMST_Institute.Created = DateTime.Now;

                entMST_Institute.Modified = DateTime.Now;


                #region Insert,Update,Copy

                if (Request.QueryString["instituteid"] != null && Request.QueryString["Copy"] == null)
                {
                    entMST_Institute.InstituteID = Convert.ToInt32(Request.QueryString["instituteid"]);
                    if (balMST_Institute.Update(entMST_Institute))
                    {
                        Response.Redirect("MST_InstituteList.aspx");
                    }
                    else
                    {
                        //ucMessage.ShowError(balMST_Institute.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["instituteid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMST_Institute.Insert(entMST_Institute))
                        {
                            if (Request.QueryString["reference"] != null)
                            {
                                Response.Write("<script language=javascript>if(window.opener != null && !window.opener.closed){window.opener.RefreshInstitute(" + entMST_Institute.InstituteID.ToString() + ");window.close();}</script>");
                                Response.End();
                            }
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
        txtInstituteName.Text = String.Empty;
        txtInstituteShortName.Text = String.Empty;
        txtInstitutecode.Text = String.Empty;
        txtInstitutePhone.Text = String.Empty;
        txtMobile.Text = String.Empty;
        txtAddress.Text = String.Empty;
        ddlCityID.SelectedIndex = 0;
        txtPincode.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtWebsite.Text = String.Empty;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls 
}