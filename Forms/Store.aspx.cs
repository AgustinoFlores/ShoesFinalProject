using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoesProject.Forms
{
    public partial class Store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String shoe = ListView1.SelectedValue.ToString();
            Response.Redirect("ShoesInfo.aspx?ShoeInfo=" + shoe);
        }
    }
}