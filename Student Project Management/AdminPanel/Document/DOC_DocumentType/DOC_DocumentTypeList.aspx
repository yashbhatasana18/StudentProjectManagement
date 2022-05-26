<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="DOC_DocumentTypeList.aspx.cs" Inherits="AdminPanel_Document_DOC_DocumentType_DOC_DocumentTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Document Type <small>(<asp:Label ID="lblCount" runat="server" Text="Document Type Count"></asp:Label>)</small>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="DOC_DocumentTypeList.aspx">Document Type</a>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <%--Repeater Start--%>
    <div class="portlet light" style="padding: 10px 20px 0px 10px; margin-bottom: 0px">
        <div class="portlet-title">
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" ForeColor="red"></asp:Label>
            <div class="caption">
                <b>Document Type List</b>&nbsp;
                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                <%--<label class="control-label pull-right">
                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                </label>--%>
            </div>
            <div class="actions">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/Document/DOC_DocumentType/DOC_DocumentTypeAddEdit.aspx"
                    CssClass="btn btn-success" Text="<i class='fa fa-plus-circle'></i>&nbsp;Add Document Type"> 
                </asp:HyperLink>
            </div>
        </div>

        <div class="portlet-body">
            <div class="row">
                <div class="col-md-12">
                    <div id="TableContent" style="overflow-x: auto;">
                        <table class="table table-responsive table-bordered table-striped table-hover" id="tbDocumentType">
                            <thead>
                                <tr class="TRDark">
                                    <th hidden>
                                        <asp:Label ID="lbhDocumentTypeID" runat="server" Text="DocumentType ID"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhDocumentTypeName" runat="server" Text="DocumentType Name"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhDeadLine" runat="server" Text="DeadLine"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhIsInternal" runat="server" Text="IsInternal"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhIsGTU" runat="server" Text="IsGTU"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhIsCompulsory" runat="server" Text="IsCompulsory"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhIsGanttChart" runat="server" Text="IsGanttChart"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhDepartmentCode" runat="server" Text="DepartmentCode"></asp:Label>
                                    </th>
                                    <th hidden class="text-center">
                                        <asp:Label ID="lbhRemarks" runat="server" Text="Remarks"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhCreationDate" runat="server" Text="Created"></asp:Label>
                                    </th>
                                    <th hidden class="text-center">
                                        <asp:Label ID="lbhModificationDate" runat="server" Text="Modification Date"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptDocumentTypeList" runat="server" OnItemCommand="rptDocumentTypeList_ItemCommand">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td hidden><%#Eval("DocumentTypeID") %></td>
                                            <td class="text-center"><%#Eval("DocumentTypeName") %></td>
                                            <td class="text-center"><%#Eval("DeadLine") %></td>
                                            <td class="text-center"><%#Eval("IsInternal") %></td>
                                            <td class="text-center"><%#Eval("IsGTU") %></td>
                                            <td class="text-center"><%#Eval("IsCompulsory") %></td>
                                            <td class="text-center"><%#Eval("IsGanttChart") %></td>
                                            <td class="text-center"><%#Eval("DepartmentCode") %></td>
                                            <td hidden class="text-center"><%#Eval("Remarks") %></td>
                                            <td class="text-center"><%#Eval("Created","{0:dd-MM-yyyy}") %></td>
                                            <td hidden class="text-center"><%#Eval("Modified","{0:dd-MM-yyyy}") %></td>
                                            <td class="tdaction text-nowrap text-center">
                                                <asp:HyperLink ID="hlEdit" SkinID="Edit" runat="server" NavigateUrl='<%# String.Concat("DOC_DocumentTypeAddEdit.aspx?","documenttypeid=",Eval("DocumentTypeID")) %>'>                                                
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlView" SkinID="View" runat="server" NavigateUrl='<%# String.Concat("DOC_DocumentTypeView.aspx?","documenttypeid=",Eval("DocumentTypeID")) %>'>                                                
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlCopy" SkinID="Copy" runat="server" NavigateUrl='<%# String.Concat("DOC_DocumentTypeAddEdit.aspx?","documenttypeid=",Eval("DocumentTypeID"),"&Copy=Y") %>'>
                                                </asp:HyperLink>

                                                <asp:LinkButton ID="hlDelete" SkinID="Delete" runat="server" CommandArgument='<%#Eval("DocumentTypeID") %>'
                                                    CommandName="DeleteRecord" ToolTip="Delete Record">
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--Repeater End--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

