using DProject.BAL;
using System;
using System.Data.SqlTypes;
using System.IO;
using System.Web.UI.WebControls;

public partial class AdminPanel_Document_DOC_ProjectDocument_DOC_ProjectDocumentList : System.Web.UI.Page
{
    SqlInt32 InstituteID = SqlInt32.Null;
    SqlInt32 LoginID = SqlInt32.Null;
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

                if (Session["InstituteID"] != null)
                    InstituteID = Convert.ToInt32(Session["InstituteID"]);

                if (Session["DepartmentID"] != null)
                    DepartmentID = Convert.ToInt32(Session["DepartmentID"]);

                if (Session["AcademicYearID"] != null)
                    AcademicYearID = Convert.ToInt32(Session["AcademicYearID"]);

                if (Session["LoginID"] != null)
                    LoginID = Convert.ToInt32(Session["LoginID"]);

                if (Session["UserCatagory"] != null)
                    LoginType = Session["UserCatagory"].ToString();

                RepeaterFill(LoginType, InstituteID, DepartmentID, AcademicYearID, LoginID);
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
        Response.Redirect("~/AdminPanel/Master/DOC_ProjectDocument/DOC_ProjectDocumentAddEdit.aspx");
    }
    #endregion New Button Event

    #region Function - Delete ProjectDocument
    protected void rptProjectDocumentList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                DOC_ProjectDocumentBAL balDOC_ProjectDocument = new DOC_ProjectDocumentBAL();
                balDOC_ProjectDocument.Delete(Convert.ToInt32(e.CommandArgument));
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
            finally
            {
                if (Session["InstituteID"] != null)
                    InstituteID = Convert.ToInt32(Session["InstituteID"]);

                if (Session["DepartmentID"] != null)
                    DepartmentID = Convert.ToInt32(Session["DepartmentID"]);

                if (Session["AcademicYearID"] != null)
                    AcademicYearID = Convert.ToInt32(Session["AcademicYearID"]);

                if (Session["LoginID"] != null)
                    LoginID = Convert.ToInt32(Session["LoginID"]);

                if (Session["UserCatagory"] != null)
                    LoginType = Session["UserCatagory"].ToString();

                RepeaterFill(LoginType, InstituteID, DepartmentID, AcademicYearID, LoginID);
            }
        }
    }
    #endregion Function - Delete ProjectDocument

    #region Repeater Fill Event
    private void RepeaterFill(SqlString LoginType, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlInt32 LoginID)
    {
        DOC_ProjectDocumentBAL balDOC_ProjectDocument = new DOC_ProjectDocumentBAL();
        rptProjectDocumentList.DataSource = balDOC_ProjectDocument.SelectAll(LoginType, InstituteID, DepartmentID, AcademicYearID, LoginID); ;
        rptProjectDocumentList.DataBind();
        int Count = rptProjectDocumentList.Items.Count;
        lblCount.Text = Count.ToString() + " Records";
    }
    #endregion Repeater Fill Event

    #region Clear Button Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["FilterQuery"] = null;
        rptProjectDocumentList.DataBind();
    }
    #endregion Clear Button Event
}