using DProject;
using DProject.BAL;
using DProject.ENT;
using System;
using System.Web.UI;

public partial class AdminPanel_Master_MST_Status_MST_StatusAddEdit : System.Web.UI.Page
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
            lblPageHeader.Text = "Add Status";
            #region DropDown List Fill Section

            #endregion

            #region Fill Controls

            FillControls();

            #endregion

        }
    }
    #endregion Page Load Event

    #region Fill DropDownList

    #endregion 

    #region FillControls By PK

    private void FillControls()
    {
        if (Request.QueryString["statusid"] != null)
        {
            lblPageHeader.Text = "Edit Status";
            MST_StatusBAL balMST_Status = new MST_StatusBAL();
            MST_StatusENT entMST_Status = new MST_StatusENT();
            entMST_Status = balMST_Status.SelectPK(Convert.ToInt32(Request.QueryString["statusid"]));

            if (!entMST_Status.StatusName.IsNull)
                txtStatusName.Text = entMST_Status.StatusName.Value.ToString();

            if (!entMST_Status.SequenceNo.IsNull)
                txtSequenceNo.Text = entMST_Status.SequenceNo.Value.ToString();
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
                MST_StatusBAL balMST_Status = new MST_StatusBAL();
                MST_StatusENT entMST_Status = new MST_StatusENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtStatusName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - StatusName is Required Field  <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion

                if (txtStatusName.Text.Trim() != String.Empty)
                    entMST_Status.StatusName = txtStatusName.Text.Trim();

                if (txtSequenceNo.Text.Trim() != String.Empty)
                    entMST_Status.SequenceNo = Convert.ToDecimal(txtSequenceNo.Text.Trim());

                entMST_Status.UserID = Convert.ToInt32(Session["UserID"]);

                entMST_Status.Created = DateTime.Now;

                entMST_Status.Modified = DateTime.Now;

                #region Insert,Update,Copy

                if (Request.QueryString["statusid"] != null && Request.QueryString["Copy"] == null)
                {
                    entMST_Status.StatusID = Convert.ToInt32(Request.QueryString["statusid"]);
                    if (balMST_Status.Update(entMST_Status))
                    {
                        Response.Redirect("MST_StatusList.aspx");
                    }
                    else
                    {
                        //ucMessage.ShowError(balMST_Status.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["Statusid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMST_Status.Insert(entMST_Status))
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
        txtStatusName.Text = String.Empty;
        txtSequenceNo.Text = String.Empty;
    }

    #endregion Clear Controls
}