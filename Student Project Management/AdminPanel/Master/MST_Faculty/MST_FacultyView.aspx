<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_FacultyView.aspx.cs" Inherits="AdminPanel_Master_MST_Faculty_MST_FacultyView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Faculty View
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_FacultyList.aspx">Faculty</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>FacultyView
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
                        Faculty View
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a class="fullscreen"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <table class="table table-bordered table-striped table-hover">
                        <tr>
                            <td>Faculty ID
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblFacultyID" runat="server" Text='<%# string.Concat(" : ",Eval("FacultyID")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Faculty Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblFacultyName" runat="server" Text='<%# string.Concat(" : ",Eval("FacultyName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Faculty ShortName
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblFacultyShortName" runat="server" Text='<%# string.Concat(" : ",Eval("FacultyShortName")) %>'></asp:Label>
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
                            <td>Address
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# string.Concat(" : ",Eval("Address")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>City
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblCityID" runat="server" Text='<%# string.Concat(" : ",Eval("CityName")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Pincode
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblPincode" runat="server" Text='<%# string.Concat(" : ",Eval("Pincode")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Phone
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblPhone" runat="server" Text='<%# string.Concat(" : ",Eval("Phone")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Mobile
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblMobile" runat="server" Text='<%# string.Concat(" : ",Eval("Mobile")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Email
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# string.Concat(" : ",Eval("Email")) %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Website
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblWebsite" runat="server" Text='<%# string.Concat(" : ",Eval("Website")) %>'></asp:Label>
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

