using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoesProject.Forms
{
    public partial class Cart : System.Web.UI.Page
    {
        DB myDB;
        string[] infoPayment;

        /*
         * The Page Load method connects to the database and sets up the page itself. It selects all the items from the cart for this specific user. It also gets their shipping address and payment method if there is one. It sets up the client events for displaying payment and shipping address updates. This also calculates the total cost of a person's shopping cart.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            myDB = new DB();
            SqlDataSource1.SelectParameters["userid"].DefaultValue = (string)Session["LoggedUser"];
            SqlDataSource1.SelectCommand = "SELECT * FROM Cart INNER JOIN Products ON Cart.product_id = Products.product_id WHERE Cart.userid = @userid";

            //setup client events
            viewShipAddress();
            viewPayment();
            AddressBtn.OnClientClick = "return showHolder()";
            SubmitAddress.OnClientClick = "return finishSubmit()";
            Payment.OnClientClick = "return showPayment()";
            PaymentSubmit.OnClientClick = "return finishPayment()";

            calculateCost();
        }

        /*
         * used to calculate the total cost of a person's shopping cart. It loops through the ListView that represents the shopping cart and calculates the cost by getting the Price and ProdQuantity, multiplying them together and adding them up. 
         * */
        protected void calculateCost()
        {
            double cost = 0;
            ListView1.DataBind();

            Label costLabel, quantityLabel;

            foreach(ListViewItem item in ListView1.Items)
            {
                costLabel = (Label) item.FindControl("Price");
                quantityLabel = (Label) item.FindControl("ProdQuantity");
                double subCost = double.Parse(costLabel.Text);
                int quantity = int.Parse(quantityLabel.Text);

                cost += (subCost * quantity);
            }

            TotalCost.Text = "$" + cost; 
        }

        /*
         * this fires whenever a user decides to click the remove button for an item. It completely removes the item from the shopping cart regardless of quantity.
         * */
        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "RemoveItem")
            {
                string[] args = e.CommandArgument.ToString().Split(',');
                SqlDataSource1.DeleteParameters["cart_id"].DefaultValue = args[0];
                SqlDataSource1.DeleteCommand = "DELETE FROM Cart WHERE cart_id = @cart_id";

                ListView1.DeleteItem(int.Parse(args[1]));
                calculateCost();
            }
        }

        /*
         * Used to show the shipping address for a user. It calls the getShipAddress method from myDB and either shows a user to add a new shipping address or allows them to edit it.
         */

        protected void viewShipAddress()
        {
            string userid = (string)Session["LoggedUser"];
            string shipAddress = myDB.getShipAddress(userid);
            string output = (shipAddress == "not found" || shipAddress == "") ? "Add a new shipping address" : shipAddress;

            ShipAddress.Text = output;
            AddressBtn.Text = (shipAddress == "not found" || shipAddress == "") ?  "Add Shipping Address" : AddressBtn.Text;
        }

        /*
         * Used to show the payment method for a user. It calls the getPayment method from myDB and either shows a user to add a new payment method or allows them to edit it.
         */
        protected void viewPayment()
        {
            string userid = (string)Session["LoggedUser"];
            string method = myDB.getPayment(userid);
            string output = "";

            if(method == "not found" || method == "")
            {
                output = "Add a payment method";
                Payment.Text = "Add Payment Method";
            }
            else
            {
                infoPayment = method.Split(',');
                output = "Card ending in " + infoPayment[0].Substring(infoPayment[0].Length - 4);
            }
            
            PaymentInfo.Text = output;
        }

        /*
         * Fired whenever a person wants to edit their address. Displays the current address in their respective text boxes
         */
        protected void AddressBtn_Click(object sender, EventArgs e)
        {
            if (ShipAddress.Text == "Add a new shipping address") return;

            string[] addresssInfo = ShipAddress.Text.Split(',');
            Address.Text = addresssInfo[0];
            City.Text = addresssInfo[1];
            State.Text = addresssInfo[2];
            Zip.Text = addresssInfo[3];

        }

        /*
         * Fired whenever a user finishes editing their shipping address. It displays the new address in the text box and updates the database as well
         */
        protected void SubmitAddress_Click(object sender, EventArgs e)
        {
            string addressStr = Address.Text;
            string cityStr = City.Text;
            string stateStr = State.Text;
            string zipStr = Zip.Text;

            string address = addressStr + "," + cityStr + "," + stateStr + "," + zipStr;
            string userid = (string)Session["LoggedUser"];

            Boolean success = myDB.updateShipAddress(userid, address);

            if (success)
            {
                ShipAddress.Text = address;
                AddressBtn.Text = "Edit Shipping Address";
            }
            else
            {
                ShipAddress.Text = "An error has occurred please try again!";
            }
        }

        /*
         * Fired whenever a person wants to edit their payment method. Displays the current parts of a payment method in their respective text boxes
         */
        protected void Payment_Click(object sender, EventArgs e)
        {
            if (PaymentInfo.Text == "Add a payment method") return;

            CardNum.Text = infoPayment[0];
            ExpDate.Text = infoPayment[1];
            CV.Text = infoPayment[2];
        }

        /*
         * Fired whenever a user finishes editing their payment method. It displays the new payment method in the text box and updates the database as well
         */
        protected void PaymentSubmit_Click(object sender, EventArgs e)
        {
            string cardNumStr = CardNum.Text;
            string expDateStr= ExpDate.Text;
            string cvStr = CV.Text;

            string[] temp = { cardNumStr, expDateStr, cvStr };

            string userid = (string)Session["LoggedUser"];
            Boolean success = myDB.updatePayment(userid, cardNumStr + "," + expDateStr + "," + cvStr);

            if (success)
            {
                infoPayment = temp;
                PaymentInfo.Text = "Card ending in " + cardNumStr.Substring(cardNumStr.Length - 4);
            }
            else
            {
                PaymentInfo.Text = "An error has occurred please try again!";
            }
        }

        /*
         * Used to simulate a final purchase. It redirects the user to PurchaseConfirm.aspx with the final cost as a datafield
         */
        protected void PurchaseBtn_Click(object sender, EventArgs e)
        {
            string userid = (string)Session["LoggedUser"];
            myDB.updateOrders(userid);
            Response.Redirect("PurchaseConfirm.aspx?Cost=" + TotalCost.Text);
        }
    }
}