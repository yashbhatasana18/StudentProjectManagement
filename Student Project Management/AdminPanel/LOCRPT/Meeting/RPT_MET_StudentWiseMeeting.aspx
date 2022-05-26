<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true"
    CodeFile="RPT_MET_StudentWiseMeeting.aspx.cs" Inherits="AdminPanel_LOCRPT_Meeting_RPT_MET_StudentWiseMeeting" %>

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
                    <asp:hyperlink id="hlAdvanceSearch" runat="server" class="block-heading" data-toggle="collapse"
                        navigateurl="#page-stats">Search</asp:hyperlink>
                    <div id="page-stats" class="block-body in">
                        <table cellpadding="2" cellspacing="1">
                            <tr valign="top">
                                <td class="style1">Student
                                </td>
                                <td class="style1" valign="top">:
                                </td>
                                <td class="style1">
                                    <%--<asp:DropDownList ID="ddlStudentID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStudentID_SelectedIndexChanged"
                                        Width="500px">
                                    </asp:DropDownList>--%>
                                    <asp:textbox id="txtStudent" runat="server" autopostback="True"
                                        ontextchanged="txtStudent_TextChanged" width="500" placeholder="Show All">
                                    </asp:textbox>
                                    <asp:label id="lblMessage" runat="server" font-size="10pt" forecolor="Red"></asp:label>
                                </td>
                                <td class="style1"></td>
                                <td class="style1" style="margin-left: 40px">&nbsp;
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
                <rsweb:ReportViewer ID="rvStudentWiseMeeting" runat="server" Font-Names="Verdana"
                    Font-Size="8pt" Height="100%" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt" Width="100%">
                    <LocalReport ReportPath="App_Code\LOCRPT\Meeting\RPT_MET_StudentWiseMeeting.rdlc">
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
                <asp:scriptmanager id="ScriptManager1" runat="server">
                </asp:scriptmanager>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
