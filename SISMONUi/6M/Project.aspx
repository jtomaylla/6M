<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Project.aspx.cs" Inherits="SISMONUi._6M.Project" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" runat="server" Text="Listado de Proyectos"></asp:Label>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960" style="padding-bottom: 0px">
                <!-- caja datos -->
                <div class="contentRight_enlaces list_perfil">
                    <telerik:RadButton ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click">
                    </telerik:RadButton>
                </div>
                <div class="conten_caja_sub_categoria marhin-topnone" style="width: 940px;">
                    <div class="top_table_bandejat">
                    </div>
                    <div class="tabla_sup_caja_sub_categoria" style="min-height: 350px;">
                        <telerik:RadGrid ID="rgList" GroupingSettings-CaseSensitive="false" runat="server"
                            AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                            GridLines="None" OnItemCommand="rgList_ItemCommand" OnPageIndexChanged="rgList_PageIndexChanged">
                            <PagerStyle FirstPageToolTip="Primera P&#225;gina" LastPageToolTip="Ultima P&#225;gina"
                                NextPagesToolTip="Siguiente" NextPageToolTip="Siguiente" PageSizeLabelText="Registros por P&#225;gina"
                                PrevPagesToolTip="Anterior" PrevPageToolTip="Anterior" />
                            <ClientSettings EnableRowHoverStyle="true">
                            </ClientSettings>
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Proyecto" UniqueName="Name" DataField="Name"
                                        FilterControlWidth="300px">
                                        <ItemStyle Width="300px" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Administrador" UniqueName="USERString" DataField="USERString"
                                        FilterControlWidth="200px">
                                        <ItemStyle Width="200px" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Estado" UniqueName="STATUSString" DataField="STATUSString"
                                        FilterControlWidth="50px">
                                        <ItemStyle Width="50px" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Edición" ItemStyle-Width="40px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Editar" runat="server" CommandName="Edicion"
                                                CommandArgument='<%# Eval("Id_Project") %>' ImageUrl="~/img/Edit.png" />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ver" ItemStyle-Width="40px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbVer" ToolTip="Ver Detalle" runat="server" CommandName="Ver"
                                                CommandArgument='<%# Eval("Id_Project") %>' ImageUrl="~/img/view.png" />
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
                            </MasterTableView>
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
