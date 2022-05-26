using DProject.BAL;
using System;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;

public partial class AdminPanel_Project_PRJ_AssignProject_PRJ_AssignProjectList : System.Web.UI.Page
{
    SqlInt32 LoginID = SqlInt32.Null;
    SqlInt32 InstituteID = SqlInt32.Null;
    SqlInt32 DepartmentID = SqlInt32.Null;
    SqlInt32 AcademicYearID = SqlInt32.Null;
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

                if (Session["AcademicYearID"] != null)
                    AcademicYearID = Convert.ToInt32(Session["AcademicYearID"]);

                if (Session["DepartmentID"] != null)
                    DepartmentID = Convert.ToInt32(Session["DepartmentID"]);

                if (Session["InstituteID"] != null)
                    InstituteID = Convert.ToInt32(Session["InstituteID"]);

                if (Session["LoginID"] != null)
                    LoginID = Convert.ToInt32(Session["LoginID"]);

                if (Session["UserCatagory"] != null)
                    LoginType = Session["UserCatagory"].ToString();

                RepeaterFill(LoginType, DepartmentID, InstituteID, LoginID, AcademicYearID);
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    #endregion Page Load Event

    #region Function - Delete AssignProject
    protected void rptAssignProjectList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                PRJ_AssignProjectBAL balPRJ_AssignProject = new PRJ_AssignProjectBAL();
                balPRJ_AssignProject.Delete(Convert.ToInt32(e.CommandArgument));
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
            finally
            {
                if (Session["AcademicYearID"] != null)
                    AcademicYearID = Convert.ToInt32(Session["AcademicYearID"]);

                if (Session["DepartmentID"] != null)
                    DepartmentID = Convert.ToInt32(Session["DepartmentID"]);

                if (Session["InstituteID"] != null)
                    InstituteID = Convert.ToInt32(Session["InstituteID"]);

                if (Session["LoginID"] != null)
                    LoginID = Convert.ToInt32(Session["LoginID"]);

                if (Session["UserCatagory"] != null)
                    LoginType = Session["UserCatagory"].ToString();

                RepeaterFill(LoginType, DepartmentID, InstituteID, LoginID, AcademicYearID);
            }
        }
    }
    #endregion Function - Delete AssignProject

    #region Repeater Fill Event
    private void RepeaterFill(SqlString LoginType, SqlInt32 DepartmentID, SqlInt32 InstituteID, SqlInt32 LoginID, SqlInt32 AcademicYearID)
    {
        PRJ_AssignProjectBAL balPRJ_AssignProject = new PRJ_AssignProjectBAL();
        rptAssignProjectList.DataSource = balPRJ_AssignProject.SelectAll(LoginType, DepartmentID, InstituteID, LoginID, AcademicYearID);
        rptAssignProjectList.DataBind();
        int Count = rptAssignProjectList.Items.Count;
        lblCount.Text = Count.ToString() + " Records";
    }
    #endregion Repeater Fill Event

    #region Clear Button Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["FilterQuery"] = null;
        rptAssignProjectList.DataBind();
    }
    #endregion Clear Button Event
}