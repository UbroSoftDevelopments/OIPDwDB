using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class printDischarge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            try
            {
                int sno = Convert.ToInt32(Request.QueryString["sno"]);

                Patient patient = new Patient(sno);
                DepartmentValidation dept = new DepartmentValidation(patient.departmentno);
                String departName = dept.Departname;

                regNumber.Text = RegistrationUtilities.GetRegistrationNo(sno);

                IOPD.DataManager.DataSet1TableAdapters.dischargeTableAdapter dta = new IOPD.DataManager.DataSet1TableAdapters.dischargeTableAdapter();
                DataSet1.dischargeDataTable ddt = dta.GetDataByPatientno(sno);
                DataSet1.dischargeRow ir = (DataSet1.dischargeRow)ddt.Rows[0];
                DateTime dt = (ir.dateofdischarge);
                receiptNo.Text = "" + ir.sno;
                dateOfEntry.Text = DateUtilities.dateFormat(dt);
                lblfirstname.Text = patient.firstname;
                lbllastname.Text = patient.lastname;
                lblfather_w_o.Text = patient.fathername;

                int month = patient.agemonths;
                int days = patient.agedays;
                String ageLabelText;
                ageLabelText = patient.ageyears + "Yr " + month + "Mn " + days + "Day";
                lblage.Text = ageLabelText;
                lblgender.Text = patient.gender;
                lbladdress.Text = "" + patient.address;
                lblmobileNumber.Text = "" + patient.mobileno;
                lblrefFrom.Text = "" + patient.referredfrom;

                if (!patient.referredfrom.Equals("Self"))
                {
                    lblreferer.Text = "<b>Reffer Number -:</b>";
                    lblrefnumber.Text = patient.doctorno;
                }

                lbldepartment.Text = departName;

                lblApproved.Text = "" + ir.approved;
                lblTreatment.Text = "" + ir.furthertreatment;
                lblReason.Text = "" + ir.reason;
                lblDoctor.Text = "" + ir.dischargingphysician;

                lblChief.Text = ir.chiefComplaint;
                lblPhysical.Text = ir.physicalFindings;
                lblInvestigation.Text = ir.investigation;
                lblTreatement.Text = ir.treatement;
                lblOperation.Text = ir.operation;
                lblBiopsy.Text = ir.biopsyReport;
                lblFinal.Text = ir.finalDiagonosis;
                lblResult.Text = ir.result;
                lblInstruction.Text = ir.instruction;
                lblDischargeMedicine.Text = ir.dischargemedicine;
            }
            catch
            {
                Response.Redirect("dischargedPatient.aspx");
            }
        }
    }
}