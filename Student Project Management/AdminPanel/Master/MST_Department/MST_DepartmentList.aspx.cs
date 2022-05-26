using DProject;
using DProject.BAL;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminPanel_MST_Department_MST_DepartmentList : System.Web.UI.Page
{
    #region 11.0 Variables

    SqlInt32 InstituteID = SqlInt32.Null;
    SqlString LoginType = SqlString.Null;
    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page
    Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;

    #endregion 11.0 Variables

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        try
        {
            if (!IsPostBack)
            {
                Session["FilterQuery"] = null;
                //CommonFunctions.FillOperatorDropDownList(ddlOperator, false);
                //btnDelete.Attributes.Add("onclick", "return CheckForDelete(this,'" + lblErrorMsg.ClientID + "');");
                if (Session["InstituteID"] != null)
                    InstituteID = Convert.ToInt32(Session["InstituteID"]);

                if (Session["UserCatagory"] != null)
                    LoginType = Session["UserCatagory"].ToString();

                RepeaterFill(LoginType, InstituteID);

                #region 12.1 DropDown List Fill Section

                FillDropDownList();

                #endregion 12.1 DropDown List Fill Section

                #region 12.2 Set Default Value

                //lblSearchHeader.Text = CV.SearchHeaderText;
                //lblSearchResultHeader.Text = CV.SearchResultHeaderText;

                Search(1);

                #endregion 12.2 Set Default Value
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    #endregion Page Load Event

    #region New Button Event
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Master/MST_Department/MST_DepartmentAddEdit.aspx");
    }
    #endregion New Button Event

    #region Function - Delete Department
    protected void rptDepartmentList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                MST_DepartmentBAL balMST_Department = new MST_DepartmentBAL();
                balMST_Department.Delete(Convert.ToInt32(e.CommandArgument));
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
            finally
            {
                if (Session["InstituteID"] != null)
                    InstituteID = Convert.ToInt32(Session["InstituteID"]);

                if (Session["UserCatagory"] != null)
                    LoginType = Session["UserCatagory"].ToString();

                RepeaterFill(LoginType, InstituteID);
            }
        }
    }
    #endregion Function - Delete Department

    #region Repeater Fill Event
    private void RepeaterFill(SqlString LoginType, SqlInt32 InstituteID)
    {
        MST_DepartmentBAL balMST_Department = new MST_DepartmentBAL();
        rptDepartmentList.DataSource = balMST_Department.SelectAll(LoginType, InstituteID); ;
        rptDepartmentList.DataBind();
        int Count = rptDepartmentList.Items.Count;
        lblCount.Text = Count.ToString() + " Records";
    }
    #endregion Repeater Fill Event

    #region Clear Button Event
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //ddlField.SelectedIndex = 0;
        //ddlOperator.SelectedIndex = 0;
        //txtFieldValue.Text = String.Empty;
        //lblQuery.Text = String.Empty;
        Session["FilterQuery"] = null;
        rptDepartmentList.DataBind();
    }
    #endregion Clear Button Event

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {
        CommonFunctions.GetDropDownPageSize(ddlPageSizeBottom);
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
    }

    #endregion 14.1 Fill DropDownList   

    #endregion 14.0 DropDownList

    #region 15.0 Search

    #region 15.1 Button Search Click Event

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search(1);
    }

    #endregion 15.1 Button Search Click Event

    #region 15.2 Search Function

    private void Search(int PageNo)
    {
        #region Parameters

        SqlString DepartmentName = SqlString.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;

        #endregion Parameters

        #region Gather Data

        if (txtDepartmentName.Text.Trim() != String.Empty)
            DepartmentName = txtDepartmentName.Text.Trim();

        #endregion Gather Data

        MST_DepartmentBAL balMST_Department = new MST_DepartmentBAL();

        DataTable dt = balMST_Department.SelectPage(Offset, PageRecordSize, out TotalRecords, DepartmentName);

        if (PageRecordSize == 0 && dt.Rows.Count > 0)
        {
            PageRecordSize = dt.Rows.Count;
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));
        }
        else
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));

        if (dt != null && dt.Rows.Count > 0)
        {
            Div_SearchResult.Visible = true;
            rptDepartmentList.DataSource = dt;
            rptDepartmentList.DataBind();

            if (PageNo > TotalPages)
                PageNo = TotalPages;

            ViewState["TotalPages"] = TotalPages;
            ViewState["CurrentPage"] = PageNo;

            CommonFunctions.BindPageList(TotalPages, TotalRecords, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            if (TotalRecords <= CV.SmallestPageSize)
            {
                Div_Pagination.Visible = false;
                Div_GoToPageNo.Visible = false;
                Div_PageSize.Visible = false;
            }
            else
            {
                Div_Pagination.Visible = true;
                Div_GoToPageNo.Visible = true;
                Div_PageSize.Visible = true;
            }
        }

        else if (TotalPages < PageNo && TotalPages > 0)
            Search(TotalPages);

        else
        {
            Div_SearchResult.Visible = false;

            ViewState["TotalPages"] = 0;
            ViewState["CurrentPage"] = 1;

            rptDepartmentList.DataSource = null;
            rptDepartmentList.DataBind();

            CommonFunctions.BindPageList(0, 0, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);
        }
    }

    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 17.0 Pagination   

    #region 17.1 Pagination Events

    #region ItemDataBound Event

    protected void rpPagination_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lb = (LinkButton)e.Item.FindControl("lbtnPageNo");
            HtmlGenericControl hgc = (HtmlGenericControl)e.Item.FindControl("liPageNo");
            if (Convert.ToInt32(ViewState["CurrentPage"]) == Convert.ToInt32(lb.CommandArgument))
            {
                hgc.Attributes["class"] = CSSClass.PaginationButtonActive;
                lb.Enabled = false;
            }
            else
                hgc.Attributes["class"] = CSSClass.PaginationButton;
        }
    }

    #endregion ItemDataBound Event

    #region PageChange Event

    protected void PageChange_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        int Value = Convert.ToInt32(lbtn.CommandArgument);
        String Name = lbtn.CommandName.ToString();

        if (Name == "PageNo" || Name == "FirstPage")
            Search(Value);

        else if (Name == "PreviousPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) - Value);

        else if (Name == "NextPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) + Value);

        else if (Name == "LastPage")
            Search(Convert.ToInt32(ViewState["TotalPages"]));

        else if (Name == "GoPageNo")
        {
            if (txtPageNo.Text.Trim() == String.Empty)
            {
                //ucMessage.ShowError(CommonMessage.ErrorRequiredField("Page No"));
                return;
            }
            else
            {
                Value = Convert.ToInt32(txtPageNo.Text);
                if (Value > Convert.ToInt32(ViewState["TotalPages"]))
                {
                    //ucMessage.ShowError(CommonMessage.ErrorInvalidField("Page No"));
                    return;
                }
                Search(Value);
            }
        }
    }

    #endregion PageChange Event

    #endregion 17.1 Pagination Events

    #endregion 17.0 Pagination

    #region 21.0 ddlPageSize Selected Index Changed Event

    protected void ddlPageSizeBottom_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageRecordSize = Convert.ToInt32(ddlPageSizeBottom.SelectedValue);
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    protected void ddlPageSizeTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    #endregion 21.0 ddlPageSize Selected Index Changed Event

    #region 22.0 ClearControls

    private void ClearControls()
    {
        txtDepartmentName.Text = String.Empty;
        CommonFunctions.BindEmptyRepeater(rptDepartmentList);
        Div_SearchResult.Visible = false;
    }

    #endregion 22.0 ClearControls
}