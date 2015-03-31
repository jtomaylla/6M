<%@ Page Title="" Language="C#" MasterPageFile="~/GanttMaster.Master" AutoEventWireup="true"
    CodeBehind="RegisterTask.aspx.cs" Inherits="SISMONUi._6M.RegisterTask" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function pageLoad() {
            ReduceRowFont();
            AddTaskEvent();
            PreventTaskDetailUpdate();
            AddBookMark();
            Semaphore();
            ShowPerformanceInToolTip();
        }

        function ReduceRowFont() {
            $('.rgtTreelistContent table tr').each(function () {
                $(this).addClass("clsNewFont");
            });
        }

        function AddBookMark() {
            $('.rgtTask.rgtTaskSingle').each(function () {
                $(this).addClass("clsBookMark");
            });
        }

        function ShowPerformanceInToolTip() {
            var $ = $telerik.$;
            var gantt = $find("<%=RadGantt1.ClientID%>");
            var tasks = gantt.get_allTasks();
            var task;
            var uid;
            var time;
            var cost;
            var title;
            for (var i = 0; i < tasks.length; i++) {
                task = tasks[i];
                uid = tasks[i]._uid;
                title = tasks[i]._data.title;
                time = tasks[i]._data.percentComplete * 100;
                cost = GetContent(uid, 6);
                $('.rgtTask.rgtTaskSingle.clsBookMark').each(function () {
                    if ($(this).attr('data-uid') == uid) {
                        $(this).find('.rgtTaskTemplate').attr('title', title + '  ' + time + '% tiempo - ' + cost + '% costo');
                        $(this).find('.rgtTaskTemplate').text(title + '  ' + time + '% tiempo - ' + cost + '% costo');
                    }
                });
            }
        }

        function Semaphore() {
            var $ = $telerik.$;
            var gantt = $find("<%=RadGantt1.ClientID%>");
            var tasks = gantt.get_allTasks();
            var task;
            var uid;
            var cls;
            for (var i = 0; i < tasks.length; i++) {
                task = tasks[i];
                uid = tasks[i]._uid;
                cls = GetContent(uid, 5);
                    $('.rgtTask.rgtTaskSingle.clsBookMark').each(function () {
                        if ($(this).attr('data-uid') == uid) {
                            $(this).find('.rgtTaskContent').addClass(cls);
                        }
                    });
            }
        }

        function GetContent(uid, position) {
            var resul = '';
            $(".rgtTreelistContent table tr").each(function () {
                if ($(this).attr('data-uid') == uid) {
                    resul = $(this).find("td").eq(position).text();
                    return false;
                }
            });
            
            return resul;
        }
        
        function AddTaskEvent() {
            var $ = $telerik.$;
            var gantt = $find("<%=RadGantt1.ClientID%>");
            $(".rgtTreelistContent table tr").bind('contextmenu', function (e) {
                // evito que se ejecute el evento
                e.preventDefault();
                // conjunto de acciones a realizar
                e.stopPropagation();
                var $element = $(e.target);
                if (!$element.is("tr")) {
                    $element = $element.parents("tr").first();
                }
                var uid = $element.attr("data-uid");
                var tasks = gantt.get_allTasks();
                var task;
                for (var i = 0; i < tasks.length; i++) {
                    if (tasks[i]._uid === uid) {
                        task = tasks[i];
                        break;
                    }
                }
                showWindow('TaskConfiguration.aspx?datos=' + task._data.id, 'Configurar Tarea', 648, 630, true, '', '');
            });
        }

        function PreventTaskDetailUpdate() {
            var $ = $telerik.$;
            var gantt = $find("<%=RadGantt1.ClientID%>");
            $(".rgtTimelineContent table tr").bind('dblclick', function (e) {
                // evito que se ejecute el evento
                e.preventDefault();
                // conjunto de acciones a realizar
                e.stopPropagation();
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="Label1" runat="server" Text="Registro de Monitoreo"></asp:Label>
        <%--<input id="Button1" type="button" value="Colorear" onclick="return Semaphore();" />--%>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content" style="padding-bottom: 0px">
                <!-- caja datos -->
                <telerik:RadAjaxPanel ID="rapTask" runat="server">
                    <div class="contentRight_enlaces list_perfil">
                        <table style="width: 100%">
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
                                                    <td style="width: 40%" align="left">
                                                        Administrador
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 500px">
                                                <tr>
                                                    <td style="width: 60%" align="left">
                                                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                                    </td>
                                                    <td style="width: 40%" align="left">
                                                        <%# DataBinder.Eval(Container.DataItem, "USERString") %>
                                                        <asp:HiddenField ID="hfId_Owner" runat="server" Value='<%# Eval("Id_Owner") %>' />
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
                                </td>
                                <td align="right" style="width: 20%">
                                    <asp:Image ID="imgHelp" runat="server" Height="32px" Width="32px" ImageUrl="~/img/help.jpg"
                                        Style="cursor: help" />
                                    <telerik:RadToolTip runat="server" ID="RadToolTip1" TargetControlID="imgHelp" Position="BottomLeft"
                                        Width="300px" Height="50px" Title="Configurar Actividades" Animation="FlyIn"
                                        ResolvedRenderMode="Classic" Skin="Metro">
                                        Para configurar o adjuntar archivos a una tarea se debe hacer click derecho sobre
                                        ella.
                                    </telerik:RadToolTip>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="conten_caja_sub_categoria marhin-topnone" style="width: 1300px;">
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
                                <asp:Label ID="lblMessage" runat="server" Text="No está asginado a ningun proyecto"
                                    Visible="False" Font-Names="Calibri" Font-Size="10pt" ForeColor="Gray"></asp:Label>
                            </div>
                            <telerik:RadGantt runat="server" ID="RadGantt1" Skin="Silk" ListWidth="386px" 
                                Width="1240px" Height="600px"
                                AutoGenerateColumns="False" SelectedView="WeekView" 
                                ontaskinsert="RadGantt1_TaskInsert">
                                <Columns>
                                    <telerik:GanttBoundColumn DataField="Title" Width="200px" HeaderText="Actividad">
                                    </telerik:GanttBoundColumn>
                                    <telerik:GanttBoundColumn DataField="Start" Width="65px" HeaderText="Inicio" DataFormatString="dd/MM/yyyy">
                                    </telerik:GanttBoundColumn>
                                    <telerik:GanttBoundColumn DataField="End" Width="65px" HeaderText="Fin" DataFormatString="dd/MM/yyyy">
                                    </telerik:GanttBoundColumn>
                                    <telerik:GanttBoundColumn DataField="Initial_Cost" Width="50px" HeaderText="Costo" DataType="Number"
                                        UniqueName="Initial_Cost">
                                    </telerik:GanttBoundColumn>
                                    <telerik:GanttBoundColumn DataField="Final_Cost" Width="50px" HeaderText="Gasto" DataType="Number"
                                        UniqueName="Final_Cost">
                                    </telerik:GanttBoundColumn>
                                    <telerik:GanttBoundColumn DataField="Indicator" Width="1px" HeaderText="Ind." DataType="String"
                                        UniqueName="Indicator">
                                    </telerik:GanttBoundColumn>
                                    <telerik:GanttBoundColumn DataField="Relative_Cost" Width="1px" HeaderText="Cost" DataType="Number"
                                        UniqueName="Relative_Cost">
                                    </telerik:GanttBoundColumn>
                                </Columns>
                                <CustomTaskFields>
                                    <telerik:GanttCustomField PropertyName="Initial_Cost" ClientPropertyName="initial_Cost"
                                        Type="Number" />
                                    <telerik:GanttCustomField PropertyName="Final_Cost" ClientPropertyName="final_Cost"
                                        Type="Number" />
                                    <telerik:GanttCustomField PropertyName="Indicator" ClientPropertyName="indicator"
                                        Type="String" />
                                    <telerik:GanttCustomField PropertyName="Relative_Cost" ClientPropertyName="relative_Cost"
                                        Type="Number" />
                                </CustomTaskFields>
                                <Localization Append="Agregar Tarea" InsertBefore="Agregar Antes" InsertAfter="Agregar Despues"
                                    AddChild="Agregar Hijo" HeaderDay="Dia" HeaderWeek="Semana" HeaderMonth="Mes" />
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
                sender.get_dropDownElement().lastChild.innerHTML = "Un total de " + sender.get_items().get_count() + " proyectos";
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
