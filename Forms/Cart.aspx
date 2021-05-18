<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ShoesProject.Forms.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            display: flex;
            margin: 20px auto;
            max-width: 100%;
        }

        .auto-style1 > div{
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Raleway" Font-Size="XX-Large" Text="Shoes"></asp:Label>
        <br />
        <br />
        <div class="auto-style1">
                <div>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Raleway" Font-Size="Large" Text="Shopping Cart"></asp:Label>
                    
                    <asp:ListView ID="ListView1" runat="server" DataKeyNames="product_id" DataSourceID="SqlDataSource1" GroupItemCount="1" OnItemCommand="ListView1_ItemCommand">
                        <ItemTemplate>
                            <td runat="server" style="padding:10px;" class="auto-style2">
                                <div>
                                    <img src = "../images/Products/<%#Eval("image") %>" height="65"/><br />
                                </div>
                                <div>

                                    <asp:Label ID="ProdName" runat="server" Font-Names="Roboto" Font-Size="Medium" ForeColor="#3E50F6"><%#Eval("product_name") %></asp:Label>
                                     <asp:LinkButton ID="Remove" runat="server" Font-Names="Roboto" Font-Size="X-Small" ForeColor="#000000" CommandName="RemoveItem" CommandArgument='<%# Eval("cart_id") + "," + Container.DataItemIndex %>'>REMOVE</asp:LinkButton>
                                </div>
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Shoes_DBConnectionString %>">
                        <SelectParameters>
                            <asp:Parameter Name ="userid" />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="cart_id" />
                        </DeleteParameters>
                    </asp:SqlDataSource>

                </div>
                <div>
                    <div>
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Raleway" Font-Size="Large" Text="Shipping Address"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Raleway" Font-Size="Large" Text="Payment Method"></asp:Label>
                    </div>
                </div>
            
        </div>
</asp:Content>
