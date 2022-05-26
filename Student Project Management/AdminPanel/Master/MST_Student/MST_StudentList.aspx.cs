using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Student_MST_StudentList : System.Web.UI.Page
{
    SqlInt32 InstituteID = SqlInt32.Null;
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
                if (Session["InstituteID"] != null)
                    InstituteID = Convert.ToInt32(Session["InstituteID"]);

                if (Session["UserCatagory"] != null)
                    LoginType = Session["UserCatagory"].ToString();

                RepeaterFill(LoginType, InstituteID);
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
        Response.Redirect("~/AdminPanel/Master/MST_Student/MST_StudentAddEdit.aspx");
    }
    #endregion New Button Event

    #region Function - Delete Student
    protected void rptStudentList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                MST_StudentBAL balMST_Student = new MST_StudentBAL();
                balMST_Student.Delete(Convert.ToInt32(e.CommandArgument));
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
            finally
            {
                if (Session["InstituteID"] != null)
                    InstituteID = Convert.ToInt32(Session["InstituteID"]);

                if (Session["UserCatagory"] != null)
                    LoginType = Session["UserCatagory"].ToString();

                RepeaterFill(LoginType, InstituteID);
            }
        }
    }
    #endregion Function - Delete Student

    #region Repeater Fill Event
    private void RepeaterFill(SqlString LoginType, SqlInt32 InstituteID)
    {
        MST_StudentBAL balMST_Student = new MST_StudentBAL();
        rptStudentList.DataSource = balMST_Student.SelectAll(LoginType, InstituteID); ;
        rptStudentList.DataBind();
        int Count = rptStudentList.Items.Count;
        lblCount.Text = Count.ToString() + " Records";
    }
    #endregion Repeater Fill Event

    #region Clear Button Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["FilterQuery"] = null;
        rptStudentList.DataBind();
    }
    #endregion Clear Button Event
}