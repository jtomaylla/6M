<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskConfiguration.aspx.cs"
    Inherits="SISMONUi._6M.TaskConfiguration" %>

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
        .taskCellL
        {
            padding-left: 8px;
            padding-bottom: 8px;
            padding-top: 8px;
            align: lef;
            border: 1px solid;
            border-style: solid none none solid;
            border-color: #D2D2D2;
            background-color: #F3F3F3;
        }
        
        .taskCellR
        {
            padding-left: 8px;
            padding-bottom: 8px;
            padding-top: 8px;
            align: lef;
            border: 1px solid;
            border-style: solid none none solid;
            border-color: #D2D2D2;
        }
        
        .taskCellREnd
        {
            padding-left: 8px;
            padding-bottom: 8px;
            padding-top: 8px;
            align: lef;
            border: 1px solid;
            border-style: solid solid none solid;
            border-color: #D2D2D2;
        }
        
        .taskCellR1End
        {
            padding-left: 8px;
            padding-bottom: 8px;
            padding-top: 8px;
            align: lef;
            height: 50px;
            border: 1px solid;
            border-style: solid solid none solid;
            border-color: #D2D2D2;
        }
        
        .taskCellR2End
        {
            padding-left: 8px;
            padding-bottom: 8px;
            padding-top: 8px;
            vertical-align: top;
            align: lef;
            height: 185px;
            border: 1px solid;
            border-style: solid solid none solid;
            border-color: #D2D2D2;
        }
        
        .taskCellRqL
        {
            padding-left: 5px;
            padding-bottom: 5px;
            padding-top: 5px;
            padding-right: 5px;
            align: lef;
            border: 1px solid;
            border-style: solid none none solid;
            border-color: #D2D2D2;
            background-color: #F3F3F3;
        }
        
        .taskCellRqR
        {
            padding-left: 5px;
            padding-bottom: 5px;
            padding-top: 5px;
            padding-right: 5px;
            align: lef;
            border: 1px solid;
            border-style: solid none none solid;
            border-color: #D2D2D2;
        }
        
        .taskCellRqREnd
        {
            padding-left: 5px;
            padding-bottom: 5px;
            padding-top: 5px;
            padding-right: 5px;
            align: lef;
            border: 1px solid;
            border-style: solid solid none solid;
            border-color: #D2D2D2;
        }
    </style>
    <script type="text/javascript" id="telerikClientEvents1">
//<![CDATA[

	function racUsers_EntryAdding(sender,args)
	{
	    //Add JavaScript handler code here
	    if (sender.get_entries().get_count() > 0) {
	        eventArgs.set_cancel(true);
	    }
	}
//]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="rsmAddResources" runat="server" AsyncPostBackTimeout="300">
    </telerik:RadScriptManager>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Silk">
    </telerik:RadSkinManager>
    <telerik:RadScriptBlock runat="server">
        <script type="text/javascript" language="javascript">
            function OnClientFileUploaded(sender, args) {
            <%=rapProject.ClientID%>.ajaxRequest('LoadFileAttachment');
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog      
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow; //IE (and Moz as well)      
            return oWindow;
        }

        function RefreshProject() {
            var parentPage = GetRadWindow().BrowserWindow;
            parentPage.AddTaskEvent();
            return false;
        }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadAjaxPanel ID="rapProject" runat="server">
        <asp:Panel ID="pnNotConfigurable" runat="server" Visible="false">
            <table width="632px" style="background-color: #fbfbfc">
                <tr>
                    <td style="height: 580px">
                        <asp:Label ID="lblMessage" runat="server" Font-Names="CALIBRI" Text="Esta tarea no es configurable"
                            ForeColor="Gray"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnOwner" runat="server" Visible="false">
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
                                <td align="left" class="taskCellL">
                                    Descripción
                                </td>
                                <td align="left" class="taskCellR1End" colspan="3">
                                    <telerik:RadTextBox ID="rdtxtDescription" runat="server" TextMode="MultiLine" 
                                        MaxLength="5000" Width="490px" Height="60px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                    Proyecto
                                </td>
                                <td align="left" class="taskCellR">
                                    <asp:Label ID="lblProject" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="taskCellL">
                                    Tarea
                                </td>
                                <td align="left" class="taskCellREnd">
                                    <asp:Label ID="lblTask" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                    Costo
                                </td>
                                <td align="left" class="taskCellR">
                                    <telerik:RadNumericTextBox ID="rntxtInicialCost" runat="server" Type="Currency" Width="100px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td align="left" class="taskCellL">
                                    Gasto
                                </td>
                                <td align="left" class="taskCellREnd">
                                    <telerik:RadNumericTextBox ID="rntxtFinalCost" runat="server" Type="Currency" Width="100px"
                                        Enabled="False">
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                    Inicio
                                </td>
                                <td align="left" class="taskCellR">
                                    <telerik:RadDateTimePicker ID="rdtpStart" runat="server" Enabled="false" Width="200px">
                                    </telerik:RadDateTimePicker>
                                </td>
                                <td align="left" class="taskCellL">
                                    Fin
                                </td>
                                <td align="left" class="taskCellREnd">
                                    <telerik:RadDateTimePicker ID="rdtpEnd" runat="server" Enabled="False" Width="200px"
                                        Culture="es-ES" ResolvedRenderMode="Classic">
                                    </telerik:RadDateTimePicker>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                </td>
                                <td align="left" class="taskCellR">
                                </td>
                                <td align="left" class="taskCellL">
                                    % Completado
                                </td>
                                <td align="left" class="taskCellREnd">
                                    <asp:Label ID="lblPercentComplete" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                </td>
                                <td align="left" class="taskCellR">
                                </td>
                                <td align="left" class="taskCellL">
                                    % Gastado
                                </td>
                                <td align="left" class="taskCellREnd">
                                    <asp:Label ID="lblRelativeCost" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                    Días antes del final
                                </td>
                                <td align="left" class="taskCellR">
                                    <telerik:RadNumericTextBox ShowSpinButtons="true" IncrementSettings-InterceptArrowKeys="true"
                                        IncrementSettings-InterceptMouseWheel="true" runat="server" ID="rntxtAlert_Days_From_End"
                                        Width="77px" DataType="System.Int32" MaxValue="365" MinValue="0">
                                        <NegativeStyle Resize="None" />
                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </telerik:RadNumericTextBox>
                                    <asp:CheckBox ID="chkAlert" runat="server" Text="Alertar por correo" />
                                </td>
                                <td align="left" class="taskCellL">
                                    Estado
                                </td>
                                <td align="left" class="taskCellREnd">
                                    <telerik:RadComboBox ID="ddlStatus" runat="server" DataSourceID="odsStatus" DataTextField="Description"
                                        DataValueField="Id_Status" Width="170px">
                                    </telerik:RadComboBox>
                                    <asp:HiddenField ID="hfId_Status" runat="server" />
                                    <asp:ObjectDataSource ID="odsStatus" runat="server" SelectMethod="GetAll" TypeName="SISMONRules.Security.RuleStatus">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                    Usuario responsable
                                </td>
                                <td align="left" class="taskCellR1End" colspan="3">
                                    <telerik:RadAutoCompleteBox runat="server" ID="racUsers" EmptyMessage="Ingrese un usuario"
                                        DataTextField="Full_Name" DataValueField="Id_User" Width="490px" 
                                        ResolvedRenderMode="Classic" oncliententryadding="racUsers_EntryAdding">
                                    </telerik:RadAutoCompleteBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                    Requisitos
                                </td>
                                <td align="left" class="taskCellR2End" colspan="3" style="height: 210px">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <table cellpadding="0px" cellspacing="0px" width="98%">
                                                    <tr>
                                                        <td class="taskCellRqL">
                                                            Documento
                                                        </td>
                                                        <td class="taskCellRqR">
                                                            <telerik:RadTextBox ID="txtDocument_Title" runat="server" ClientIDMode="Static" Width="300px">
                                                            </telerik:RadTextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Debe ingresar nombre de documento"
                                                                ControlToValidate="txtDocument_Title" Display="None" ValidationExpression="\d+">*</asp:RegularExpressionValidator>
                                                        </td>
                                                        <td class="taskCellRqREnd">
                                                            <asp:CheckBox ID="chkRequired" runat="server" Text="Requerido" Checked="true" Font-Names="Tahoma"
                                                                Font-Size="8pt" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <div class="actions">
                                                                <telerik:RadButton ID="btnAgregar" runat="server" ValidationGroup="save" Text="Agregar Requisito"
                                                                    OnClick="btnAgregar_Click">
                                                                    <Icon PrimaryIconUrl="../img/add_16.ico" PrimaryIconLeft="5px"></Icon>
                                                                </telerik:RadButton>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadGrid ID="rgList" runat="server" Width="485px" AllowPaging="True" PageSize="1"
                                                    AutoGenerateColumns="False" OnItemCommand="rgList_ItemCommand" OnPageIndexChanged="rgList_PageIndexChanged"
                                                    Culture="es-PE">
                                                    <PagerStyle FirstPageToolTip="Primera P&#225;gina" LastPageToolTip="Ultima P&#225;gina"
                                                        NextPagesToolTip="Siguiente" NextPageToolTip="Siguiente" PageSizeLabelText="Registros por P&#225;gina"
                                                        PrevPagesToolTip="Anterior" PrevPageToolTip="Anterior" Mode="Slider" />
                                                    <ClientSettings EnableRowHoverStyle="true">
                                                    </ClientSettings>
                                                    <MasterTableView>
                                                        <Columns>
                                                            <telerik:GridBoundColumn HeaderText="Documento" UniqueName="Document_Title" DataField="Document_Title">
                                                                <ItemStyle Width="350px" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Requerido" UniqueName="Required" DataField="Required">
                                                                <ItemStyle Width="100px" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgbEliminar" runat="server" CausesValidation="false" CommandName="Delete"
                                                                        ImageUrl="~/img/delete.gif" CommandArgument='<%# Eval("Index") %>' ToolTip="Eliminar documento" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            </telerik:GridTemplateColumn>
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
        </asp:Panel>
        <asp:Panel ID="pnUser" runat="server" Visible="false">
            <table width="632px" style="background-color: #fbfbfc">
                <tr>
                    <td style="padding: 5px 5px 5px 5px">
                        <table width="100%" border="0px" cellpadding="0px" cellspacing="0px" style="background-color: #fbfbfc;
                            font-family: calibri;">
                            <tr>
                                <td colspan="4">
                                    <legend class="legend">Agregar archivos adjuntos</legend>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                    Proyecto
                                </td>
                                <td align="left" class="taskCellR">
                                    <asp:Label ID="lblProjectU" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="taskCellL">
                                    Tarea
                                </td>
                                <td align="left" class="taskCellREnd">
                                    <asp:Label ID="lblTaskU" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                    Costo Final
                                </td>
                                <td align="left" class="taskCellR">
                                    <telerik:RadTextBox ID="txtFinal_CostU" runat="server" Width="60px">
                                    </telerik:RadTextBox>
                                    <asp:Label ID="lblFinal_CostU" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="taskCellL">
                                    Fecha Final
                                </td>
                                <td align="left" class="taskCellREnd">
                                    <telerik:RadDateTimePicker ID="rdtpFinalEndU" runat="server" Width="200px">
                                    </telerik:RadDateTimePicker>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                    &nbsp;% Completado
                                </td>
                                <td align="left" class="taskCellR">
                                    <telerik:RadNumericTextBox ShowSpinButtons="true" MaxValue="100" MinValue="0" Enabled="false" IncrementSettings-InterceptArrowKeys="true"
                                        IncrementSettings-InterceptMouseWheel="true" runat="server" ID="rntxtPercentCompleteU"
                                        Width="77px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td align="left" class="taskCellL">
                                    Estado
                                </td>
                                <td align="left" class="taskCellREnd">
                                    <asp:Label ID="lblStatusU" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="taskCellL">
                                    Adjuntos
                                </td>
                                <td align="left" class="taskCellR2End" style="height: 355px" colspan="3">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <telerik:RadGrid ID="rgListU" runat="server" Width="510px" AutoGenerateColumns="False"
                                                    OnItemCommand="rgListU_ItemCommand" Culture="es-PE" ResolvedRenderMode="Classic"
                                                    MasterTableView-DataKeyNames="Id_Task_Configuration" OnItemDataBound="rgListU_ItemDataBound">
                                                    <PagerStyle FirstPageToolTip="Primera P&#225;gina" LastPageToolTip="Ultima P&#225;gina"
                                                        NextPagesToolTip="Siguiente" NextPageToolTip="Siguiente" PageSizeLabelText="Registros por P&#225;gina"
                                                        PrevPagesToolTip="Anterior" PrevPageToolTip="Anterior" Mode="Slider" />
                                                    <ClientSettings EnableRowHoverStyle="true">
                                                    </ClientSettings>
                                                    <MasterTableView>
                                                        <Columns>
                                                            <telerik:GridBoundColumn HeaderText="Documento" UniqueName="Document_Title" DataField="Document_Title">
                                                                <ItemStyle Width="300px" />
                                                                <HeaderStyle />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Requerido" UniqueName="Required" DataField="Required">
                                                                <ItemStyle Width="10%" />
                                                                <HeaderStyle />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderStyle-Width="170px" ItemStyle-Width="170px" HeaderText="Archivo">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgAtta" runat="server" Width="16" Height="16" ImageUrl='~/img/att.gif'
                                                                        Style="cursor: pointer" ToolTip="Click para ver el adjunto" CommandName="ViewAtt"
                                                                        CommandArgument='<%# Eval("Id_Task_Configuration") %>' />
                                                                    <asp:ImageButton ToolTip="Eliminar el adjunto" Width="16" Height="16" CausesValidation="false"
                                                                        CommandArgument='<%# Eval("Id_Task_Configuration") %>' ImageUrl='~/img/ico_delete.png'
                                                                        runat="server" ID="imgDeleteAtt" CommandName="DeleteAttachment" />
                                                                    <telerik:RadAsyncUpload ID="rauAttachment" RegisterWithScriptManager="true" ToolTip="Cargar archivo"
                                                                        MaxFileInputsCount="1" MultipleFileSelection="Disabled" InputSize="10" Width="180px"
                                                                        OnClientFileUploaded="OnClientFileUploaded" runat="server">
                                                                        <Localization Select="Select." Remove="Elim." />
                                                                    </telerik:RadAsyncUpload>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
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
                                <td colspan="4">
                                    <div class="actions">
                                        <telerik:RadButton ID="btnGrabarU" runat="server" Text="Grabar" OnClick="btnGrabarU_Click">
                                        </telerik:RadButton>
                                        &nbsp;
                                        <telerik:RadButton ID="btnCerrarT" runat="server" Text="Cerrar Actividad" OnClick="btnCerrarT_Click">
                                        </telerik:RadButton>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <telerik:RadWindow runat="server" ID="rwMessage" Modal="True" Behaviors="Close" Title="6M"
            Skin="Silk" Animation="FlyIn" EnableShadow="True" Height="150px" Width="300px"
            Behavior="Close" ResolvedRenderMode="Classic">
            <ContentTemplate>
                <table style="z-index: 8000; width: 265px; height: 85px">
                    <tr>
                        <td style="padding: 5px 5px 5px 5px; vertical-align: middle" align="center">
                            <asp:Label ID="lblMsg" runat="server" Font-Names="CALIBRI" ForeColor="#666666" Text=""
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </telerik:RadWindow>
        <telerik:RadWindow runat="server" ID="rwConfirmation" Modal="True" Behaviors="Close"
            VisibleOnPageLoad="false" Title="6M" Skin="Silk" Animation="FlyIn" EnableShadow="True"
            Height="220px" Width="282px" Behavior="Close" ResolvedRenderMode="Classic">
            <ContentTemplate>
                <table style="z-index: 8000; width: 265px; height: 85px">
                    <tr>
                        <td style="padding: 5px 5px 5px 5px; vertical-align: middle" align="center">
                            <table width="100%" border="0px" cellpadding="0px" cellspacing="0px" style="background-color: #fbfbfc;
                                font-family: calibri;">
                                <tr>
                                    <td colspan="2">
                                        <legend class="legend">Re abrir la tarea</legend>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="taskCellL">
                                        Razón&nbsp&nbsp
                                    </td>
                                    <td align="left" class="taskCellREnd">
                                        <telerik:RadTextBox ID="txtChange_Reason" runat="server" TextMode="MultiLine" Width="190px"
                                            EmptyMessage="Ingrese una razón">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <div class="actions">
                                            <telerik:RadButton ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click"
                                                ValidationGroup="save" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </telerik:RadWindow>
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
