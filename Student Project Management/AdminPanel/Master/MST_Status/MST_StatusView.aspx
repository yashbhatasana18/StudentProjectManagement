<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_StatusView.aspx.cs" Inherits="AdminPanel_Master_MST_Status_MST_StatusView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Status View
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_StatusList.aspx">Status</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>StatusView
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
                        Status View
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a class="fullscreen"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="table table-bordered table-striped table-hover">
                        <tr>
                            <td>StatusID
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblStatusID" runat="server" Text='<%# string.Concat(" : ",Eval("StatusID")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Status Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblStatusName" runat="server" Text='<%# string.Concat(" : ",Eval("StatusName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Sequence
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblSequenceNo" runat="server" Text='<%# string.Concat(" : ",Eval("SequenceNo")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>UserName
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblUserName" runat="server" Text='<%# string.Concat(" : ",Eval("UserName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <%--<tr>
                            <td>Remarks
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblRemarks" runat="server" Text='<%# string.Concat(" : ",Eval("Remarks")) %>'></asp:Label>
                            </td>
                        </tr>--%>
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

