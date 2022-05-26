using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_AcademicYear_MST_AcademicYearAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        txtAcademicYearName.Focus();
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            lblPageHeader.Text = "Add Academic Year";
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
        //CommonFillMethods.FillDropDownListInstituteID(ddlInstituteID);
        //CommonFillMethods.FillDate(ddlDate0, ddlMonth0, ddlYear0);
        //CommonFillMethods.FillDate(ddlDate1, ddlMonth1, ddlYear1);

    }

    #endregion 

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["academicyearid"] != null)
        {
            lblPageHeader.Text = "Edit AcademicYear";
            MST_AcademicYearBAL balMST_AcademicYear = new MST_AcademicYearBAL();
            MST_AcademicYearENT entMST_AcademicYear = new MST_AcademicYearENT();
            entMST_AcademicYear = balMST_AcademicYear.SelectPK(Convert.ToInt32(Request.QueryString["academicyearid"]));

            if (!entMST_AcademicYear.AcademicYearName.IsNull)
                txtAcademicYearName.Text = entMST_AcademicYear.AcademicYearName.Value.ToString();

            if (!entMST_AcademicYear.FromDate.IsNull)
                txtFromDate.Text = entMST_AcademicYear.FromDate.Value.ToString("dd-MM-yyyy");

            if (!entMST_AcademicYear.ToDate.IsNull)
                txtToDate.Text = entMST_AcademicYear.ToDate.Value.ToString("dd-MM-yyyy");

            if (!entMST_AcademicYear.Remarks.IsNull)
                txtRemarks.Text = entMST_AcademicYear.Remarks.Value.ToString();

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
                MST_AcademicYearBAL balMST_AcademicYear = new MST_AcademicYearBAL();
                MST_AcademicYearENT entMST_AcademicYear = new MST_AcademicYearENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtAcademicYearName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - AcademicYearName is Required Field  <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion


                if (txtAcademicYearName.Text.Trim() != String.Empty)
                    entMST_AcademicYear.AcademicYearName = txtAcademicYearName.Text.Trim();

                if (txtFromDate.Text.Trim() != String.Empty)
                    entMST_AcademicYear.FromDate = DateTime.Parse(txtFromDate.Text.Trim());

                if (txtToDate.Text.Trim() != String.Empty)
                    entMST_AcademicYear.ToDate = DateTime.Parse(txtToDate.Text.Trim());

                entMST_AcademicYear.InstituteID = Convert.ToInt32(Session["InstituteID"]);

                entMST_AcademicYear.UserID = Convert.ToInt32(Session["UserID"]);

                if (txtRemarks.Text.Trim() != String.Empty)
                    entMST_AcademicYear.Remarks = txtRemarks.Text.Trim();

                entMST_AcademicYear.Created = DateTime.Now;

                entMST_AcademicYear.Modified = DateTime.Now;


                #region Insert,Update,Copy

                if (Request.QueryString["academicyearid"] != null && Request.QueryString["Copy"] == null)
                {
                    entMST_AcademicYear.AcademicYearID = Convert.ToInt32(Request.QueryString["academicyearid"]);
                    if (balMST_AcademicYear.Update(entMST_AcademicYear))
                    {
                        Response.Redirect("MST_AcademicYearList.aspx");
                    }
                    else
                    {
                       //ucMessage.ShowError(balMST_AcademicYear.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["academicyearid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMST_AcademicYear.Insert(entMST_AcademicYear))
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
        txtAcademicYearName.Text = String.Empty;
        txtFromDate.Text = String.Empty;
        txtToDate.Text = String.Empty;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls 
}