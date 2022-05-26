﻿<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="WRK_WorkAssignedList.aspx.cs" Inherits="AdminPanel_Work_WRK_WorkAssigned_WRK_WorkAssignedList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    WorkAssigned <small>(<asp:Label ID="lblCount" runat="server" Text="WorkAssigned Count"></asp:Label>)</small>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="WRK_WorkAssignedList.aspx">WorkAssigned</a>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <%--Repeater Start--%>
    <div class="portlet light" style="padding: 10px 20px 0px 10px; margin-bottom: 0px">
        <div class="portlet-title">
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" ForeColor="red"></asp:Label>
            <div class="caption">
                <b>Work Assigned List</b>&nbsp;
                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                <%--<label class="control-label pull-right">
                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                </label>--%>
            </div>
            <div class="actions">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/Work/WRK_WorkAssigned/WRK_WorkAssignedAddEdit.aspx"
                    CssClass="btn btn-success" Text="<i class='fa fa-plus-circle'></i>&nbsp;Add WorkAssigned"> 
                </asp:HyperLink>
            </div>
        </div>

        <div class="portlet-body">
            <div class="row">
                <div class="col-md-12">
                    <div id="TableContent" style="overflow-x: auto;">
                        <table class="table table-responsive table-bordered table-striped table-hover" id="tbWorkAssigned">
                            <thead>
                                <tr class="TRDark">
                                    <th hidden>
                                        <asp:Label ID="lbhWorkAssignedID" runat="server" Text="Work Assigned ID"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhFacultyName" runat="server" Text="Guide Name"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhProjectCode" runat="server" Text="Project Code"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhProjectTitle" runat="server" Text="Project Title"></asp:Label>
                                    </th>
                                    <th class="text-center"> 
                                        <asp:Label ID="lbhStudentName" runat="server" Text="Student Name"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhDeadLine" runat="server" Text="DeadLine"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhWorkTobeDone" runat="server" Text="WorkTobeDone"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhSubmittedDate" runat="server" Text="Submitted Date"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhFacultyRemarks" runat="server" Text="Faculty Remarks"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhInstituteName" runat="server" Text="Institute Name"></asp:Label>
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
                                <asp:Repeater ID="rptWorkAssignedList" runat="server" OnItemCommand="rptWorkAssignedList_ItemCommand">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td hidden><%#Eval("WorkAssignedID") %></td>
                                            <td class="text-center"><%#Eval("GuideName") %></td>
                                            <td class="text-center"><%#Eval("ProjectCode") %></td>
                                            <td class="text-center"><%#Eval("ProjectTitle") %></td>
                                            <td class="text-center"><%#Eval("StudentName") %></td>
                                            <td class="text-center"><%#Eval("DeadLine") %></td>
                                            <td class="text-center"><%#Eval("WorkTobeDone") %></td>
                                            <td class="text-center"><%#Eval("SubmittedDate") %></td>
                                            <td class="text-center"><%#Eval("FacultyRemarks") %></td>
                                            <td class="text-center"><%#Eval("InstituteName") %></td>
                                            <td class="text-center"><%#Eval("Created","{0:dd-MM-yyyy}") %></td>
                                            <td hidden class="text-center"><%#Eval("Modified","{0:dd-MM-yyyy}") %></td>
                                            <td class="tdaction text-nowrap text-center">
                                                <asp:HyperLink ID="hlEdit" SkinID="Edit" runat="server" NavigateUrl='<%# String.Concat("WRK_WorkAssignedAddEdit.aspx?","workassignedid=",Eval("WorkAssignedID")) %>'>                                                
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlView" SkinID="View" runat="server" NavigateUrl='<%# String.Concat("WRK_WorkAssignedView.aspx?","workassignedid=",Eval("WorkAssignedID")) %>'>                                                
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlCopy" SkinID="Copy" runat="server" NavigateUrl='<%# String.Concat("WRK_WorkAssignedAddEdit.aspx?","workassignedid=",Eval("WorkAssignedID"),"&Copy=Y") %>'>
                                                </asp:HyperLink>

                                                <asp:LinkButton ID="hlDelete" SkinID="Delete" runat="server" CommandArgument='<%#Eval("WorkAssignedID") %>'
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

