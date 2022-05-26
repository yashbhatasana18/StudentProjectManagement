<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="PRJ_GuideView.aspx.cs" Inherits="AdminPanel_Project_PRJ_Guide_PRJ_GuideView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Guide View
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="PRJ_GuideList.aspx">Guide</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>GuideView
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <div style="padding-right: 25px; float: right">
        <br />
        <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="javascript:history.go(-1)">
	        [ Back to page ]
        </asp:HyperLink>
        <%--        <div>
            <ucmessage:showmessage id="ucMessage" runat="server" />
        </div>--%>
    </div>

    <br />
    <br />
    <br />

    <div class="container-fluid">
        <%--Collepse Effect for View page Start--%>
        <div class="block">

            <%--<asp:Label ID="lblPageHeader" runat="server" />--%>

            <%--<asp:HyperLink ID="hlViewDetail" runat="server" class="block-heading" data-toggle="collapse" NavigateUrl="#page-stats">     
            </asp:HyperLink><div id="page-stats" class="block-body collapse in">--%>

            <div class="portlet box red">
                <div class="portlet-title">
                    <div class="caption">
                        Guide View
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a class="fullscreen"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="table table-bordered table-striped table-hover">
                        <tr>
                            <td>Guide ID
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblGuideID" Text='<%# string.Concat(" : ",Eval("GuideID")) %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Guide Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblGuideName" Text='<%# string.Concat(" : ",Eval("GuideName")) %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Guide Short Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblGuideShortName" Text='<%# string.Concat(" : ",Eval("GuideShortName")) %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Is Active
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblIsActive" Text='<%# string.Concat(" : ",Eval("IsActive")) %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Department
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblDepartmentID" Text='<%# string.Concat(" : ",Eval("DepartmentName")) %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Remarks
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblRemarks" Text='<%# string.Concat(" : ",Eval("Remarks")) %>' runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Created
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblCreated" Text='<%# string.Concat(" : ",Eval("Created","{0:d}")) %>'
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Modified
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblModified" Text='<%# string.Concat(" : ",Eval("Modified","{0:d}")) %>'
                                    runat="server"></asp:Label>
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

