using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoesProject.Forms
{
    public partial class PurchaseConfirm : System.Web.UI.Page
    {
        /*
         * This method just allows the confirmation page to show the final cost of the purchase the user made.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            string cost = Request.QueryString.Get("Cost");
            FinalCost.Text = cost;
        }
    }
}