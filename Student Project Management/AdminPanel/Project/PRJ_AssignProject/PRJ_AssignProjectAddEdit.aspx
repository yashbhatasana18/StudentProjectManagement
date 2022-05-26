<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="PRJ_AssignProjectAddEdit.aspx.cs" Inherits="AdminPanel_Project_PRJ_AssignProject_PRJ_AssignProjectAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    AssignProject
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="PRJ_AssignProjectList.aspx">AssignProject</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>AssignProjectAddEdit
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <div style="padding-right: 25px; float: right;">
        <br />
        <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="javascript:history.go(-1)">
	        [ Back to page ]
        </asp:HyperLink>
    </div>
    <br />
    <br />
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
                            <asp:Label ID="lblProjectID" runat="server" Text="Project"></asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlProjectID" runat="server" CssClass="form-control select2me">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvProjectID" runat="server"
                                ControlToValidate="ddlProjectID" ErrorMessage="Select Project" Display="Dynamic" InitialValue="-99"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <asp:Label ID="lblStudentName" runat="server" Text="Student Name"></asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:DropDownList runat="server" ID="ddlStudentID" CssClass="form-control select2me"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvStudentID" runat="server"
                                ControlToValidate="ddlStudentID" Display="Dynamic" InitialValue="-99"
                                ErrorMessage="Select Student Name" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            Is Leader ?
                        </label>
                        <div class="radio-list col-md-6">
                            <label class="radio-inline col-md-3">
                                <asp:RadioButton ID="rbYesisleader" runat="server" GroupName="isleader" />
                                Yes
                            </label>
                            <label class="radio-inline col-md-3">
                                <asp:RadioButton ID="rbNoisleader" runat="server" GroupName="isleader" Checked="True" />
                                No
                            </label>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <asp:Label ID="lblSequenceNo" runat="server" Text="Sequence"></asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtSequenceNo" type="text" class="form-control" placeholder="Enter Sequence" />
                            <asp:RequiredFieldValidator ID="rfvSequenceNo" runat="server"
                                ControlToValidate="txtSequenceNo" ErrorMessage="Enter Sequence" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
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
                            <div class="col-md-offset-3 col-md-9">
                                <asp:LinkButton ID="btnSave" runat="server" SkinID="btnSave" ValidationGroup="master" OnClick="btnSave_Click" />
                                <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Project/PRJ_AssignProject/PRJ_AssignProjectList.aspx" />
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

