using IOPD.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OIPD
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            //int opd = 10; /*PatientUtilities.gettodaystotalopd();*/
            //int ipd = PatientUtilities.gettodaystotalipd();
            //int discharge = PatientUtilities.gettodaystotaldischarge();
            //int beds = PatientUtilities.gettotalemptybeds();
            //int totalbeds = bedUtilities.totalbeds();
            //ttlOpdPatient.Text = opd + "<br />Patients";
            //ttlIpdPatient.Text = ipd + "<br />Patients";
            //ttlDischargePatient.Text = discharge + "<br />Patients";
            //ttlEmptyBeds.Text = beds + "/" + totalbeds + "<br />Empty Beds";
        }
    }
}