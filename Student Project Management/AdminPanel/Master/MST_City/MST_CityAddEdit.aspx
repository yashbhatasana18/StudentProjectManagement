<%@ Page Title="City Add/Edit | Student Project Management" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_CityAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_City_MST_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageHeader" runat="Server">
    City 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_CityList.aspx">City</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>CityAddEdit
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">

    <div style="padding-right: 25px; float: right;">
        <br />
        <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="javascript:history.go(-1)">
	        [ Back to page ]
        </asp:HyperLink>
    </div>

    <asp:Panel ID="pnlAlert" runat="server" Visible="false">
        <div class="alert alert-success alert-dismissable ">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true"></button>
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </asp:Panel>

    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                <span class="caption-subject font-green-sharp bold uppercase">
                    <asp:Label runat="server" ID="lblPageHeader"></asp:Label>
                </span>
            </div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal" role="form">
                <div class="form-body">
                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <asp:Label ID="lblCityName" runat="server" Text="City Name"></asp:Label>
                        </label>
                        <div class="col-md-3">
                            <asp:TextBox runat="server" ID="txtCityName" name="txtDepartmentName" type="text" class="form-control" placeholder="Enter City Name" />
                            <asp:RequiredFieldValidator ID="rfvCityName" runat="server"
                                ControlToValidate="txtCityName" ErrorMessage="Enter City Name" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <asp:Label runat="server" ID="lblRemarks">Remarks</asp:Label>
                        </label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" class="form-control" placeholder="Enter Remarks"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-actions">
                        <div class="row">
                            <div class="col-md-offset-3 col-md-9">
                                <asp:LinkButton ID="btnSave" runat="server" SkinID="btnSave" ValidationGroup="master" OnClick="btnSave_Click" />
                                <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Master/MST_City/MST_CityList.aspx" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

