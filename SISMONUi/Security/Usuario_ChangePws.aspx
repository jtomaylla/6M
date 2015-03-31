<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario_ChangePws.aspx.cs"
    Inherits="SISMONUi.Security.Usuario_ChangePws" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/general.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../js/Helper.js" type="text/javascript"></script>
    <script src="../js/commons.js" type="text/javascript"></script>
    <link href="../css/jAlerts/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.alerts.js" type="text/javascript"></script>
    <script type="text/javascript">
        //        function grabar() {
        //            var parentPage = GetRadWindow().BrowserWindow;
        //            parentPage.msg('Contraseña cambiada correctamente');
        //            GetRadWindow().close();
        //            return false;
        //        }
        //        function validatePage() {
        //            Page_ClientValidate();
        //            var s, headerSep, first, pre, post, end;
        //            headerSep = ""; first = "<ul>"; pre = "<li>"; post = "</li>"; end = "</ul>";
        //            s = first;
        //            for (i = 0; i < Page_Validators.length; i++) {
        //                if (!Page_Validators[i].isvalid && typeof (Page_Validators[i].errormessage) == "string") {
        //                    s += pre + Page_Validators[i].errormessage + post;
        //                }
        //            }
        //            s += end;
        //            if (!Page_IsValid) {
        //                var parentPage = GetRadWindow().BrowserWindow;
        //                parentPage.msgValidChangePws('Datos Requeridos', s);
        //            }
        //        }
    </script>
</head>
<body style="background-image: none">
    <form id="form1" runat="server">
    <%--<telerik:radscriptmanager id="RadScriptManager1" runat="server">
    </telerik:radscriptmanager>
    <telerik:radformdecorator id="RadFormDecorator1" decoratedcontrols="All" runat="server" />--%>
    <div>
        <table>
            <tr>
                <td style="width: 130px; padding-left: 10px; padding-top: 15px">
                    Usuario
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 10px">
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px">
                    Nueva Contraseña
                </td>
                <td>
                    :
                </td>
                <td>
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
                <td style="padding-left: 10px">
                    Re Contraseña
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtRePws" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRePws" runat="server" ControlToValidate="txtRePws"
                        ErrorMessage="Ingrese Re-Contraseña" SetFocusOnError="True" ValidationGroup="save"
                        Display="None">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 10px">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 10px; text-align: center">
                    <telerik:RadButton ID="btnAceptar" runat="server" Text="Aceptar" OnClientClick="return validatePage();"
                        OnClick="btnAceptar_Click" ValidationGroup="save" />
                    &nbsp;&nbsp;<telerik:RadButton ID="btnCancelar" runat="server" OnClientClick="GetRadWindow().close();return false;"
                        Text="Regresar" />
                </td>
            </tr>
        </table>
    </div>
    <input id="hidIdUser" runat="server" type="hidden" />
    </form>
</body>
</html>
