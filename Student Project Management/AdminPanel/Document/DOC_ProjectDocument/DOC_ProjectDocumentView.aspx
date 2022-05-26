<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="DOC_ProjectDocumentView.aspx.cs" Inherits="AdminPanel_Document_DOC_ProjectDocument_DOC_ProjectDocumentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Project Document View
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="DOC_ProjectDocumentList.aspx">ProjectDocument</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>ProjectDocumentView
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
                        Document Type View
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a class="fullscreen"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="table table-bordered table-striped table-hover">
                        <tr>
                            <td>Project Document ID
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblProjectDocumentID" runat="server" Text='<%# string.Concat(" : ",Eval("ProjectDocumentID")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Project Title
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblProjectTitle" runat="server" Text='<%# string.Concat(" : ",Eval("ProjectTitle")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Project Code
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblProjectCode" runat="server" Text='<%# string.Concat(" : ",Eval("ProjectCode")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>SubmissionDate
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblSubmissionDate" runat="server" Text='<%# string.Concat(" : ",Eval("SubmissionDate")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Document Type 
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# string.Concat(" : ",Eval("DocumentTypeName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Document Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblDocumentName" runat="server" Text='<%# string.Concat(" : ",Eval("DocumentName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Document Path
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblDocumentPath" runat="server" Text='<%# string.Concat(" : ",Eval("DocumentPath")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Academic Year
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblAcademicYearID" runat="server" Text='<%# string.Concat(" : ",Eval("AcademicYearName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Institute
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblInstituteID" runat="server" Text='<%# string.Concat(" : ",Eval("InstituteName")) %>'></asp:Label>
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

