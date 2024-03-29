﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true"
    CodeFile="RPT_WRKA_WorkAssigedListByProject.aspx.cs" Inherits="AdminPanel_LOCRPT_WorkAssigned_RPT_WRKA_WorkAssigedListByProject" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    WorkAssiged List By Project
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="portlet-body form">
        <div class="form-horizontal" role="form">
            <div class="form-body">
                <div class="form-group">
                    <label class="col-md-3 control-label">
                        <asp:Label ID="lblStudent" runat="server" Text="Project"></asp:Label>
                    </label>
                    <div class="col-md-5">
                        <asp:DropDownList ID="ddlProjectID" runat="server" AutoPostBack="true" CssClass="form-control select2me"
                            OnSelectedIndexChanged="ddlProjectID_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="form-group">
            <rsweb:ReportViewer ID="rvWorkAssignedListByProject" runat="server"
                Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"
                WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                <LocalReport ReportPath="App_Code\LOCRPT\Work Assigned\RPT_WRKA_WorkAssigedListByProject.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
        <div class="form-group">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
    </div>
    <%--<table style="margin: auto; width: 100%">
        <tr>
            <td></td>
            <td colspan="3">
                <div class="block" style="margin-top: 10px; s">
                    <asp:HyperLink ID="hlAdvanceSearch" runat="server" class="block-heading" data-toggle="collapse"
                        NavigateUrl="#page-stats">Search</asp:HyperLink>
                    <div class="block-body in">
                        <table cellpadding="2" cellspacing="1" style="overflow: visible;">
                            <tr valign="top">
                                <td>
                                </td>
                                <td valign="top">:
                                </td>
                                <td>
                                    
                                </td>
                                <td></td>
                                <td style="margin-left: 40px"></td>
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
