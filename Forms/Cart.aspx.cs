using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoesProject.Forms
{
    public partial class Cart : System.Web.UI.Page
    {
        DB myDB;
        protected void Page_Load(object sender, EventArgs e)
        {
            myDB = new DB();
            SqlDataSource1.SelectParameters["userid"].DefaultValue = (string) Session["LoggedUser"];
            SqlDataSource1.SelectCommand = "SELECT * FROM Cart INNER JOIN Products ON Cart.product_id = Products.product_id WHERE Cart.userid = @userid";
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "RemoveItem")
            {
                string[] args = e.CommandArgument.ToString().Split(',');
                SqlDataSource1.DeleteParameters["cart_id"].DefaultValue = args[0];
                SqlDataSource1.DeleteCommand = "DELETE FROM Cart WHERE cart_id = @cart_id";

                ListView1.DeleteItem(int.Parse(args[1]));
            }
        }
    }
}