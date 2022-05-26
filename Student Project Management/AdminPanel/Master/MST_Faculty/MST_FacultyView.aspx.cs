using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Faculty_MST_FacultyView : System.Web.UI.Page
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
            if (Request.QueryString["facultyid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["facultyid"] != null)
        {
            MST_FacultyBAL balMST_Faculty = new MST_FacultyBAL();
            DataTable dtMST_Faculty = balMST_Faculty.SelectView(Convert.ToInt32(Request.QueryString["facultyid"]));
            if (dtMST_Faculty != null)
            {
                foreach (DataRow dr in dtMST_Faculty.Rows)
                {

                    if (!dr["FacultyID"].Equals(DBNull.Value))
                        lblFacultyID.Text = Convert.ToString(dr["FacultyID"]);

                    if (!dr["FacultyName"].Equals(DBNull.Value))
                        lblFacultyName.Text = Convert.ToString(dr["FacultyName"]);

                    if (!dr["FacultyShortName"].Equals(DBNull.Value))
                        lblFacultyShortName.Text = Convert.ToString(dr["FacultyShortName"]);

                    if (!dr["DepartmentName"].Equals(DBNull.Value))
                        lblDepartmentID.Text = Convert.ToString(dr["DepartmentName"]);

                    if (!dr["Address"].Equals(DBNull.Value))
                        lblAddress.Text = Convert.ToString(dr["Address"]);

                    if (!dr["CityName"].Equals(DBNull.Value))
                        lblCityID.Text = Convert.ToString(dr["CityName"]);

                    if (!dr["Pincode"].Equals(DBNull.Value))
                        lblPincode.Text = Convert.ToString(dr["Pincode"]);

                    if (!dr["Phone"].Equals(DBNull.Value))
                        lblPhone.Text = Convert.ToString(dr["Phone"]);

                    if (!dr["Mobile"].Equals(DBNull.Value))
                        lblMobile.Text = Convert.ToString(dr["Mobile"]);

                    if (!dr["Email"].Equals(DBNull.Value))
                        lblEmail.Text = Convert.ToString(dr["Email"]);

                    if (!dr["Website"].Equals(DBNull.Value))
                        lblWebsite.Text = Convert.ToString(dr["Website"]);

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