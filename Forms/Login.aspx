<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoesProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function swapPage(appear, disappear) {
            var pageShow = document.getElementById(appear);
            var pageHide = document.getElementById(disappear);

            pageHide.style.display = "none";
            pageShow.style.display = "block";
        }
    </script>
    <style type="text/css">
        .auto-style1 {float: left; width: 50%;}
        .floatingDiv{float: right; width: 50%; text-align: center}
        #Login1 {text-align: center}
        #Login2 {text-align: center}
        #signupForm {opacity: 0}
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <asp:Image ID="Image1" runat="server" CssClass="auto-style1" Height="653px" ImageUrl="~/images/loginshoe.png" Width="742px" />
            <div class = "floatingDiv" id ="loginForm">
                <asp:Label ID="TitleLabel" runat="server" Font-Bold="True" Font-Names="Roboto" Font-Size="XX-Large" Text="SIGN IN"></asp:Label>
                <br />
                <asp:Login ID="Login1" runat="server" TitleText="" OnAuthenticate="Login1_Authenticate" Width="636px">
                </asp:Login>
                <asp:CreateUserWizard ID="SignUpForm" runat="server" CreateUserButtonText="Submit" Width="636px"  QuestionLabelText="Security Question" OnCreatingUser="SignUpForm_CreatingUser" style="display:none">
                    <WizardSteps>
                        <asp:CreateUserWizardStep runat="server" />
                        <asp:CompleteWizardStep runat="server" />
                    </WizardSteps>
                </asp:CreateUserWizard>
                <br />
                <asp:Button ID="PageSwap" runat="server" Text="Sign Up!" OnClick="PageSwap_Click" />
            </div>
    </form>
</body>
</html>
