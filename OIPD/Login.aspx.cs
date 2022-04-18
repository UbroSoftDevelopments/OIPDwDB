using IOPD.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OIPD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.IsUserLoggedIn(Session);
            if (b)
                Response.Redirect("home.aspx");

        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Equals(""))
                {
                    throw new Exception("Enter User Name");
                }
                if (txtPassword.Text.Equals(""))
                {
                    throw new Exception("Enter Password");
                }
                bool b = LoginManager.logIn("" + txtUserName.Text, "" + txtPassword.Text, Response, Session);
                if (!b)
                    throw new Exception("Invalid username or password");
            }
            catch (Exception ex)
            {
                //Validation.setError(lblError, ex);
            }
        }
    }
}