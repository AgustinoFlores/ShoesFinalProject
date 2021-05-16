<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="ShoesProject.Homepage" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #topHeader:last-child{
            float: right;
        }
        #TextBox1{
            border-radius: 5px;
        }

        #Image1{
            cursor: pointer;

        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        
    <div id="topMenu">
        <asp:Image ID="Image1" runat="server" Height="161px" ImageUrl="~/images/logo.png" Width="210px" />
        <asp:TextBox ID="TextBox1" runat="server" BorderStyle="Solid"></asp:TextBox>
        <asp:Label ID="WelcomeMessage" runat="server" Font-Names="Roboto"></asp:Label>
        <asp:ImageButton ID="CartBtn" runat="server" ImageUrl="~/images/Icon feather-shopping-cart.png" OnClick="CartBtn_Click" />
    </div>
    
    <asp:Label ID="Categories" runat="server" Font-Bold="True" Font-Names="Roboto" Font-Size="X-Large" Text="SNEAKERS"></asp:Label>
    
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="product_id" DataSourceID="SqlDataSource1" GroupItemCount="5" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
            <ItemTemplate>
                <td runat="server" style="padding:10px;">
                    <asp:LinkButton ID="SelectButton" runat="server" CommandName="Select">
                        <img src = "../images/Products/<%#Eval("image") %>" height="100"/><br />
                        <h4 style="color: black"><%#Eval("product_name") %></h4>
                        <div style="color: black">$<%#Eval("price") %></div>
                    </asp:LinkButton>
                </td>
            </ItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="groupPlaceholderContainer" runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-style:none;cursor:pointer">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Shoes_DBConnectionString %>" SelectCommand="SELECT * FROM [Products]"></asp:SqlDataSource>
    
    </form>
</body>
</html>
