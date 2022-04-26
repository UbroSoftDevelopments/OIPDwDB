using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class Renewform : System.Web.UI.Page
    {
        Patient patient;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;

            message.Text = "";
            int sno = Convert.ToInt32(Request.QueryString["sno"]);
            this.patient = new Patient(sno);
            DepartmentValidation dep = new DepartmentValidation(patient.departmentno);
            lbldepart.Text = dep.Departname;
            lbltitle.Text = "" + patient.title;
            txtfirstname.Text = "" + patient.firstname;
            txtlastname.Text = "" + patient.lastname;
            txtfathersname.Text = "" + patient.fathername;
            txtYears.Text = "" + patient.ageyears;
            txtMonths.Text = "" + patient.agemonths;
            txtDays.Text = "" + patient.agedays;
            dropdowngender.Text = "" + patient.gender;
            txtaddress.Text = "" + patient.address;
            drpdwnRef.Text = "" + patient.referredfrom;
            if (!(patient.referredfrom.Equals("Self")))
            {
                lblDocNumber.Visible = true;
                txtDocNumber.Visible = true;
                txtDocNumber.Text = "" + patient.doctorno;
            }
            txtnumber.Text = "" + patient.mobileno;
        }
        public void renew(object sender, EventArgs e)
        {
            try
            {
                if (txtdate.Text.Equals(""))
                    throw new Exception("Enter renew date please");
                IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter();
                DateTime dt = System.DateTime.Now;
                dt = dt.AddHours(12.50);
                DateTime date = Convert.ToDateTime((txtdate.Text) + " " + dt.Hour + ":" + dt.Minute + dt.ToString("tt"));
                da.UpdateRenewDate(date.AddDays(15), (patient.totalrenews + 1), patient.patientno);
                pri.Visible = true;
                btnPrint.NavigateUrl = "printReceipt.aspx?sno=" + patient.patientno;
            }
            catch (Exception ex)
            {
                Validation.setError(message, ex);
            }

        }
    }
}