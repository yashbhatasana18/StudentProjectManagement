using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Institute_MST_InstituteList : System.Web.UI.Page
{
    SqlString LoginType = SqlString.Null;

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
                //CommonFunctions.FillOperatorDropDownList(ddlOperator, false);
                //btnDelete.Attributes.Add("onclick", "return CheckForDelete(this,'" + lblErrorMsg.ClientID + "');");

                if (Session["UserCatagory"] != null)
                    LoginType = Session["UserCatagory"].ToString();

                RepeaterFill(LoginType);
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
        Response.Redirect("~/AdminPanel/Master/MST_Institute/MST_InstituteAddEdit.aspx");
    }
    #endregion New Button Event

    #region Function - Delete Institute
    protected void rptInstituteList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                MST_InstituteBAL balMST_Institute = new MST_InstituteBAL();
                balMST_Institute.Delete(Convert.ToInt32(e.CommandArgument));
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
            finally
            {
                if (Session["UserCatagory"] != null)
                    LoginType = Session["UserCatagory"].ToString();

                RepeaterFill(LoginType);
            }
        }
    }
    #endregion Function - Delete Institute

    #region Repeater Fill Event
    private void RepeaterFill(SqlString LoginType)
    {
        MST_InstituteBAL balMST_Institute = new MST_InstituteBAL();
        rptInstituteList.DataSource = balMST_Institute.SelectAll(LoginType); ;
        rptInstituteList.DataBind();
        int Count = rptInstituteList.Items.Count;
        lblCount.Text = Count.ToString() + " Records";
    }
    #endregion Repeater Fill Event

    #region Clear Button Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //ddlField.SelectedIndex = 0;
        //ddlOperator.SelectedIndex = 0;
        //txtFieldValue.Text = String.Empty;
        //lblQuery.Text = String.Empty;
        //gv.DataBind();
        Session["FilterQuery"] = null;
        rptInstituteList.DataBind();
    }
    #endregion Clear Button Event

}