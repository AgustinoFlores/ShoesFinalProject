<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoesProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {float: left; width: 50%;}
        .floatingDiv{float: right; width: 50%; text-align: center}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" CssClass="auto-style1" Height="653px" ImageUrl="~/images/loginshoe.png" Width="742px" />
            <div class = "floatingDiv">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Roboto" Font-Size="XX-Large" Text="SIGN IN"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Font-Names="Roboto" Text="Username"></asp:Label>
                <br />
                <asp:TextBox ID="userBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Font-Names="Roboto" Text="Password"></asp:Label>
                <br />
                <asp:TextBox ID="pwordBox" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="LOG IN" Width="128px" OnClick="Button1_Click" />
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" Text="Sign Up!" />
            </div>
        </div>
    </form>
</body>
</html>
