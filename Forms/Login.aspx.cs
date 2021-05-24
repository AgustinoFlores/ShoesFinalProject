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

        /*
         * Whenever a page loads it creates a new connection to the database. This method checks if it is currently running a postback. After checking if it is a postback, the page checks whether the user wants to signup or login. If the user wants to signup, the method runs a JavaScript function to display the signup form. If the user wants to login, the method runs the same JavaScript function but to display the login form. 
         */
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
        
        /*
         * Initializes the ViewState for IsSignUp to allow checking this information between different Postbacks.
         */
        protected void Page_Init(object sender, EventArgs e)
        {
            ViewState["IsSignUp"] = null;
        }

        /*
         * This method uses the myDB.login function to check if a user exists in the database. If they do they are redirected to the store's main page.
         */
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

        /*
         * Used to toggle the viewstate property IsSignUp. If IsSignUp is null, it is instantied as true. If it isn't then the method gives the opposite value to the property. Ex: if ViewState["IsSignUp"] is true then it is given false and vice versa.
         */
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

        /*
         * This is fired whenever a user finishes the signup form. This method connects to myDb.createUser using the information a user inputted in the signup form.
         */
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