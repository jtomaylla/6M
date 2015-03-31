<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ModuleDetails.aspx.cs" Inherits="SISMONUi.Security.ModuleDetails" %>

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
                                    <strong>Nombre</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadTextBox ID="txtNombre" Width="640px" runat="server">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv0" runat="server" ControlToValidate="txtNombre"
                                        Display="None" ErrorMessage="Ingrese Nombre" SetFocusOnError="True" ValidationGroup="save">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <label>
                                    <strong>Descripción</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadTextBox ID="txtDescripcion" Width="640px" runat="server" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <label>
                                    <strong>URL</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadTextBox ID="txtURL" runat="server" Width="640px">
                                    </telerik:RadTextBox>
                                    <asp:RegularExpressionValidator ID="rev" runat="server" ControlToValidate="txtURL"
                                        Display="None" ErrorMessage="Ingrese URL Válida" SetFocusOnError="True" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                        ValidationGroup="save">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtURL" Display="None"
                                        ErrorMessage="Ingrese URL" SetFocusOnError="True" ValidationGroup="save">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <label>
                                    <strong>Dominio</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadTextBox ID="txtDominio" runat="server" Width="640px">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtDominio"
                                        Display="None" ErrorMessage="Ingrese Dominio" SetFocusOnError="True" ValidationGroup="save">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <label>
                                    <strong>Estado</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadComboBox ID="ddlEstado" Width="305px" DataSourceID="odsEstado" DataTextField="Description"
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
