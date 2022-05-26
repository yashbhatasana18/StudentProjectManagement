using DProject.BAL;
using System;
using System.Web.UI.WebControls;

public partial class AdminPanel_Document_DOC_DocumentType_DOC_DocumentTypeList : System.Web.UI.Page
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
        Response.Redirect("~/AdminPanel/Master/DOC_DocumentType/DOC_DocumentTypeAddEdit.aspx");
    }
    #endregion New Button Event

    #region Function - Delete Student
    protected void rptDocumentTypeList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                DOC_DocumentTypeBAL balDOC_DocumentType = new DOC_DocumentTypeBAL();
                balDOC_DocumentType.Delete(Convert.ToInt32(e.CommandArgument));
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
        DOC_DocumentTypeBAL balDOC_DocumentType = new DOC_DocumentTypeBAL();
        rptDocumentTypeList.DataSource = balDOC_DocumentType.SelectAll(); ;
        rptDocumentTypeList.DataBind();
        int Count = rptDocumentTypeList.Items.Count;
        lblCount.Text = Count.ToString() + " Records";
    }
    #endregion Repeater Fill Event

    #region Clear Button Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["FilterQuery"] = null;
        rptDocumentTypeList.DataBind();
    }
    #endregion Clear Button Event
}