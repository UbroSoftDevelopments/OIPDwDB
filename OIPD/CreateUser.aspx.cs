using System;
using System.Collections.Generic;
using System.IO;
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
            if (txtTitlename.Text.Equals(""))
            {
                lblErrors.Text = "Enter Title";
                return;
            }
            if (txtSubTitle.Text.Equals(""))
            {
                lblErrors.Text = "Enter Sub Title";
                return;
            }
            if (txtBigTitle.Text.Equals(""))
            {
                lblErrors.Text = "Enter Big Title";
                return;
            }
            if (txtAddress.Text.Equals(""))
            {
                lblErrors.Text = "Enter Address";
                return;
            }

            String uName = txtUserName.Text;
            String pass = txtPassword.Text;
            String rePass = txtRetypePassword.Text;
            int userType = Convert.ToInt32("" + drpdwnUserType.SelectedValue);
            String title = txtTitlename.Text;
            String subtitle = txtSubTitle.Text;
            String bigtitle = txtBigTitle.Text;
            String address = txtAddress.Text;

            Byte[] bytes;
            using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream)) 
            {
                bytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
            }
           
            string base64ImageRepresentation = Convert.ToBase64String(FileUpload1.FileBytes);

            if (!pass.Equals(rePass))
            {
                lblErrors.Text = "Passwords Did Not Match";
                txtRetypePassword.Text = "";
                return;
            }

            String res = LoginManager.addNewUser(uName, pass, userType, bytes , title, subtitle, bigtitle, address);
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