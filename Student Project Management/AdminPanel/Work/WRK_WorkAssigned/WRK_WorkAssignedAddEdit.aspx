<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="WRK_WorkAssignedAddEdit.aspx.cs" Inherits="AdminPanel_Work_WRK_WorkAssigned_WRK_WorkAssignedAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    WorkAssigned
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="PRJ_WorkAssignedList.aspx">WorkAssigned</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>WorkAssignedAddEdit 
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
                        <%--Collepse Effect for View page Start--%>
                        <%--<div class="block">
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
                            </div>--%>
                        <%-- Collepse Effect for View page End--%>

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
                                <asp:Label ID="lblWorkToBeDone" runat="server" Text="Work To Be Done"></asp:Label>
                            </label>
                            <div class="col-md-6">
                                <asp:TextBox runat="server" ID="txtWorkToBeDone" TextMode="MultiLine" type="text" class="form-control" placeholder="Enter Work To Be Done" />
                                <asp:RequiredFieldValidator ID="rfvWorkToBeDone" runat="server"
                                    ControlToValidate="txtWorkToBeDone" ErrorMessage="Enter Work To Be Done" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <asp:Label ID="lblDeadLine" runat="server" Text="Dead Line"></asp:Label>
                            </label>
                            <div class="col-md-2">
                                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                    <asp:TextBox runat="server" ID="txtDeadLine" type="text" class="form-control" placeholder="Enter Dead Line" />
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator ID="rfvDeadLine" runat="server"
                                    ControlToValidate="txtDeadLine" ErrorMessage="Enter Dead Line" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <label class="col-md-2 control-label">
                                <span class="required">*</span>
                                <asp:Label ID="lblSubmitDate" runat="server" Text="Submit Date"></asp:Label>
                            </label>
                            <div class="col-md-2">
                                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">

                                    <asp:TextBox runat="server" ID="txtSubmitDate" type="text" class="form-control" placeholder="Enter Submit Date" />
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator ID="rfvSubmitDate" runat="server"
                                    ControlToValidate="txtSubmitDate" ErrorMessage="Enter Submit Date" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <asp:Label runat="server" ID="lblFacultyRemarks">Faculty Remarks</asp:Label>
                            </label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtFacultyRemarks" runat="server" TextMode="MultiLine" class="form-control" placeholder="Enter Faculty Remarks"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                <span class="required">*</span>
                                <span>Status</span>
                            </label>
                            <div class="col-md-6">
                                <asp:DropDownList runat="server" ID="ddlStatusID" CssClass="form-control select2me"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvStatusID" runat="server"
                                    ControlToValidate="ddlStatusID" Display="Dynamic" InitialValue="-99"
                                    ErrorMessage="Select Status" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:LinkButton ID="btnSave" runat="server" SkinID="btnSave" ValidationGroup="master" OnClick="btnSave_Click" />
                                    <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Work/WRK_WorkAssigned/WRK_WorkAssignedList.aspx" />
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

