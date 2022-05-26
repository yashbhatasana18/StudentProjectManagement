<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MET_MeetingView.aspx.cs" Inherits="AdminPanel_Meeting_MET_Meeting_MET_MeetingView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Meeting View
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
    <li>StudentView
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

    <div class="container-fluid">
        <%--Collepse Effect for View page Start--%>
        <div class="block">

            <div class="portlet box red">
                <div class="portlet-title">
                    <div class="caption">
                        Meeting View
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a class="fullscreen"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="table table-bordered table-striped table-hover">
                        <tr>
                            <td>Meeting
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblMeetingID" runat="server" Text='<%# string.Concat(" : ",Eval("MeetingID")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Project
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblProjectID" runat="server" Text='<%# string.Concat(" : ",Eval("ProjectCode")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>MeetingDate
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblMeetingDate" runat="server" Text='<%# string.Concat(" : ",Eval("MeetingDate","{0:d}")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>NextMeetingDate
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblNextMeetingDate" runat="server" Text='<%# string.Concat(" : ",Eval("NextMeetingDate","{0:d}")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>WorkDone
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblWorkDone" runat="server" Text='<%# string.Concat(" : ",Eval("WorkDone")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>WorkAssigned
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblWorkAssigned" runat="server" Text='<%# string.Concat(" : ",Eval("WorkAssigned")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>MeetingDuration
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblMeetingDuration" runat="server" Text='<%# string.Concat(" : ",Eval("MeetingDuration")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>FacultyRemarks
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblFacultyRemarks" runat="server" Text='<%# string.Concat(" : ",Eval("FacultyRemarks")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Faculty
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblFacultyID" runat="server" Text='<%# string.Concat(" : ",Eval("FacultyName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Institute
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblInstituteID" runat="server" Text='<%# string.Concat(" : ",Eval("InstituteName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Created
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblCreated" runat="server" Text='<%# string.Concat(" : ",Eval("Created","{0:d}")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Modified
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblModified" runat="server" Text='<%# string.Concat(" : ",Eval("Modified","{0:d}")) %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <%-- Collepse Effect for View page End--%>
    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

