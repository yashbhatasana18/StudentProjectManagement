using DProject.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Institute_MST_InstituteView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "Institute View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["instituteid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["instituteid"] != null)
        {
            MST_InstituteBAL balMST_Institute = new MST_InstituteBAL();
            DataTable dtMST_Institute = balMST_Institute.SelectView(Convert.ToInt32(Request.QueryString["instituteid"]));
            if (dtMST_Institute != null)
            {
                foreach (DataRow dr in dtMST_Institute.Rows)
                {

                    if (!dr["InstituteID"].Equals(DBNull.Value))
                        lblInstituteID.Text = Convert.ToString(dr["InstituteID"]);

                    if (!dr["InstituteName"].Equals(DBNull.Value))
                        lblInstituteName.Text = Convert.ToString(dr["InstituteName"]);

                    if (!dr["InstituteShortName"].Equals(DBNull.Value))
                        lblInstituteShortName.Text = Convert.ToString(dr["InstituteShortName"]);

                    if (!dr["Institutecode"].Equals(DBNull.Value))
                        lblInstitutecode.Text = Convert.ToString(dr["Institutecode"]);

                    if (!dr["InstitutePhone"].Equals(DBNull.Value))
                        lblInstitutePhone.Text = Convert.ToString(dr["InstitutePhone"]);

                    if (!dr["Mobile"].Equals(DBNull.Value))
                        lblMobile.Text = Convert.ToString(dr["Mobile"]);

                    if (!dr["Address"].Equals(DBNull.Value))
                        lblAddress.Text = Convert.ToString(dr["Address"]);

                    if (!dr["CityName"].Equals(DBNull.Value))
                        lblCityID.Text = Convert.ToString(dr["CityName"]);

                    if (!dr["Pincode"].Equals(DBNull.Value))
                        lblPincode.Text = Convert.ToString(dr["Pincode"]);

                    if (!dr["Email"].Equals(DBNull.Value))
                        lblEmail.Text = Convert.ToString(dr["Email"]);

                    if (!dr["Website"].Equals(DBNull.Value))
                        lblWebsite.Text = Convert.ToString(dr["Website"]);

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