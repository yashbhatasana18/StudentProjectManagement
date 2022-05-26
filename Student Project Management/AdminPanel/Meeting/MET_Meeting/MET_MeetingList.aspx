<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MET_MeetingList.aspx.cs" Inherits="AdminPanel_Meeting_MET_Meeting_MET_MeetingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" Runat="Server">
    Meeting <small>(<asp:Label ID="lblCount" runat="server" Text="Meeting Count"></asp:Label>)</small>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" Runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MET_MeetingList.aspx">Meeting</a>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" Runat="Server">
        <%--Repeater Start--%>
    <div class="portlet light" style="padding: 10px 20px 0px 10px; margin-bottom: 0px">
        <div class="portlet-title">
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" ForeColor="red"></asp:Label>
            <div class="caption">
                <b>Meeting List</b>&nbsp;
                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                <%--<label class="control-label pull-right">
                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                </label>--%>
            </div>
            <div class="actions">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/Meeting/MET_Meeting/MET_MeetingAddEdit.aspx"
                    CssClass="btn btn-success" Text="<i class='fa fa-plus-circle'></i>&nbsp;Add Meeting"> 
                </asp:HyperLink>
            </div>
        </div>

        <div class="portlet-body">
            <div class="row">
                <div class="col-md-12">
                    <div id="TableContent" style="overflow-x: auto;">
                        <table class="table table-responsive table-bordered table-striped table-hover" id="tbMeeting">
                            <thead>
                                <tr class="TRDark">
                                    <th hidden>
                                        <asp:Label ID="lbhMeetingID" runat="server" Text="MeetingID"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhMeetingDate" runat="server" Text="Meeting Date"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhNextMeetingDate" runat="server" Text="Next Meeting Date"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhWorkAssigned" runat="server" Text="Work Assigned"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhWorkDone" runat="server" Text="WorkDone"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhMeetingDuration" runat="server" Text="Meeting Duration"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhFacultyRemarks" runat="server" Text="Faculty Remarks"></asp:Label>
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
                                <asp:Repeater ID="rptMeetingList" runat="server" OnItemCommand="rptMeetingList_ItemCommand">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td hidden><%#Eval("MeetingID") %></td>
                                            <td class="text-center"><%#Eval("MeetingDate") %></td>
                                            <td class="text-center"><%#Eval("NextMeetingDate") %></td>
                                            <td class="text-center"><%#Eval("WorkAssigned") %></td>
                                            <td class="text-center"><%#Eval("WorkDone") %></td>
                                            <td class="text-center"><%#Eval("MeetingDuration") %></td>
                                            <td class="text-center"><%#Eval("FacultyRemarks") %></td>
                                            <td class="text-center"><%#Eval("Created","{0:dd-MM-yyyy}") %></td>
                                            <td hidden class="text-center"><%#Eval("Modified","{0:dd-MM-yyyy}") %></td>
                                            <td class="tdaction text-nowrap text-center">
                                                <asp:HyperLink ID="hlEdit" SkinID="Edit" runat="server" NavigateUrl='<%# String.Concat("MET_MeetingAddEdit.aspx?","meetingid=",Eval("MeetingID")) %>'>                                                
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlView" SkinID="View" runat="server" NavigateUrl='<%# String.Concat("MET_MeetingView.aspx?","meetingid=",Eval("MeetingID")) %>'>                                                
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlCopy" SkinID="Copy" runat="server" NavigateUrl='<%# String.Concat("MET_MeetingAddEdit.aspx?","meetingid=",Eval("MeetingID"),"&Copy=Y") %>'>
                                                </asp:HyperLink>

                                                <asp:LinkButton ID="hlDelete" SkinID="Delete" runat="server" CommandArgument='<%#Eval("MeetingID") %>'
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
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

