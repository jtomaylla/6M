<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Organization.aspx.cs" Inherits="SISMONUi._6M.Organization" %>

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
    <style type="text/css">
        .bold
        {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" runat="server" Text="Listado de Proyectos"></asp:Label>
        <asp:HiddenField ID="hfOperacionGridView" runat="server" />
        <asp:HiddenField ID="hfId_Organization" runat="server" />
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960" style="padding-bottom: 0px">
                <!-- caja datos -->
                <div class="contentRight_enlaces list_perfil">
                    <telerik:RadButton ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                </div>
                <div class="conten_caja_sub_categoria marhin-topnone" style="width: 940px;">
                    <div class="top_table_bandejat">
                    </div>
                    <div class="tabla_sup_caja_sub_categoria" style="min-height: 350px;">
                        <telerik:RadAjaxPanel ID="rapOrganization" runat="server" HorizontalAlign="NotSet">
                            <telerik:RadGrid ID="rgList" runat="server" AllowPaging="True" GroupingSettings-CaseSensitive="false"
                                BorderWidth="2px" AllowSorting="True" AutoGenerateColumns="False" OnItemDataBound="rgList_ItemDataBound"
                                OnItemCommand="rgList_ItemCommand" OnPageIndexChanged="rgList_PageIndexChanged"
                                AllowAutomaticDeletes="True" AllowAutomaticInserts="True" AllowAutomaticUpdates="True"
                                ResolvedRenderMode="Classic">
                                <PagerStyle FirstPageToolTip="Primera P&#225;gina" LastPageToolTip="Ultima P&#225;gina"
                                    NextPagesToolTip="Siguiente" NextPageToolTip="Siguiente" PageSizeLabelText="Registros por P&#225;gina"
                                    PrevPagesToolTip="Anterior" PrevPageToolTip="Anterior" />
                                <ClientSettings EnableRowHoverStyle="true">
                                </ClientSettings>
                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="Organización" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="700px" AllowFiltering="false" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrganization" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Font-Bold="True" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn ItemStyle-Width="30px" AllowFiltering="false" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" ToolTip="Editar" runat="server" CommandName="EditDetails"
                                                    CommandArgument='<%# Eval("Id_Organization") %>' ImageUrl="~/img/Edit.png" />
                                            </ItemTemplate>
                                            <HeaderStyle Font-Bold="True" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgView" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id_Organization") %>'
                                                    ImageUrl="~/img/view.png" ToolTip="Ver" />
                                            </ItemTemplate>
                                            <HeaderStyle Font-Bold="True" Width="30px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings EditFormType="Template">
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                        <FormTemplate>
                                            <table id="TableLvl" style="background: white; background: url('../img/BackgroundForm.png') repeat"
                                                width="100%">
                                                <tr>
                                                    <td valign="top" style="padding: 20px">
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="50%">
                                                                    <table style="font-family: calibri">
                                                                        <tr>
                                                                            <td colspan="2" class="bold">
                                                                                <%# Eval("Name") %>
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Image ID="imgOrganizationImage" runat="server" AlternateText='<%# Eval("Id_Organization") %>'
                                                                                    Width="50px" Height="60px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="bold">
                                                                                Descripción
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("Description") %>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="bold">
                                                                                Estado
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td>
                                                                                <%# Eval("STATUSString") %>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="padding-left: 20px" width="50%">
                                                                    <telerik:RadGrid ID="rgLevel" runat="server" Width="400px" AutoGenerateColumns="false">
                                                                        <MasterTableView>
                                                                            <Columns>
                                                                                <telerik:GridBoundColumn HeaderText="Nivel de Organización" UniqueName="OrganizationLeval"
                                                                                    DataField="Name">
                                                                                    <HeaderStyle Font-Bold="True" />
                                                                                </telerik:GridBoundColumn>
                                                                                <telerik:GridBoundColumn HeaderText="Nivel" UniqueName="Level" DataField="Level">
                                                                                    <ItemStyle Width="50px" />
                                                                                    <HeaderStyle Font-Bold="True" />
                                                                                </telerik:GridBoundColumn>
                                                                            </Columns>
                                                                            <NoRecordsTemplate>
                                                                                <table style="text-align: center; width: 100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%= GetGlobalResourceObject("MsjApp", "NoRecordGrid")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </NoRecordsTemplate>
                                                                        </MasterTableView>
                                                                    </telerik:RadGrid>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="actions">
                                                            <div class="right">
                                                                <telerik:RadButton ID="btnCerrar" runat="server" Text="Cerrar" CommandName="Cancel" />
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </FormTemplate>
                                    </EditFormSettings>
                                    <PagerStyle Mode="NumericPages" />
                                    <NoRecordsTemplate>
                                        <table style="text-align: center; width: 100%">
                                            <tr>
                                                <td>
                                                    <%= GetGlobalResourceObject("MsjApp", "NoRecordGrid")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </telerik:RadAjaxPanel>
                    </div>
                    <div class="bottom_table_bandejat">
                    </div>
                </div>
                <!-- fin caja datos -->
            </div>
        </div>
    </div>
</asp:Content>
