using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoesProject
{
    public partial class Login : System.Web.UI.Page
    {
        DB myDb;
        protected void Page_Load(object sender, EventArgs e)
        {
            myDb = new DB();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String username = userBox.Text;
            String password = pwordBox.Text;

            if(myDb.login(username, password))
            {
                Response.Redirect("Homepage.aspx?LoggedUser=" + username);
            }
        }
    }
}