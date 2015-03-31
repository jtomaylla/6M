<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProfileDetails.aspx.cs" Inherits="SISMONUi.Security.ProfileDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function validListPage(source, arguments) {
            var treeView = $find("<%=rtvPaginas.ClientID%>")
            var elem = treeView.get_checkedNodes();
            if (elem.length == 0) {
                arguments.IsValid = false;
                return;
            }
            else {
                arguments.IsValid = true;
                return;
            }
        }

    </script>
    <style type="text/css">
        .rtChk
        {
            padding: 0px;
            vertical-align: middle !important;
            margin: 0px 2px !important;
            width: 14px !important;
            height: 14px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_subtitulos">
        <asp:Label ID="lblTitle" Text="Detalle de Perfil" runat="server" Font-Bold="True"></asp:Label>
    </div>
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content960">
                <!-- caja datos -->
                <div class="contentRight_enlaces list_perfil">
                    <telerik:RadButton ID="btnGrabar" Text="Grabar" runat="server" OnClick="btnGrabar_Click"
                        ValidationGroup="save" />
                    <telerik:RadButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Regresar" />
                </div>
                <div class="conten_caja_sub_categoria marhin-topnone" style="width: 940px;">
                    <div class="top_table_bandejat">
                    </div>
                    <div class="tabla_sup_caja_sub_categoria" style="min-height: 250px;">
                        <fieldset class="fieldset">
                            <legend class="legend">Módulo :
                                <asp:Label ID="lblModulo" runat="server" Style="font-weight: 700"></asp:Label></legend>
                            <div class="row">
                                <label>
                                    <strong>Nombre</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadTextBox ID="txtNombre" runat="server" Width="640px" Style="text-transform: uppercase">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                        ErrorMessage="Ingrese Nombre" ValidationGroup="save" Display="None" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <label>
                                    <strong>Descripción</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadTextBox ID="txtDescrip" runat="server" Width="640px" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <label>
                                    <strong>Estado</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadComboBox CssClass="" ID="ddlEstado" DataSourceID="odsEstado" runat="server"
                                        Width="305px" DataTextField="Description" DataValueField="Id_Status">
                                    </telerik:RadComboBox>
                                    <asp:ObjectDataSource ID="odsEstado" TypeName="SISMONRules.Security.RuleStatus" SelectMethod="GetAll"
                                        runat="server"></asp:ObjectDataSource>
                                </div>
                            </div>
                            <div class="row">
                                <label>
                                    <strong>Páginas</strong>
                                </label>
                                <div style="margin-left: 196px">
                                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                                        SelectedIndex="0" Align="Justify" ReorderTabsOnSelect="True">
                                        <Tabs>
                                            <telerik:RadTab Text="Páginas" Selected="True">
                                            </telerik:RadTab>
                                            <telerik:RadTab Text="Usuarios">
                                            </telerik:RadTab>
                                        </Tabs>
                                    </telerik:RadTabStrip>
                                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                                        <telerik:RadPageView ID="RadPageView1" runat="server" Height="200px">
                                            <table style="border-collapse: collapse; width: 100%; border: 1px solid #768ca5">
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <telerik:RadTreeView ID="rtvPaginas" runat="server" CheckBoxes="True" Height="170px"
                                                            MultipleSelect="True" TriStateCheckBoxes="False">
                                                        </telerik:RadTreeView>
                                                        <asp:CustomValidator ID="cvPagina" runat="server" ErrorMessage="Seleccione al menos una página"
                                                            ValidationGroup="save" ClientValidationFunction="validListPage"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="RadPageView2" runat="server" Height="200px">
                                            <table style="border-collapse: collapse; width: 100%; border: 1px solid #768ca5;
                                                height: 200px">
                                                <tr>
                                                    <td style="vertical-align: top">
                                                        <telerik:RadGrid ID="rgUserList" runat="server" AllowPaging="True" GroupingSettings-CaseSensitive="false"
                                                            AllowSorting="True" AutoGenerateColumns="False" GridLines="None" MasterTableView-DataKeyNames="Id_User">
                                                            <PagerStyle FirstPageToolTip="Primera P&#225;gina" LastPageToolTip="Ultima P&#225;gina"
                                                                NextPagesToolTip="Siguiente" NextPageToolTip="Siguiente" PageSizeLabelText="Registros por P&#225;gina"
                                                                PrevPagesToolTip="Anterior" PrevPageToolTip="Anterior" />
                                                            <ClientSettings EnableRowHoverStyle="true">
                                                            </ClientSettings>
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn HeaderText="Usuario" UniqueName="Col1" DataField="UserName">
                                                                        <HeaderStyle Font-Bold="True" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn HeaderText="Estado" UniqueName="ColEstado" DataField="STATUSString">
                                                                        <HeaderStyle Font-Bold="True" Width="100px" />
                                                                    </telerik:GridBoundColumn>
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
                                                        </telerik:RadGrid>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </telerik:RadPageView>
                                    </telerik:RadMultiPage>
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
    <asp:ValidationSummary ID="vsArticulo" ShowMessageBox="true" HeaderText="Datos requeridos"
        ShowSummary="false" runat="server" ValidationGroup="save" />
</asp:Content>
