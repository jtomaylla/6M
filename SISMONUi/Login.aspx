<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SISMONUi.Login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="css/General.css" rel="stylesheet" type="text/css" />
    <link href="css/jbar.colors.css" rel="stylesheet" type="text/css" />
    <link href="css/jbar.css" rel="stylesheet" type="text/css" />
    <link href="css/jAlerts/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="js/jquery.alerts.js" type="text/javascript"></script>
    <script src="js/commons.js" type="text/javascript"></script>
    <script src="js/jquery.bar.custom.js" type="text/javascript"></script>
    <script src="js/helpers.js" type="text/javascript"></script>
    <style type="text/css">
        .tasktable
        {
            padding-left: 15px;
            padding-bottom: 15px;
            padding-top: 15px;
            padding-right: 15px;
            align: lef;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadFormDecorator ID="rfdLogin" runat="server" Skin="Silk" DecoratedControls="All" />
    <telerik:RadAjaxPanel ID="rapLogin" runat="server" HorizontalAlign="NotSet">
        <div id="wrapper">
            <div id="intwrapper">
                <div class="gestion_cabecera">
                    <div class="gestion_cabeceraleft">
                        <h2>
                            <img src="img/6m.png" />
                        </h2>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="contenido_wrapper">
                    <div class="contenido_ttl_login">
                        <div class="ttl_login">
                            Login</div>
                    </div>
                    <div class="contenido_content">
                        <div class="box_img_login">
                            <img src="img/img_login.jpg" width="222" height="244" />
                        </div>
                        <div class="contenido_contentRight">
                            <div class="box_login">
                                <table width="205" border="0" cellpadding="0" cellspacing="0" class="table_login">
                                    <tr>
                                        <td width="205" align="left">
                                            Usuario
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="spb">
                                            <asp:TextBox ID="txtUsuario" OnTextChanged="txtUsuario_TextChanged" runat="server"
                                                Width="183px" class="txt_login"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                                                ValidationGroup="login" ControlToValidate="txtUsuario" ErrorMessage="Debe ingresar el usuario.">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            Contraseña
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="spb">
                                            <asp:TextBox ID="txtContrasena" OnTextChanged="txtContrasena_TextChanged" runat="server"
                                                Width="183px" class="txt_login" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                                                ValidationGroup="login" ControlToValidate="txtContrasena" ErrorMessage="Debe ingresar una contraseña.">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            Módulo
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddlModule" runat="server" Skin="Silk" DataTextField="Name"
                                                Width="183px" DataValueField="Id_Module">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Button ID="btnLogin" CssClass="btn_ingresar" runat="server" Text="" OnClick="btnLogin_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <span></span>
                                <p>
                                    El acceso a este sistema es exclusivamente para el cumplimiento de las labores internas
                                    de la empresa, la que se reserva el derecho de auditar su empleo, sancionar conforme
                                    a reglamento a las personas que hagan uso no autorizado, mal uso o uso malintencionado
                                    de ella; y/o denunciar penalmente a aquellas personas mediante manipulación dolosa
                                    al sistema causen perjuicio a nuestra Empresa.</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="footer_gestion">
                    <a class="splash" href="Acercade.aspx" title="WCSSoftCorp">
                        <%--<img src='<%= ResolveUrl("img/wcsFooter.png") %>' />--%>
                    </a>
                </div>
                <div class="copyright_gestion">
                </div>
            </div>
        </div>
        <telerik:RadWindow runat="server" ID="rwChangePsw" Modal="true" Skin="Silk" Animation="FlyIn"
            AnimationDuration="500" VisibleOnPageLoad="false" Behaviors="Close" Title="Cambiar Contraseña"
            EnableShadow="true" Height="290px" Width="395px">
            <ContentTemplate>
                <table style="z-index: 8000; background-color: #fbfbfc">
                    <tr>
                        <td style="padding: 5px 5px 5px 5px">
                            <table width="100%" border="0px" cellpadding="0px" cellspacing="0px" style="background-color: #fbfbfc;
                                font-family: calibri;">
                                <tr>
                                    <td align="left" class="tasktable" style="border-style: solid none none solid; border-top-width: 0.5px;
                                        border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2; background-color: #F3F3F3;">
                                        Usuario
                                    </td>
                                    <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                        border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                        <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="tasktable" style="border-style: solid none none solid; border-top-width: 0.5px;
                                        border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2; background-color: #F3F3F3;">
                                        Nueva Contraseña
                                    </td>
                                    <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                        border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                        <asp:TextBox ID="txtPws" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPws" runat="server" ControlToValidate="txtPws"
                                            ErrorMessage="Ingrese Contraseña" SetFocusOnError="True" ValidationGroup="save"
                                            Display="None">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="cvPws" runat="server" ControlToCompare="txtPws" ControlToValidate="txtRePws"
                                            ErrorMessage="Las contraseñas no son iguales" SetFocusOnError="True" ValidationGroup="save"
                                            Display="None">*</asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="tasktable" style="border-style: solid none none solid; border-top-width: 0.5px;
                                        border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2; background-color: #F3F3F3;">
                                        Re Contraseña
                                    </td>
                                    <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                        border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                        <asp:TextBox ID="txtRePws" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvRePws" runat="server" ControlToValidate="txtRePws"
                                            ErrorMessage="Ingrese Re-Contraseña" SetFocusOnError="True" ValidationGroup="save"
                                            Display="None">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="actions">
                                            <telerik:RadButton ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click"
                                                ValidationGroup="save" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </telerik:RadWindow>
        <asp:ValidationSummary ID="vsLogin" ShowMessageBox="true" HeaderText="Datos requeridos"
            ShowSummary="false" runat="server" ValidationGroup="login" />
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
