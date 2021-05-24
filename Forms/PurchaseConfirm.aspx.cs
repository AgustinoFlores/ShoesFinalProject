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
        protected void Page_Load(object sender, EventArgs e)
        {
            string cost = Request.QueryString.Get("Cost");
            FinalCost.Text = cost;
        }
    }
}