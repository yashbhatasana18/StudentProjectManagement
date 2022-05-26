<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="DOC_DocumentTypeView.aspx.cs" Inherits="AdminPanel_Document_DOC_DocumentType_DOC_DocumentTypeView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Document Type View
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="DOC_DocumentTypeList.aspx">DocumentType</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>DocumentTypeView
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
                            <td>DocumentType
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblDocumentTypeID" runat="server" Text='<%# string.Concat(" : ",Eval("DocumentTypeID")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>DocumentTypeName
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblDocumentTypeName" runat="server" Text='<%# string.Concat(" : ",Eval("DocumentTypeName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>IsInternal
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblIsInternal" runat="server" Text='<%# string.Concat(" : ",Eval("IsInternal")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>IsGTU
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblIsGTU" runat="server" Text='<%# string.Concat(" : ",Eval("IsGTU")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>DeadLine
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblDeadLine" runat="server" Text='<%# string.Concat(" : ",Eval("DeadLine","{0:d}")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>IsCompulsory
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblIsCompulsory" runat="server" Text='<%# string.Concat(" : ",Eval("IsCompulsory")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>IsGanttChart
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblIsGanttChart" runat="server" Text='<%# string.Concat(" : ",Eval("IsGanttChart")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>AcademicYear
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblAcademicYearID" runat="server" Text='<%# string.Concat(" : ",Eval("AcademicYearName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Department
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblDepartmentID" runat="server" Text='<%# string.Concat(" : ",Eval("DepartmentName")) %>'></asp:Label>
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

