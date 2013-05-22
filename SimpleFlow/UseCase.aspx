<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UseCase.aspx.cs" Inherits="SimpleFlow.UseCase" %>

<%-- <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="Styles/DataGridCss2.css" rel="stylesheet" type="text/css" />
    <title>Simple Flow</title>
</head>
<body>
    <form id="form1" runat="server">
    <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>--%>
    <div class="row" style="height:50px; margin-top:10px; margin-left:20px;">
        <legend>
        
        SELECT THE USE CASE YOU WANT TO SOLVE</legend>
    </div>
    <div class="row">
        <div class="span5" style="text-align:right;">
            <asp:Label ID="LabelUser" runat="server" Text="USER:"></asp:Label>
        </div>
        <div class="span6">
            <asp:TextBox ID="TextBoxUser" runat="server" CausesValidation="true" ValidationGroup="validUser"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="validUser"
                ErrorMessage="Please write your name or alias" ControlToValidate="TextBoxUser"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row" style="margin-left:40px; margin-top:30px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True" onrowcommand="GridView1_RowCommand" 
            Width="800px">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" >
                <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonStart" runat="server" CausesValidation="true" 
                            CommandName="Select" Text="Select" ValidationGroup="validUser" />
                    </ItemTemplate>
                    <ControlStyle CssClass="btn btn-primary" Font-Bold="True" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="HeaderStyle" />
            <RowStyle CssClass="RowStyle" />
            <AlternatingRowStyle CssClass="AltRowStyle" />
        </asp:GridView>
    </div>
    <div class="row" style="margin-top:30px;">
        <div class="span8 offset2" >
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Simple Flow.png" Height="80" Width="600" />
            </div>
    </div>
    </form>
</body>
</html>
