using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Status_MST_StatusList : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        try
        {
            if (!IsPostBack)
            {
                Session["FilterQuery"] = null;

                RepeaterFill();
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    #endregion Page Load Event

    #region New Button Event
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Master/MST_Status/MST_StatusAddEdit.aspx");
    }
    #endregion New Button Event

    #region Function - Delete Student
    protected void rptStatusList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                MST_StatusBAL balMST_Status = new MST_StatusBAL();
                balMST_Status.Delete(Convert.ToInt32(e.CommandArgument));
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
            finally
            {
                RepeaterFill();
            }
        }
    }
    #endregion Function - Delete Student

    #region Repeater Fill Event
    private void RepeaterFill()
    {
        MST_StatusBAL balMST_Status = new MST_StatusBAL();
        rptStatusList.DataSource = balMST_Status.SelectAll(); ;
        rptStatusList.DataBind();
        int Count = rptStatusList.Items.Count;
        lblCount.Text = Count.ToString() + " Records";
    }
    #endregion Repeater Fill Event

    #region Clear Button Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["FilterQuery"] = null;
        rptStatusList.DataBind();
    }
    #endregion Clear Button Event
}