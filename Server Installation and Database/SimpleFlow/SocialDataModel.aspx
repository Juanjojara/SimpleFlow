<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SocialDataModel.aspx.cs" Inherits="SimpleFlow.SocialDataModel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="Styles/DataGridCss2.css" rel="stylesheet" type="text/css" />
    <title>Simple Flow</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="PanelUser" runat="server" Width="400" Height="200" style="background:#FFFFFF; float:right; padding-left:10px; border-right: 4px yellowGreen solid; border-top: 4px yellowGreen solid; border-bottom: 4px yellowGreen solid; z-index: 5; position: absolute;" 
        BackColor="White" BorderColor="Green" BorderStyle="Solid" BorderWidth="2" >

        <asp:GridView ID="GridViewUser" runat="server" 
                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                        CssClass="GridViewStyle" GridLines="None" >
                        <Columns>
                            <asp:BoundField DataField="Input" HeaderText="Input" />
                            <asp:BoundField DataField="Name" HeaderText="Description" />
                            <asp:BoundField DataField="Output" HeaderText="Output" />
                        </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelFriend" runat="server" Width="400" Height="300" style="background:#FFFFFF; float:right; padding-left:10px; 
        border-right: 4px yellowGreen solid; border-top: 4px yellowGreen solid; border-bottom: 4px yellowGreen solid; z-index: 5; position: absolute; 
        margin-left:0px; margin-top:200px;" BackColor="White" BorderColor="Green" BorderStyle="Solid" BorderWidth="2" >

        <asp:GridView ID="GridViewFriends" runat="server" 
                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                        CssClass="GridViewStyle" GridLines="None" >
                        <Columns>
                            <asp:BoundField DataField="Input" HeaderText="Input" />
                            <asp:BoundField DataField="Name" HeaderText="Description" />
                            <asp:BoundField DataField="Output" HeaderText="Output" />
                        </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelAlbum" runat="server" Width="400" Height="400" style="background:#FFFFFF; float:right; padding-left:10px; 
        border-right: 4px yellowGreen solid; border-top: 4px yellowGreen solid; border-bottom: 4px yellowGreen solid; z-index: 5; position: absolute; 
        margin-left:300px; margin-top:0px;" BackColor="White" BorderColor="Green" BorderStyle="Solid" BorderWidth="2" >

        <asp:GridView ID="GridViewAlbum" runat="server" 
                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                        CssClass="GridViewStyle" GridLines="None" >
                        <Columns>
                            <asp:BoundField DataField="Input" HeaderText="Input" />
                            <asp:BoundField DataField="Name" HeaderText="Description" />
                            <asp:BoundField DataField="Output" HeaderText="Output" />
                        </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelPhoto" runat="server" Width="400" Height="400" style="background:#FFFFFF; float:right; padding-left:10px; 
        border-right: 4px yellowGreen solid; border-top: 4px yellowGreen solid; border-bottom: 4px yellowGreen solid; z-index: 5; position: absolute; 
        margin-left:300px; margin-top:80px;" BackColor="White" BorderColor="Green" BorderStyle="Solid" BorderWidth="2" >

        <asp:GridView ID="GridViewPhoto" runat="server" 
                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                        CssClass="GridViewStyle" GridLines="None" >
                        <Columns>
                            <asp:BoundField DataField="Input" HeaderText="Input" />
                            <asp:BoundField DataField="Name" HeaderText="Description" />
                            <asp:BoundField DataField="Output" HeaderText="Output" />
                        </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelPost" runat="server" Width="400" Height="200" style="background:#FFFFFF; float:right; padding-left:10px; 
        border-right: 4px yellowGreen solid; border-top: 4px yellowGreen solid; border-bottom: 4px yellowGreen solid; z-index: 5; position: absolute; 
        margin-left:300px; margin-top:160px;" BackColor="White" BorderColor="Green" BorderStyle="Solid" BorderWidth="2" >

        <asp:GridView ID="GridViewPost" runat="server" 
                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                        CssClass="GridViewStyle" GridLines="None" >
                        <Columns>
                            <asp:BoundField DataField="Input" HeaderText="Input" />
                            <asp:BoundField DataField="Name" HeaderText="Description" />
                            <asp:BoundField DataField="Output" HeaderText="Output" />
                        </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelVideo" runat="server" Width="400" Height="200" style="background:#FFFFFF; float:right; padding-left:10px; 
        border-right: 4px yellowGreen solid; border-top: 4px yellowGreen solid; border-bottom: 4px yellowGreen solid; z-index: 5; position: absolute; 
        margin-left:300px; margin-top:240px;" BackColor="White" BorderColor="Green" BorderStyle="Solid" BorderWidth="2" >

        <asp:GridView ID="GridViewVideo" runat="server" 
                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                        CssClass="GridViewStyle" GridLines="None" >
                        <Columns>
                            <asp:BoundField DataField="Input" HeaderText="Input" />
                            <asp:BoundField DataField="Name" HeaderText="Description" />
                            <asp:BoundField DataField="Output" HeaderText="Output" />
                        </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelLike" runat="server" Width="400" Height="200" style="background:#FFFFFF; float:right; padding-left:10px; 
        border-right: 4px yellowGreen solid; border-top: 4px yellowGreen solid; border-bottom: 4px yellowGreen solid; z-index: 5; position: absolute; 
        margin-left:550px; margin-top:0px;" BackColor="White" BorderColor="Green" BorderStyle="Solid" BorderWidth="2" >

        <asp:GridView ID="GridViewLike" runat="server" 
                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                        CssClass="GridViewStyle" GridLines="None" >
                        <Columns>
                            <asp:BoundField DataField="Input" HeaderText="Input" />
                            <asp:BoundField DataField="Name" HeaderText="Description" />
                            <asp:BoundField DataField="Output" HeaderText="Output" />
                        </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelComment" runat="server" Width="400" Height="300" style="background:#FFFFFF; float:right; padding-left:10px; 
        border-right: 4px yellowGreen solid; border-top: 4px yellowGreen solid; border-bottom: 4px yellowGreen solid; z-index: 5; position: absolute; 
        margin-left:550px; margin-top:200px;" BackColor="White" BorderColor="Green" BorderStyle="Solid" BorderWidth="2">

        <asp:GridView ID="GridViewComment" runat="server" 
                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                        CssClass="GridViewStyle" GridLines="None" >
                        <Columns>
                            <asp:BoundField DataField="Input" HeaderText="Input" />
                            <asp:BoundField DataField="Name" HeaderText="Description" />
                            <asp:BoundField DataField="Output" HeaderText="Output" />
                        </Columns>
                    <RowStyle CssClass="RowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
    </asp:Panel>
    <div class="row" style="height:50px; margin-top:10px; margin-left:20px;">
            <legend>DESIGN A SIMPLE SOCIAL NETWORK FLOW</legend>
         <%--<asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>--%>
    </div>
    <div class="row" style="height:40px;">
        <%--col 1--%>
        <div class="span2 offset2">
            <div class="row" style="height:40px;">
                <div class="span2">
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                    <asp:Button CssClass="btn btn-info" ToolTip="This data object represents the current user. The one that installed the application and that is running the process." Style="font-weight:bold;" 
                    ID="ButtonUser" runat="server" Text="User" Width="120" Height="40" UseSubmitBehavior="False" OnClientClick="return false;" />
                </div>
            </div>
            <div class="row" style="height:120px;">
                <div class="span2">
                    <asp:Image ID="Image3" runat="server" Style="margin-left:60px; margin-top:5px;" Height="110" 
                        ImageUrl="~/Images/Data Model Column 1.png" />
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                    <asp:Button CssClass="btn btn-info" ToolTip="This data object represents the friends or contacts of the current user in the social network." Style="font-weight:bold;" 
                    ID="ButtonFriend" runat="server" Text="Friends" Width="120" Height="40" UseSubmitBehavior="False" OnClientClick="return false;" />
                </div>
            </div>
            <div class="row" style="height:280px;">
                <div class="span2">
                </div>
            </div>
        </div>
        <%--col 2--%>
        <div class="span2">
            <div class="row" style="height:40px;">
                <div class="span2">
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl="~/Images/Data Model Column 2.png" />
                </div>
            </div>
        </div>
        <%--col 3--%>
        <div class="span2">
            <div class="row" style="height:40px;">
                <div class="span2">
                    <asp:Button CssClass="btn btn-info" ToolTip="This data object represents the Albums of a user. Albums can contain photos and videos." Style="font-weight:bold;" 
                    ID="ButtonAlbum" runat="server" Text="Albums" Width="120" Height="40" UseSubmitBehavior="False" OnClientClick="return false;" />
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                    <asp:Button CssClass="btn btn-info" ToolTip="This data object represents the photos of a user." Style="font-weight:bold;" 
                    ID="ButtonPhoto" runat="server" Text="Photos" Width="120" Height="40" UseSubmitBehavior="False" OnClientClick="return false;" />
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                    <asp:Button CssClass="btn btn-info" ToolTip="This data object represents the message posts of a user. A post could contain a photo, a video or a link." Style="font-weight:bold;" 
                    ID="ButtonPost" runat="server" Text="Posts" Width="120" Height="40" UseSubmitBehavior="False" OnClientClick="return false;" />
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                    <asp:Button CssClass="btn btn-info" ToolTip="This data object represents the videos of a user." Style="font-weight:bold;" 
                    ID="ButtonVideo" runat="server" Text="Videos" Width="120" Height="40" UseSubmitBehavior="False" OnClientClick="return false;" />
                </div>
            </div>
        </div>
        <%--col 4--%>
        <div class="span2">
            <div class="row" style="height:40px;">
                <div class="span2">
                    <asp:Image ID="Image2" runat="server" 
                        ImageUrl="~/Images/Data Model Column 4.png" />
                </div>
            </div>
        </div>
        <%--col 5--%>
        <div class="span2">
            <div class="row" style="height:40px;">
                <div class="span2">
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                    <asp:Button CssClass="btn btn-info" ToolTip="This data object represents the likes that an object has. If a user likes an object it means that it is relevant for him." Style="font-weight:bold;" 
                    ID="ButtonLike" runat="server" Text="Likes" Width="120" Height="40" UseSubmitBehavior="False" OnClientClick="return false;" />
                </div>
            </div>
            <div class="row" style="height:120px;">
                <div class="span2">
                    <asp:Image ID="Image4" runat="server" Style="margin-left:60px;" Height="110" 
                        ImageUrl="~/Images/Data Model Column 5.png" />
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                    <asp:Button CssClass="btn btn-info" ToolTip="This data object represents the comments that an object has." Style="font-weight:bold;" 
                    ID="ButtonComment" runat="server" Text="Comments" Width="120" Height="40" UseSubmitBehavior="False" OnClientClick="return false;" />
                </div>
            </div>
            <div class="row" style="height:40px;">
                <div class="span2">
                </div>
            </div>
        </div>
    </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var panel = $("#PanelUser");
            panel.hide();
            $("#ButtonUser").click(function () {
                panel.fadeToggle(700);
            });
            panel.click(function () {
                panel.fadeToggle(700);
            });

            var panelFriend = $("#PanelFriend");
            panelFriend.hide();
            $("#ButtonFriend").click(function () {
                panelFriend.fadeToggle(700);
            });
            panelFriend.click(function () {
                panelFriend.fadeToggle(700);
            });

            var PanelAlbum = $("#PanelAlbum");
            PanelAlbum.hide();
            $("#ButtonAlbum").click(function () {
                PanelAlbum.fadeToggle(700);
            });
            PanelAlbum.click(function () {
                PanelAlbum.fadeToggle(700);
            });

            var PanelPhoto = $("#PanelPhoto");
            PanelPhoto.hide();
            $("#ButtonPhoto").click(function () {
                PanelPhoto.fadeToggle(700);
            });
            PanelPhoto.click(function () {
                PanelPhoto.fadeToggle(700);
            });

            var PanelPost = $("#PanelPost");
            PanelPost.hide();
            $("#ButtonPost").click(function () {
                PanelPost.fadeToggle(700);
            });
            PanelPost.click(function () {
                PanelPost.fadeToggle(700);
            });

            var PanelVideo = $("#PanelVideo");
            PanelVideo.hide();
            $("#ButtonVideo").click(function () {
                PanelVideo.fadeToggle(700);
            });
            PanelVideo.click(function () {
                PanelVideo.fadeToggle(700);
            });

            var PanelLike = $("#PanelLike");
            PanelLike.hide();
            $("#ButtonLike").click(function () {
                PanelLike.fadeToggle(700);
            });
            PanelLike.click(function () {
                PanelLike.fadeToggle(700);
            });

            var PanelComment = $("#PanelComment");
            PanelComment.hide();
            $("#ButtonComment").click(function () {
                PanelComment.fadeToggle(700);
            });
            PanelComment.click(function () {
                PanelComment.fadeToggle(700);
            });
        });
    </script>
</body>
</html>
