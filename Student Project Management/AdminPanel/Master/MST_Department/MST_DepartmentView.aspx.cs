using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Department_MST_DepartmentView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "Department View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["departmentid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["departmentid"] != null)
        {
            int id = 0;
            if (int.TryParse(CommonFunctions.Decrypt(Request.QueryString["departmentid"].ToString()), out id))
            {
                MST_DepartmentBAL balMST_Department = new MST_DepartmentBAL();
            DataTable dtMST_Department = balMST_Department.SelectView(Convert.ToInt32(CommonFunctions.Decrypt(Request.QueryString["departmentid"])));
                if (dtMST_Department != null)
                {
                    foreach (DataRow dr in dtMST_Department.Rows)
                    {

                        if (!dr["DepartmentID"].Equals(DBNull.Value))
                            lblDepartmentID.Text = Convert.ToString(dr["DepartmentID"]);

                        if (!dr["DepartmentName"].Equals(DBNull.Value))
                            lblDepartmentName.Text = Convert.ToString(dr["DepartmentName"]);

                        if (!dr["DepartmentCode"].Equals(DBNull.Value))
                            lblDepartmentCode.Text = Convert.ToString(dr["DepartmentCode"]);

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
    }
    #endregion FillControls
}