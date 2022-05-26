using DProject;
using DProject.DAL;
using System;
using System.Data;
using System.Web.UI;

public partial class Login_Login : System.Web.UI.Page
{
    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblHeaderCompanyName.Text = CV.DefaultCompanyName;
            this.Page.Title = "Login - " + CV.DefaultCompanyName;
            //FillDropDownList();
        }
        txtUserName.Focus();
    }

    #endregion Page Load Event

    //#region Fill DropDownList

    //private void FillDropDownList()
    //{
    //    CommonFillMethods.FillDropDownListAcademicYearID(ddlAcademicYearID);
    //    CommonFillMethods.FillDropDownListInstituteID(ddlInstituteID);
    //    CommonFillMethods.FillDropDownListUserCatagoryID(ddlUserCategoryID);
    //}

    //#endregion Fill DropDownList

    #region Button Click Event

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text != String.Empty)
        {
            if (txtPassword.Text != String.Empty)
            {
                
                SEC_AdminDAL dalSEC_Admin = new SEC_AdminDAL();
                DataTable dt = dalSEC_Admin.SelectLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["UserID"].ToString() != String.Empty)
                        {
                            Session["UserID"] = Convert.ToInt32(dr["UserID"]);
                        }
                        if (dr["UserName"].ToString() != String.Empty)
                        {
                            Session["UserName"] = dr["UserName"].ToString();
                        }
                        if (dr["UserCatagoryID"].ToString() != String.Empty)
                        {
                            Session["UserCatagoryID"] = Convert.ToInt32(dr["UserCatagoryID"]);
                        }
                        if (dr["UserCatagory"].ToString() != String.Empty)
                        {
                            Session["UserCatagory"] = dr["UserCatagory"].ToString();
                        }
                        if (dr["DepartmentID"].ToString() != String.Empty)
                        {
                            Session["DepartmentID"] = Convert.ToInt32(dr["DepartmentID"]);
                        }
                        if (dr["DepartmentCode"].ToString() != String.Empty)
                        {
                            Session["DepartmentCode"] = dr["DepartmentCode"].ToString();
                        }
                        if (dr["DepartmentName"].ToString() != String.Empty)
                        {
                            Session["DepartmentName"] = dr["DepartmentName"].ToString();
                        }
                        if (dr["LoginID"].ToString() != String.Empty)
                        {
                            Session["LoginID"] = Convert.ToInt32(dr["LoginID"]);
                        }
                        if (dr["InstituteID"].ToString() != String.Empty)
                        {
                            Session["InstituteID"] = Convert.ToInt32(dr["InstituteID"]);
                        }
                        if (dr["InstituteName"].ToString() != String.Empty)
                        {
                            Session["InstituteName"] = dr["InstituteName"].ToString();
                        }
                        if (dr["AcademicYearID"].ToString() != String.Empty)
                        {
                            Session["AcademicYearID"] = Convert.ToInt32(dr["AcademicYearID"]);
                        }
                        if (dr["AcademicYearName"].ToString() != String.Empty)
                        {
                            Session["AcademicYearName"] = dr["AcademicYearName"].ToString();
                        }
                    }
                    Response.Redirect("~/AdminPanel/Default.aspx");
                }
                else
                {
                    lblMessage.Text = "The username or password you entered is incorrect.";
                }
            }
            else
            {
                lblMessage.Text = "Enter your Password.";
            }
        }
        else
        {
            lblMessage.Text = "Enter your Username.";
        }
    }

    #endregion Button Click Event
}