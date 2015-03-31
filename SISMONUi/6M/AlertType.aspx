<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AlertType.aspx.cs" Inherits="SISMONUi._6M.AlertType" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" runat="server" Text="Listado de Alertas"></asp:Label>
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
                        <telerik:RadGrid ID="rgList" GroupingSettings-CaseSensitive="false" Width="890px" runat="server"
                            AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                            GridLines="None" OnItemCommand="rgList_ItemCommand" OnPageIndexChanged="rgList_PageIndexChanged">
                            <pagerstyle firstpagetooltip="Primera P&#225;gina" lastpagetooltip="Ultima P&#225;gina"
                                nextpagestooltip="Siguiente" nextpagetooltip="Siguiente" pagesizelabeltext="Registros por P&#225;gina"
                                prevpagestooltip="Anterior" prevpagetooltip="Anterior" />
                            <clientsettings enablerowhoverstyle="true">
                            </clientsettings>
                            <mastertableview>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Alerta" UniqueName="Proyecto" DataField="Description"
                                        FilterControlWidth="720px">
                                        <ItemStyle Width="600px" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Edición" ItemStyle-Width="40px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Editar" runat="server" CommandName="Edicion"
                                                CommandArgument='<%# Eval("Id_Alert_Type") %>' ImageUrl="~/img/Edit.png" />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ver" ItemStyle-Width="40px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbVer" ToolTip="Ver Detalle" runat="server" CommandName="Ver"
                                                CommandArgument='<%# Eval("Id_Alert_Type") %>' ImageUrl="~/img/view.png" />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridTemplateColumn>
                                </Columns>
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
                            </mastertableview>
                        </telerik:RadGrid>
                    </div>
                    <div class="bottom_table_bandejat">
                    </div>
                </div>
                <!-- fin caja datos -->
            </div>
        </div>
    </div>
</asp:Content>
