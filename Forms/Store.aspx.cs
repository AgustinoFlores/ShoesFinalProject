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

        /*
         * This method redirects the user to ShoesInfo to display the information of the current shoe selected within the ListView. Whenever a user clicks on a ListViewItem this method runs.
         */
        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String shoe = ListView1.SelectedValue.ToString();
            Response.Redirect("ShoesInfo.aspx?ShoeInfo=" + shoe);
        }
    }
}