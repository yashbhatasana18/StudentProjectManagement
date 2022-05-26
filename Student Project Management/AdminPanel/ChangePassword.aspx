<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="AdminPanel_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Change Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="ChangePassword.aspx">ChangePassword</a>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">

    <div style="float: right; padding-right: 25px; padding-top: 20px">
        <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="javascript:history.go(-1)">
	[ Back to page ]
        </asp:HyperLink>
    </div>

    <br />
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
                            <span>Old Password</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password" ValidationGroup="Password" class="form-control" placeholder="Enter Old Password" />
                            <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server"
                                ControlToValidate="txtOldPassword" ErrorMessage="Enter Old Password" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="Password" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblOldPassword" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>New Password</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" ValidationGroup="Password" class="form-control" placeholder="Enter New Password" />
                            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server"
                                ControlToValidate="txtNewPassword" ErrorMessage="Enter New Password" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="Password" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Repeat New Password</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtRepeatPassword" TextMode="Password" ValidationGroup="Password" class="form-control" placeholder="Enter New Password Again" />
                            <asp:RequiredFieldValidator ID="rfvRepeatPassword" runat="server"
                                ControlToValidate="txtRepeatPassword" ErrorMessage="Enter New Password Again" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="Password" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-offset-4 col-md-8">
                            <asp:LinkButton ID="btnSave" SkinID="btnSave" runat="server" ValidationGroup="Password" OnClick="btnSave_Click" />
                            <asp:HyperLink ID="btnCancel" SkinID="hlCancel" runat="server" CausesValidation="false" NavigateUrl="~/AdminPanel/Default.aspx" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

