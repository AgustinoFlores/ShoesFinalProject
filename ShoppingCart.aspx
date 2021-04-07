<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ShoesProject.ShoppingCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            display: flex;
            margin: 20px auto;
            max-width: 100%;
        }

        .auto-style1 > div{
            border: 1px dashed gray;
            flex: 1 1 auto; /* Size of items defined inside items */
            padding: 20px;
        }

        .auto-style1 > div:nth-child(1){
            flex-grow: 2;
        }
        
        .auto-style1 > div:nth-child(2){
            text-align: center;
        }
        .auto-style2 {
            width: 499px;
            height: 70px;
            border: 1px solid #707070;
            border-radius: 5px;
            display: flex;
        }

        .auto-style2 > div{
            flex: 1 1 auto;
        }

        .auto-style2 > div:nth-child(2){
            flex: 2 1 auto;
        }


        .auto-style3 {
            padding: 0px 10px 0px 10px;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Raleway" Font-Size="XX-Large" Text="Shoes"></asp:Label>
        <br />
        <br />
        <div class="auto-style1">
                <div>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Raleway" Font-Size="Large" Text="Shopping Cart"></asp:Label>
                    <div class="auto-style2">
                        <div>
                            <asp:Image ID="Image1" runat="server" CssClass="auto-style3" Height="78px" ImageUrl="~/images/shoe.png" Width="77px" />
                        </div>
                        <div>

                            <asp:Label ID="Label4" runat="server" Font-Names="Roboto" Font-Size="Medium" ForeColor="#3E50F6" Text="Air VaporMax 2020 Flyknit"></asp:Label>
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Roboto" Font-Size="Small" ForeColor="#000000" Text="Nike"></asp:Label>
                        </div>
                    </div>
                </div>
                <div>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Raleway" Font-Size="Large" Text="Shipping Address"></asp:Label>
                </div>
            
        </div>
    </form>
</body>
</html>
