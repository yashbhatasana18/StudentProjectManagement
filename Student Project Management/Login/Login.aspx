<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login | Student Project Management</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../Default/assets/global/plugins/select2/select2.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/admin/pages/css/login3.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- BEGIN THEME STYLES -->
    <link href="../Default/assets/global/css/components.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/admin/layout/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="../Default/assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
    <style>
        h3 {
            margin-bottom: 14px !important;
        }

        .content {
            padding-top: 10px !important;
        }

        .login {
            background-color: #364150 !important;
        }

        .input-icon {
            border-radius: 20px !important;
        }

        .login .content .input-icon .form-control {
            border-radius: 20px !important;
            border-color: darkgrey;
        }

        .input-icon > .form-control {
            border-radius: 20px !important;
        }

        .form-control {
            border-radius: 20px !important;
        }

        div, input, select, textarea, span, img, table, label, td, th, p, a, button, ul, code, pre, li {
            border-radius: 20px !important;
        }
    </style>
</head>
<body class="login">
    <form id="Form1" class="login-form" runat="server" action="Login.aspx" name="StudentLogin">
        <asp:Panel ID="cpPanel" runat="server" DefaultButton="lbtnLogin" Style="margin-top: 50px;">
            <!-- BEGIN LOGO -->
            <div class="logo">
                <h1 style="color: white;" class="bold">
                    <asp:Label ID="lblHeaderCompanyName" runat="server"></asp:Label>
                </h1>
                <h2 style="color: white;" class="bold">Control Panel</h2>
            </div>
            <!-- END LOGO -->
            <!-- BEGIN LOGIN -->
            <div class="content" style="border-radius: 10px !important; background-color: #ECEEF1; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);">
                <!-- BEGIN LOGIN FORM -->
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        <h3 class="form-title text-center bold" style="color: #4DC0CC;">Login to your account</h3>
                        <br />
                        <%--<div>
                        <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                    </div>--%>
                        <div class="form-group">
                            <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                            <%--<label class="control-label "><span class="text-danger">*</span>&nbsp;Username</label>--%>
                            <div class="input-icon">
                                <i class="fa fa-user"></i>
                                <asp:TextBox ID="txtUserName" CssClass="form-control placeholder-no-fix" runat="server" placeholder="Enter UserName"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Enter UserName" ValidationGroup="login"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <%--<label class="control-label "><span class="text-danger">*</span>&nbsp;Password</label>--%>
                            <div class="input-icon">
                                <i class="fa fa-lock"></i>
                                <asp:TextBox ID="txtPassword" CssClass="form-control placeholder-no-fix" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Enter Password" ValidationGroup="login"></asp:RequiredFieldValidator>
                        </div>

                        <%--<div class="form-group">
                            <div class="input-icon">
                                <i class="fa fa-lock"></i>
                                <asp:DropDownList ID="ddlAcademicYearID" CssClass="form-control placeholder-no-fix" runat="server"></asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvAcademicYear" runat="server" ControlToValidate="ddlAcademicYearID" Display="Dynamic" InitialValue="-99" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Select AcademicYear" ValidationGroup="login"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <div class="input-icon">
                                <i class="fa fa-lock"></i>
                                <asp:DropDownList ID="ddlInstituteID" CssClass="form-control placeholder-no-fix" runat="server"></asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvInstitute" runat="server" ControlToValidate="ddlInstituteID" Display="Dynamic" InitialValue="-99" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Select Institute" ValidationGroup="login"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <div class="input-icon">
                                <i class="fa fa-lock"></i>
                                <asp:DropDownList ID="ddlUserCategoryID" CssClass="form-control placeholder-no-fix" runat="server"></asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvUserCategory" runat="server" ControlToValidate="ddlUserCategoryID" InitialValue="-99" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Select User Category" ValidationGroup="login"></asp:RequiredFieldValidator>
                        </div>--%>

                        <div>
                            <asp:LinkButton runat="server" ID="lbtnLogin" CssClass="btn green uppercase pull-right" TabIndex="3" ValidationGroup="login" OnClick="btnLogIn_Click">
                                Login&nbsp;&nbsp;<i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                        </div>

                        <%--                        <div class="forget-password text-center">
                            <h4>Forgot your password ?</h4>
                            <p>
                                No worries, click
                        <asp:HyperLink ID="hlChangePassword" runat="server" NavigateUrl="~/AdminPanel/ChangePassword.aspx" Target="_blank">here </asp:HyperLink>
                                to reset your password.
                            </p>
                        </div>--%>
                    </div>
                </div>
                <!-- END LOGIN FORM -->
            </div>
        </asp:Panel>
    </form>

    <%--<div class="copyright">
        <%#DateTime.Now.Year %> &copy; WebExpanders
    </div>--%>
    <script src="../Default/assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="../Default/assets/global/plugins/jquery-migrate.min.js" type="text/javascript"></script>
    <script src="../Default/assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Default/assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="../Default/assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="../Default/assets/global/plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="../Default/assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Default/assets/global/plugins/select2/select2.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../Default/assets/global/scripts/metronic.js" type="text/javascript"></script>
    <script src="../Default/assets/admin/layout/scripts/layout.js" type="text/javascript"></script>
    <script src="../Default/assets/admin/layout/scripts/demo.js" type="text/javascript"></script>
    <script src="../Default/assets/admin/pages/scripts/login.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>
        jQuery(document).ready(function () {
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            Login.init();
            Demo.init();
        });
    </script>
    <!-- END JAVASCRIPTS -->
</body>
</html>
