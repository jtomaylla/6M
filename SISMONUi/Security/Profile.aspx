<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs" Inherits="SISMONUi.Security.Profile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" runat="server" Text="Listado de Perfil"></asp:Label>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960" style="padding-bottom: 0px">
                <!-- caja datos -->
                <div class="contentRight_enlaces list_perfil">
                    <table style="width: 928px">
                        <tr>
                            <td style="text-align: left; width: 50px">
                                Modulo
                            </td>
                            <td>
                                :
                            </td>
                            <td style="text-align: left">
                                <telerik:RadComboBox ID="ddlModulo" runat="server" Width="200px" AutoPostBack="true"
                                    DataTextField="Name" DataValueField="Id_Module" OnSelectedIndexChanged="ddlModulo_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </td>
                            <td style="text-align: right">
                                <telerik:RadButton ID="btnNuevo" CssClass="btn_nuevo" runat="server" Text="Nuevo"
                                    OnClick="btnNuevo_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="conten_caja_sub_categoria marhin-topnone" style="width: 940px;">
                    <div class="top_table_bandejat">
                    </div>
                    <div class="tabla_sup_caja_sub_categoria" style="min-height: 350px;">
                        <telerik:RadGrid ID="rgList" runat="server" AllowFilteringByColumn="True" AllowPaging="True"
                            GroupingSettings-CaseSensitive="false" AllowSorting="True" AutoGenerateColumns="False"
                            GridLines="None" OnItemCommand="rgList_ItemCommand" OnSelectedIndexChanged="rgList_SelectedIndexChanged"
                            MasterTableView-DataKeyNames="Id_Profile" OnPageIndexChanged="rgList_PageIndexChanged">
                            <PagerStyle FirstPageToolTip="Primera P&#225;gina" LastPageToolTip="Ultima P&#225;gina"
                                NextPagesToolTip="Siguiente" NextPageToolTip="Siguiente" PageSizeLabelText="Registros por P&#225;gina"
                                PrevPagesToolTip="Anterior" PrevPageToolTip="Anterior" />
                            <ClientSettings EnableRowHoverStyle="true" Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true">
                            </ClientSettings>
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Perfil" UniqueName="ColPerfil" DataField="Name"
                                        FilterControlWidth="95%">
                                        <%--<ItemStyle Width="500px" />--%>
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Estado" UniqueName="ColEstado" DataField="STATUSString">
                                        <HeaderStyle Font-Bold="True" Width="100px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Edición" ItemStyle-Width="40px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Editar" runat="server" CommandArgument='<%# Eval("Id_Profile") %>'
                                                CommandName="Edicion" ImageUrl="~/img/Edit.png" />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" Width="50px" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ver" ItemStyle-Width="40px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbVer" ToolTip="Ver Detalle" CommandArgument='<%# Eval("Id_Profile") %>'
                                                runat="server" CommandName="Ver" ImageUrl="~/img/view.png" />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" Width="50px" />
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
