<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true"
    CodeFile="RPT_PRJ_ProjectStatementList.aspx.cs" Inherits="AdminPanel_LOCRPT_Project_RPT_PRJ_ProjectStatementList" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Project List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="portlet-body form">
        <div class="form-horizontal" role="form">
            <div class="form-body">
                <div class="form-group">
                    <label class="col-md-3 control-label">
                        <asp:Label ID="lblStudent" runat="server" Text="Technology"></asp:Label>
                    </label>
                    <div class="col-md-5">
                        <asp:DropDownList ID="ddlTechnology" CssClass="form-control select2me" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">
                        <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                    </label>
                    <div class="col-md-5">
                        <asp:DropDownList ID="ddlDepartment" CssClass="form-control select2me" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-offset-7 col-md-5">
                        <asp:Button ID="btnShow" SkinID="btnShow" runat="server" Text="Show" />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="container">
        <div class="form-group">
            <rsweb:ReportViewer ID="rvProjectStatementList" runat="server"
                Width="100%" Font-Names="Verdana" Font-Size="8pt"
                InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                WaitMessageFont-Size="14pt">
                <LocalReport ReportPath="App_Code\LOCRPT\Project\RPT_PRJ_ProjectStatementList.rdlc">
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
