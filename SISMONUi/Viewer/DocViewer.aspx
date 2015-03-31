<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocViewer.aspx.cs" Inherits="SISMONUi.Viewer.DocViewer" %>

<%@ Register Assembly="PdfViewer" Namespace="PdfViewer" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ShowPdf ID="Visor" runat="server" Width="100%" Height="530px" BorderColor="#99CCFF"
        BorderStyle="Solid" />
    </form>
</body>
</html>
