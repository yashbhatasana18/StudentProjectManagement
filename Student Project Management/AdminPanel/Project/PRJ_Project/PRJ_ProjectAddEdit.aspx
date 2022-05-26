<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="PRJ_ProjectAddEdit.aspx.cs" Inherits="AdminPanel_Project_PRJ_Project_PRJ_ProjectAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Project
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="PRJ_ProjectList.aspx">Project</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>ProjectAddEdit
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
                            <span>Department</span>
                        </label>
                        <div class="col-md-5">
                            <asp:DropDownList runat="server" ID="ddlDepartmentID" CssClass="form-control select2me"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDepartmentID" runat="server"
                                ControlToValidate="ddlDepartmentID" Display="Dynamic" InitialValue="-99"
                                ErrorMessage="Select Department" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <asp:Label ID="lblGuideName" runat="server" Text="Guide Name"></asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:DropDownList runat="server" ID="ddlGuideID" CssClass="form-control select2me"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvGuideID" runat="server"
                                ControlToValidate="ddlGuideID" Display="Dynamic" InitialValue="-99"
                                ErrorMessage="Select Guide Name" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Technology</span>
                        </label>
                        <div class="col-md-5">
                            <asp:DropDownList runat="server" ID="ddlTechnologyID" CssClass="form-control select2me"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvTechnologyID" runat="server"
                                ControlToValidate="ddlTechnologyID" Display="Dynamic" InitialValue="-99"
                                ErrorMessage="Select Technology" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <asp:Label ID="lblProjectTitle" runat="server" Text="Project Title"></asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtProjectTitle" type="text" class="form-control" placeholder="Enter Project Title" />
                            <asp:RequiredFieldValidator ID="rfvProjectTitle" runat="server"
                                ControlToValidate="txtProjectTitle" ErrorMessage="Enter Project Title" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <asp:Label ID="lblProjectShortTitle" runat="server" Text="Project Short Title"></asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtProjectShortTitle" type="text" class="form-control" placeholder="Enter Project Short Title" />
                            <asp:RequiredFieldValidator ID="rfvProjectShortTitle" runat="server"
                                ControlToValidate="txtProjectShortTitle" ErrorMessage="Enter Project Short Title" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <asp:Label ID="lblProjectCode" runat="server" Text="Project Code"></asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtProjectCode" type="text" class="form-control" placeholder="Enter Project Code" />
                            <asp:RequiredFieldValidator ID="rfvProjectCode" runat="server"
                                ControlToValidate="txtProjectCode" ErrorMessage="Enter Project Code" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <asp:Label runat="server" ID="lblDescription">Project Description</asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="form-control" placeholder="Enter Project Description"></asp:TextBox>
                        </div>
                    </div>

                    <%--                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <asp:Label ID="lblSemester" runat="server" Text="Semester"></asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtSemester" type="text" class="form-control" placeholder="Enter Semester" />
                            <asp:RequiredFieldValidator ID="rfvSemester" runat="server"
                                ControlToValidate="txtSemester" ErrorMessage="Enter Semester" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtYear" type="text" class="form-control" placeholder="Enter Year" />
                            <asp:RequiredFieldValidator ID="rfvYear" runat="server"
                                ControlToValidate="txtYear" ErrorMessage="Enter Year" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>--%>

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
                                <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Project/PRJ_Project/PRJ_ProjectList.aspx" />
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

