<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserDetails.aspx.cs" Inherits="SISMONUi.Security.UserDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        //************************************************************************************************************//
        function msg(mensage) {
            jAlert(mensage,"<%= GetGlobalResourceObject("MsjApp", "TitleConfirm").ToString() %>");
        }
        function msgValidChangePws(title,mensage) {
            jAlert(mensage,title);
        }

        function OnClientFileUploaded(sender, args) {
            <%=rapOrganization.ClientID%>.ajaxRequest('LoadImage');
        }
        //************************************************************************************************************//
        
        
    </script>
    <style type="text/css">
        .button
        {
            background-color: #b0b3b4;
            border-style: none;
            font-size: 12px;
            color: White;
            height: 28px;
            width: 70px;
            cursor: pointer;
        }
        
        .button:hover
        {
            background-color: #007DFB;
            border-style: none;
            font-size: 12px;
            color: White;
            height: 28px;
            width: 70px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" Text="Mantenimiento de Usuario" runat="server" Font-Bold="True"></asp:Label>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960">
                <!-- caja datos -->
                <telerik:RadAjaxPanel ID="rapOrganization" runat="server" HorizontalAlign="NotSet"
                    LoadingPanelID="RadAjaxLoadingPanelMaster">
                    <div class="contentRight_enlaces list_perfil">
                        <telerik:RadButton ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar"
                            ValidationGroup="save" ResolvedRenderMode="Classic" />
                        <telerik:RadButton ID="btnCancelar" runat="server" Text="Regresar" OnClick="btnCancelar_Click" />
                        <%--<asp:Button ID="Button1" runat="server" class="button" Text="Prueba" />--%>
                    </div>
                    <div class="conten_caja_sub_categoria marhin-topnone" style="width: 940px;">
                        <div class="top_table_bandejat">
                        </div>
                        <div class="tabla_sup_caja_sub_categoria" style="min-height: 250px;">
                            <fieldset class="fieldset">
                                <legend class="legend">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                Informacion General
                                            </td>
                                            <td align="right">
                                                <asp:Image ID="imgUserImage" runat="server" Width="80px" Height="90px" />
                                            </td>
                                        </tr>
                                    </table>
                                </legend>
                                <div class="row">
                                    <label>
                                        <strong>Nombre:</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtFirst_Name" runat="server" Width="640px" Style="text-transform: uppercase">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirst_Name"
                                            ErrorMessage="Debe ingresar nombre" Display="None" ValidationGroup="save">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Ap. Paterno</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtSurname1" runat="server" Style="text-transform: uppercase"
                                            Width="640px">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSurname1"
                                            ErrorMessage="Debe ingresar el apellido paterno." Display="None" ValidationGroup="save">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Ap. Materno</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtSurname2" runat="server" Style="text-transform: uppercase"
                                            Width="640px">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSurname2"
                                            ErrorMessage="Debe ingresar el apellido materno." Display="None" ValidationGroup="save">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Email</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtEmail" runat="server" Style="text-transform: lowercase"
                                            Width="640px">
                                        </telerik:RadTextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                            Display="None" ValidationGroup="save" ErrorMessage="Formato de email inválido."
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Usuario</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtUserName" runat="server" Style="text-transform: uppercase"
                                            Width="640px">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                            Display="None" ValidationGroup="save" ErrorMessage="Ingrese Usuario" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Foto</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <asp:ImageButton ToolTip="Eliminar foto" Width="16" Height="16" CausesValidation="false"
                                            ImageUrl='~/img/ico_delete.png' runat="server" ID="imgDeleteAtt" Visible="false"
                                            OnClick="imgDeleteAtt_Click" />
                                        <telerik:RadAsyncUpload runat="server" ID="rauUserImage" MultipleFileSelection="Disabled"
                                            AllowedFileExtensions="jpg" ToolTip="Cargar imagen de usuario" MaxFileInputsCount="1">
                                            <Localization Select="Select." Remove="Elim." />
                                        </telerik:RadAsyncUpload>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Forzar cambiar contraseña</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <table style="width: 5%">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkMust_Change_Password" runat="server" Checked="true" Font-Names="Tahoma"
                                                        Font-Size="8pt" />
                                                </td>
                                                <td>
                                                    <asp:Image ID="helpIcon1" runat="server" ToolTip="Forzar cambiar la contraseña en el siguiente inicio de sesión"
                                                        ImageUrl="~/img/icon-help.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Organización</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadComboBox ID="ddlOrganization" runat="server" Width="300px" DataValueField="Id_Organization"
                                            DataTextField="Name">
                                        </telerik:RadComboBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Estado</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadComboBox ID="ddlStatus" runat="server" CausesValidation="false" DataTextField="Description"
                                            DataValueField="Id_Status" Width="300px">
                                        </telerik:RadComboBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Rol</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTreeView ID="rtvProfile" runat="server" CheckBoxes="True" TriStateCheckBoxes="True"
                                            Height="180px">
                                        </telerik:RadTreeView>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="bottom_table_bandejat">
                        </div>
                    </div>
                </telerik:RadAjaxPanel>
                <!-- fin caja datos -->
            </div>
        </div>
    </div>
    <asp:ValidationSummary ID="vsMant" ShowMessageBox="true" HeaderText="Datos requeridos"
        ShowSummary="false" runat="server" ValidationGroup="save" />
    <input id="hfId_User" runat="server" type="hidden" />
</asp:Content>
