using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class RefferalHospitals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrors.Text = "";
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            else
            {
                if (LoginManager.IsClerkLoggedIn(Session))
                    Response.Redirect("unauthorizedPage.aspx");
            }

        }

        protected void addHospital(object sender, EventArgs e)
        {
            try
            {
                if (txtHospName.Text.Equals(""))
                    throw new Exception("Please Give Hospital Name");

                if (txtHospAddress.Text.Equals(""))
                    throw new Exception("Please Give Hospital Address");

                if (txtHospContactNo.Text.Equals(""))
                    throw new Exception("Please Give Hospital Contact No");

                if (txtHospMail.Text.Equals(""))
                    throw new Exception("Please Give Hospital Mail");

                if (txtHospShare.Text.Equals(""))
                    throw new Exception("Please Give Hospital Share(%)");

                String hName = txtHospName.Text;
                String hAdd = txtHospAddress.Text;
                String hContact = txtHospContactNo.Text;
                String mail = txtHospMail.Text;
                int share = Convert.ToInt32("" + txtHospShare.Text);

                IOPD.DataManager.DataSet1TableAdapters.refferHospitalsTableAdapter rhta = new IOPD.DataManager.DataSet1TableAdapters.refferHospitalsTableAdapter();
                rhta.InsertQuery(hName, hAdd, hContact, mail, share);

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Validation.setError(lblErrors, ex);
            }
        }
    }
}