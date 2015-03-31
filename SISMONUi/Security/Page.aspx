<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Page.aspx.cs" Inherits="SISMONUi.Security.Page" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function onClientContextMenuItemClicking(sender, args) {
            var menuItem = args.get_menuItem();
            var treeNode = args.get_node();
            menuItem.get_menu().hide();
            switch (menuItem.get_value()) {
                case "Delete":
                    jConfirm("¿Esta seguro de eliminar la página : " + treeNode.get_text() + '?', 'Confirmar Solicitud',
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <telerik:RadAjaxPanel ID="rapPage" runat="server">
        <div class="contenido_subtitulos">
            <asp:Label ID="lblTitle" runat="server" Text="Mantenimiento de Páginas"></asp:Label>
        </div>
        <div class="contenido_content">
            <div class="contenido_contentLeft">
                <div class="contenLeft_content">
                    <div class="contenLeft_titulo" style="padding-top: 5px!important; padding-left: 3px!important">
                        Modulo
                        <telerik:RadComboBox ID="ddlModule" runat="server" Width="200px" AutoPostBack="true"
                            DataTextField="Name" DataValueField="Id_Module" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                    <hr style="width: 200px" />
                    <telerik:RadTreeView ID="rtvPages" EnableDragAndDrop="true" Width="220px" Height="360px"
                        runat="server" OnContextMenuItemClick="rtvPages_ContextMenuItemClick" OnNodeClick="rtvPages_NodeClick"
                        EnableDragAndDropBetweenNodes="True" OnNodeDrop="rtvPages_NodeDrop" OnClientContextMenuItemClicking="onClientContextMenuItemClicking">
                    </telerik:RadTreeView>
                </div>
            </div>
            <div class="contenido_contentRight">
                <div class="contentRight_enlaces">
                    <telerik:RadButton ID="btnGrabar" runat="server" ValidationGroup="save" OnClick="btnGrabar_Click"
                        Text="Grabar" />
                    <telerik:RadButton ID="btnCancelar" runat="server" Text="Regresar" ValidationGroup="cancel"
                        OnClick="btnCancelar_Click" />
                </div>
                <!-- tabla -->
                <div class="conten_caja_sub_categoria" style="margin-top: 5px!important">
                    <div class="tap_sup_caja_sub_categoria">
                    </div>
                    <div class="tit_caja_sub_categoria">
                        <div class="content_table">
                            <fieldset class="fieldset">
                                <legend class="legend">Página Padre:<asp:Label ID="lblPage_Parent" runat="server"
                                    Text=""></asp:Label></legend>
                                <div class="row">
                                    <label>
                                        <strong>Nombre</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtNombre" runat="server" Width="400px">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                            ErrorMessage="Ingrese Nombre" ValidationGroup="save" Display="None" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Ruta</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtRuta" runat="server" Width="400px">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Descripción</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtDescrip" runat="server" Width="400px" Height="50px" TextMode="MultiLine">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Crea Menu</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <div>
                                            <asp:CheckBox ID="chkCreaMenu" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Es de Tipo Vinculo</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <div>
                                            <asp:CheckBox ID="chkTipoVinculo" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Estado</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadComboBox ID="ddlStatus" DataSourceID="odsEstado" runat="server" Width="200px"
                                            DataTextField="Description" DataValueField="Id_Status">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="odsEstado" TypeName="SISMONRules.Security.RuleStatus" SelectMethod="GetAll"
                                            runat="server"></asp:ObjectDataSource>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <div class="tap_inf_caja_sub_categoria">
                    </div>
                </div>
                <!-- fin tabla -->
            </div>
        </div>
        <asp:ValidationSummary ID="vsPagina" ShowMessageBox="true" HeaderText="Datos requeridos"
            ShowSummary="false" runat="server" ValidationGroup="save" />
    </telerik:RadAjaxPanel>
</asp:Content>
