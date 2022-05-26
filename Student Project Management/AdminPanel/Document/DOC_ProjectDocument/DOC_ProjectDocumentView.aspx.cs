using DProject.BAL;
using System;
using System.Data;
using System.Web.UI;

public partial class AdminPanel_Document_DOC_ProjectDocument_DOC_ProjectDocumentView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "Document Type View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["projectdocumentid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["projectdocumentid"] != null)
        {
            DOC_ProjectDocumentBAL balDOC_ProjectDocument = new DOC_ProjectDocumentBAL();
            DataTable dtDOC_ProjectDocument = balDOC_ProjectDocument.SelectView(Convert.ToInt32(Request.QueryString["projectdocumentid"]));
            if (dtDOC_ProjectDocument != null)
            {
                foreach (DataRow dr in dtDOC_ProjectDocument.Rows)
                {

                    if (!dr["ProjectDocumentID"].Equals(DBNull.Value))
                        lblProjectDocumentID.Text = Convert.ToString(dr["ProjectDocumentID"]);

                    if (!dr["ProjectCode"].Equals(DBNull.Value))
                        lblProjectCode.Text = Convert.ToString(dr["ProjectCode"]);

                    if (!dr["DocumentTypeName"].Equals(DBNull.Value))
                        lblDocumentTypeName.Text = Convert.ToString(dr["DocumentTypeName"]);

                    if (!dr["SubmissionDate"].Equals(DBNull.Value))
                        lblSubmissionDate.Text = Convert.ToString(dr["SubmissionDate"]);

                    if (!dr["ProjectTitle"].Equals(DBNull.Value))
                        lblProjectTitle.Text = Convert.ToString(dr["ProjectTitle"]);

                    if (!dr["DocumentName"].Equals(DBNull.Value))
                        lblDocumentName.Text = Convert.ToString(dr["DocumentName"]);

                    if (!dr["DocumentPath"].Equals(DBNull.Value))
                        lblDocumentPath.Text = Convert.ToString(dr["DocumentPath"]);

                    if (!dr["AcademicYearName"].Equals(DBNull.Value))
                        lblAcademicYearID.Text = Convert.ToString(dr["AcademicYearName"]);

                    if (!dr["InstituteName"].Equals(DBNull.Value))
                        lblInstituteID.Text = Convert.ToString(dr["InstituteName"]);

                    if (!dr["Remarks"].Equals(DBNull.Value))
                        lblRemarks.Text = Convert.ToString(dr["Remarks"]);

                    if (!dr["Created"].Equals(DBNull.Value))
                        lblCreated.Text = Convert.ToString(dr["Created"]);

                    if (!dr["Modified"].Equals(DBNull.Value))
                        lblModified.Text = Convert.ToString(dr["Modified"]);

                }
            }
        }
    }
    #endregion FillControls
}