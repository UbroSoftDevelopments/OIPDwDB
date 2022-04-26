using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class discharge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;

        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {

                int sno = Convert.ToInt32(RegistrationUtilities.GetPatientNo(txtPatientNumber.Text));
                Patient patient = new Patient(sno);
                IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter ita = new IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter();
                DataSet1.ipdformDataTable idt = ita.GetDataByPatientNo(sno);
                if (idt.Rows.Count == 0)
                {
                    lblErrMsg.Text = "This Patient is not in IPD";
                    return;
                }
                if (patient.isValidPatient())
                    Response.Redirect("dischargePatient.aspx?patientno=" + sno);
                else
                    lblErrMsg.Text = "Enter Valid Patient Number";

            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message);
            }
        }
    }
}