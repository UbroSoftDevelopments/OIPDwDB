using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class WardMaster : System.Web.UI.Page
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


        }
        protected void buttonsubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string wardname = txtwardname.Text;
                string speciality = txtspeciality.Text;
                if (wardname.Equals("") || wardname.Equals(null))
                    throw new Exception("Please Enter Valid Ward Name");
                IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter();
                da.InsertQuery(wardname, speciality);
                message.Text = "Entered Successfully!!";
                Validation.makeLabelVisible(message);
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Validation.setError(message, "" + ex.Message);
            }

        }
        protected void buttonreset_Click(object sender, EventArgs e)
        {
            Validation.totalResetTextBoxes(txtwardname, txtspeciality);
            Validation.makeLabelInVisible(message);
        }
    }
}