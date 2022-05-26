<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_InstituteAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_Institute_MST_InstituteAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Institute
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_InstituteList.aspx">Institute</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>InstituteAddEdit
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">

    <div style="padding-right: 25px; float: right">
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

                    <h4 class="bold">Institute Detail</h4>
                    <hr />

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Institute Name</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtInstituteName" type="text" class="form-control" placeholder="Enter Institute Name" />
                            <asp:RequiredFieldValidator ID="rfvInstituteName" runat="server"
                                ControlToValidate="txtInstituteName" ErrorMessage="Enter Institute Name" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <%--<span class="required">*</span>--%>
                            <span>Institute Short Name</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtInstituteShortName" type="text" class="form-control" placeholder="Enter Institute Short Name" />
                            <%--<asp:RequiredFieldValidator ID="rfvInstituteShortName" runat="server"
                                ControlToValidate="txtInstituteShortName" ErrorMessage="Enter Institute Short Name" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span>Institute Code</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" type="text" ID="txtInstitutecode" class="form-control" placeholder="Enter Institute Code" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span>Institute Phone</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" type="text" ID="txtInstitutePhone" class="form-control" placeholder="Enter Institute Phone" />
                        </div>
                    </div>

                    <h4 class="bold">Address Detail</h4>
                    <hr />

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span>Address</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAddress" class="form-control" placeholder="Enter Address" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>City</span>
                        </label>
                        <div class="col-md-5">
                            <asp:DropDownList runat="server" ID="ddlCityID" CssClass="form-control select2me"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCityID" runat="server"
                                ControlToValidate="ddlCityID" Display="Dynamic" InitialValue="-99"
                                ErrorMessage="Select City Name" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span>Pincode</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" type="text" ID="txtPincode" class="form-control" placeholder="Enter Pincode" />
                        </div>
                    </div>

                    <h4 class="bold">Contact Detail</h4>
                    <hr />

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span>Email</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" type="text" ID="txtEmail" class="form-control" placeholder="Enter Email" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span>Mobile</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" type="text" ID="txtMobile" class="form-control" placeholder="Enter Mobile" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span>Website</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" type="text" ID="txtWebsite" class="form-control" placeholder="Enter Website" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <asp:Label runat="server" ID="lblRemarks">Remarks</asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" class="form-control" placeholder="Enter Remarks"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-actions">
                        <div class="row">
                            <div class="col-md-offset-5 col-md-7">
                                <asp:LinkButton ID="btnSave" runat="server" SkinID="btnSave" ValidationGroup="master" OnClick="btnSave_Click" />
                                <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Master/MST_Institute/MST_InstituteList.aspx" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

