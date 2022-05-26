<%@ Page Title="Student Add/Edit | Student Project Management" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_StudentAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_Student_MST_StudentAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Student
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_StudentList.aspx">Student</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>StudentAddEdit
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
        <div class="alert alert-dismissable ">
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

                    <h4 class="bold">Basic Detail</h4>
                    <hr />

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
                            <span>Enrollment No</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtEnrollmentNo" type="text" class="form-control" placeholder="Enter Enrollment No" MaxLength="12" />
                            <asp:RequiredFieldValidator ID="rfvEnrollmentNo" runat="server"
                                ControlToValidate="txtEnrollmentNo" ErrorMessage="Enter EnrollmentNo" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEnrollmentNo" runat="server"
                                ControlToValidate="txtEnrollmentNo" ErrorMessage="Please Enter Valid Enrollment No!" ForeColor="Red"
                                ValidationExpression="[0-9]{12}"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Student Name</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtStudentName" type="text" class="form-control" placeholder="Enter Student Name" />
                            <asp:RequiredFieldValidator ID="rfvStudentName" runat="server"
                                ControlToValidate="txtStudentName" ErrorMessage="Enter Student Name" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Date Of Birth</span>
                        </label>
                        <div class="col-md-5">
                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                <asp:TextBox runat="server" ID="txtDOB" type="text" class="form-control" placeholder="Enter Date Of Birth" />
                                <span class="input-group-btn">
                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvDOB" runat="server"
                                ControlToValidate="txtDOB" Display="Dynamic" ErrorMessage="Enter Date Of Birth" ValidationGroup="master"
                                SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblPhotoPath_XXXXX" CssClass="col-md-3 control-label" runat="server" Text="Signature"></asp:Label>
                        <div class="col-md-5 fileinput fileinput-new" data-provides="fileinput">
                            <div class="fileinput-new thumbnail" style="width: auto; max-width: 200px; max-height: 150px; height: auto;">
                                <asp:Image ID="imgPhotoPath" runat="server" ImageUrl="~/Default/noimage.png" />
                            </div>
                            <div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 200px; max-height: 150px;">
                            </div>
                            <div>
                                <span class="btn default btn-file">
                                    <span class="fileinput-new">Select image </span>
                                    <span class="fileinput-exists">Change </span>
                                    <asp:FileUpload ID="fuSignature" runat="server" />
                                </span>
                                <asp:LinkButton ID="btnDeletePhotoPath" CssClass="btn red" runat="server" Visible="false">Remove</asp:LinkButton>
                                <asp:HiddenField ID="hfIsDeletePhotoPath" runat="server" />
                                <asp:HyperLink ID="hlPhotoPath" runat="server" Target="_blank" CssClass="btn btn-primary" Visible="false">
                                    <i class="fa fa-download" id="icnPhotoPath" runat="server"></i>Download
                                </asp:HyperLink>
                            </div>
                        </div>
                    </div>

                    <%--<div class="form-group">
                        <div class="">
                            <asp:Label ID="lblSignaturePath" runat="server"></asp:Label>
                        </div>
                    </div>--%>

                    <h4 class="bold">Contact Detail</h4>
                    <hr />

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <asp:Label runat="server" ID="lblMobile">Mobile</asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Enter Mobile No" MaxLength="10"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revMobile" runat="server"
                                ControlToValidate="txtMobile" ErrorMessage="Please Enter Valid Mobile Number!" ForeColor="Red"
                                ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <asp:Label runat="server" ID="lblEmail">Email</asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter Email"></asp:TextBox>
                            <asp:RegularExpressionValidator runat="server" ID="revEmail" ControlToValidate="txtEmail"
                                ErrorMessage="Please enter valid email" ForeColor="Red"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                            </asp:RegularExpressionValidator>
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
                                <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Master/MST_Student/MST_StudentList.aspx" />
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

