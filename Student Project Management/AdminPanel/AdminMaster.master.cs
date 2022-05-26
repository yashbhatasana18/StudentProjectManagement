using DProject;
using System;

public partial class AdminPanel_AdminMaster : System.Web.UI.MasterPage
{
    #region PageLoad

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //if (Session["UserCatagory"].ToString() == "Faculty" || Session["UserCatagory"].ToString() == "Student")
        //{
        //    ((HtmlGenericControl)this.Page.Master.FindControl("MasterMenu")).Style.Add("display", "none");
        //    ((HtmlGenericControl)this.Page.Master.FindControl("MasterMenuS")).Style.Add("display", "none");
        //    ((HtmlGenericControl)this.Page.Master.FindControl("divDocumentTag")).Style.Add("display", "none");
        //    ((HtmlGenericControl)this.Page.Master.FindControl("divDocumentType")).Style.Add("display", "none");
        //}
        //if (Session["UserCatagory"].ToString() == "Head/DepartmentCoordinator")
        //{
        //    ((HtmlGenericControl)this.Page.Master.FindControl("MasterMenu")).Style.Add("display", "none");
        //    ((HtmlGenericControl)this.Page.Master.FindControl("MasterMenuS")).Style.Add("display", "none");
        //    ((HtmlGenericControl)this.Page.Master.FindControl("divProjectTechnology")).Style.Add("display", "none");
        //}
        //if (Session["UserCatagory"].ToString() == "Student")
        //{
        //    ((HtmlGenericControl)this.Page.Master.FindControl("liCompany")).Style.Add("display", "none");
        //    ((HtmlGenericControl)this.Page.Master.FindControl("liCompanyS")).Style.Add("display", "none");
        //    ((HtmlGenericControl)this.Page.Master.FindControl("divProjectTechnology")).Style.Add("display", "none");
        //    ((HtmlGenericControl)this.Page.Master.FindControl("liReportS")).Style.Add("display", "none");
        //    ((HtmlGenericControl)this.Page.Master.FindControl("liReport")).Style.Add("display", "none");
        //}
        lblUser.Text = Session["UserName"].ToString();
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            ddlAcademicYearID.SelectedValue = Convert.ToString(Session["AcademicYearID"]);
        }

        if (Session["UserCatagory"].ToString() == "Student")
        {
            ddlAcademicYearID.Enabled = false;
        }
    }

    #endregion PageLoad

    #region Fill DropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListAcademicYearIDMaster(ddlAcademicYearID);
    }

    #endregion Fill DropDownList

    #region Logout Button Click

    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Login/Login.aspx");
    }

    #endregion Logout Button Click

    # region Change Password

    protected void lbtnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ChangePassword.aspx");
    }

    #endregion Change Password

    #region ddlAcademicYear Selected Index Changed

    protected void ddlAcademicYearID_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["AcademicYearID"] = Convert.ToInt32(ddlAcademicYearID.SelectedValue);
        Session["AcademicYearName"] = ddlAcademicYearID.SelectedItem;
        Response.Redirect("");
    }

    #endregion ddlAcademicYear Selected Index Changed
}
