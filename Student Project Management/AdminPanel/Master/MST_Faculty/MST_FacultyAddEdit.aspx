<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_FacultyAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_Faculty_MST_FacultyAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Faculty
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_FacultyList.aspx">Faculty</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>FacultyAddEdit
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

                    <h4 class="bold">Faculty Detail</h4>
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
                            <span>Faculty Name</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtFacultyName" type="text" class="form-control" placeholder="Enter Faculty Name" />
                            <asp:RequiredFieldValidator ID="rfvFacultyName" runat="server"
                                ControlToValidate="txtFacultyName" ErrorMessage="Enter Faculty Name" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Faculty Short Name</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtFacultyShortName" type="text" class="form-control" placeholder="Enter Faculty Short Name" />
                            <asp:RequiredFieldValidator ID="rfvFacultyShortName" runat="server"
                                ControlToValidate="txtFacultyShortName" ErrorMessage="Enter Faculty Short Name" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
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
                            <asp:TextBox runat="server" type="text" ID="txtPincode" class="form-control" MaxLength="6" placeholder="Enter Pincode" />
                            <asp:RegularExpressionValidator runat="server" ID="rexPincode" ControlToValidate="txtPincode" ValidationGroup="master"
                                ValidationExpression="^[0-9]{6}$" ErrorMessage="Please Enter 6 Digit Pincode!" ForeColor="Red" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <asp:Label runat="server" ID="lblPhone">Phone</asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="Enter Phone No" MaxLength="10"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revPhone" runat="server"
                                ControlToValidate="txtPhone" ErrorMessage="Please Enter Valid Phone Number!" ForeColor="Red" 
                                ValidationExpression="[0-9]{10}" ValidationGroup="master"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <asp:Label runat="server" ID="lblMobile">Mobile</asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Enter Mobile No" MaxLength="10"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revMobile" runat="server"
                                ControlToValidate="txtMobile" ErrorMessage="Please Enter Valid Mobile Number!" ForeColor="Red"
                                ValidationExpression="[0-9]{10}" ValidationGroup="master"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <asp:Label runat="server" ID="lblEmail">Email</asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter Email"></asp:TextBox>
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtEmail" ErrorMessage="Enter Valid Email" ForeColor="Red" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="master"></asp:RegularExpressionValidator>
                            
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
                                <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Master/MST_Faculty/MST_FacultyList.aspx" />
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

