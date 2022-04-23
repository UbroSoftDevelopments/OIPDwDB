using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class pad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;*/
            string dname = "";
            if (Request.QueryString["docname"] != null || (Request.QueryString["docname"]).Trim() != "")
            {
                dname = Request.QueryString["docname"];
                lblDocName.Text = "Doctor Name: &nbsp;<b>" + dname + "</b>";
            }
            else
                lblDocName.Text = "&nbsp;";
            int sno = Convert.ToInt32(Request.QueryString["sno"]);
            if (sno == 0)
                return;
            IOPD.DataManager.Patient p = new Patient(sno);
            txtName.Text = "" + IOPD.DataManager.PatientUtilities.getpatientname(sno);
            lblAge.Text = "" + p.ageyears + "Y " + p.agemonths + "M " + p.agedays + "D";
            lblSex.Text = "" + p.gender;
            lblDt.Text = DateUtilities.onlyDateFormat("" + p.dateofentry);
            lblAddress.Text = p.address + "";
        }
    }
}