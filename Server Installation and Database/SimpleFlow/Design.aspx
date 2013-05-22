<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Design.aspx.cs" Inherits="SimpleFlow.Design" %>

<%--<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>--%>

<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="Styles/DataGridCss2.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function textVisibility() {
        document.getElementById('<%= TextBoxAppMsg.ClientID %>').style.visibility = "visible";
        document.getElementById('<%= LabelAppMsg.ClientID %>').style.visibility = "visible";

        var radioButtonlist = document.getElementsByName('<%= RadioButtonListPostMessage.ClientID %>');
        for (var x = 0; x < radioButtonlist.length; x++) {
            if (radioButtonlist[x].value == "OnlyUsrMsg" && radioButtonlist[x].checked) {
                document.getElementById('<%= TextBoxAppMsg.ClientID %>').style.visibility = "hidden";
                document.getElementById('<%= LabelAppMsg.ClientID %>').style.visibility = "hidden";
            }
        }
    }

    function textVisibilityComment() {
        document.getElementById('<%= TextBoxAppCom.ClientID %>').style.visibility = "visible";
        document.getElementById('<%= LabelAppCom.ClientID %>').style.visibility = "visible";

        document.getElementById('<%= TextBoxOption.ClientID %>').style.visibility = "hidden";
        document.getElementById('<%= LabelOption.ClientID %>').style.visibility = "hidden";
        document.getElementById('<%= ButtonOption.ClientID %>').style.visibility = "hidden";
        document.getElementById('<%= GridViewOptions.ClientID %>').style.display = 'none';
        var radioButtonlistCom = document.getElementsByName('<%= RadioButtonListPostComment.ClientID %>');
        for (var x = 0; x < radioButtonlistCom.length; x++) {
            if (radioButtonlistCom[x].value == "MultOptCom" && radioButtonlistCom[x].checked) {
                document.getElementById('<%= TextBoxAppCom.ClientID %>').style.visibility = "hidden";
                document.getElementById('<%= LabelAppCom.ClientID %>').style.visibility = "hidden";

                document.getElementById('<%= TextBoxOption.ClientID %>').style.visibility = "visible";
                document.getElementById('<%= LabelOption.ClientID %>').style.visibility = "visible";
                document.getElementById('<%= ButtonOption.ClientID %>').style.visibility = "visible";
                document.getElementById('<%= GridViewOptions.ClientID %>').style.display = 'block';
            }
            if (radioButtonlistCom[x].value == "OnlyUsrCom" && radioButtonlistCom[x].checked) {
                document.getElementById('<%= TextBoxAppCom.ClientID %>').style.visibility = "hidden";
                document.getElementById('<%= LabelAppCom.ClientID %>').style.visibility = "hidden";
            }
        }
    }

    function OnloadControl() {
        textVisibility();
        textVisibilityComment();
    }

    function ShowTooltip() {
        if (document.getElementById('<%= Panel1.ClientID %>').style.visibility == "hidden") {
            document.getElementById('<%= Panel1.ClientID %>').style.visibility = "visible";
        } else {
            document.getElementById('<%= Panel1.ClientID %>').style.visibility = "hidden";
        }
    }
    </script>
    <title>Simple Flow</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="400" Height="200" style="background:#FFFFFF; float:right; padding-left:10px; border-right: 4px yellowGreen solid; border-top: 4px yellowGreen solid; border-bottom: 4px yellowGreen solid; z-index: 5; position: absolute;" 
        BackColor="White" BorderColor="Green" BorderStyle="Solid" BorderWidth="2" >
            <asp:Label ID="LabelUseCaseTooltip" runat="server" Text="" style="padding-top:10px; padding-bottom:10px; padding-left:10px; padding-right:10px;"></asp:Label>
    </asp:Panel>
    <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>--%>
    <div class="row" style="height:50px; margin-top:10px; margin-left:20px;">
            <legend>DESIGN A SIMPLE SOCIAL NETWORK FLOW</legend>
         <%--<asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>--%>
    </div>
    <div class="row" style="height:40px;">
        <div class="span2">
            <asp:Button CssClass="btn btn-info" Style="font-weight:bold;" 
            ID="ButtonReset" runat="server" Text="Reset Flow" Width="120" 
                onclick="ButtonReset_Click"/>
        </div>
        <div class="span2">
            <asp:Button CssClass="btn btn-info" Style="font-weight:bold;" 
            ID="ButtonUndo" runat="server" Text="Undo Action" Width="120" 
                onclick="ButtonUndo_Click"/>
        </div>
        <div class="span2">
            <asp:Button CssClass="btn btn-info" Style="font-weight:bold;" 
            ID="ButtonSave" runat="server" Text="Save Flow" Width="120" 
            onclick="ButtonSave_Click" ValidationGroup="SaveFlow"/>
        </div>
        <div class="span2">
            <asp:Button CssClass="btn btn-danger" Style="font-weight:bold;" 
            ID="ButtonPlay" runat="server" Text="Execute Flow" Width="120" 
            onclick="ButtonPlay_Click" ValidationGroup="SaveFlow"/>
        </div>
        <%--<div class="span2 offset1">
            <asp:Button CssClass="btn btn-info" Style="font-weight:bold;" 
            ID="ButtonUseCase" runat="server" Text="New Use Case" Width="120" 
                onclick="ButtonUseCase_Click"/>
        </div>
        <div class="span2">
            <asp:Button CssClass="btn btn-info" Style="font-weight:bold;" 
            ID="ButtonQuestionnaire" runat="server" Text="Questionnaire" Width="120" 
                onclick="ButtonQuestionnaire_Click"/>
        </div>--%>
    </div>
    <div class="row" style="height:60px;" >
        <%--<div class="span2">
            <asp:Button CssClass="btn btn-info" Style="font-weight:bold;" 
            ID="Button2" runat="server" Text="Use Case Info" Width="120" 
            CausesValidation="False" UseSubmitBehavior="False" OnClientClick="return false;" />
        </div>--%>
        <div class="span2">
            <asp:Button CssClass="btn btn-info" Style="font-weight:bold;" 
            ID="ButtonRight" runat="server" Text="Show Imports" Width="120" 
                onclick="ButtonRight_Click"/>
        </div>
        <div class="offset1 span5" style="text-align:center;" >
            <asp:Label ID="Label1" runat="server" Text="FLOW NAME: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div class="span1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Please give a name to this flow" Display="None"
                ControlToValidate="TextBox1" ValidationGroup="SaveFlow"></asp:RequiredFieldValidator>
        </div>
        <div class="span3">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                HeaderText="Attention!" ShowMessageBox="True" ValidationGroup="SaveFlow"/>
        </div>
        
    </div>
    <div class="row" style="margin-left:20px;">
        <div class="span4">
            <%--        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                <div class="row">
                        <legend>Available Actions</legend>
                </div>
                <div class="row" style="margin-top:-30px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SimpleFlowDS" DataKeyNames="ActionId" 
                    EnableModelValidation="True" GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ActionId" HeaderText="ActionId" ReadOnly="True" 
                                SortExpression="ActionId" visible="false"/>
                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="400" >
                                <ItemTemplate>
                                    <%--<asp:Image ID="imgID" runat="server" ToolTip='<%# BIND("ActionType") %>' Width="30" Height="30" />--%>
                                    <asp:Button CssClass="btn btn-primary" Style="font-weight:bold;" ID="Button1" runat="server" CausesValidation="True" 
                                        CommandName="Select" Text='<%# BIND("ActionName") %>' CommandArgument='<%# BIND("ActionType") %>' 
                                        ValidationGroup="SelectInput" Tooltip='<%# BIND("ActionDescription") %>' Width="300"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:EntityDataSource ID="SimpleFlowDS" runat="server" 
                        ConnectionString="name=SimpleFlowEntities" 
                        DefaultContainerName="SimpleFlowEntities" EntitySetName="Actions" 
                        Select="it.[ActionName], it.[ActionId], it.[ActionDescription], it.[ActionType], it.[ActionPosition]"
                         OrderBy="it.[ActionPosition]" >
                    </asp:EntityDataSource>
                </div>
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
        <div class="span6">
            <div class="row" style="text-align:center;">
                    <legend>Flow Actions</legend>
            </div>
            <div class="row">
            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
                    <asp:GridView ID="GridView2" runat="server" EnableModelValidation="True" 
                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                        CssClass="GridViewStyle" GridLines="None" 
                        onrowdatabound="GridView2_RowDataBound" 
                        onrowcommand="GridView2_RowCommand" >
                        <Columns>
                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="100" >
                                <ItemTemplate>
                                    <asp:RegularExpressionValidator ID="REInputValidator" Width="140" runat="server" 
                                        ErrorMessage="Select an item from the Output to fill the [???]" ControlToValidate="ActionName" 
                                        ValidationGroup="SelectInput" ValidationExpression="^((?!\[\?\?\?\]).)*$"></asp:RegularExpressionValidator>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Step" HeaderText="Step" >
                            <HeaderStyle CssClass="HeaderStyle" ForeColor="White" />
                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Name" ItemStyle-Width="300" >
                                <ItemTemplate>
                                    <asp:Textbox ID="ActionName" ReadOnly="true" runat="server" TextMode="MultiLine" 
                                     Rows="2" CausesValidation="true" Text='<%# BIND("Name") %>' 
                                     Width="150" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="HeaderStyle" ForeColor="White" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="100"/>--%>
                            <asp:TemplateField ShowHeader="False" HeaderText="Output" ItemStyle-Width="100" >
                                <ItemTemplate>
                                    <asp:Button CssClass="btn" Style="font-weight:bold;" ID="OutputAction" runat="server" CausesValidation="False" 
                                        CommandName="Select" Text='<%# BIND("Output") %>' Width="90"/>
                                        
                                </ItemTemplate>
                                <HeaderStyle CssClass="HeaderStyle" ForeColor="White" />
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <%--<EditRowStyle CssClass="EditRowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />--%>
                    <%--<HeaderStyle CssClass="HeaderStyle" />--%>
                    <%--<PagerStyle CssClass="PagerStyle" />--%>
                    <RowStyle CssClass="RowStyle" />
                    <%--<SelectedRowStyle CssClass="SelectedRowStyle" />--%>
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
            </div>
        </div>
        <div class="span3" style=" border-left-style:inset; padding-left:10px;">
        <asp:MultiView ID="MultiViewRight" runat="server">
            <asp:View ID="ViewOptions" runat="server">
            <asp:MultiView ID="MultiViewGeneral" runat="server">
                <asp:View ID="ViewGeneral" runat="server">
                    <div class="row">
                        <div class="span3" style="text-align:left;">
                            <legend>Action Options</legend>
                        </div>
                    </div>
                    <div class="row">
                        <div class="span3" style="text-align:left;">
                            <asp:Label ID="LabelTitle" runat="server" Text="Action Title: "></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="span3">
                            <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="span3" style="text-align:left;">
                            <asp:Label ID="LabelDescription" runat="server" Text="Action Description: "></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="span3">
                            <asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox>
                        </div>
                    </div>
        
                </asp:View>
            </asp:MultiView>
            <asp:MultiView ID="MultiViewSpecific" runat="server">
                <asp:View ID="ViewUserProfile" runat="server">
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxName" Text="Name" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxPicture" Text="Picture" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxGender" Text="Gender" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxLocation" Text="Location" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxBirthday" Text="Birthday" runat="server" /><br />
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="ViewPostMessage" runat="server">
                    <div class="row">
                        <div class="span3">
                            <asp:Label ID="LabelMsgOpt" runat="server" Text="Messages specified:" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="span4">
                            <asp:RadioButtonList ID="RadioButtonListPostMessage" runat="server" 
                                 onclick="textVisibility();">
                                <asp:ListItem Value="OnlyAppMsg">By the app</asp:ListItem>
                                <asp:ListItem Value="OnlyUsrMsg">By the user</asp:ListItem>
                                <asp:ListItem Value="AppUsrMsg">First part by the app and last part by the user</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="span3">
                            <asp:Label ID="LabelAppMsg" runat="server" Text="Application Message"></asp:Label>
                            <asp:TextBox ID="TextBoxAppMsg" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="ViewSelectX" runat="server">
                    Select the number of items that will be selected/voted
                    <asp:DropDownList ID="DropDownListX" runat="server">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:DropDownList>
                </asp:View>
                <asp:View ID="ViewPostComment" runat="server">
                    <div class="row">
                        <div class="span3">
                            <asp:Label ID="LabelComOpt" runat="server" Text="Messages specified:" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="span4">
                            <asp:RadioButtonList ID="RadioButtonListPostComment" TextAlign="Right" 
                                runat="server" CausesValidation="true" 
                                 onclick="textVisibilityComment();" RepeatColumns="2" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="OnlyAppCom">By the app</asp:ListItem>
                                <asp:ListItem Value="OnlyUsrCom">By the user</asp:ListItem>
                                <asp:ListItem Value="AppUsrCom">First part by the app and last part by the user</asp:ListItem>
                                <asp:ListItem Value="MultOptCom">Multiple choice specified by the app</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row" style="position:relative;">
                        <div class="row" style="position:relative; left:20px;">
                            <div class="span3">
                                <asp:Label ID="LabelAppCom" runat="server" Text="Application Message" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="TextBoxAppCom" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="position:absolute; top:0px; left:40px; z-index:10;">
                            <div class="row">
                                <div class="span3">
                                    <asp:Label ID="LabelOption" runat="server" Text="Write option" Font-Bold="true"></asp:Label>
                                    <asp:TextBox ID="TextBoxOption" runat="server" CausesValidation="True"></asp:TextBox><br />
                                    <asp:Button ID="ButtonOption" runat="server" Text="Add option" 
                                        onclick="ButtonOption_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="span3">
                                    <asp:GridView ID="GridViewOptions" runat="server" EnableModelValidation="True" 
                                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                                        CssClass="GridViewStyle" GridLines="None"  
                                        OnRowCommand="GridViewOptions_RowCommand" 
                                        onrowdeleting="GridViewOptions_RowDeleting" >
                                        <Columns>
                                            <asp:BoundField DataField="Option" HeaderText="Comment Option" />
                                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                                        </Columns>
                                        <EditRowStyle CssClass="EditRowStyle" />
                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                        <HeaderStyle CssClass="HeaderStyle" />
                                        <PagerStyle CssClass="PagerStyle" />
                                        <RowStyle CssClass="RowStyle" />
                                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="AltRowStyle" />
                                    </asp:GridView>
                                    <asp:CustomValidator ID="validateOptions" runat="server" ValidationGroup="SelectInput" 
                                       ControlToValidate="RadioButtonListPostComment"  
                                        ErrorMessage=" Please add at least 2 Comment Options" 
                                        onservervalidate="validateOptions_ServerValidate" ></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--<div class="row">
                        <div class="span3">
                            <asp:Label ID="LabelObjCom" runat="server" Text="URL of the item to comment"></asp:Label>
                            <asp:TextBox ID="TextBoxObjCom" runat="server"></asp:TextBox>
                        </div>
                    </div>--%>
                </asp:View>
                <asp:View ID="ViewPostPhotoFromAlbum" runat="server">
                    <%--<div class="row">
                        <div class="span3">
                            <asp:Label ID="LabelAlbum" runat="server" Text="Album URL"></asp:Label>
                            <asp:TextBox ID="TextBoxAlbum" runat="server" ></asp:TextBox>
                        </div>
                    </div>--%>
                </asp:View>
                <asp:View ID="ViewPhotoProfile" runat="server">
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxPhoto" Text="Photo" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxPhotoDesc" Text="Description" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxPhotoOwner" Text="Owner" runat="server" />
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="ViewLikeObject" runat="server">
                    <%--<div class="row">
                        <div class="span3">
                            <asp:Label ID="LabelObjUrl" runat="server" Text="URL of the item to like"></asp:Label>
                            <asp:TextBox ID="TextBoxObjUrl" runat="server" ></asp:TextBox>
                        </div>
                    </div>--%>
                </asp:View>
                <asp:View ID="ViewTagPhoto" runat="server">
                    <%--<div class="row">
                        <div class="span3">
                            <asp:Label ID="LabelPhotoUrl" runat="server" Text="URL of the photo to tag"></asp:Label>
                            <asp:TextBox ID="TextBoxPhotoUrl" runat="server" ></asp:TextBox>
                        </div>
                    </div>--%>
                    <%--
                    <div class="row">
                        <div class="span3">
                            <asp:Label ID="LabelPhotoTag" runat="server" Text="Write a Tag for the Photo"></asp:Label>
                            <asp:TextBox ID="TextBoxPhotoTag" runat="server" ></asp:TextBox>
                        </div>
                    </div>--%>
                </asp:View>
                <asp:View ID="ViewAlbumProfile" runat="server">
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxAlbumTitle" Text="Title" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxAlbumDesc" Text="Description" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxAlbumPhoto" Text="Cover Photo" runat="server" />
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="ViewGetComments" runat="server">
                    <%--<div class="row">
                        <div class="span3">
                            <asp:Label ID="LabelComObj" runat="server" Text="URL of the item to retrieve comments"></asp:Label>
                            <asp:TextBox ID="TextBoxComObj" runat="server" ></asp:TextBox>
                        </div>
                    </div>--%>
                </asp:View>
                <asp:View ID="ViewCommentProfile" runat="server">
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxComment" Text="Comment" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxCommentUser" Text="User" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="span2">
                            <asp:CheckBox ID="CheckBoxCommentLikes" Text="Number of Likes" runat="server" />
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
            </asp:View>
            <asp:View ID="ViewImports" runat="server">
            <div class="row">
                <div class="span3">
                    <Legend>Import Objects</Legend>
                </div>
            </div>
            <div class="row">
                <div class="span3">
                    <asp:DropDownList ID="DropDownListObjType" runat="server">
                        <asp:ListItem Value="ALBUM">ALBUM</asp:ListItem>
                        <asp:ListItem Value="PHOTO">PHOTO</asp:ListItem>
                        <asp:ListItem Value="VIDEO">VIDEO</asp:ListItem>
                        <asp:ListItem Value="POST">POST</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="LabelObject" runat="server" Text="Write the object URL" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="TextBoxObject" runat="server" CausesValidation="True"></asp:TextBox><br />
                    <asp:Button ID="ButtonObject" runat="server" Text="Add object"
                        onclick="ButtonObject_Click" />
                </div>
            </div>
            <div class="row">
                <div class="span3">
                    <asp:GridView ID="GridViewImports" runat="server" 
                        AutoGenerateColumns="False" HorizontalAlign="Center" 
                        CssClass="GridViewStyle" GridLines="None" 
                        onrowcommand="GridViewImports_RowCommand" 
                        onrowdatabound="GridViewImports_RowDataBound" >
                        <Columns>
                            <asp:BoundField DataField="objectPosition" HeaderText="#" />
                            <asp:TemplateField ShowHeader="False" HeaderText="Import" ItemStyle-Width="100" >
                                <ItemTemplate>
                                    <asp:Button CssClass="btn" Style="font-weight:bold;" ID="ImportObject" runat="server" CausesValidation="False" 
                                        CommandName="Select" Text='<%# BIND("objectType") %>' Width="90"/>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </div>
            </div>
            </asp:View>
        </asp:MultiView>
        </div>        
    </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var panel = $("#Panel1");
            panel.hide();
            $("#Button2").click(function () {
                panel.fadeToggle(700);
            });
            panel.click(function () {
                panel.fadeToggle(700);
            });
        });
    </script>
</body>
</html>
