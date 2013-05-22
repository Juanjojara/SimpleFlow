<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostPhoto.aspx.cs" Inherits="SimpleFlow.PostPhoto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <title>Simple Flow</title>
</head>
<body>
    <form class="form-horizontal" id="form1" runat="server">
    <div class="row" style="height:50px; margin-left:100px; margin-top:50px;">
        <legend>Upload a photo to the album of the application</legend>
    </div>
    <div class="control-group">
        <label class="control-label" for="inputMsg">Select a photo to upload</label>
        <div class="controls">
          <%--<input type="text" id="inputMsg" placeholder="Message">--%>
          <asp:FileUpload ID="FileUpload1" runat="server" />
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
