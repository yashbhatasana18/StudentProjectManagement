using DProject.BAL;
using System;
using System.Data;

public partial class AdminPanel_Master_MST_Status_MST_StatusView : System.Web.UI.Page
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
            if (Request.QueryString["Statusid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["statusid"] != null)
        {
            MST_StatusBAL balMST_Status = new MST_StatusBAL();
            DataTable dtMST_Status = balMST_Status.SelectView(Convert.ToInt32(Request.QueryString["statusid"]));
            if (dtMST_Status != null)
            {
                foreach (DataRow dr in dtMST_Status.Rows)
                {

                    if (!dr["StatusID"].Equals(DBNull.Value))
                        lblStatusID.Text = Convert.ToString(dr["StatusID"]);

                    if (!dr["StatusName"].Equals(DBNull.Value))
                        lblStatusName.Text = Convert.ToString(dr["StatusName"]);

                    if (!dr["SequenceNo"].Equals(DBNull.Value))
                        lblSequenceNo.Text = Convert.ToString(dr["SequenceNo"]);

                    if (!dr["UserName"].Equals(DBNull.Value))
                        lblUserName.Text = Convert.ToString(dr["UserName"]);

                    //if (!dr["Remarks"].Equals(DBNull.Value))
                    //    lblRemarks.Text = Convert.ToString(dr["Remarks"]);

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