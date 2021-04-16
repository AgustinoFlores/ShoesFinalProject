using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ShoesProject
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        DB myDb;
        protected void Page_Load(object sender, EventArgs e)
        {
            myDb = new DB();
            Label2.Text = myDb.getPath();
        }
    }
}