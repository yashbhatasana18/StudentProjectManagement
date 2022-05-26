using DProject.BAL;
using System;
using System.Data;
using System.Web.UI;

public partial class AdminPanel_Master_MST_City_MST_CityView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //lblPageHeader.Text = "City View";
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            if (Request.QueryString["cityid"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["cityid"] != null)
        {
            int id = 0;
            if (int.TryParse(CommonFunctions.Decrypt(Request.QueryString["cityid"].ToString()), out id))
            {
                MST_CityBAL balMST_City = new MST_CityBAL();
                DataTable dtMST_City = balMST_City.SelectView(Convert.ToInt32(CommonFunctions.Decrypt(Request.QueryString["cityid"])));
                if (dtMST_City != null)
                {
                    foreach (DataRow dr in dtMST_City.Rows)
                    {

                        if (!dr["CityID"].Equals(DBNull.Value))
                            lblCityID.Text = Convert.ToString(dr["CityID"]);

                        if (!dr["CityName"].Equals(DBNull.Value))
                            lblCityName.Text = Convert.ToString(dr["CityName"]);

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