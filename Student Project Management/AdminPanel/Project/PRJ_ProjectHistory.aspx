<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="PRJ_ProjectHistory.aspx.cs" Inherits="AdminPanel_Project_PRJ_ProjectHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%=ResolveClientUrl("~/Default/assets/admin/pages/css/timeline.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    ProjectHistory
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>ProjectHistory
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

    <div class="portlet light" style="padding: 10px 20px 0px 10px; margin-bottom: 0px">
        <div class="portlet-title">
            <div class="caption">
                <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                <span class="caption-subject font-green-sharp bold uppercase">
                    <asp:Label runat="server" ID="lblPageHeader"></asp:Label>
                </span>
            </div>
        </div>
        <br />
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
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <asp:Button runat="server" ID="btnShow" SkinID="btnShow" ValidationGroup="master" OnClick="btnShow_Click" />
                        </div>
                    </div>

                    <asp:Panel ID="pnlDetails" runat="server" Visible="false">
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
                        <br />
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

                        <%--<div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="TableContent" style="overflow-x: auto;">
                                        <table class="table table-responsive table-bordered table-striped table-hover" id="tbAssignProject">
                                            <thead>
                                                <tr class="TRDark">
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhsr" runat="server" Text="Sr."></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhSubmitDate" runat="server" Text="Submit Date"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhWorkToBeDone" runat="server" Text="WorkToBeDone"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhFacultyRemarks" runat="server" Text="Faculty Remarks"></asp:Label>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptProjectHistory" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="odd gradeX">
                                                            <td class="text-center"><%#Container.ItemIndex+1 %></td>
                                                            <td class="text-center"><%#Eval("SubmittedDate","{0:dd-MM-yyyy}") %></td>
                                                            <td class="text-center"><%#Eval("WorkToBeDone") %></td>
                                                            <td class="text-center"><%#Eval("FacultyRemarks") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>--%>

                        <div class="container">
                            <asp:Repeater ID="rptProjectHistory" runat="server">
                                <ItemTemplate>
                                    <%--<div class="timeline-item">
                                            <div class="timeline-badge">
                                                <div class="timeline-icon i">
                                                    <i class="icon-calendar font-red-intense"></i>
                                                </div>
                                            </div>
                                            <div class="timeline-body">
                                                <div class="timeline-body-arrow">
                                                </div>
                                                <div class="timeline-body-head">
                                                    <div class="timeline-body-head-caption">
                                                        <span class="timeline-body-title font-blue-madison"><%#Eval("SubmittedDate","{0:dd-MM-yyyy}")%></span>
                                                        <span class="font-grey-cascade"><%#Eval("WorkToBeDone") %></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>--%>
                                    <div class="container">
                                        <blockquote class="hero" style="border-left: 5px solid #54e53d;">
                                            <%#Eval("WorkToBeDone") %>
                                            <small><%#Eval("SubmittedDate","{0:dd-MM-yyyy}")%></small>
                                        </blockquote>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
    <script src="<%=ResolveClientUrl("~/Default/assets/admin/pages/scripts/timeline.js") %>" type="text/javascript"></script>
</asp:Content>

