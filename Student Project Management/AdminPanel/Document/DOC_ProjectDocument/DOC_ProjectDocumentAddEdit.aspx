<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="DOC_ProjectDocumentAddEdit.aspx.cs" Inherits="AdminPanel_Document_DOC_ProjectDocument_DOC_ProjectDocumentAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Project Document
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="DOC_ProjectDocumentList.aspx">ProjectDocument</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>ProjectDocumentAddEdit
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <div style="padding-right: 25px; float: right">
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
                            <span>Project</span>
                        </label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlProjectID" runat="server" CssClass="form-control select2me">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvProjectName" runat="server"
                                ControlToValidate="ddlProjectID" ErrorMessage="Select Project" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red" InitialValue="-99"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Document Type</span>
                        </label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlDocumentTypeID" runat="server" CssClass="form-control select2me">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDocumentType" runat="server"
                                ControlToValidate="ddlDocumentTypeID" ErrorMessage="Select Document Type" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red" InitialValue="-99"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Document Name</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtDocumentName" type="text" class="form-control" placeholder="Enter Document Name" />
                            <asp:RequiredFieldValidator ID="rfvDocumentName" runat="server"
                                ControlToValidate="txtDocumentName" ErrorMessage="Enter Document Name" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Submission Date</span>
                        </label>
                        <div class="col-md-5">
                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                <asp:TextBox runat="server" ID="txtSubmissionDate" type="text" class="form-control" placeholder="Enter Submission Date" />
                                <span class="input-group-btn">
                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvSubmissionDate" runat="server"
                                ControlToValidate="txtSubmissionDate" Display="Dynamic" ErrorMessage="Enter Submission Date" ValidationGroup="master"
                                SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--<div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span></span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="" type="text" class="form-control" placeholder="Enter Submission Date" />
                            <asp:RequiredFieldValidator ID="" runat="server"
                                ControlToValidate="txtSubmissionDate" Display="Dynamic" ErrorMessage="Enter Submission Date" ValidationGroup="master"
                                SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>--%>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Document</span>
                        </label>
                        <div class="col-md-5">
                            <asp:Label ID="lblDocumentPath" runat="server"></asp:Label>
                            <asp:FileUpload ID="fuDocument" runat="server" TabIndex="6" />
                            <asp:RequiredFieldValidator ID="rfvUpDocument" runat="server"
                                ControlToValidate="fuDocument" Display="Dynamic" ErrorMessage="Select Document For Upload" ValidationGroup="master"
                                SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Document/DOC_ProjectDocument/DOC_ProjectDocumentList.aspx" />
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

