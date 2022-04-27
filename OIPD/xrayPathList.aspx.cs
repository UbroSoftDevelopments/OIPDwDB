using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class xrayPathList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            if (!this.IsPostBack)
            {
                /*txtStartDate.Text = DateUtilities.dateFormat("1-1-2018 12:00");
                DateTime dt = System.DateTime.Now;
                dt = dt.AddHours(12.50);
                txtEndDate.Text = "" + dt;*/
            }
        }
        protected void searching(object sender, EventArgs e)
        {
            try
            {
                //int sno = Convert.ToInt32(RegistrationUtilities.GetPatientNo(txtPatientNumber.Text));
                string name = txtPatientNumber.Text;



                //Response.Redirect("patientData.aspx?patientno="+sno);
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "" + ex.Message;
            }
        }
        protected void noPatient(object sender, EventArgs e)
        {
            //Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl("printPathBill.aspx?sno=0")));
            Response.Redirect("printPathBill.aspx?sno=0");
        }
    }
}