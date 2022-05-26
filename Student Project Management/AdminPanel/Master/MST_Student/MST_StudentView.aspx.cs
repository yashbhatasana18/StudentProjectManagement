using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Student_MST_StudentView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "Student View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["studentid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["studentid"] != null)
        {
            MST_StudentBAL balMST_Student = new MST_StudentBAL();
            DataTable dtMST_Student = balMST_Student.SelectView(Convert.ToInt32(Request.QueryString["studentid"]));
            if (dtMST_Student != null)
            {
                foreach (DataRow dr in dtMST_Student.Rows)
                {

                    if (!dr["StudentID"].Equals(DBNull.Value))
                        lblStudentID.Text = Convert.ToString(dr["StudentID"]);

                    if (!dr["StudentName"].Equals(DBNull.Value))
                        lblStudentName.Text = Convert.ToString(dr["StudentName"]);

                    if (!dr["EnrollmentNo"].Equals(DBNull.Value))
                        lblEnrollmentNo.Text = Convert.ToString(dr["EnrollmentNo"]);

                    if (!dr["Email"].Equals(DBNull.Value))
                        lblEmail.Text = Convert.ToString(dr["Email"]);

                    if (!dr["DOB"].Equals(DBNull.Value))
                        lblDOB.Text = Convert.ToDateTime(dr["DOB"]).ToString("dd-MM-yyyy");

                    if (!dr["SignaturePath"].Equals(DBNull.Value))
                        lblSignaturePath.Text = Convert.ToString(dr["SignaturePath"]);

                    if (!dr["Mobile"].Equals(DBNull.Value))
                        lblMobile.Text = Convert.ToString(dr["Mobile"]);

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