using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class Treatment : System.Web.UI.Page
    {
        int patientNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            patientNo = Convert.ToInt32(Request.QueryString["patientno"]);
            Patient p = new Patient(patientNo);
            if (!(p.isValidPatient()))
                Response.Redirect("treatementList.aspx");
        }

        protected void addTreatment(object sender, EventArgs e)
        {
            try
            {
                if (txtdate.Text.Equals(""))
                    throw new Exception("Enter treatment date");
                if (txtname.Text.Equals(""))
                    throw new Exception("Enter treatment name");
                if (txtdetails.Text.Equals(""))
                    throw new Exception("Enter treatment details");

                DateTime dat = System.DateTime.Now;
                dat = dat.AddHours(12.50);
                DateTime dt = Convert.ToDateTime((txtdate.Text) + " " + dat.Hour + ":" + dat.Minute + dat.ToString("tt"));
                string name = txtname.Text;
                string details = txtdetails.Text;

                IOPD.DataManager.DataSet1TableAdapters.treatementTableAdapter tta = new IOPD.DataManager.DataSet1TableAdapters.treatementTableAdapter();
                tta.Insert1(patientNo, dt, name, details, LoginManager.CurrentUser(Session));
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Validation.setError(lblmsg, ex);
            }
        }
    }
}