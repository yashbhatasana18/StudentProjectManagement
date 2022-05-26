<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="WRK_WorkAssignedView.aspx.cs" Inherits="AdminPanel_Work_WRK_WorkAssigned_WRK_WorkAssignedView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" Runat="Server">
    WorkAssigned
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" Runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_WorkAssignedList.aspx">WorkAssigned</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>WorkAssigned View
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" Runat="Server">
    <div style="padding-right: 25px; float: right">
        <br />
        <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="javascript:history.go(-1)">
	        [ Back to page ]
        </asp:HyperLink>

    </div>

    <br />
    <br />
    <br />

    <div class="container-fluid">
        <%--Collepse Effect for View page Start--%>
        <div class="block">

            <div class="portlet box red">
                <div class="portlet-title">
                    <div class="caption">
                        WorkAssigned View
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a class="fullscreen"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="table table-bordered table-striped table-hover">
                        <tr>
                            <td>WorkAssignedID
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblWorkAssignedID" runat="server" Text='<%# string.Concat(" : ",Eval("WorkAssignedID")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Guide Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblGuideName" runat="server" Text='<%# string.Concat(" : ",Eval("GuideName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Project Code
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblProjectCode" runat="server" Text='<%# string.Concat(" : ",Eval("ProjectCode")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Project Title
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblProjectTitle" runat="server" Text='<%# string.Concat(" : ",Eval("ProjectTitle")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Student Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblStudentName" runat="server" Text='<%# string.Concat(" : ",Eval("StudentName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Student Enrollment No
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblEnrollmentNo" runat="server" Text='<%# string.Concat(" : ",Eval("EnrollmentNo")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>DeadLine
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblDeadLine" runat="server" Text='<%# string.Concat(" : ",Eval("DeadLine")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>WorkTobeDone
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblWorkTobeDone" runat="server" Text='<%# string.Concat(" : ",Eval("WorkTobeDone")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>SubmittedDate
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblSubmittedDate" runat="server" Text='<%# string.Concat(" : ",Eval("SubmittedDate")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Faculty Remarks
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblFacultyRemarks" runat="server" Text='<%# string.Concat(" : ",Eval("FacultyRemarks")) %>'></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td>Institute Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblInstituteName" runat="server" Text='<%# string.Concat(" : ",Eval("InstituteName")) %>'></asp:Label>
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
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

