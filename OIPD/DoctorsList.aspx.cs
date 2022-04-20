using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class DoctorList : System.Web.UI.Page
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
            lblmessage.Text = "";

        }
        protected void buttonsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txttilte.Text.Equals(""))
                    throw new Exception("Please Add Title");

                if (txtname.Text.Equals(""))
                    throw new Exception("Please Give Name");

                if (txtqualification.Text.Equals(""))
                    throw new Exception("Please Add Qualifications");

                int index = DropDownList1.SelectedIndex;
                if (index <= 0)
                    throw new Exception("Please select department");

                int dindex = ddtype.SelectedIndex;
                if (dindex <= 0)
                    throw new Exception("Please Select Doctor type");

                if (txtcharge.Text.Equals(""))
                    throw new Exception("Please Add Charge");

                string title = txttilte.Text;
                string name = txtname.Text;

                int department = Convert.ToInt32(DropDownList1.SelectedValue);
                string qualification = txtqualification.Text;
                string type = ddtype.SelectedValue;
                int charge = Convert.ToInt32(txtcharge.Text);
                IOPD.DataManager.DataSet1TableAdapters.doctorslistTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.doctorslistTableAdapter();
                da.InsertQuery(title, name, department, qualification, type, charge);
                Validation.setSuccess(lblmessage, "Successfully inserted !!");
                GridView1.DataBind();

                buttonreset_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;

            }

        }
        protected void buttonreset_Click(object sender, EventArgs e)
        {
            Validation.totalResetTextBoxes(txtcharge, txtname, txtqualification);
            DropDownList1.SelectedIndex = 0;
            ddtype.SelectedIndex = 0;
        }
    }
}