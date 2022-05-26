<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true"
    CodeFile="RPT_MET_ProjectWiseMeeting.aspx.cs" Inherits="AdminPanel_LOCRPT_Meeting_RPT_MET_ProjectWiseMeeting" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <table style="margin: auto;">
        <tr>
            <td></td>
            <td colspan="3">
                <div class="block" style="margin-top: 10px;">
                    <asp:HyperLink ID="hlAdvanceSearch" runat="server" class="block-heading" data-toggle="collapse"
                        NavigateUrl="#page-stats">Search</asp:HyperLink>
                    <div id="page-stats" class="block-body collapse in">
                        <table cellpadding="2" cellspacing="1">
                            <tr valign="top">
                                <td class="style1">Project
                                </td>
                                <td class="style1" valign="top">:
                                </td>
                                <td class="style1">
                                    <asp:DropDownList ID="ddlProjectID" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlProjectID_SelectedIndexChanged" Width="600px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style1"></td>
                                <td class="style1" style="margin-left: 40px">
                                    <%--<asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="Show" />--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="3" rowspan="3" style="margin-left: 40px">
                <rsweb:ReportViewer ID="rvProjectWiseMeeting" runat="server"
                    Font-Names="Verdana" Font-Size="8pt" Height="100%"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt" Width="100%">
                    <LocalReport ReportPath="App_Code\LOCRPT\Meeting\RPT_MET_ProjectWiseMeeting.rdlc">
                    </LocalReport>
                </rsweb:ReportViewer>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
