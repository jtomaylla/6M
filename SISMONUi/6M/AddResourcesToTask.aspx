<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddResourcesToTask.aspx.cs"
    Inherits="SISMONUi._6M.AddResourcesToTask" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/GeneralGantt.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="<%# ResolveUrl("~/css/general.css") %>" />
    <script type="text/javascript" src='<%# ResolveUrl("~/js/jquery-1.11.1.min.js") %>'></script>
    <link rel="stylesheet" type="text/css" href="<%# ResolveUrl("~/css/jAlerts/jquery.alerts.css") %>" />
    <script type="text/javascript" src='<%# ResolveUrl("~/js/jquery.alerts.js") %>'></script>
    <script type="text/javascript" src='<%# ResolveUrl("~/js/cufon-yui.js") %>'></script>
    <script type="text/javascript" src='<%# ResolveUrl("~/js/commons.js") %>'></script>
    <script type="text/javascript" src='<%# ResolveUrl("~/js/jquery.tabs.pack.js") %>'></script>
    <script type="text/javascript" src='<%# ResolveUrl("~/js/helper.js") %>'></script>
    <style type="text/css">
        .tasktable
        {
            padding-left: 15px;
            padding-bottom: 15px;
            padding-top: 15px;
            align: lef;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="rsmAddResources" runat="server" AsyncPostBackTimeout="300">
    </telerik:RadScriptManager>
    <telerik:RadAjaxPanel ID="rapProject" runat="server">
        <table width="632px" style="background-color: #fbfbfc">
            <tr>
                <td style="padding: 5px 5px 5px 5px">
                    <table width="100%" border="0px" cellpadding="0px" cellspacing="0px" style="background-color: #fbfbfc;
                        font-family: calibri;">
                        <tr>
                            <td colspan="4">
                                <legend class="legend">Asignacion de recursos</legend>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="tasktable" style="border-style: solid none none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2; background-color: #F3F3F3;">
                                Proyecto
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                <asp:Label ID="lblProject" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid none none none; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2; background-color: #F3F3F3;">
                                Tarea
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="tasktable" style="border-style: solid none none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2; background-color: #F3F3F3;">
                                Costo Inicial
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                <telerik:RadNumericTextBox ID="rntxtInicialCost" runat="server" Type="Currency" Width="60px">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid none none none; border-top-width: 0.5px;
                                background-color: #F3F3F3; border-top-color: #D2D2D2;">
                                Costo Final
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                <telerik:RadNumericTextBox ID="rntxtFinalCost" runat="server" Type="Currency" 
                                    Width="60px">
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="tasktable" style="border-style: solid none none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2; background-color: #F3F3F3;">
                                Fecha Inicio
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                <telerik:RadDateTimePicker ID="rdtpStart" runat="server" Enabled="false">
                                </telerik:RadDateTimePicker>
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid none none none; border-top-width: 0.5px;
                                background-color: #F3F3F3; border-top-color: #D2D2D2;">
                                Fecha Fin
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                <telerik:RadDateTimePicker ID="rdtpEnd" runat="server" Enabled="false">
                                </telerik:RadDateTimePicker>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="tasktable" style="border-style: solid none none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2; background-color: #F3F3F3;">
                                &nbsp;% Completado</td>
                            <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                <asp:Label ID="lblPercentComplete" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid none none none; border-top-width: 0.5px;
                                background-color: #F3F3F3; border-top-color: #D2D2D2;">
                                Fecha Final
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                <telerik:RadDatePicker ID="rdpFinalEnd" runat="server" Enabled="false">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="tasktable" style="border-style: solid none none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2; background-color: #F3F3F3;">
                                Alerta antes de fin
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                <telerik:RadNumericTextBox ID="rntxtAlert_Days_From_End" runat="server" 
                                    Width="60px">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid none none none; border-top-width: 0.5px;
                                background-color: #F3F3F3; border-top-color: #D2D2D2;">
                                Estado
                            </td>
                            <td align="left" class="tasktable" style="border-style: solid solid none solid; border-top-width: 0.5px;
                                border-right-width: 0.5px; border-left-width: 0.5px; border-color: #D2D2D2">
                                <telerik:RadComboBox ID="ddlStatus" runat="server" DataSourceID="odsStatus" DataTextField="Description"
                                    DataValueField="Id_Status" Width="170px">
                                </telerik:RadComboBox>
                                <asp:ObjectDataSource ID="odsStatus" runat="server" SelectMethod="GetAll" TypeName="SISMONRules.Security.RuleStatus">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="tasktable" style="border-style: solid none solid solid; border-top-width: 0.5px;
                                border-left-width: 0.5px; background-color: #F3F3F3; border-top-color: #D2D2D2;
                                border-bottom-color: #D2D2D2; border-left-color: #D2D2D2; border-bottom-width: 0.5px;">
                                Recursos asignados
                            </td>
                            <td align="left" class="tasktable" style="height: 85px; border-style: solid solid none solid;
                                border-top-width: 0.5px; border-right-width: 0.5px; border-left-width: 0.5px;
                                border-color: #D2D2D2" colspan="3">
                                <telerik:RadAutoCompleteBox runat="server" ID="racUsers" EmptyMessage="Ingrese un usuario"
                                    DataTextField="Full_Name" DataValueField="Id_User" Width="440px" ResolvedRenderMode="Classic">
                                </telerik:RadAutoCompleteBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="border-top-style: none; border-right-style: solid; border-left-style: solid;
                                border-right-color: #D2D2D2; border-left-color: #D2D2D2; border-right-width: 0.5px;
                                border-left-width: 0.5px">
                                <asp:Label ID="lblMessage" runat="server" Font-Names="CALIBRI" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div class="actions">
                                    <telerik:RadButton ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click">
                                    </telerik:RadButton>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
