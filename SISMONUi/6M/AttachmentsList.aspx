<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttachmentsList.aspx.cs"
    Inherits="SISMONUi._6M.AttachmentsList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font: 12px Arial, Helvetica, sans-serif;
            color: #4b4b4b;
        }
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
            width: 70px;
        }
        
        .taskCellLFinalRow
        {
            padding-left: 8px;
            padding-bottom: 8px;
            padding-top: 8px;
            align: lef;
            border: 1px solid;
            border-style: solid none solid solid;
            border-color: #D2D2D2;
            background-color: #F3F3F3;
            width: 70px;
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
        
        .taskCellREndFinalRow
        {
            padding-left: 8px;
            padding-bottom: 8px;
            padding-top: 8px;
            align: lef;
            border: 1px solid;
            border-style: solid solid solid solid;
            border-color: #D2D2D2;
        }
        
        /* Not in a box */
        form.no-box
        {
            background: #ffffff;
            border-radius: 3px; /*border: 1px solid #a7a7a7;*/
            margin-bottom: 25px;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            -ms-box-sizing: border-box;
            box-sizing: border-box;
        }
        
        .legend
        {
            width: 100%;
            padding: 6px 15px;
            background: url('../img/legend-bg.png') repeat-x #e9ebf0;
            border: 1px solid #d2d2d2;
            border-top-width: 1px;
            border-radius: 3px 3px 0 0;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            -ms-box-sizing: border-box;
            box-sizing: border-box;
        }
        
        
        .fieldset
        {
            margin: 3px;
            margin-bottom: 5px;
        }
        
        form.wizard fieldset
        {
            margin-bottom: 0;
            margin-top: 0;
        }
        
        .fieldset .row:last-child
        {
            border-radius: 0 0 3px 3px;
        }
        
        /* Row style */
        form .row
        {
            padding: 0 15px;
            border: 1px solid #d2d2d2;
            border-top: 0;
            background: url('../img/row-bg.png') repeat-x #f9f9fa;
        }
        
        form .row.no-bg
        {
            background: none;
            border: none;
        }
        
        form .row:before, form .row:after
        {
            display: table;
            content: '';
        }
        
        form .row:after
        {
            clear: both;
        }
        
        form .row > label
        {
            float: left;
            padding: 20px 0;
            margin-right: 15px;
        }
        
        form .row > div
        {
            position: relative;
            padding-left: 15px;
            border-left: 1px solid #d2d2d2;
        }
        
        form .row > div:after, form .row > div:before
        {
            display: table;
            content: '';
        }
        
        form .row > div:after
        {
            clear: both;
        }
        
        form .row > div > *:not(.icon):not(label)
        {
            margin: 20px 0;
            width: 100%;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            -ms-box-sizing: border-box;
            box-sizing: border-box;
        }
        
        form .row label strong, form .row label small
        {
            display: block;
        }
        
        form.box .row, .box form .row
        {
            border-left: none;
            border-right: none;
            margin: 0 -10px;
        }
        
        form.box .row:last-child, .box form .row:last-child
        {
            border-bottom: none;
        }
        
        
        /* Actions Bar */
        .actions
        {
            padding: 8px;
            float: left;
            width: 100%;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
            border: 1px solid #d2d2d2;
            border-top: 1px solid #c1c1c1;
            border-radius: 0 0 2px 2px;
            background: url('../img/actions-bg.png') #f0f1f4 repeat-x;
        }
        
        form.no-box .actions .left
        {
            float: left;
        }
        
        .actions .right
        {
            float: right;
        }
    </style>
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog      
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow; //IE (and Moz as well)      
            return oWindow;
        }

        function showDoc(fileName) {
            var parentPage = GetRadWindow().BrowserWindow;
            //            parentPage.showAttachmentDoc('../Viewer/DocViewer.aspx?datos=' + fileName + '|1', 'Documento adjunto', 385, 500, true, '', '');
            parentPage.showAttachmentDoc('../Viewer/DocViewer.aspx?datos=' + fileName + '|1', 'Documento adjunto', 800, 600, true, '', '');
            return false;
        }

    </script>
</head>
<body style="background-color: #fbfbfc">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="rsmAttachments" runat="server" AsyncPostBackTimeout="300">
    </telerik:RadScriptManager>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Silk">
    </telerik:RadSkinManager>
    <telerik:RadAjaxPanel ID="rapProject" runat="server">
        <asp:Panel ID="pnNoAttachments" runat="server" Visible="false">
            <table width="390px" style="background-color: #fbfbfc">
                <tr>
                    <td align="center" style="height: 120px">
                        <asp:Label ID="lblMessage" runat="server" Font-Names="CALIBRI" Text="No existen ningun archivo adjunto"
                            ForeColor="Gray"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Repeater ID="rpAttachment" runat="server" OnItemDataBound="rpAttachment_ItemDataBound"
            OnItemCommand="rpAttachment_ItemCommand">
            <ItemTemplate>
                <table width="400px" style="background-color: #fbfbfc">
                    <tr>
                        <td style="padding: 5px 5px 5px 5px">
                            <table width="100%" border="0px" cellpadding="0px" cellspacing="0px" style="background-color: #fbfbfc;
                                font-family: calibri;">
                                <tr>
                                    <td colspan="2">
                                        <legend class="legend">
                                            <asp:Label ID="lblUser" runat="server" Text='<%# Eval("USERString") %>'></asp:Label></legend>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="taskCellL">
                                        Documento
                                    </td>
                                    <td align="left" class="taskCellREnd">
                                        <asp:Label ID="lblDocument_Title" runat="server" Text='<%# Eval("Document_Title") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="taskCellL">
                                        Requerido
                                    </td>
                                    <td align="left" class="taskCellREnd">
                                        <asp:Label ID="lblRequired" runat="server" Text='<%# Eval("Required") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="taskCellL">
                                        Tipo
                                    </td>
                                    <td align="left" class="taskCellREnd">
                                        <asp:Image ID="imgType" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="taskCellLFinalRow">
                                        Descargar
                                    </td>
                                    <td align="left" class="taskCellREndFinalRow">
                                        <asp:ImageButton ID="imgDownload" runat="server" Width="16px" Height="16px" Style="cursor: pointer"
                                            CommandArgument='<%# Eval("File_Name") %>' />
                                        <asp:Label ID="lblUnavailableFile" runat="server" Text="Archivo no disponible" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <telerik:RadWindow ID="rwAttachment" ClientIDMode="Static" runat="server">
        </telerik:RadWindow>
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
