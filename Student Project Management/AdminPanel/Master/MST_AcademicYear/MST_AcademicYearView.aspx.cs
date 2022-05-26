using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_AcademicYear_MST_AcademicYearView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "Academic Year View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["academicyearid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["academicyearid"] != null)
        {
            MST_AcademicYearBAL balMST_AcademicYear = new MST_AcademicYearBAL();
            DataTable dtMST_AcademicYear = balMST_AcademicYear.SelectView(Convert.ToInt32(Request.QueryString["academicyearid"]));
            if (dtMST_AcademicYear != null)
            {
                foreach (DataRow dr in dtMST_AcademicYear.Rows)
                {

                    if (!dr["AcademicYearID"].Equals(DBNull.Value))
                        lblAcademicYearID.Text = Convert.ToString(dr["AcademicYearID"]);

                    if (!dr["AcademicYearName"].Equals(DBNull.Value))
                        lblAcademicYearName.Text = Convert.ToString(dr["AcademicYearName"]);

                    if (!dr["FromDate"].Equals(DBNull.Value))
                        lblFromDate.Text = Convert.ToDateTime(dr["FromDate"]).ToString("dd-MM-yyyy");

                    if (!dr["ToDate"].Equals(DBNull.Value))
                        lblToDate.Text = Convert.ToDateTime(dr["ToDate"]).ToString("dd-MM-yyyy");

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