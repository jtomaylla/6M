<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="User.aspx.cs" Inherits="SISMONUi.Security.User" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" runat="server" Text="Listado de Usuario"></asp:Label>
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
                        <telerik:RadGrid ID="rgList" GroupingSettings-CaseSensitive="false" runat="server"
                            AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                            GridLines="None" OnItemCommand="rgList_ItemCommand" OnPageIndexChanged="rgList_PageIndexChanged">
                            <PagerStyle FirstPageToolTip="Primera P&#225;gina" LastPageToolTip="Ultima P&#225;gina"
                                NextPagesToolTip="Siguiente" NextPageToolTip="Siguiente" PageSizeLabelText="Registros por P&#225;gina"
                                PrevPagesToolTip="Anterior" PrevPageToolTip="Anterior" />
                            <ClientSettings EnableRowHoverStyle="true">
                            </ClientSettings>
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Usuario" UniqueName="column" DataField="UserName"
                                        FilterControlWidth="50px">
                                        <ItemStyle Width="80px" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Nombre" UniqueName="First_Name" DataField="First_Name"
                                        FilterControlWidth="100px">
                                        <ItemStyle Width="120px" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Ap. Pat." UniqueName="Surname1" DataField="Surname1"
                                        FilterControlWidth="100px">
                                        <ItemStyle Width="120px" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Ap. Mat." UniqueName="Surname2" DataField="Surname2"
                                        FilterControlWidth="100px">
                                        <ItemStyle Width="120px" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Estado" UniqueName="EstadoString" DataField="STATUSString">
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Edición" ItemStyle-Width="40px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Editar" runat="server" CommandName="Edicion"
                                                CommandArgument='<%# Eval("Id_User") %>' ImageUrl="~/img/Edit.png" />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ver" ItemStyle-Width="40px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbVer" ToolTip="Ver Detalle" runat="server" CommandName="Ver"
                                                CommandArgument='<%# Eval("Id_User") %>' ImageUrl="~/img/view.png" />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Reset" ItemStyle-Width="40px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgReset" ToolTip="Resetear password" runat="server" CommandName="Reset"
                                                CommandArgument='<%# Eval("Id_User") %>' ImageUrl="~/img/arrow_refresh.png" />
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
