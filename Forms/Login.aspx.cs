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

            if (IsPostBack)
            {
                if (!(bool) ViewState["IsSignUp"])
                {
                    TitleLabel.Text = "SIGN UP";
                    Login1.Visible = false;
                    SignUpForm.Visible = true;
                }
                else
                {
                    TitleLabel.Text = "SIGN UP";
                    Login1.Visible = true;
                    SignUpForm.Visible = false;
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            ViewState["IsSignUp"] = true;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            String username = Login1.UserName;
            String password = Login1.Password;
            String id = myDb.login(username, password);

            if (id != "not found")
            {
                Session["LoggedUser"] = id;
                Response.Redirect("Store.aspx?LoggedUser=" + username);
            }
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            if(ViewState["IsSignUp"] == null)
            {
                ViewState["IsSignUp"] = true;
                Response.Redirect(Request.RawUrl);

            }
            else
            {
                ViewState["IsSignUp"] = (bool) ViewState["IsSignUp"];
                Response.Redirect(Request.RawUrl);
            }

            
        }
    }
}