<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleFlow.Default" %>

<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <title>Simple Flow</title>
</head>
<body>
    <form id="form1" runat="server" >
        <div class="row">
            <div class="span12" style="text-align: left; margin-top:20px; margin-left:80px; font-family: Calibri; font-size:xx-large; color: #44CCAE; ">
            It is literally true that you can succeed best <br /><br />and quickest by helping others to succeed.<br /><br /> —Napoleon Hill
            </div>
        </div>
        <div class="row span12" style="margin-top: 50px; height:250px;">
            <div class="span2"></div>
            <div class="span8 offset2">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Simple Flow.png" Height="80" Width="600" />
            </div>
            <div class="span4"></div>
        </div>
        <div class="row" style="margin-top: 100px;">
            <div class="span4" style="text-align: center; margin-left: 50px; font-family: Calibri; font-size:xx-large; color: #44CCAE; ">
            <%--<input type="submit" class="btn btn-primary btn-large" 
                    style="width: 118px; font-weight:bold;" value="Participate"/>--%>
            <asp:Button ID="Button1" runat="server" Text="Participate" 
                    CssClass="btn btn-primary btn-large" style="width: 118px; font-weight:bold;" 
                    onclick="Button1_Click" />
                <br /><br />using your Facebook account
            </div>
            <div class="span4" style="text-align: center; font-family: Calibri; font-size:xx-large; color: #44CCAE; ">
            <asp:Button ID="Button2" runat="server" Text="Login" 
                    CssClass="btn btn-primary btn-large" style="width: 118px; font-weight:bold;" 
                    onclick="Button2_Click" />
            <br /><br />using a local account
            </div>
            <div class="span4" style="text-align: center; font-family: Calibri; font-size:xx-large; color: #44CCAE; ">
            <asp:Button ID="Button3" runat="server" Text="Try Out" 
                    CssClass="btn btn-primary btn-large" style="width: 118px; font-weight:bold;" 
                    onclick="Button3_Click" />
            <br /><br />the interactive spreadsheet
            </div>
        </div>    
    </form>
</body>
</html>
