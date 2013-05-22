<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostMessageFriend.aspx.cs" Inherits="SimpleFlow.PostMessageFriend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <title>Simple Flow</title>
</head>
<body>
    <form class="form-horizontal" id="form1" runat="server">
    <div class="row" style="height:50px; margin-left:100px; margin-top:50px;">
        <legend>Write a message that will be posted in your friend's Wall</legend>
    </div>
    <div class="control-group">
        <label class="control-label" for="inputMsg">Message</label>
        <div class="controls">
          <%--<input type="text" id="inputMsg" placeholder="Message">--%>
          <textarea rows="10" cols="30" placeholder="Write a Message"></textarea>
        </div>
    </div>
    <div class="control-group" style="margin-left:100px; margin-top:100px;">
        <div class="controls">
            <asp:Button CssClass="btn btn-primary btn-large" Width="100" ID="ButtonNext" 
                runat="server" Text="Next" onclick="ButtonNext_Click" />
        </div>
    </div>
    <%--<div class="row" style="height:500px;">
    </div>--%>
    <div class="row" style="height:50px; margin-left:100px; margin-top:100px;">
        <legend></legend>
    </div>
    </form>
</body>
</html>
