<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true"
    CodeFile="RPT_MET_DateWiseMeeting.aspx.cs" Inherits="AdminPanel_LOCRPT_Meeting_RPT_MET_DateWiseMeeting" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <table style="margin: auto; width: 100%">
        <tr>
            <td></td>
            <td colspan="3">
                <div class="block" style="margin-top: 10px; s">
                    <asp:hyperlink id="hlAdvanceSearch" runat="server" class="block-heading" data-toggle="collapse"
                        navigateurl="#page-stats">Search</asp:hyperlink>
                    <div class="block-body in">
                        <table cellpadding="2" cellspacing="1" style="overflow: visible;">
                            <tr valign="top">
                                <td>Meeting Date
                                </td>
                                <td valign="top">:
                                </td>
                                <td>
                                    <asp:textbox id="txtCal" width="170px" runat="server"></asp:textbox>
                                    <asp:imagebutton id="imgbtnCal" runat="server" imageurl="~/Images/Master/images.jpg"
                                        alternatetext="Click for Calander" />
                                </td>
                                <td>
                                    <asp:button id="btnShow" runat="server" text="Show" onclick="btnShow_Click" />
                                </td>
                                <td style="margin-left: 40px">
                                    <asp:button id="btnShowAll" runat="server" text="Show All"
                                        onclick="btnShowAll_Click" />
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
                <rsweb:reportviewer id="rvDateWiseMeeting" runat="server" font-names="Verdana"
                    font-size="8pt" height="100%" interactivedeviceinfos="(Collection)"
                    waitmessagefont-names="Verdana" waitmessagefont-size="14pt" width="100%">
                    <LocalReport ReportPath="App_Code\LOCRPT\Meeting\RPT_MET_DateWiseMeeting.rdlc">
                    </LocalReport>
                </rsweb:reportviewer>
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
