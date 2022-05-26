<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true"
    CodeFile="RPT_DOC_ProjectWiseDocumentListAfterDeadLine.aspx.cs" Inherits="AdminPanel_LOCRPT_Document_RPT_DOC_ProjectWiseDocumentListAfterDeadLine" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Project Wise Document List After DeadLine
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="portlet-body form">
        <div class="form-horizontal" role="form">
            <div class="form-body">
                <div class="form-group">
                    <label class="col-md-3 control-label">
                        <asp:Label ID="lblStudent" runat="server" Text="Document Type"></asp:Label>
                    </label>
                    <div class="col-md-5">
                        <asp:DropDownList ID="ddlDocumentTypeID" runat="server" AutoPostBack="true" CssClass="form-control select2me"
                            OnSelectedIndexChanged="ddlDocumentTypeID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="form-group">
            <rsweb:ReportViewer ID="rvProjectDocumentListAfterDeadLine" runat="server" Font-Names="Verdana"
                Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                WaitMessageFont-Size="14pt" Width="100%">
                <LocalReport ReportPath="App_Code\LOCRPT\Document\RPT_DOC_ProjectWiseDocumentListAfterDeadLine.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
        <div class="form-group">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
    </div>
    <%--<table style="margin: auto;">
        <tr>
            <td></td>
            <td colspan="3">

                <div class="block" style="margin-top: 10px;">
                    <asp:HyperLink ID="hlAdvanceSearch" runat="server" class="block-heading"
                        data-toggle="collapse" NavigateUrl="#page-stats">Search</asp:HyperLink>
                    <div id="page-stats" class="block-body collapse in">
                        <table cellpadding="2" cellspacing="1">
                            <tr valign="top">
                                <td class="style1">Document Type
                                </td>
                                <td class="style1" valign="top">:
                                </td>
                                <td class="style1">
                                    
                                </td>
                                <td class="style1"></td>
                                <td class="style1" style="margin-left: 40px">
                                    
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
            <td colspan="3" rowspan="3">
                
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
    </table>--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
