<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Excel.aspx.cs" Inherits="SimpleFlow.Excel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <title>Simple Flow</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="row" style="height:50px; margin-top:10px; margin-left:20px;">
        <legend>Facebook Analytics</legend>
    </div>
    <div class="row">
        <div class="span12" style="text-align: left; margin-top:20px; margin-left:80px; font-family: Calibri; font-size:xx-large; color: #44CCAE; ">
            Please copy the code below <br /><br />and paste it in the "Settings" sheet of the spreadsheet.<br /><br />
        </div>
    </div>
    <div class="row">
        <div class="span12" style="text-align: left; margin-top:20px; margin-left:80px; font-family: Calibri; font-size:x-large; color: #44CCAE; ">
        Your Access Token:<br />
        <asp:Label ID="Label1" runat="server" style="font-family: Calibri; font-size:medium;" Text="Label"></asp:Label>
        </div>
    </div>
    <!--<div class="row">
        <div class="span12" style="text-align: left; margin-top:20px; margin-left:80px; font-family: Calibri; font-size:x-large; color: #44CCAE; ">
        Download the file from here:<br />
        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/downloadfile.ashx" Target="_blank" runat="server">Facebook Analytics on Excel</asp:HyperLink>
        </div>
    </div>-->
    </form>
</body>
</html>
