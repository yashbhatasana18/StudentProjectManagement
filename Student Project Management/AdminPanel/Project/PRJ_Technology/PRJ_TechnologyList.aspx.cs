using DProject.BAL;
using System;
using System.Web.UI.WebControls;

public partial class AdminPanel_Project_PRJ_Technology_PRJ_TechnologyList : System.Web.UI.Page
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

    #region Function - Delete Technology
    protected void rptTechnologyList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                PRJ_TechnologyBAL balPRJ_Technology = new PRJ_TechnologyBAL();
                balPRJ_Technology.Delete(Convert.ToInt32(e.CommandArgument));
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
    #endregion Function - Delete Technology

    #region Repeater Fill Event
    private void RepeaterFill()
    {
        PRJ_TechnologyBAL balPRJ_Technology = new PRJ_TechnologyBAL();
        rptTechnologyList.DataSource = balPRJ_Technology.SelectAll();
        rptTechnologyList.DataBind();
        int Count = rptTechnologyList.Items.Count;
        lblCount.Text = Count.ToString() + " Records";
    }
    #endregion Repeater Fill Event

    #region Clear Button Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["FilterQuery"] = null;
        rptTechnologyList.DataBind();
    }
    #endregion Clear Button Event
}