<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true"
    CodeFile="RPT_DOC_ProjectDocumentDeadLineAchived.aspx.cs" Inherits="AdminPanel_LOCRPT_Document_RPT_DOC_ProjectDocumentDeadLineAchived" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Project Document DeadLine Achived
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
                        <asp:DropDownList ID="ddlDocumentTypeID" runat="server" CssClass="form-control select2me"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlDocumentTypeID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="form-group">
            <rsweb:ReportViewer ID="rvProjectDocumentDeadLineAchived" runat="server"
                Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"
                WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                <LocalReport ReportPath="App_Code\LOCRPT\Document\RPT_DOC_ProjectDocumentDeadLineAchived.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
        <div class="form-group">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
