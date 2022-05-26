using DProject.BAL;
using System;
using System.Data;
using System.Web.UI;

public partial class AdminPanel_Document_DOC_DocumentType_DOC_DocumentTypeView : System.Web.UI.Page
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
            if (Request.QueryString["documenttypeid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["documenttypeid"] != null)
        {
            DOC_DocumentTypeBAL balDOC_DocumentType = new DOC_DocumentTypeBAL();
            DataTable dtDOC_DocumentType = balDOC_DocumentType.SelectView(Convert.ToInt32(Request.QueryString["documenttypeid"]));
            if (dtDOC_DocumentType != null)
            {
                foreach (DataRow dr in dtDOC_DocumentType.Rows)
                {

                    if (!dr["DocumentTypeID"].Equals(DBNull.Value))
                        lblDocumentTypeID.Text = Convert.ToString(dr["DocumentTypeID"]);

                    if (!dr["DocumentTypeName"].Equals(DBNull.Value))
                        lblDocumentTypeName.Text = Convert.ToString(dr["DocumentTypeName"]);

                    if (!dr["IsInternal"].Equals(DBNull.Value))
                        lblIsInternal.Text = Convert.ToString(dr["IsInternal"]);

                    if (!dr["IsGTU"].Equals(DBNull.Value))
                        lblIsGTU.Text = Convert.ToString(dr["IsGTU"]);

                    if (!dr["DeadLine"].Equals(DBNull.Value))
                        lblDeadLine.Text = Convert.ToString(dr["DeadLine"]);

                    if (!dr["IsCompulsory"].Equals(DBNull.Value))
                        lblIsCompulsory.Text = Convert.ToString(dr["IsCompulsory"]);

                    if (!dr["IsGanttChart"].Equals(DBNull.Value))
                        lblIsGanttChart.Text = Convert.ToString(dr["IsGanttChart"]);

                    if (!dr["AcademicYearName"].Equals(DBNull.Value))
                        lblAcademicYearID.Text = Convert.ToString(dr["AcademicYearName"]);

                    if (!dr["DepartmentName"].Equals(DBNull.Value))
                        lblDepartmentID.Text = Convert.ToString(dr["DepartmentName"]);

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