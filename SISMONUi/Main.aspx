<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Main.aspx.cs" Inherits="SISMONUi.Main" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <div class="contenido_content">
        <div class="cont_seguridadp no_padleft">
            <div class="contenido_content1140">
                 <!-- caja datos -->
                <div class="conten_caja_sub_categoria marhin-topnone" style="width: 1000px;">
                    <div class="top_table_bandejat">
                    </div>
                    <div class="tabla_sup_caja_sub_categoria" style="min-height: 350px;">
                        <table style="width: 100%; height: 500px">
                            <tr>
                                <td align="center" style="padding:5px">
                                    <asp:Label ID="lblMessage" runat="server" Font-Names="CALIBRI" 
                                    ForeColor="Gray" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="pnNotification" runat="server" Height="495px" ScrollBars="Vertical">
                                        <asp:DataList ID="dlNotification" runat="server" 
                                            OnItemDataBound="dlNotification_ItemDataBound" RepeatColumns="2" 
                                            RepeatDirection="Vertical" onitemcommand="dlNotification_ItemCommand" >
                                            <ItemTemplate>
                                                <table style="width:390px;height:190px;background-repeat:no-repeat;background-position:center; background-image: url('img/NotificationImg.jpg');">
                                                    <tr>
                                                        <td align="center" style="padding:5px;height:60px;vertical-align:bottom">
                                                            <asp:Label ID="lblNotificationType" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align:top;padding-top:5px;padding-left:53px;padding-right:30px">
                                                            <asp:Label ID="lblNotification" runat="server" ForeColor="#999999" Font-Names="Calibri"></asp:Label>
                                                            <asp:LinkButton ID="lbProjectName" runat="server" onclick="lbProjectName_Click" 
                                                            CommandArgument='<%# Eval("Id_Project")%>' CommandName="RedirectToRegisterTask" 
                                                            Font-Names="Calibri" Font-Size="Small" 
                                                            ForeColor="#6699FF"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="background-color:White;height:20px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </SeparatorTemplate>
                                        </asp:DataList>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="bottom_table_bandejat">
                    
                    </div>
                </div>
                <!-- fin caja datos -->
                
            </div>
        </div>
    </div>
</asp:Content>
