<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RegisterTask_.aspx.cs" Inherits="SISMONUi._6M.RegisterTask_" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnClientSelectedIndexChanged(sender, args) {
            // To get the item
            var item = args.get_item();
            //To get the item text
            var itemText = args.get_item()._text;
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
                        <telerik:RadComboBox runat="server" ID="rcbProject" DataTextField="Name" DataValueField="Id_Project"
                            AutoPostBack="true" Height="190px" Width="450px" MarkFirstMatch="True" EnableLoadOnDemand="True"
                            HighlightTemplatedItems="True" OnClientItemsRequested="UpdateItemCountField"
                            OnDataBound="rcbProject_DataBound" OnItemsRequested="rcbProject_ItemsRequested"
                            OnSelectedIndexChanged="rcbProject_SelectedIndexChanged" ResolvedRenderMode="Classic">
                            <HeaderTemplate>
                                <table style="width: 410px">
                                    <tr>
                                        <td style="width: 60%" align="left">
                                            Proyecto
                                        </td>
                                        <td style="width: 40%" align="left">
                                            Administrador
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 410px">
                                    <tr>
                                        <td style="width: 60%" align="left">
                                            <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                        </td>
                                        <td style="width: 40%" align="left">
                                            <%# DataBinder.Eval(Container.DataItem, "USERString") %>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <FooterTemplate>
                                Un total de
                                <asp:Literal runat="server" ID="RadComboItemsCount" />
                                proyectos
                            </FooterTemplate>
                        </telerik:RadComboBox>
                    </div>
                    <div class="conten_caja_sub_categoria marhin-topnone" style="width: 940px;">
                        <div class="top_table_bandejat">
                        </div>
                        <div class="tabla_sup_caja_sub_categoria" style="min-height: 350px;">
                            <telerik:RadGantt runat="server" ID="RadGantt1" Skin="Silk" SelectedView="WeekView"
                                Width="900px" Height="600px" AutoGenerateColumns="false">
                                <Columns>
                                    <telerik:GanttBoundColumn DataField="Title" Width="100px" HeaderText="Proyecto">
                                    </telerik:GanttBoundColumn>
                                    <telerik:GanttBoundColumn DataField="Start" Width="100px" HeaderText="Fecha Ini">
                                    </telerik:GanttBoundColumn>
                                    <telerik:GanttBoundColumn DataField="End" Width="100px" HeaderText="Fecha Fin">
                                    </telerik:GanttBoundColumn>
                                     <telerik:GanttBoundColumn DataField="PercentComplete" Width="80px" HeaderText="Completado">
                                    </telerik:GanttBoundColumn>
                                    <telerik:GanttBoundColumn DataField="Initial_Cost" HeaderText="Costo Ini." DataType="Number"
                                        UniqueName="Initial_Cost">
                                    </telerik:GanttBoundColumn>
                                </Columns>
                                <CustomTaskFields>
                                    <telerik:GanttCustomField PropertyName="Initial_Cost" ClientPropertyName="Initial_Cost"
                                        Type="String" />
                                </CustomTaskFields>
                            </telerik:RadGantt>
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
                sender.get_dropDownElement().lastChild.innerHTML = "Un total de " + sender.get_items().get_count() + " usuarios";
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
