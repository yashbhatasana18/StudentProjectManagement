<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_InstituteList.aspx.cs" Inherits="AdminPanel_Master_MST_Institute_MST_InstituteList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Institute <small>(<asp:Label ID="lblCount" runat="server" Text="Institute Count"></asp:Label>)</small>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_InstituteList.aspx">Institute</a>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <%--Repeater Start--%>
    <div class="portlet light" style="padding: 10px 20px 0px 10px; margin-bottom: 0px">
        <div class="portlet-title">
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false" ForeColor="red"></asp:Label>
            <div class="caption">
                <b>Institute List</b>&nbsp;
                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                <%--<label class="control-label pull-right">
                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                </label>--%>
            </div>
            <div class="actions">
                <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/AdminPanel/Master/MST_Institute/MST_InstituteAddEdit.aspx"
                    CssClass="btn btn-success" Text="<i class='fa fa-plus-circle'></i>&nbsp;Add Institute"> 
                </asp:HyperLink>
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-md-12">
                    <div id="TableContent" style="overflow-x: auto;">
                        <table class="table table-responsive table-bordered table-striped table-hover" id="tbInstitute">
                            <thead>
                                <tr class="TRDark">
                                    <th hidden>
                                        <asp:Label ID="lblInstituteID" runat="server" Text="Institute ID"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblInstituteName" runat="server" Text="Institute Name"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblInstituteShortName" runat="server" Text="Short Name"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhInstituteCode" runat="server" Text="Institute Code"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblInstitutePhone" runat="server" Text="Phone"></asp:Label>
                                    </th>
                                    <%--<th class="text-center">
                                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                </th>--%>
                                    <th class="text-center">
                                        <asp:Label ID="lblCityName" runat="server" Text="City"></asp:Label>
                                    </th>
                                    <th class="text-center" hidden>
                                        <asp:Label ID="lblPincode" runat="server" Text="Pincode"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblWebsite" runat="server" Text="Website"></asp:Label>
                                    </th>
                                    <th class="text-center" hidden>
                                        <asp:Label ID="lbhRemarks" runat="server" Text="Remarks"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhCreationDate" runat="server" Text="Creation"></asp:Label>
                                    </th>
                                    <th class="text-center" hidden>
                                        <asp:Label ID="lbhModificationDate" runat="server" Text="Modification Date"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptInstituteList" runat="server" OnItemCommand="rptInstituteList_ItemCommand">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td hidden><%#Eval("InstituteID") %></td>
                                            <td><%#Eval("InstituteName") %></td>
                                            <td class="text-center"><%#Eval("InstituteShortName") %></td>
                                            <td class="text-center"><%#Eval("InstituteCode") %></td>
                                            <td class="text-center"><%#Eval("Mobile") %></td>
                                            <td class="text-center"><%#Eval("InstitutePhone") %></td>                               
                                            <%--<td class="text-center"><%#Eval("Address") %></td>--%>
                                            <td class="text-center"><%#Eval("CityName") %></td>
                                            <td class="text-center" hidden><%#Eval("Pincode") %></td>
                                            <td class="text-center"><%#Eval("Email") %></td>
                                            <td class="text-center"><%#Eval("Website") %></td>
                                            <td class="text-center" hidden><%#Eval("Remarks") %></td>
                                            <td class="text-center"><%#Eval("Created","{0:dd-MM-yyyy}") %></td>
                                            <td class="text-center" hidden><%#Eval("Modified","{0:dd-MM-yyyy}") %></td>
                                            <td class="tdaction text-nowrap text-center">
                                                <asp:HyperLink ID="hlEdit" SkinID="Edit" runat="server" NavigateUrl='<%# String.Concat("MST_InstituteAddEdit.aspx?","instituteid=",Eval("InstituteID")) %>'>
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlView" SkinID="View" runat="server" NavigateUrl='<%# String.Concat("MST_InstituteView.aspx?","instituteid=",Eval("InstituteID")) %>'>
                                                </asp:HyperLink>

                                                <asp:HyperLink ID="hlCopy" SkinID="Copy" runat="server" NavigateUrl='<%# String.Concat("MST_InstituteAddEdit.aspx?","instituteid=",Eval("InstituteID"),"&Copy=Y") %>'>
                                                </asp:HyperLink>

                                                <asp:LinkButton ID="hlDelete" SkinID="Delete" runat="server" CommandArgument='<%#Eval("InstituteID") %>'
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

