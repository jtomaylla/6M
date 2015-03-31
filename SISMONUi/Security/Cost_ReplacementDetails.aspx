<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cost_ReplacementDetails.aspx.cs" Inherits="SISMONUi.Security.Cost_ReplacementDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
     <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" Text="Mantenimiento de Modulo" runat="server" Font-Bold="True"></asp:Label>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960">
                <!-- caja datos -->
                <div class="contentRight_enlaces list_perfil">
                    <telerik:RadButton ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click"
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
                                    <strong>Keyword</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadTextBox ID="txtKeyword" Width="640px" runat="server">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv0" runat="server" ControlToValidate="txtKeyword"
                                        Display="None" ErrorMessage="Ingrese Keyword" SetFocusOnError="True" ValidationGroup="save">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <label>
                                    <strong>Costo Inicial</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadTextBox ID="txtCost" Width="640px" runat="server">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCost"
                                        Display="None" ErrorMessage="Ingrese Costo Inicial" SetFocusOnError="True" ValidationGroup="save">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <label>
                                    <strong>Estado</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadComboBox ID="ddlStatus" Width="305px" DataSourceID="odsEstado" DataTextField="Description"
                                        DataValueField="Id_Status" runat="server">
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="odsEstado" TypeName="SISMONRules.Security.RuleStatus" SelectMethod="GetAll"
                                        runat="server"></asp:ObjectDataSource>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="bottom_table_bandejat">
                    </div>
                </div>
                <!-- fin caja datos -->
            </div>
        </div>
    </div>
    <asp:ValidationSummary ID="vsMant" ShowMessageBox="true" HeaderText="Datos requeridos"
        ShowSummary="false" runat="server" ValidationGroup="save" />
</asp:Content>
