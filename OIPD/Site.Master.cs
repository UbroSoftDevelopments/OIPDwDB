using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.IsUserLoggedIn(Session);
            if (!b)
            {
                adminMenu.Visible = false;
                demo.Visible = false;
                userMenu.Visible = false;
                demoUser.Visible = false;
                index.Visible = true;
            }
            else
            {
                if (LoginManager.IsAdminLoggedIn(Session) && !LoginManager.IsClerkLoggedIn(Session))
                {
                    adminMenu.Visible = true;
                    demo.Visible = true;
                    userMenu.Visible = false;
                    demoUser.Visible = false;
                    index.Visible = false;
                    adUser.Text = "" + LoginManager.CurrentUser(Session);
                }
                else
                {
                    adminMenu.Visible = false;
                    demo.Visible = false;
                    userMenu.Visible = true;
                    demoUser.Visible = true;
                    index.Visible = false;
                    ckUser.Text = "" + LoginManager.CurrentUser(Session);
                }
            }


        }

        public void changeBg(string src)
        {

        }
    }
    
}