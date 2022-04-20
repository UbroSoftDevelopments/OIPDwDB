using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class CreateCharges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErr.Text = "";
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            else
            {
                if (LoginManager.IsClerkLoggedIn(Session))
                    Response.Redirect("unauthorizedPage.aspx");
            }
            if (!this.IsPostBack)
            {
                IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter wmta = new IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter();
                DataSet1.wardmasterDataTable wmdt = wmta.GetData();
                txtappliedfor.Items.Insert(0, new ListItem("---Select---", "-1"));
                for (int x = 0; x < wmdt.Rows.Count; x++)
                {
                    DataSet1.wardmasterRow wmr = (DataSet1.wardmasterRow)wmdt.Rows[x];
                    txtappliedfor.Items.Insert(x + 1, new ListItem("" + wmr.wardname, "" + wmr.wardname));
                }
            }
        }
        public void addChargesToTable(object sender, EventArgs e)
        {
            try
            {
                IOPD.DataManager.DataSet1TableAdapters.chargesTableAdapter cta = new IOPD.DataManager.DataSet1TableAdapters.chargesTableAdapter();
                cta.InsertQuery("" + txtchargeName.Text, "" + txtappliedfor.SelectedValue, Convert.ToInt32("" + txtamount.Text));
                charges.DataBind();
                txtchargeName.Text = "";
                txtappliedfor.SelectedIndex = 0;
                txtamount.Text = "";
            }
            catch (Exception ex)
            {
                lblErr.Text = "" + ex.Message;
            }
        }
    }
}