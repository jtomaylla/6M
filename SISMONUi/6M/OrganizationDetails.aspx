<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="OrganizationDetails.aspx.cs" Inherits="SISMONUi._6M.OrganizationDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function onClientContextMenuItemClicking(sender, args) {
            var menuItem = args.get_menuItem();
            var treeNode = args.get_node();
            menuItem.get_menu().hide();
            switch (menuItem.get_value()) {
                case "Delete":
                    jConfirm("¿Esta seguro de eliminar el nivel : " + treeNode.get_text() + '?', 'Confirmar Solicitud',
                    function (r) {
                        if (r == true) {
                            menuItem.set_value('Deleted');
                            menuItem.click();
                        }
                    });
                    args.set_cancel(true);
                    break;
            }
        }
    </script>
    <style type="text/css">
        .bold
        {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" Text="Detalle de la Organización" runat="server" Font-Bold="True"></asp:Label>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960">
                <!-- caja datos -->
                <telerik:RadAjaxPanel ID="rapOrganization1" runat="server" HorizontalAlign="NotSet"
                    LoadingPanelID="RadAjaxLoadingPanelMaster">
                    <div class="contentRight_enlaces list_perfil">
                        <telerik:RadButton ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar"
                            ValidationGroup="save" />
                        <telerik:RadButton ID="btnCancelar" runat="server" Text="Regresar" OnClick="btnCancelar_Click" />
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
                                                <asp:Image ID="imgOrganizationImage" runat="server" Width="80px" Height="90px" />
                                            </td>
                                        </tr>
                                    </table>
                                </legend>
                                <div class="row">
                                    <label>
                                        <strong>Nombre:</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtName" runat="server" Width="640px" Style="text-transform: uppercase">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                            ErrorMessage="Debe ingresar nombre para la organización" Display="None" ValidationGroup="save">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Descripción:</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtDescription" runat="server" Width="640px" Style="text-transform: uppercase">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Foto</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadAsyncUpload runat="server" ID="rauOrganizationImage" MultipleFileSelection="Disabled"
                                            AllowedFileExtensions="jpg" ToolTip="Cargar imagen de usuario" MaxFileInputsCount="1">
                                            <Localization Select="Select." Remove="Elim." />
                                        </telerik:RadAsyncUpload>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Estado:</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadComboBox ID="ddlStatus" runat="server" DataTextField="Description" DataValueField="Id_Status">
                                        </telerik:RadComboBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Niveles</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <legend class="legend">
                                                        <asp:Image ID="imgHelp" runat="server" Height="28px" Width="28  px" ImageUrl="~/img/help.jpg"
                                                            Style="cursor: help" />
                                                        <telerik:RadToolTip runat="server" ID="RadToolTip1" TargetControlID="imgHelp" Position="BottomLeft"
                                                            Width="300px" Height="50px" Title="Configurar Actividades" Animation="FlyIn"
                                                            ResolvedRenderMode="Classic" Skin="Metro">
                                                            Puede arrastrar los niveles hacia arriba o hacia abajo para cambiar su orden
                                                        </telerik:RadToolTip>
                                                    </legend>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" style="width: 50%">
                                                    <telerik:RadTreeView ID="rtvLevel" EnableDragAndDrop="True" Width="220px" Height="200px"
                                                        runat="server" OnContextMenuItemClick="rtvLevel_ContextMenuItemClick" OnNodeClick="rtvLevel_NodeClick"
                                                        EnableDragAndDropBetweenNodes="True" OnNodeDrop="rtvLevel_NodeDrop" OnClientContextMenuItemClicking="onClientContextMenuItemClicking"
                                                        ResolvedRenderMode="Classic">
                                                    </telerik:RadTreeView>
                                                </td>
                                                <td valign="top" style="width: 50%">
                                                    <fieldset class="fieldset">
                                                        <legend class="legend">Configurar Nivel</legend>
                                                        <div class="row">
                                                            <label>
                                                                <strong>Nivel:</strong>
                                                            </label>
                                                            <div style="margin-left: 196px">
                                                                <telerik:RadTextBox ID="txtLevelName" runat="server" Width="150px" Style="text-transform: uppercase">
                                                                </telerik:RadTextBox>
                                                            </div>
                                                        </div>
                                                        <div class="actions">
                                                            <div class="right">
                                                                <telerik:RadButton ID="btnAgregar" runat="server" ValidationGroup="save" Text="Agregar"
                                                                    OnClick="btnAgregar_Click">
                                                                    <Icon PrimaryIconUrl="../img/add_16.ico" PrimaryIconLeft="5px"></Icon>
                                                                </telerik:RadButton>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </table>
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
</asp:Content>
