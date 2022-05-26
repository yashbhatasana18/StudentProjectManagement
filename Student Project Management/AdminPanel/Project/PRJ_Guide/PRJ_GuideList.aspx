<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="PRJ_GuideList.aspx.cs" Inherits="AdminPanel_Project_PRJ_Guide_PRJ_GuideList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Guide <small>(<asp:Label ID="lblCount" runat="server" Text="Guide Count"></asp:Label>)</small>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="PRJ_GuideList.aspx">Guide</a>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <%--Repeater Start--%>
    <div class="portlet light" style="padding: 10px 20px 0px 10px; margin-bottom: 0px">
        <div class="portlet-title">
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" ForeColor="red"></asp:Label>
            <div class="caption">
                <b>Guide List</b>&nbsp;
                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                <%--<label class="control-label pull-right">
                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                </label>--%>
            </div>
            <div class="actions">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/Project/PRJ_Guide/PRJ_GuideAddEdit.aspx"
                    CssClass="btn btn-success" Text="<i class='fa fa-plus-circle'></i>&nbsp;Add Guide"> 
                </asp:HyperLink>
            </div>
        </div>

        <div class="portlet-body">
            <div class="row">
                <div class="col-md-12">
                    <div id="TableContent" style="overflow-x: auto;">
                        <table class="table table-responsive table-bordered table-striped table-hover" id="tbGuide">
                            <thead>
                                <tr class="TRDark">
                                    <th hidden>
                                        <asp:Label ID="lbhGuideID" runat="server" Text="Guide ID"></asp:Label>
                                    </th>
                                    <th class="text-left">
                                        <asp:Label ID="lbhGuideName" runat="server" Text="Guide Name"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhGuideShortName" runat="server" Text="Guide Short Name"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhIsActive" runat="server" Text="Is Active"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhDepartment" runat="server" Text="Department"></asp:Label>
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
                                <asp:Repeater ID="rptGuideList" runat="server" OnItemCommand="rptGuideList_ItemCommand">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td hidden><%#Eval("GuideID") %></td>
                                            <td class="text-left"><%#Eval("GuideName") %></td>
                                            <td class="text-center"><%#Eval("GuideShortName") %></td>
                                            <td class="text-center"><%#Eval("IsActive") %></td>
                                            <td class="text-center"><%#Eval("DepartmentName") %></td>
                                            <td hidden class="text-center"><%#Eval("Remarks") %></td>
                                            <td class="text-center"><%#Eval("Created","{0:dd-MM-yyyy}") %></td>
                                            <td hidden class="text-center"><%#Eval("Modified","{0:dd-MM-yyyy}") %></td>
                                            <td class="tdaction text-nowrap text-center">
                                                <asp:HyperLink ID="hlEdit" SkinID="Edit" runat="server" NavigateUrl='<%# String.Concat("PRJ_GuideAddEdit.aspx?","guideid=",Eval("GuideID")) %>'>                                                
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlView" SkinID="View" runat="server" NavigateUrl='<%# String.Concat("PRJ_GuideView.aspx?","guideid=",Eval("GuideID")) %>'>                                                
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlCopy" SkinID="Copy" runat="server" NavigateUrl='<%# String.Concat("PRJ_GuideAddEdit.aspx?","guideid=",Eval("GuideID"),"&Copy=Y") %>'>
                                                </asp:HyperLink>

                                                <asp:LinkButton ID="hlDelete" SkinID="Delete" runat="server" CommandArgument='<%#Eval("GuideID") %>'
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

