using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoesProject.App_Code
{
    public partial class PageLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CartBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}