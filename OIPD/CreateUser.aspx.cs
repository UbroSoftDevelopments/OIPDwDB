using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;
using IOPD.DataManager.DataSet1TableAdapters;

namespace OIPD
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            else
            {
                if (LoginManager.IsClerkLoggedIn(Session))
                    Response.Redirect("unauthorizedPage.aspx");
            }

            lblErrors.Text = "";
            if (!this.IsPostBack)
            {
                IOPD.DataManager.DataSet1TableAdapters.usertypeTableAdapter utta = new IOPD.DataManager.DataSet1TableAdapters.usertypeTableAdapter();
                DataSet1.usertypeDataTable utdt = utta.GetData();
                drpdwnUserType.Items.Insert(0, new ListItem("--------Select User Type--------", "-1"));
                for (int x = 0; x < utdt.Rows.Count; x++)
                {
                    DataSet1.usertypeRow utr = (DataSet1.usertypeRow)utdt.Rows[x];
                    drpdwnUserType.Items.Insert(x + 1, new ListItem("" + utr.type, "" + utr.sno));
                }
            }
        }

        protected void addUser(object sender, EventArgs e)
        {
            if (txtUserName.Text.Equals("") || txtUserName.Text.Equals("admin"))
            {
                lblErrors.Text = "Enter Valid User Name";
                return;
            }
            if (drpdwnUserType.SelectedIndex == 0)
            {
                lblErrors.Text = "Select User Type";
                return;
            }
            if (txtPassword.Text.Equals(""))
            {
                lblErrors.Text = "Enter Password";
                return;
            }
            if (txtRetypePassword.Text.Equals(""))
            {
                lblErrors.Text = "Re-type your password";
                return;
            }

            String uName = txtUserName.Text;
            String pass = txtPassword.Text;
            String rePass = txtRetypePassword.Text;
            int userType = Convert.ToInt32("" + drpdwnUserType.SelectedValue);

            if (!pass.Equals(rePass))
            {
                lblErrors.Text = "Passwords Did Not Match";
                txtRetypePassword.Text = "";
                return;
            }

            String res = LoginManager.addNewUser(uName, userType, pass);
            if (res.Equals("Success"))
                Response.Redirect("home.aspx");
            else
                lblErrors.Text = res;
            GridView1.DataBind();
        }

        public void changeStatus(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string username = "" + b.CommandArgument;
            IOPD.DataManager.DataSet1TableAdapters.siteusersTableAdapter sta = new IOPD.DataManager.DataSet1TableAdapters.siteusersTableAdapter();
            DataSet1.siteusersDataTable sdt = sta.GetDataByUserName(username);
            DataSet1.siteusersRow sr = (DataSet1.siteusersRow)sdt.Rows[0];
            string status = sr.status;
            if (status.Equals("active"))
                sta.UpdateStatusByName("inactive", username);
            else
                sta.UpdateStatusByName("active", username);
            GridView1.DataBind();
        }
    }
}