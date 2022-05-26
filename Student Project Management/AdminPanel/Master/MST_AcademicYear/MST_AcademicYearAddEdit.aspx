<%@ Page Title="" EnableTheming="true" Theme="Admin" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="MST_AcademicYearAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_AcademicYear_MST_AcademicYearAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageHeader" runat="Server">
    Academic Year 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink runat="server" NavigateUrl="~/AdminPanel/Default.aspx">Home</asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <a href="MST_AcademicYearList.aspx">Academic Year</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>AcademicYearAddEdit
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">

    <div style="padding-right: 25px; float: right;">
        <br />
        <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="javascript:history.go(-1)">
	        [ Back to page ]
        </asp:HyperLink>
    </div>

    <asp:Panel ID="pnlAlert" runat="server" Visible="false">
        <div class="alert alert-success alert-dismissable ">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true"></button>
            <asp:Label ID="lblErrorMsg" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </asp:Panel>

    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                <span class="caption-subject font-green-sharp bold uppercase">
                    <asp:Label runat="server" ID="lblPageHeader"></asp:Label>
                </span>
            </div>
        </div>

        <div class="portlet-body form">
            <div class="form-horizontal" role="form">
                <div class="form-body">

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>Academic Year Name</span>
                        </label>
                        <div class="col-md-3">
                            <asp:TextBox runat="server" ID="txtAcademicYearName" name="txtAcademicYearName" type="text" class="form-control" placeholder="Enter Academic Year Name" />
                            <asp:RequiredFieldValidator ID="rfvAcademicYearName" runat="server"
                                ControlToValidate="txtAcademicYearName" ErrorMessage="Enter City Name" Display="Dynamic"
                                SetFocusOnError="True" ValidationGroup="master" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>From Date</span>
                        </label>
                        <div class="col-md-3">
                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                <asp:TextBox runat="server" ID="txtFromDate" type="text" class="form-control" placeholder="Enter From Date" />
                                <span class="input-group-btn">
                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="rfvFromDate" runat="server"
                            ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Enter From Date" ValidationGroup="master"
                            SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <span class="required">*</span>
                            <span>To Date</span>
                        </label>
                        <div class="col-md-3">
                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                <asp:TextBox runat="server" ID="txtToDate" type="text" class="form-control" placeholder="Enter To Date" />
                                <span class="input-group-btn">
                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                </span>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="rfvToDate" runat="server"
                            ControlToValidate="txtToDate" Display="Dynamic" ErrorMessage="Enter To Date" ValidationGroup="master"
                            SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">
                            <asp:Label runat="server" ID="lblRemarks">Remarks</asp:Label>
                        </label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="300px" class="form-control" placeholder="Enter Remarks"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-actions">
                        <div class="row">
                            <div class="col-md-offset-3 col-md-9">
                                <asp:LinkButton ID="btnSave" runat="server" SkinID="btnSave" ValidationGroup="master" OnClick="btnSave_Click" />
                                <asp:HyperLink ID="btnCancel" runat="server" SkinID="hlCancel" CausesValidation="false" NavigateUrl="~/AdminPanel/Master/MST_AcademicYear/MST_AcademicYearList.aspx" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

