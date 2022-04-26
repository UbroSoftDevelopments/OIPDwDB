using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class ChangeDepartment : System.Web.UI.Page
    {
        int Patientno;
        Patient patient;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool b = LoginManager.ProtectPage(Session, Response);
                if (!b)
                    return;

                lblMessage.Text = "";
                if (!this.IsPostBack)
                {
                    Patientno = Convert.ToInt32("" + Request.QueryString["patientno"]);
                    patient = new Patient(Patientno);
                    lblPatient.Text = patient.title + " " + patient.firstname + " " + patient.lastname;
                    lblDate.Text = "" + patient.dateofentry.Day + "/" + patient.dateofentry.Month + "/" + patient.dateofentry.Year;
                    PatientUtilities.getPatientBedDetails(Patientno);
                    lblDepart.Text = patient.getDepartmentName();

                    IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter ita = new IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter();
                    DataTable idt = ita.GetDataByPatientNo(Patientno);
                    DataSet1.ipdformRow ir = (DataSet1.ipdformRow)idt.Rows[0];
                    lblReason.Text = "" + ir.comments;

                    IOPD.DataManager.DataSet1TableAdapters.doctorslistTableAdapter dlta = new IOPD.DataManager.DataSet1TableAdapters.doctorslistTableAdapter();
                    DataSet1.doctorslistRow dlr = (DataSet1.doctorslistRow)dlta.GetDataByDoctorNo(ir.doctorno).Rows[0];
                    lblDoctor.Text = dlr.doctorname;

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "" + ex.Message;
            }
        }
        protected void bttnadmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDepartments.SelectedValue == "-1")
                    throw new Exception("Please Select New Department");
                int newDepart = Convert.ToInt32(ddlDepartments.SelectedValue);
                int pno = Convert.ToInt32("" + Request.QueryString["patientno"]);
                PatientUtilities.updatePatientDepartment(pno, newDepart);
                lblMessage.Text = "Department Changed Successfully";
               // Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ("" + ex.Message);
            }
        }
    }
}