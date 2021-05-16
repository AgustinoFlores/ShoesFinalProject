using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoesProject
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WelcomeMessage.Text = "Welcome " + Request.QueryString.Get("LoggedUser") + "!";
        }

        protected void CartBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ShoeInfo.aspx?ShoeInfo=" + "HI");
        }
    }
}