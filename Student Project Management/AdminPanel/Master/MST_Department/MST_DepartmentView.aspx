<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_DepartmentView.aspx.cs" Inherits="AdminPanel_Master_MST_Department_MST_DepartmentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Department View
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_DepartmentList.aspx">Department</a>
    </li>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">

    <div style="padding-right: 25px; float: right;">
        <br />
        <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="javascript:history.go(-1)">
	[ Back to page ]
        </asp:HyperLink>
        <div>
            <%--<ucmessage:showmessage id="ucMessage" runat="server" />--%>
        </div>
    </div>

    <br />
    <br />
    <br />

    <div class="container-fluid">
        <%--Collepse Effect for View page Start--%>
        <div class="block">

            <asp:Label ID="lblPageHeader" runat="server" />

            <%--<asp:HyperLink ID="hlViewDetail" runat="server" class="block-heading" data-toggle="collapse" NavigateUrl="#page-stats">     
            </asp:HyperLink><div id="page-stats" class="block-body collapse in">--%>

            <div class="portlet box red">
                <div class="portlet-title">
                    <div class="caption">
                        Department View
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a class="fullscreen"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="table table-bordered table-striped table-hover">
                        <tr>
                            <td>Department </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblDepartmentID" runat="server" Text='<%# string.Concat(" : ",Eval("DepartmentID")) %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>DepartmentName </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblDepartmentName" runat="server" Text='<%# string.Concat(" : ",Eval("DepartmentName")) %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>DepartmentCode</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblDepartmentCode" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Institute </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblInstituteID" runat="server" Text='<%# string.Concat(" : ",Eval("InstituteName")) %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Remarks </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblRemarks" runat="server" Text='<%# string.Concat(" : ",Eval("Remarks")) %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Created </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblCreated" runat="server" Text='<%# string.Concat(" : ",Eval("Created","{0:d}")) %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Modified </td>
                            <td>: </td>
                            <td>
                                <asp:Label ID="lblModified" runat="server" Text='<%# string.Concat(" : ",Eval("Modified","{0:d}")) %>'></asp:Label></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <%-- Collepse Effect for View page End--%>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

