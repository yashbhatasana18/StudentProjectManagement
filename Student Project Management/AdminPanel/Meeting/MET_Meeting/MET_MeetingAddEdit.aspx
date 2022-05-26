<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MET_MeetingAddEdit.aspx.cs" Inherits="AdminPanel_Meeting_MET_Meeting_MET_MeetingAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Meeting
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MET_MeetingList.aspx">Meeting</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>MeetingAddEdit
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
                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <asp:Label ID="lblEnrollmentNo" runat="server" Text="Enrollment No"></asp:Label>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtStudentEnrollmentNo" type="text" class="form-control" MaxLength="12" placeholder="Enter EnrollmentNo" />
                            <asp:RequiredFieldValidator ID="rfvStudentEnrollmentNo" runat="server"
                                ControlToValidate="txtStudentEnrollmentNo" ErrorMessage="Enter EnrollmentNo" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <asp:Button runat="server" ID="btnShow" SkinID="btnShow" ValidationGroup="master" OnClick="btnShow_Click" />
                        </div>
                    </div>

                    <asp:Panel ID="pnlDetails" runat="server" Visible="false">

                        <%--<div class="container-fluid">                           
                            <div class="block">
                                <div class="portlet box red">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            Student Project Details
                                        </div>
                                        <div class="tools">
                                            <a href="javascript:;" class="collapse"></a>
                                            <a class="fullscreen"></a>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <table class="table table-bordered table-striped table-hover">
                                            <tr>
                                                <td>Project Title </td>
                                                <td>: </td>
                                                <td>
                                                    <asp:Label ID="lblProjectTitle" Text='<%# string.Concat(" : ",Eval("ProjectTitle")) %>'
                                                        runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Guide Name </td>
                                                <td>: </td>
                                                <td>
                                                    <asp:Label ID="lblGuideName" Text='<%# string.Concat(" : ",Eval("GuideName")) %>'
                                                        runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Student Name </td>
                                                <td>: </td>
                                                <td>
                                                    <asp:Label ID="lblStudentName" Text='<%# string.Concat(" : ",Eval("StudentName")) %>'
                                                        runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>--%>

                        <div class="container">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="top-news">
                                        <a href="javascript:;" class="btn yellow">
                                            <span>Project Title</span>
                                            <em>
                                                <asp:Label runat="server" ID="lblProjectTitle">
                                                    <%# string.Concat(" : ",Eval("ProjectTitle")) %>
                                                </asp:Label>
                                            </em>
                                            <i class="icon-docs top-news-icon"></i>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="top-news">
                                        <a href="javascript:;" class="btn green">
                                            <span>Guide Name</span>
                                            <em>
                                                <asp:Label runat="server" ID="lblGuideName">
                                                    <%# string.Concat(" : ",Eval("GuideName")) %>
                                                </asp:Label>
                                            </em>
                                            <i class="icon-user top-news-icon"></i>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="top-news">
                                        <a href="javascript:;" class="btn blue">
                                            <span>Student Name</span>
                                            <em>
                                                <asp:Label runat="server" ID="lblStudentName">
                                                    <%# string.Concat(" : ",Eval("StudentName")) %>
                                                </asp:Label>
                                            </em>
                                            <i class="icon-user top-news-icon"></i>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <span>Meeting Date</span>
                            </label>
                            <div class="col-md-5">
                                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                    <asp:TextBox runat="server" ID="txtMeetingDate" type="text" class="form-control" placeholder="Enter Meeting Date" />
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvMeetingDate" runat="server"
                                ControlToValidate="txtMeetingDate" Display="Dynamic" ErrorMessage="Enter Meeting Date" ValidationGroup="master"
                                SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <span>Next Meeting Date</span>
                            </label>
                            <div class="col-md-5">
                                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                    <asp:TextBox runat="server" ID="txtNextMeetingDate" type="text" class="form-control" placeholder="Enter Next Meeting Date" />
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvNextMeetingDate" runat="server"
                                ControlToValidate="txtNextMeetingDate" Display="Dynamic" ErrorMessage="Enter Next Meeting Date" ValidationGroup="master"
                                SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <asp:Label runat="server" ID="lblWorkDone">Work Done</asp:Label>
                            </label>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtWorkDone" runat="server" TextMode="MultiLine" class="form-control" placeholder="Enter Work Done"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <asp:Label runat="server" ID="lblWorkAssigned">Work Assigned</asp:Label>
                            </label>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtWorkAssigned" runat="server" TextMode="MultiLine" class="form-control" placeholder="Enter Work Assigned"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <span>Faculty</span>
                            </label>
                            <div class="col-md-5">
                                <asp:DropDownList runat="server" ID="ddlFacultyID" CssClass="form-control select2me"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvFacultyID" runat="server"
                                    ControlToValidate="ddlFacultyID" Display="Dynamic" InitialValue="-99"
                                    ErrorMessage="Select Faculty" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <asp:Label runat="server" ID="lblMeetingDuration">Meeting Duration</asp:Label>
                            </label>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtMeetingDuration" runat="server" class="form-control" placeholder="Enter Meeting Duration"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <asp:Label runat="server" ID="lblFacultyRemarks">Faculty Remarks</asp:Label>
                            </label>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtFacultyRemarks" runat="server" TextMode="MultiLine" class="form-control" placeholder="Enter Faculty Remarks"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-5 col-md-7">
                                    <asp:LinkButton ID="btnSave" runat="server" SkinID="btnSave" ValidationGroup="master" OnClick="btnSave_Click" />
                                    <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Meeting/MET_Meeting/MET_MeetingList.aspx" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

