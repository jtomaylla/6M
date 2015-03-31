<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Module.aspx.cs" Inherits="SISMONUi.Security.Module" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" runat="server" Text="Listado de Modulo"></asp:Label>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960" style="padding-bottom: 0px">
                <!-- caja datos -->
                <br />
                <div class="conten_caja_sub_categoria marhin-topnone" style="width: 940px;">
                    <div class="top_table_bandejat">
                    </div>
                    <div class="tabla_sup_caja_sub_categoria" style="min-height: 350px;">
                        <telerik:radgrid id="rgList" groupingsettings-casesensitive="false" runat="server"
                            allowfilteringbycolumn="True" allowpaging="True" allowsorting="True" autogeneratecolumns="False"
                            gridlines="None" onitemcommand="rgList_ItemCommand" onpageindexchanged="rgList_PageIndexChanged">
                            <PagerStyle FirstPageToolTip="Primera P&#225;gina" LastPageToolTip="Ultima P&#225;gina"
                                NextPagesToolTip="Siguiente" NextPageToolTip="Siguiente" PageSizeLabelText="Registros por P&#225;gina"
                                PrevPagesToolTip="Anterior" PrevPageToolTip="Anterior" />
                            <ClientSettings EnableRowHoverStyle="true">
                            </ClientSettings>
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Modulo" UniqueName="column" DataField="Name"
                                        FilterControlWidth="200px">
                                        <ItemStyle Width="200px" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Descripción" UniqueName="column2" DataField="Description">
                                        <ItemStyle />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="URL" UniqueName="column3" DataField="URL">
                                        <ItemStyle />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Dominio" UniqueName="column4" DataField="Domain">
                                        <ItemStyle />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Estado" UniqueName="STATUSString" DataField="STATUSString"
                                     FilterControlWidth="40px">
                                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Edic." ItemStyle-Width="30px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" ToolTip="Editar" runat="server" CommandName="Edicion"
                                                CommandArgument='<%# Eval("Id_Module") %>' ImageUrl="~/img/Edit.png" />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Bold="True" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ver" ItemStyle-Width="30px" AllowFiltering="false"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbVer" ToolTip="Ver Detalle" runat="server" CommandName="Ver"
                                                CommandArgument='<%# Eval("Id_Module") %>' ImageUrl="~/img/view.png" />
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
                        </telerik:radgrid>
                    </div>
                    <div class="bottom_table_bandejat">
                    </div>
                </div>
                <!-- fin caja datos -->
            </div>
        </div>
    </div>
</asp:Content>
