<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayout.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ShoesProject.Forms.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <script type="text/javascript">
        function showHolder() {
            var holder = document.getElementById("<%=AddressHolder.ClientID %>");
            var addressBtn = document.getElementById("<%=AddressBtn.ClientID %>");
            holder.style.display = "block";
            addressBtn.style.display = "none";

            return false;
        }

        function finishSubmit() {
            var holder = document.getElementById("<%=AddressHolder.ClientID %>");
            var addressBtn = document.getElementById("<%=AddressBtn.ClientID %>");
            holder.style.display = "none";
            addressBtn.style.display = "block";
        }

        function showPayment() {
            var paymentBtn = document.getElementById("<%=Payment.ClientID %>");
            var paymentHolder = document.getElementById("<%=PaymentHolder.ClientID %>");
            paymentHolder.style.display = "block";
            paymentBtn.style.display = "none";

            return false;
        }

        function finishPayment() {
            var paymentBtn = document.getElementById("<%=Payment.ClientID %>");
            var paymentHolder = document.getElementById("<%=PaymentHolder.ClientID %>");
            paymentHolder.style.display = "none";
            paymentBtn.style.display = "block";
        }

    </script>
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


        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                    <br />
                                    <asp:Label ID="Label13" runat="server" Text="Quantity: "></asp:Label>
                                    <asp:Label ID="ProdQuantity" runat="server" Font-Names="Roboto" Font-Size="Small" Text='<%# Eval("quantity") %>'></asp:Label>
                                    <asp:Label ID="Label14" runat="server" Text="$"></asp:Label>
                                    <asp:Label ID="Price" runat="server" Font-Names="Roboto" Font-Size="Smaller" Text = '<%# Eval("price") %>'></asp:Label>
                                    <br />
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

                    <br />

                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Roboto" Font-Size="Larger" ForeColor="#1B5E20" Text="Total Cost:"></asp:Label>
                    <asp:Label ID="TotalCost" runat="server"></asp:Label>
                    <br />

                    <asp:Button ID="PurchaseBtn" runat="server" OnClick="PurchaseBtn_Click" Text="PURCHASE!" />

                </div>
                <div>
                    <div>
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Raleway" Font-Size="Large" Text="Shipping Address"></asp:Label>
                        <br />
                        <asp:Label ID="ShipAddress" runat="server" Font-Names="Raleway" Font-Size="Small"></asp:Label>
                        <br />
                        <asp:Panel runat="server" ID="AddressHolder" style="display:none">
                            <asp:Label ID="Label4" runat="server" Text="Address:"></asp:Label>
                            <asp:TextBox ID="Address" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label5" runat="server" Text="City:"></asp:Label>
                            <asp:TextBox ID="City" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label7" runat="server" Text="State:"></asp:Label>
                            <asp:TextBox ID="State" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label8" runat="server" Text="Zip:"></asp:Label>
                            <asp:TextBox ID="Zip" runat="server"></asp:TextBox>
                            <br />
                            <asp:Button ID="SubmitAddress" runat="server" Text="Submit" OnClick="SubmitAddress_Click" />
                        </asp:Panel>
                        
                        <br />
                        <asp:Button ID="AddressBtn" runat="server" Text="Edit Shipping Address" OnClick="AddressBtn_Click" />
                    </div>
                    <div>
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Raleway" Font-Size="Large" Text="Payment Method"></asp:Label>
                        <br />
                        <asp:Label ID="PaymentInfo" runat="server" Font-Names="Raleway" Font-Size="Small"></asp:Label>
                        <br />
                        <asp:Panel ID="PaymentHolder" runat="server" style="display:none">
                            <asp:Label ID="Label9" runat="server" Text="Card Number:"></asp:Label>
                            <asp:TextBox ID="CardNum" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label10" runat="server" Text="Exp Date:"></asp:Label>
                            <asp:TextBox ID="ExpDate" runat="server" Width="61px"></asp:TextBox>
                            <asp:Label ID="Label11" runat="server" Text="CV: "></asp:Label>
                            <asp:TextBox ID="CV" runat="server" Width="41px"></asp:TextBox>
                            <br />
                            <asp:Button ID="PaymentSubmit" runat="server" OnClick="PaymentSubmit_Click" Text="Submit" />
                        </asp:Panel>
                        <br />
                        <asp:Button ID="Payment" runat="server" OnClick="Payment_Click" Text="Edit Payment Method" />
                    </div>
                </div>
            
        </div>
</asp:Content>
