<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DocumentExplorer_.aspx.cs" Inherits="SISMONUi._6M.DocumentExplorer" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function pageLoad() {
            AddTaskEvent();
        }

        function AddTaskEvent() {
            $(".configuration").click(function () {
                var id = $(this).attr('ID');
                showWindow('AttachmentsList.aspx?datos=' + id, 'Archivos Adjuntos', 445, 235, true, '', '');
            })
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="Label1" runat="server" Text="Registro de Horas"></asp:Label>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960" style="padding-bottom: 0px">
                <!-- caja datos -->
                <telerik:RadAjaxPanel ID="rapTask" runat="server">
                    <div class="contentRight_enlaces list_perfil">
                        <table style="width: 925px">
                            <tr>
                                <td align="left" style="width: 80%">
                                    <telerik:RadComboBox runat="server" ID="rcbProject" DataTextField="Name" DataValueField="Id_Project"
                                        AutoPostBack="true" Height="190px" Width="540px" MarkFirstMatch="True" EnableLoadOnDemand="True"
                                        HighlightTemplatedItems="True" OnDataBound="rcbProject_DataBound" OnClientItemsRequested="UpdateItemCountField"
                                        OnItemsRequested="rcbProject_ItemsRequested" OnSelectedIndexChanged="rcbProject_SelectedIndexChanged"
                                        ResolvedRenderMode="Classic">
                                        <HeaderTemplate>
                                            <table style="width: 500px">
                                                <tr>
                                                    <td style="width: 60%" align="left">
                                                        Proyecto
                                                    </td>
                                                    <%--<td style="width: 40%" align="left">
                                                        Administrador
                                                    </td>--%>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 500px">
                                                <tr>
                                                    <td style="width: 60%" align="left">
                                                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                                    </td>
                                                    <%--<td style="width: 40%" align="left">
                                                        <%# DataBinder.Eval(Container.DataItem, "USERString") %>
                                                        <asp:HiddenField ID="hfId_Owner" runat="server" Value='<%# Eval("Id_Owner") %>' />
                                                    </td>--%>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Un total de
                                            <asp:Literal runat="server" ID="RadComboItemsCount" />
                                            proyectos
                                        </FooterTemplate>
                                    </telerik:RadComboBox>
                                </td>
                                <td align="right" style="width: 20%">
                                    <asp:Image ID="imgHelp" runat="server" Height="32px" Width="32px" ImageUrl="~/img/help.jpg"
                                        Style="cursor: help" />
                                    <telerik:RadToolTip runat="server" ID="RadToolTip1" TargetControlID="imgHelp" Position="BottomLeft"
                                        Width="300px" Height="50px" Title="Ver Arhivos Adjuntos" Animation="FlyIn" ResolvedRenderMode="Classic"
                                        Skin="Metro">
                                        Para poder visualizar los documentos adjuntos haga click sobre el nombre de cada
                                        documento.
                                    </telerik:RadToolTip>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="conten_caja_sub_categoria marhin-topnone" style="width: 940px;">
                        <div class="top_table_bandejat">
                            <table style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblIsNotOwner" runat="server" Text="Ud. no tiene permisos para modificar este proyecto. Cualquier cambio sera descartado."
                                            Visible="False" Font-Names="Calibri" Font-Size="10pt" ForeColor="Gray"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="tabla_sup_caja_sub_categoria" style="min-height: 350px;">
                            <div align="center" style="width: 100%">
                                <asp:Label ID="lblMessage" runat="server" Text="No está administrando ningun proyecto en este momento"
                                    Visible="False" Font-Names="Calibri" Font-Size="10pt" ForeColor="Gray"></asp:Label>
                            </div>
                            <asp:Panel ID="sss" runat="server" ScrollBars="Auto">
                                <telerik:RadTreeMap ID="rtmProject" runat="server" AlgorithmType="Horizontal" Skin="Windows7"
                                    DataFieldID="ID" DataFieldParentID="ParentID" DataTextField="Text" DataValueField="Value"
                                    DataKeyNames="DivID,DivClass" OnItemDataBound="rtmProject_ItemDataBound">
                                    <ClientItemTemplate>
                                    <div id='#=dataItem.DivID#' class='#=dataItem.DivClass#' style="font-size:x-small;font-family:Calibri; cursor:pointer">#=text#</div>
                                        #if (dataItem.DownloadLink) {#  
                                        
                                        #} #
                                    </ClientItemTemplate>
                                </telerik:RadTreeMap>
                            </asp:Panel>
                        </div>
                        <div class="bottom_table_bandejat">
                        </div>
                    </div>
                </telerik:RadAjaxPanel>
                <!-- fin caja datos -->
            </div>
        </div>
    </div>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function UpdateItemCountField(sender, args) {
                //Set the footer text.
                sender.get_dropDownElement().lastChild.innerHTML = "Un total de " + sender.get_items().get_count() + " proyectos";
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
