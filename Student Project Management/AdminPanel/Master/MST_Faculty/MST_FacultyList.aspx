﻿<%@ Page Title="Faculty List | Student Project Management" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_FacultyList.aspx.cs" Inherits="AdminPanel_Master_MST_Faculty_MST_FacultyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Faculty <small>(<asp:Label ID="lblCount" runat="server" Text="Faculty Count"></asp:Label>)</small>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_FacultyList.aspx">Faculty</a>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <br />
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

    <%-- Search --%>
    <asp:UpdatePanel ID="upApplicationFeature" runat="server">
        <ContentTemplate>
            <div class="col-md-12">
                <div class="portlet light">
                    <div class="portlet-title">
                        <div class="caption">
                            <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                            <asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server"></asp:Label>
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse pull-right"></a>
                        </div>
                    </div>
                    <div class="portlet-body form">
                        <div role="form">
                            <div class="form-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-search"></i>
                                                </span>
                                                <asp:TextBox ID="txtFacultyName" CssClass="First form-control" runat="server" PlaceHolder="Enter Faculty Name"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSearch" SkinID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnClear" runat="server" SkinID="btnClear" Text="Clear" OnClick="btnClear_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- End Search --%>

    <%-- List --%>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <%--Repeater Start--%>
                    <div class="portlet light" style="padding: 10px 20px 0px 10px; margin-bottom: 0px">
                        <div class="portlet-title">
                            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" ForeColor="red"></asp:Label>
                            <div class="caption">
                                <b>Faculty List</b>&nbsp;
                                    <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                <%--<label class="control-label pull-right">
                                        <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                                    </label>--%>
                            </div>
                            <div class="actions">
                                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/Master/MST_Faculty/MST_FacultyAddEdit.aspx"
                                    CssClass="btn btn-success" Text="<i class='fa fa-plus-circle'></i>&nbsp;Add Faculty"> 
                                </asp:HyperLink>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row" runat="server" id="Div_SearchResult" visible="false">
                                <div class="col-md-12 table-responsive">
                                    <div id="TableContent" style="overflow-x: auto;">
                                        <table class="table table-responsive table-bordered table-striped table-hover" id="tbFaculty">
                                            <thead>
                                                <tr class="TRDark">
                                                    <th hidden>
                                                        <asp:Label ID="lbhFacultyID" runat="server" Text="Faculty ID"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lblDepartmentCode" runat="server" Text="Department Code"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhFaculty" runat="server" Text="Faculty Name"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhFacultyShortName" runat="server" Text="ShortName"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                                                    </th>
                                                    <th hidden>
                                                        <asp:Label ID="lbhRemarks" runat="server" Text="Remarks"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhCreationDate" runat="server" Text="Creation"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptFacultyList" runat="server" OnItemCommand="rptFacultyList_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr class="odd gradeX">
                                                            <td hidden><%#Eval("FacultyID") %></td>
                                                            <td class="text-center"><%#Eval("DepartmentCode") %></td>
                                                            <td><%#Eval("FacultyName") %></td>
                                                            <td class="text-center"><%#Eval("FacultyShortName") %></td>
                                                            <td class="text-center"><%#Eval("Mobile") %></td>
                                                            <td><%#Eval("Email") %></td>
                                                            <td hidden><%#Eval("Remarks") %></td>
                                                            <td class="text-center"><%#Eval("Created","{0:dd-MM-yyyy}") %></td>
                                                            <td hidden class="text-center"><%#Eval("Modified","{0:dd-MM-yyyy}") %></td>
                                                            <td class="tdaction text-nowrap text-center">
                                                                <asp:HyperLink ID="hlEdit" SkinID="Edit" runat="server" NavigateUrl='<%# String.Concat("MST_FacultyAddEdit.aspx?","facultyid=",Eval("FacultyID")) %>'>                                                
                                                                </asp:HyperLink>

                                                                <asp:HyperLink ID="hlView" SkinID="View" runat="server" NavigateUrl='<%# String.Concat("MST_FacultyView.aspx?","facultyid=",Eval("FacultyID")) %>'>                                                
                                                                </asp:HyperLink>

                                                                <asp:HyperLink ID="hlCopy" SkinID="Copy" runat="server" NavigateUrl='<%# String.Concat("MST_FacultyAddEdit.aspx?","facultyid=",Eval("FacultyID"),"&Copy=Y") %>'>
                                                                </asp:HyperLink>

                                                                <asp:LinkButton ID="hlDelete" SkinID="Delete" runat="server" CommandArgument='<%#Eval("FacultyID") %>'
                                                                    CommandName="DeleteRecord" ToolTip="Delete Record">
                                                                </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                    <%-- Pagination --%>
                                    <div class="row">
                                        <div class="col-md-5">
                                            <div class="dataTables_paginate paging_simple_numbers" runat="server" id="Div_Pagination">
                                                <ul class="pagination">
                                                    <li class="paginate_button previous disabled" id="liFirstPage" runat="server">
                                                        <asp:LinkButton ID="lbtnFirstPage" Enabled="false" OnClick="PageChange_Click" CommandName="FirstPage" CommandArgument="1" runat="server"><i class="fa fa-angle-double-left"></i></asp:LinkButton></li>
                                                    <li class="paginate_button previous disabled" id="liPrevious" runat="server">
                                                        <asp:LinkButton ID="lbtnPrevious" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="PreviousPage" runat="server"><i class="fa fa-angle-left"></i></asp:LinkButton></li>
                                                    <asp:Repeater ID="rpPagination" runat="server" OnItemDataBound="rpPagination_ItemDataBound">
                                                        <ItemTemplate>
                                                            <li>
                                                                <li class="paginate_button" id="liPageNo" runat="server">
                                                                    <asp:LinkButton ID="lbtnPageNo" runat="server" OnClick="PageChange_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PageNo")%>' CommandName="PageNo"><%# DataBinder.Eval(Container.DataItem, "PageNo")%></asp:LinkButton></li>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <li class="paginate_button next disabled" id="liNext" runat="server">
                                                        <asp:LinkButton ID="lbtnNext" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="NextPage" runat="server"><i class="fa fa-angle-right"></i></asp:LinkButton></li>
                                                    <li class="paginate_button previous disabled" id="liLastPage" runat="server">
                                                        <asp:LinkButton ID="lbtnLastPage" Enabled="false" OnClick="PageChange_Click" CommandName="LastPage" CommandArgument="-99" runat="server"><i class="fa fa-angle-double-right"></i></asp:LinkButton></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="col-md-3 pull-right">
                                            <div class="btn-group" runat="server" id="Div_GoToPageNo">
                                                <asp:TextBox ID="txtPageNo" placeholder="Page No" onkeypress="return IsNumeric(event)" runat="server" CssClass="pagination-panel-input form-control input-xsmall input-inline col-md-4" MaxLength="9"></asp:TextBox>
                                                <asp:LinkButton ID="lbtnGoToPageNo" runat="server" CssClass="btn btn-default input-inline col-md-4" CommandName="GoPageNo" CommandArgument="0" OnClick="PageChange_Click">Go</asp:LinkButton>
                                            </div>
                                            <div class="btn-group pull-right" runat="server" id="Div_PageSize">
                                                <label class="control-label">Page Size</label>
                                                <asp:DropDownList ID="ddlPageSizeBottom" AutoPostBack="true" CssClass="form-control input-xsmall" runat="server" OnSelectedIndexChanged="ddlPageSizeBottom_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- END Pagination --%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--Repeater End--%>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- END List --%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
