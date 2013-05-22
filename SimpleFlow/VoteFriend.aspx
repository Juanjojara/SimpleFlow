<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteFriend.aspx.cs" Inherits="SimpleFlow.VoteFriend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </asp:View>
        </asp:MultiView>
    
    </div>
    <asp:Button ID="Button1" runat="server" Text="Label" onclick="Button1_Click" 
        style="height: 26px" />
    <asp:Button ID="Button2" runat="server" Text="TextBox" 
        onclick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" Text="Check" onclick="Button3_Click" />
    </form>
</body>
</html>
