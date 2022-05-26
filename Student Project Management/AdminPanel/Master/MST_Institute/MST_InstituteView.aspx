<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_InstituteView.aspx.cs" Inherits="AdminPanel_Master_MST_Institute_MST_InstituteView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Institute View
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_InstituteList.aspx">Institute</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>InstituteView
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">

    <div style="padding-right: 25px; float: right">
        <br />
        <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="javascript:history.go(-1)">
	[ Back to page ]
        </asp:HyperLink>
        <%--<div>
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
                        Institute View
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a class="fullscreen"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="table table-bordered table-striped table-hover">
                        <tr>
                            <td>Institute ID
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblInstituteID" runat="server" Text='<%# string.Concat(" : ",Eval("InstituteID")) %>'></asp:Label>
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
                            <td>Institute Short Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblInstituteShortName" runat="server" Text='<%# string.Concat(" : ",Eval("InstituteShortName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Institute code
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblInstitutecode" runat="server" Text='<%# string.Concat(" : ",Eval("Institutecode")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Institute Phone
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblInstitutePhone" runat="server" Text='<%# string.Concat(" : ",Eval("InstitutePhone")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Mobile
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblMobile" runat="server" Text='<%# string.Concat(" : ",Eval("Mobile")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Address
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# string.Concat(" : ",Eval("Address")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>City
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblCityID" runat="server" Text='<%# string.Concat(" : ",Eval("CityName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Pincode
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblPincode" runat="server" Text='<%# string.Concat(" : ",Eval("Pincode")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Email
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# string.Concat(" : ",Eval("Email")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Website
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblWebsite" runat="server" Text='<%# string.Concat(" : ",Eval("Website")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Remarks
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblRemarks" runat="server" Text='<%# string.Concat(" : ",Eval("Remarks")) %>'></asp:Label>
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

