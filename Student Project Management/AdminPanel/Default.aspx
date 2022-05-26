<%@ Page Title="Dashboard | Student Project Management" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AdminPanel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Dashboard
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>Dashboard
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="Server">
    <!-- BEGIN DASHBOARD STATS -->
    <br />
    <div class="col-md-12">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="dashboard-stat blue-madison">
                <div class="visual">
                    <i class="fa fa-group fa-icon-medium"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <asp:Label ID="lblStudents" runat="server" Text="Student Count"></asp:Label>
                    </div>
                    <div class="desc">
                        Students
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="dashboard-stat red-intense">
                <div class="visual">
                    <i class="fa fa-briefcase fa-icon-medium"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <asp:Label ID="lblProjects" runat="server" Text="Project Count"></asp:Label>
                    </div>
                    <div class="desc">
                        Projects
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="portlet light" style="padding: 10px 20px 0px 10px; margin-bottom: 0px">
        <div class="portlet-body">
            <div class="row">
                <div class="col-md-6">
                    <div id="TableContent" style="overflow-x: auto;">
                        <table class="table table-responsive table-bordered table-striped table-hover" id="tbTechnology">
                            <thead>
                                <tr class="TRDark">
                                    <th class="text-center">
                                        <asp:Label ID="lbhTechnologyName" runat="server" Text="Technology Name"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lbhProjectCount" runat="server" Text="Project Count"></asp:Label>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptTechnology" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td class="text-center"><%#Eval("TechnologyName") %></td>
                                            <td class="text-center"><%#Eval("ProjectCount") %></td>
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
    <!-- END DASHBOARD STATS -->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

