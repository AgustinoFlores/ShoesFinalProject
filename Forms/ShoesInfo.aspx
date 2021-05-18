<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="ShoesInfo.aspx.cs" Inherits="ShoesProject.Forms.ShoesInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
      
        <asp:Label ID="ShoeName" runat="server"></asp:Label>
        <br />
        <asp:Image ID="ShoeImage" runat="server" Height="100px" />
        <asp:Button ID="AddCart" runat="server" OnClick="AddCart_Click" Text="Add To Cart" />
        <asp:Label ID="CartMsg" runat="server"></asp:Label>
        <br />
        <asp:Label ID="ShoeDesc" runat="server"></asp:Label>
    </div>
</asp:Content>