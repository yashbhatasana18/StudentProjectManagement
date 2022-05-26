<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="DOC_DocumentTypeAddEdit.aspx.cs" Inherits="AdminPanel_Document_DOC_DocumentType_DOC_DocumentTypeAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Document Type
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="DOC_DocumentTypeList.aspx">DocumentType</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>DocumentTypeAddEdit
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
                            <span>Department</span>
                        </label>
                        <div class="col-md-5">
                            <asp:DropDownList runat="server" ID="ddlDepartmentID" CssClass="form-control select2me"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDepartmentID" runat="server"
                                ControlToValidate="ddlDepartmentID" Display="Dynamic" InitialValue="-99"
                                ErrorMessage="Select Department" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Academic Year</span>
                        </label>
                        <div class="col-md-5">
                            <asp:DropDownList runat="server" ID="ddlAcademicYearID" CssClass="form-control select2me"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvAcademicYearID" runat="server"
                                ControlToValidate="ddlAcademicYearID" Display="Dynamic" InitialValue="-99"
                                ErrorMessage="Select Academic Year" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Document Type Name</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtDocumentTypeName" type="text" class="form-control" placeholder="Enter Document Type Name" />
                            <asp:RequiredFieldValidator ID="rfvDocumentTypeName" runat="server"
                                ControlToValidate="txtDocumentTypeName" ErrorMessage="Enter Document Type Name" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Dead Line</span>
                        </label>
                        <div class="col-md-5">
                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                <asp:TextBox runat="server" ID="txtDeadLine" type="text" class="form-control" placeholder="Enter Dead Line" />
                                <span class="input-group-btn">
                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="rfvDeadLine" runat="server"
                            ControlToValidate="txtDeadLine" Display="Dynamic" ErrorMessage="Enter Dead Line" ValidationGroup="master"
                            SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            Is Internal ?
                        </label>
                        <div class="radio-list col-md-6">
                            <label class="radio-inline col-md-3">
                                <asp:RadioButton ID="rbYesinternal" runat="server" GroupName="isinternal" />
                                Yes
                            </label>
                            <label class="radio-inline col-md-3">
                                <asp:RadioButton ID="rbNointernal" runat="server" GroupName="isinternal" Checked="True" />
                                No
                            </label>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            Is GTU ?
                        </label>
                        <div class="radio-list col-md-6">
                            <label class="radio-inline col-md-3">
                                <asp:RadioButton ID="rbYesgtu" runat="server" GroupName="isgtu" />
                                Yes
                            </label>
                            <label class="radio-inline col-md-3">
                                <asp:RadioButton ID="rbNogtu" runat="server" GroupName="isgtu" Checked="True" />
                                No
                            </label>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            Is Compulsory ?
                        </label>
                        <div class="radio-list col-md-6">
                            <label class="radio-inline col-md-3">
                                <asp:RadioButton ID="rbYescompulsory" runat="server" GroupName="iscompulsory" />
                                Yes
                            </label>
                            <label class="radio-inline col-md-3">
                                <asp:RadioButton ID="rbNocompulsory" runat="server" GroupName="iscompulsory" Checked="True" />
                                No
                            </label>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            Is Gantt Chart ?
                        </label>
                        <div class="radio-list col-md-6">
                            <label class="radio-inline col-md-3">
                                <asp:RadioButton ID="rbYesgantchart" runat="server" GroupName="isganttchart" />
                                Yes
                            </label>
                            <label class="radio-inline col-md-3">
                                <asp:RadioButton ID="rbNogantchart" runat="server" GroupName="isganttchart" Checked="True" />
                                No
                            </label>
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
                                <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Document/DOC_DocumentType/DOC_DocumentTypeList.aspx" />
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

