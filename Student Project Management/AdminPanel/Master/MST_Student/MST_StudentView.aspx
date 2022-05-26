<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_StudentView.aspx.cs" Inherits="AdminPanel_Master_MST_Student_MST_StudentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Student View
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
                        Student View
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a class="fullscreen"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="table table-bordered table-striped table-hover">
                        <tr>
                            <td>Student </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblStudentID" Text='<%# string.Concat(" : ",Eval("StudentID")) %>'
                                    runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>StudentName </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblStudentName" Text='<%# string.Concat(" : ",Eval("StudentName")) %>'
                                    runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>EnrollmentNo </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblEnrollmentNo" Text='<%# string.Concat(" : ",Eval("EnrollmentNo")) %>'
                                    runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Email </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblEmail" Text='<%# string.Concat(" : ",Eval("Email")) %>' runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>DOB </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblDOB" Text='<%# string.Concat(" : ",Eval("DOB","{0:d}")) %>' runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>SignaturePath </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblSignaturePath" Text='<%# string.Concat(" : ",Eval("SignaturePath")) %>'
                                    runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Mobile </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblMobile" Text='<%# string.Concat(" : ",Eval("Mobile")) %>' runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Department </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblDepartmentID" Text='<%# string.Concat(" : ",Eval("DepartmentName")) %>'
                                    runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Institute </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblInstituteID" Text='<%# string.Concat(" : ",Eval("InstituteName")) %>'
                                    runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Remarks </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblRemarks" Text='<%# string.Concat(" : ",Eval("Remarks")) %>' runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Created </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblCreated" Text='<%# string.Concat(" : ",Eval("Created","{0:d}")) %>'
                                    runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Modified </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblModified" Text='<%# string.Concat(" : ",Eval("Modified","{0:d}")) %>'
                                    runat="server"></asp:Label></td>
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

