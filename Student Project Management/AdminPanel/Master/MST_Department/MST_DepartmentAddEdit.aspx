<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_DepartmentAddEdit.aspx.cs" Inherits="AdminPanel_MST_Department_MST_DepartmentAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Department 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_DepartmentList.aspx">Department</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>DepartmentAddEdit
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">

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

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Institute Name</span>
                        </label>
                        <div class="col-md-6">
                            <asp:DropDownList runat="server" ID="ddlInstituteID" CssClass="form-control select2me"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvInstituteID" runat="server"
                                ControlToValidate="ddlInstituteID" Display="Dynamic" InitialValue="-99"
                                ErrorMessage="Select Institute Name" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Department Name</span>
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="txtDepartmentName" type="text" class="form-control" placeholder="Enter Department Name" />
                            <asp:RequiredFieldValidator ID="rfvDepartmentName" runat="server"
                                ControlToValidate="txtDepartmentName" ErrorMessage="Enter Department Name" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Department Code</span>
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" type="text" ID="txtDepartmentCode" class="form-control" placeholder="Enter Department Code" />
                            <asp:RequiredFieldValidator ID="rfvDepartmentCode" runat="server"
                                ControlToValidate="txtDepartmentCode" Display="Dynamic"
                                ErrorMessage="Enter Department Code" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <asp:Label runat="server" ID="lblRemarks">Remarks</asp:Label>
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" class="form-control" placeholder="Enter Remarks"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-actions">
                        <div class="row">
                            <div class="col-md-offset-3 col-md-9">
                                <asp:LinkButton ID="btnSave" runat="server" SkinID="btnSave" ValidationGroup="master" OnClick="btnSave_Click" />
                                <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Master/MST_Department/MST_DepartmentList.aspx" />
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

