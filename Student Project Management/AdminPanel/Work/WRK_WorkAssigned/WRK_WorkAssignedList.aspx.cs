using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Work_WRK_WorkAssigned_WRK_WorkAssignedList : System.Web.UI.Page
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

                RepeaterFill(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID);
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    #endregion Page Load Event

    #region Function - Delete WorkAssigned
    protected void rptWorkAssignedList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                WRK_WorkAssignedBAL balWRK_WorkAssigned = new WRK_WorkAssignedBAL();
                balWRK_WorkAssigned.Delete(Convert.ToInt32(e.CommandArgument));
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

                RepeaterFill(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID);
            }
        }
    }
    #endregion Function - Delete WorkAssigned

    #region Repeater Fill Event
    private void RepeaterFill(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
    {
        WRK_WorkAssignedBAL balWRK_WorkAssigned = new WRK_WorkAssignedBAL();
        rptWorkAssignedList.DataSource = balWRK_WorkAssigned.SelectAll(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID);
        rptWorkAssignedList.DataBind();
        int Count = rptWorkAssignedList.Items.Count;
        lblCount.Text = Count.ToString() + " Records";
    }
    #endregion Repeater Fill Event

    #region Clear Button Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["FilterQuery"] = null;
        rptWorkAssignedList.DataBind();
    }
    #endregion Clear Button Event
}