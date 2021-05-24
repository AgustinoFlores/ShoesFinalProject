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
                if (ViewState["IsSignUp"] == null || !(bool) ViewState["IsSignUp"])
                {
                    TitleLabel.Text = "SIGN UP";
                    PageSwap.Text = "Sign In!";
                    Page.ClientScript.RegisterStartupScript(GetType(), "InitSignUp", "swapPage('" + SignUpForm.ClientID + "', '" + Login1.ClientID + "')", true);
                }
                else
                {
                    TitleLabel.Text = "SIGN IN";
                    PageSwap.Text = "Sign Up!";
                    Page.ClientScript.RegisterStartupScript(GetType(), "InitSignIn", "swapPage('" + Login1.ClientID + "', '" + SignUpForm.ClientID + "')", true);
                }
            }
        }
        
        protected void Page_Init(object sender, EventArgs e)
        {
            ViewState["IsSignUp"] = null;
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

        protected void PageSwap_Click(object sender, EventArgs e)
        {
            if(ViewState["IsSignUp"] == null)
            {
                ViewState["IsSignUp"] = true;
            }
            else
            {
                ViewState["IsSignUp"] = !((bool) ViewState["IsSignUp"]);
            }

            
        }

        protected void SignUpForm_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            String username = SignUpForm.UserName;
            String password = SignUpForm.Password;
            String email = SignUpForm.Email;
            String securityQuestion = SignUpForm.Question;
            String securityAnswer = SignUpForm.Answer;

            myDb.createUser(username, password, email, securityQuestion, securityAnswer);
        }
    }
}