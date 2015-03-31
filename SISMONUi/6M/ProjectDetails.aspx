<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProjectDetails.aspx.cs" Inherits="SISMONUi._6M.ProjectDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" Text="Detalle de Proyecto" runat="server" Font-Bold="True"></asp:Label>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960">
                <!-- caja datos -->
                <telerik:RadAjaxPanel ID="rapProject" runat="server">
                    <div class="contentRight_enlaces list_perfil">
                        <telerik:RadButton ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar"
                            ValidationGroup="save">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnCancelar" runat="server" Text="Regresar" OnClick="btnCancelar_Click">
                        </telerik:RadButton>
                    </div>
                    <div class="conten_caja_sub_categoria marhin-topnone" style="width: 940px;">
                        <div class="top_table_bandejat">
                        </div>
                        <div class="tabla_sup_caja_sub_categoria" style="min-height: 250px;">
                            <fieldset class="fieldset">
                                <legend class="legend">Informacion General</legend>
                                <div class="row">
                                    <label>
                                        <strong>Nombre:</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadTextBox ID="txtName" runat="server" Width="640px" Style="text-transform: uppercase">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                            ErrorMessage="Debe ingresar nombre para el proyecto" Display="None" ValidationGroup="save">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Administrador</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <div>
                                            <asp:Label ID="lblOwner" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Usuarios de Proyecto</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadAutoCompleteBox runat="server" ID="racProjectUsers" MinFilterLength="3"
                                            EmptyMessage="Ingrese un usuario" DataTextField="Full_Name" DataValueField="Id_User"
                                            Width="640px" ResolvedRenderMode="Classic" Culture="es-ES">
                                        </telerik:RadAutoCompleteBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <label>
                                        <strong>Estado</strong>
                                    </label>
                                    <div style="margin-left: 196px">
                                        <telerik:RadComboBox ID="ddlStatus" Width="305px" DataSourceID="odsStatus" DataTextField="Description"
                                            DataValueField="Id_Status" runat="server">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="odsStatus" TypeName="SISMONRules.Security.RuleStatus" SelectMethod="GetAll"
                                            runat="server"></asp:ObjectDataSource>
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
