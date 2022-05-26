<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="PRJ_ProjectList.aspx.cs" Inherits="AdminPanel_Project_PRJ_Project_PRJ_ProjectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Project <small>(<asp:Label ID="lblCount" runat="server" Text="Project Count"></asp:Label>)</small>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="PRJ_ProjectList.aspx">Project</a>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <%--Repeater Start--%>
    <div class="portlet light" style="padding: 10px 20px 0px 10px; margin-bottom: 0px">
        <div class="portlet-title">
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" ForeColor="red"></asp:Label>
            <div class="caption">
                <b>Project List</b>&nbsp;
                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                <%--<label class="control-label pull-right">
                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                </label>--%>
            </div>
            <div class="actions">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/Project/PRJ_Project/PRJ_ProjectAddEdit.aspx"
                    CssClass="btn btn-success" Text="<i class='fa fa-plus-circle'></i>&nbsp;Add Project"> 
                </asp:HyperLink>
            </div>
        </div>

        <div class="portlet-body">
            <div class="row">
                <div class="col-md-12">
                    <div id="TableContent" style="overflow-x: auto;">
                        <table class="table table-responsive table-bordered table-striped table-hover" id="tbProject">
                            <thead>
                                <tr class="TRDark">
                                    <th hidden>
                                        <asp:Label ID="lbhProjectID" runat="server" Text="Project ID"></asp:Label>
                                    </th>
                                    <th class="text-left">
                                        <asp:Label ID="lbhProjectTitle" runat="server" Text="Project Title"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhProjectShortTitle" runat="server" Text="Project Short Title"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhProjectCode" runat="server" Text="Project Code"></asp:Label>
                                    </th>
                                    <th class="text-left">
                                        <asp:Label ID="lbhGuideName" runat="server" Text="Guide Name"></asp:Label>
                                    </th>
                                    <%--<th class="text-center">
                                        <asp:Label ID="lbhDescription" runat="server" Text="Description"></asp:Label>
                                    </th>--%>
                                    <th class="text-center">
                                        <asp:Label ID="lbhDepartment" runat="server" Text="Department"></asp:Label>
                                    </th>
                                    <%--<th class="text-center">
                                        <asp:Label ID="lbhSemester" runat="server" Text="Semester"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhYear" runat="server" Text="Year"></asp:Label>
                                    </th>--%>
                                    <th class="text-center">
                                        <asp:Label ID="lbhAcademicYear" runat="server" Text="AcademicYear"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhTechnology" runat="server" Text="Technology"></asp:Label>
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
                                <asp:Repeater ID="rptProjectList" runat="server" OnItemCommand="rptProjectList_ItemCommand">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td hidden><%#Eval("ProjectID") %></td>
                                            <td class="text-left"><%#Eval("ProjectTitle") %></td>
                                            <td class="text-center"><%#Eval("ProjectShortTitle") %></td>
                                            <td class="text-center"><%#Eval("ProjectCode") %></td>
                                            <td class="text-left"><%#Eval("GuideName") %></td>
                                            <%--<td class="text-center"><%#Eval("Description") %></td>--%>
                                            <td class="text-center"><%#Eval("DepartmentCode") %></td>
                                            <%--<td class="text-center"><%#Eval("Semester") %></td>
                                            <td class="text-center"><%#Eval("Year") %></td>--%>
                                            <td class="text-center"><%#Eval("AcademicYearName") %></td>
                                            <td class="text-center"><%#Eval("TechnologyName") %></td>
                                            <td hidden class="text-center"><%#Eval("Remarks") %></td>
                                            <td class="text-center"><%#Eval("Created","{0:dd-MM-yyyy}") %></td>
                                            <td hidden class="text-center"><%#Eval("Modified","{0:dd-MM-yyyy}") %></td>
                                            <td class="tdaction text-nowrap text-center">
                                                <asp:HyperLink ID="hlEdit" SkinID="Edit" runat="server" NavigateUrl='<%# String.Concat("PRJ_ProjectAddEdit.aspx?","projectid=",Eval("ProjectID")) %>'>                                                
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlView" SkinID="View" runat="server" NavigateUrl='<%# String.Concat("PRJ_ProjectView.aspx?","projectid=",Eval("ProjectID")) %>'>                                                
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlCopy" SkinID="Copy" runat="server" NavigateUrl='<%# String.Concat("PRJ_ProjectAddEdit.aspx?","projectid=",Eval("ProjectID"),"&Copy=Y") %>'>
                                                </asp:HyperLink>

                                                <asp:LinkButton ID="hlDelete" SkinID="Delete" runat="server" CommandArgument='<%#Eval("ProjectID") %>'
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

