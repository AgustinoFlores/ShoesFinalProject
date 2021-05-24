<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="PurchaseConfirm.aspx.cs" Inherits="ShoesProject.Forms.PurchaseConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Your purchase was successful!" Font-Bold="False" Font-Names="Roboto" Font-Size="Larger"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Total Cost:"></asp:Label>
    <asp:Label ID="FinalCost" runat="server" Font-Bold="True" Font-Names="Raleway" Font-Size="Medium" ForeColor="#1B5E20"></asp:Label>
</asp:Content>
