<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="ShoesProject.Forms.Store" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Label ID="Categories" runat="server" Text="SNEAKERS"></asp:Label>
    
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
    
</asp:Content>
