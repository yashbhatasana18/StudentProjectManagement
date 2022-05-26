using DProject.BAL;
using DProject.DAL;
using DProject.ENT;
using System;
using System.Data;
using System.Web.UI;

public partial class AdminPanel_ChangePassword : System.Web.UI.Page
{
    #region Page Load event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        txtOldPassword.Focus();
        if(!Page.IsPostBack)
        {
            lblPageHeader.Text = "Change Password";
        }
    }
    #endregion Page Load event

    #region Save button event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            SEC_AdminDAL dalSEC_Admin = new SEC_AdminDAL();
            SEC_AdminENT entSEC_Admin = new SEC_AdminENT();
            SEC_AdminBAL balSEC_Admin = new SEC_AdminBAL();
            DataTable dt = dalSEC_Admin.CheckPassword(Convert.ToInt32(Session["UserID"]), Convert.ToString(Session["UserName"]), txtOldPassword.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    entSEC_Admin.UserID = Convert.ToInt32(dr["UserID"]);
                    entSEC_Admin.UserCatagoryID = Convert.ToInt32(dr["UserCatagoryID"]);
                    entSEC_Admin.AdminName = dr["UserName"].ToString();
                    entSEC_Admin.AdminPassword = txtNewPassword.Text.Trim();
                    entSEC_Admin.LoginID = Convert.ToInt32(dr["LoginID"]);
                    entSEC_Admin.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                    entSEC_Admin.InstituteID = Convert.ToInt32(dr["InstituteID"]);
                    entSEC_Admin.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    entSEC_Admin.Remarks = dr["Remarks"].ToString();
                    entSEC_Admin.Created = DateTime.Now;
                    entSEC_Admin.Modified = DateTime.Now;

                    balSEC_Admin.Update(entSEC_Admin);
                    pnlAlert.Visible = true;
                    lblErrorMsg.Text = "Password Successfully Changed.";
                    //ucMessage.ShowSuccess("Password Successfully Changed.");
                }
            }
            else
            {
                lblOldPassword.Text = "Old Password is wrong.";
            }
        }
        else
        {
            Response.Redirect("~/Login/Login.aspx");
        }
    }
    #endregion Save button event

}