<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AlertTypeDetails.aspx.cs" Inherits="SISMONUi._6M.AlertTypeDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtDays_From_Start").keydown(function (event) {
                if (event.shiftKey) {
                    event.preventDefault();
                }

                if (event.keyCode == 46 || event.keyCode == 8) {
                }
                else {
                    if (event.keyCode < 95) {
                        if (event.keyCode < 48 || event.keyCode > 57) {
                            event.preventDefault();
                        }
                    }
                    else {
                        if (event.keyCode < 96 || event.keyCode > 105) {
                            event.preventDefault();
                        }
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" Text="Detalle de Proyecto" runat="server" Font-Bold="True"></asp:Label>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960">
                <!-- caja datos -->
                <telerik:RadAjaxPanel ID="rapAlertType" runat="server">
                    <div class="contentRight_enlaces list_perfil">
                        <telerik:RadButton ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar"
                            ValidationGroup="save" />
                        <telerik:RadButton ID="btnCancelar" runat="server" Text="Regresar" OnClick="btnCancelar_Click" />
                    </div>
                    <div class="conten_caja_sub_categoria marhin-topnone" style="width: 940px;">
                        <div class="top_table_bandejat">
                        </div>
                        <div class="tabla_sup_caja_sub_categoria" style="min-height: 250px;">
                            <fieldset class="fieldset">
                                <legend class="legend">Informacion General</legend>
                                <div class="row">
                                    <label>
                                        <strong>Tipo de alerta:</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtDescription" runat="server" Width="640px" Style="text-transform: uppercase">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Alertas</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 30%">
                                                                Dias desde el inicio :
                                                            </td>
                                                            <td style="width: 20%">
                                                                <telerik:RadNumericTextBox ShowSpinButtons="true" IncrementSettings-InterceptArrowKeys="true"
                                                                    IncrementSettings-InterceptMouseWheel="true" runat="server" ID="txtDays_From_Start"
                                                                    Width="77px">
                                                                </telerik:RadNumericTextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Debe ingresar solo números"
                                                                    ControlToValidate="txtDays_From_Start" Display="None" ValidationExpression="\d+">*</asp:RegularExpressionValidator>
                                                            </td>
                                                            <td style="width: 20%">
                                                                % Costo
                                                            </td>
                                                            <td style="width: 30%">
                                                                <telerik:RadNumericTextBox ShowSpinButtons="true" IncrementSettings-InterceptArrowKeys="true"
                                                                IncrementSettings-InterceptMouseWheel="true" runat="server" ID="txtCost_Percent" MinValue="0" MaxValue="100"
                                                                Width="77px">
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td align="right">
                                                                <telerik:RadButton ID="btnAgregar" runat="server" ValidationGroup="save" Text="Agregar"
                                                                    OnClick="btnAgregar_Click">
                                                                    <Icon PrimaryIconUrl="../img/add_16.ico" PrimaryIconLeft="5px"></Icon>
                                                                </telerik:RadButton>
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
                                                    <telerik:RadGrid ID="rgList" runat="server" AllowPaging="True" AllowSorting="True"
                                                        AutoGenerateColumns="False" OnItemCommand="rgList_ItemCommand">
                                                        <PagerStyle FirstPageToolTip="Primera P&#225;gina" LastPageToolTip="Ultima P&#225;gina"
                                                            NextPagesToolTip="Siguiente" NextPageToolTip="Siguiente" PageSizeLabelText="Registros por P&#225;gina"
                                                            PrevPagesToolTip="Anterior" PrevPageToolTip="Anterior" />
                                                        <ClientSettings EnableRowHoverStyle="true">
                                                        </ClientSettings>
                                                        <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridBoundColumn HeaderText="Dias desde el inicio" UniqueName="Days_From_Start"
                                                                    DataField="Days_From_Start" FilterControlWidth="400px">
                                                                    <ItemStyle Width="400px" />
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn HeaderText="% Costo" UniqueName="Cost_Percent"
                                                                    DataField="Cost_Percent" FilterControlWidth="50px">
                                                                    <ItemStyle Width="50px" />
                                                                    <HeaderStyle Font-Bold="True" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgbEliminar" runat="server" CausesValidation="false" CommandName="Delete"
                                                                            ImageUrl="~/img/delete.gif" CommandArgument='<%# Eval("Id_Alert") %>' OnClientClick="jConfirm('¿Esta seguro de eliminar esta alerta?','Confirmación',this); return false;"
                                                                            ToolTip="Eliminar alerta" />
                                                                        <asp:HiddenField ID="hfId_Alert" runat="server" Value='<%# Eval("Id_Alert") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="30px" />
                                                                    <ItemStyle HorizontalAlign="Center" />
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
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="bottom_table_bandejat">
                        </div>
                    </div>
                </telerik:RadAjaxPanel>
                <!-- fin caja datos -->
            </div>
        </div>
    </div>
    <asp:ValidationSummary ID="vsMant" ShowMessageBox="true" HeaderText="Datos requeridos"
        ShowSummary="false" runat="server" ValidationGroup="save" />
</asp:Content>
