using DProject.BAL;
using DProject.ENT;
using System;
using System.Web.UI;
public partial class AdminPanel_Master_MST_City_MST_CityAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        txtCityName.Focus();
        if (!Page.IsPostBack)
        {
            Session["FilterQuery"] = null;
            lblPageHeader.Text = "Add City";

            #region Fill Controls

            FillControls();

            #endregion

        }
    }
    #endregion Page Load Event

    #region FillControls By PK

    private void FillControls()
    {

        if (Request.QueryString["cityid"] != null)
        {
            lblPageHeader.Text = "Edit City";
            int id = 0;
            if (int.TryParse(CommonFunctions.Decrypt(Request.QueryString["cityid"].ToString()), out id))
            {
                MST_CityBAL balMST_City = new MST_CityBAL();
                MST_CityENT entMST_City = new MST_CityENT();

                entMST_City = balMST_City.SelectPK(Convert.ToInt32(CommonFunctions.Decrypt(Request.QueryString["cityid"])));

                if (!entMST_City.CityName.IsNull)
                    txtCityName.Text = entMST_City.CityName.Value.ToString();

                if (!entMST_City.Remarks.IsNull)
                    txtRemarks.Text = entMST_City.Remarks.Value.ToString();
            }
        }
    }

    #endregion FillControls By PK 

    #region Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                MST_CityBAL balMST_City = new MST_CityBAL();
                MST_CityENT entMST_City = new MST_CityENT();

                #region Validate Fields

                String ErrorMsg = String.Empty;
                if (txtCityName.Text.Trim() == String.Empty)
                {
                    ErrorMsg += " - CityName is Required Field  <br />";
                }
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = "Please Correct follwing error <br />" + ErrorMsg;
                    //ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion Validate Fields


                if (txtCityName.Text.Trim() != String.Empty)
                    entMST_City.CityName = txtCityName.Text.Trim();

                if (txtRemarks.Text.Trim() != String.Empty)
                    entMST_City.Remarks = txtRemarks.Text.Trim();

                entMST_City.UserID = Convert.ToInt32(Session["UserID"]);

                entMST_City.Created = DateTime.Now;

                entMST_City.Modified = DateTime.Now;


                #region Insert,Update,Copy
                int id = 0;
                if (Request.QueryString["cityid"] != null && Request.QueryString["Copy"] == null)
                {
                    if (int.TryParse(CommonFunctions.Decrypt(Request.QueryString["cityid"].ToString()), out id))
                    {
                        entMST_City.CityID = Convert.ToInt32(CommonFunctions.Decrypt(Request.QueryString["cityid"]));
                        if (balMST_City.Update(entMST_City))
                        {
                            Response.Redirect("MST_CityList.aspx");
                        }
                        else
                        {
                            lblErrorMsg.Text = balMST_City.Message;
                            //ucMessage.ShowError(balMST_City.Message);
                        }
                    }

                }
                else
                {
                    if (Request.QueryString["cityid"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMST_City.Insert(entMST_City))
                        {
                            if (Request.QueryString["reference"] != null)
                            {
                                Response.Write("<script language=javascript>if(window.opener != null && !window.opener.closed){window.opener.RefreshCity(" + entMST_City.CityID.ToString() + ");window.close();}</script>");
                                //Response.Write("<script>window.opener.location.reload(true);window.close();</" + "script>");
                                Response.End();
                            }
                            pnlAlert.Visible = true;
                            lblErrorMsg.Text = "Record Added Successfully";
                            //ucMessage.ShowSuccess("Record Added Successfully");
                            ClearControls();
                        }
                    }
                }

                #endregion Insert,Update,Copy

            }
            catch (Exception ex)
            {
                pnlAlert.Visible = true;
                lblErrorMsg.Text = ex.Message;
                //ucMessage.ShowError(ex.Message);
            }
        }
    }
    #endregion Save Button Event

    #region Clear Controls

    private void ClearControls()
    {
        txtCityName.Text = String.Empty;
        txtRemarks.Text = String.Empty;
    }

    #endregion Clear Controls 
}