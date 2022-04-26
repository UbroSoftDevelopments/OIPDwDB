using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class dischargePatient : System.Web.UI.Page
    {
        Patient patient;
        int bedno;
        protected void Page_Load(object sender, EventArgs e)
        {

            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;

            int patientno = Convert.ToInt32("" + Request.QueryString["patientno"]);
            patient = new Patient(patientno);
            lblPatient.Text = patient.title + " " + patient.firstname + " " + patient.lastname;
            lblDate.Text = "" + patient.dateofentry.Day + "/" + patient.dateofentry.Month + "/" + patient.dateofentry.Year;
            PatientUtilities.getPatientBedDetails(patientno);
            lblWard.Text = "" + PatientUtilities.wardname;
            lblRoom.Text = "" + PatientUtilities.roomno;
            lblBed.Text = "" + PatientUtilities.bedno;
            bedno = PatientUtilities.bedsno;
            lblDepart.Text = patient.getDepartmentName();

            IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter ita = new IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter();
            DataSet1.ipdformDataTable idt = ita.GetDataByPatientNo(patientno);
            DataSet1.ipdformRow ir = (DataSet1.ipdformRow)idt.Rows[0];
            lblReason.Text = "" + ir.comments;

            /***********************IF HALF DISCHARGE FORM WAS FILLED AND SAVED THEN REFILL THAT FORM***************/
            if (dischargeUtilities.isPatientHalfDischarged(patientno) && !this.IsPostBack)
            {
                IOPD.DataManager.DataSet1TableAdapters.tempDischargeTableAdapter tdta = new IOPD.DataManager.DataSet1TableAdapters.tempDischargeTableAdapter();
                DataSet1.tempDischargeDataTable tddt = tdta.GetHalfDischargedData(patientno);
                DataSet1.tempDischargeRow tdr = (DataSet1.tempDischargeRow)tddt.Rows[0];

                txtdate.Text = DateUtilities.onlyDateFormat(tdr.dateofdischarge);
                string approvedDischarge = tdr.approved;
                if (approvedDischarge.Equals("Yes"))
                    rdoPhysian.Items[0].Selected = true;
                else
                    rdoPhysian.Items[1].Selected = true;
                string dischargeReason = tdr.reason;
                for (int x = 0; x < drpdwnDschrgReason.Items.Count; x++)
                {
                    if (dischargeReason.Equals("" + drpdwnDschrgReason.Items[x].Value))
                    {
                        //lblErr.Text += "" + x;
                        drpdwnDschrgReason.Items[0].Selected = false;
                        drpdwnDschrgReason.Items[x].Selected = true;
                        break;
                    }
                }
                string furtherTreatment = tdr.furthertreatment;
                if (furtherTreatment.Equals("Yes"))
                    rdoTreament.Items[0].Selected = true;
                else
                    rdoTreament.Items[1].Selected = true;
                txtDischargingPhysician.Text = tdr.dischargingphysician;
                txtChiefComplaint.Text = tdr.chiefcomplaint;
                txtPhysicalFindings.Text = tdr.physicalfindings;
                txtInvestigation.Text = tdr.investigation;
                txtTreatment.Text = tdr.treatement;
                txtOperation.Text = tdr.operation;
                txtBiopsy.Text = tdr.biopsyreport;
                txtFinalDiagnosis.Text = tdr.finaldiagonosis;
                txtResult.Text = tdr.result;
                txtInstruction.Text = tdr.instruction;
                txtDischargeMedicine.Text = tdr.dischargemedicine;
            }

        }

        protected void discharging(object sender, EventArgs e)
        {
            try
            {
                string complain, physical, investigation, treatement, operation, biopsy, final, result, instruction, dischargemedicine;
                if (txtdate.Text.Equals(""))
                    throw new Exception("Select Date of Discharge");
                if (drpdwnDschrgReason.SelectedIndex == 0)
                    throw new Exception("Select Reason of Discharge");
                if (txtDischargingPhysician.Text.Equals(""))
                    throw new Exception("Give name of discharging physician");

                if (txtChiefComplaint.Text.Equals(""))
                    complain = "None";
                else
                    complain = txtChiefComplaint.Text.ToString();

                if (txtPhysicalFindings.Text.Equals(""))
                    physical = "None";
                else
                    physical = txtPhysicalFindings.Text.ToString();

                if (txtInvestigation.Text.Equals(""))
                    investigation = "None";
                else investigation = txtInvestigation.Text.ToString();

                if (txtTreatment.Text.Equals(""))
                    treatement = "None";
                else treatement = txtTreatment.Text.ToString();

                if (txtOperation.Text.Equals(""))
                    operation = "None";
                else operation = txtOperation.Text.ToString();

                if (txtBiopsy.Text.Equals(""))
                    biopsy = "None";
                else biopsy = txtBiopsy.Text.ToString();

                if (txtFinalDiagnosis.Text.Equals(""))
                    final = "None";
                else final = txtFinalDiagnosis.Text.ToString();

                if (txtResult.Text.Equals(""))
                    result = "None";
                else result = txtResult.Text.ToString();

                if (txtInstruction.Text.Equals(""))
                    instruction = "None";
                else instruction = txtInstruction.Text.ToString();

                if (txtDischargeMedicine.Text.Equals("") || txtDischargeMedicine.Text.Equals(null))
                    dischargemedicine = "None";
                else dischargemedicine = txtDischargeMedicine.Text.ToString();

                DateTime dt = System.DateTime.Now;
                dt = dt.AddHours(12.50);
                DateTime date = Convert.ToDateTime((txtdate.Text) + " " + dt.Hour + ":" + dt.Minute + dt.ToString("tt"));
                string leave = bedUtilities.leaveBed(bedno, date, Convert.ToInt32("" + Request.QueryString["patientno"]), "" + drpdwnDschrgReason.SelectedItem, LoginManager.CurrentUser(Session));
                if (!(leave.Equals("successfull")))
                    throw new Exception(leave);
                IOPD.DataManager.DataSet1TableAdapters.dischargeTableAdapter dta = new IOPD.DataManager.DataSet1TableAdapters.dischargeTableAdapter();
                dta.Insert1(Convert.ToInt32(Request.QueryString["patientno"]), date, "" + rdoPhysian.SelectedValue, "" + drpdwnDschrgReason.SelectedValue, "" + rdoTreament.SelectedValue, "" + txtDischargingPhysician.Text, LoginManager.CurrentUser(Session), complain, physical, investigation, treatement, operation, biopsy, final, result, instruction, dischargemedicine);
                makereadonly();
                dischargeUtilities.deleteDischargedPatient(Convert.ToInt32(Request.QueryString["patientno"]));
                bool b = addTotalExpences(Convert.ToInt32(Request.QueryString["patientno"]));
                if (!b)
                {
                    Response.Write("Error Discharging Patient");
                    return;
                }
                btnBill.NavigateUrl = "receivePayments.aspx?patientno=" + Request.QueryString["patientno"];
                btnPrint.NavigateUrl = "printDischarge.aspx?sno=" + Request.QueryString["patientno"];
            }
            catch (Exception ex)
            {
                Validation.setError(lblErr, ex);
            }
        }

        public bool addTotalExpences(int pno)
        {
            bool b = chargesUtilities.doDischargeEntries(pno, LoginManager.CurrentUser(Session));
            return b;
            /*DataSet1TableAdapters.ipdformTableAdapter da = new DataSet1TableAdapters.ipdformTableAdapter();
            DataSet1.ipdformDataTable dt = da.GetDataByPatientNo(pno);
            DataSet1.ipdformRow dr = (DataSet1.ipdformRow)dt.Rows[0];

            DataSet1TableAdapters.dischargeTableAdapter dta = new DataSet1TableAdapters.dischargeTableAdapter();
            DataSet1.dischargeDataTable ddt = dta.GetDataByPatientno(pno);
            DataSet1.dischargeRow ddr = (DataSet1.dischargeRow)ddt.Rows[0];

            DataSet1TableAdapters.expensesTableAdapter eda = new DataSet1TableAdapters.expensesTableAdapter();
            DataSet1.expensesDataTable edt = eda.GetDataByPatientNo(pno);
            DateTime from;
            if (edt.Rows.Count > 2)
            {
                DataSet1.expensesRow er = (DataSet1.expensesRow)edt.Rows[2];
                from = Convert.ToDateTime(er.dateofexpense);
                from = from.AddDays(1);
            }
            else
                from = dr.dateofentry;
            Dictionary<string, int> charges = chargesUtilities.showChargesOfPatient(pno, from, ddr.dateofdischarge);

            foreach (KeyValuePair<string, int> allc in charges)
            {
                edt=eda.GetDataByChargeName(pno,allc.Key);
                if (allc.Key.Equals("Days") || allc.Key.Equals("Registration Fees") || allc.Key.Equals("IPD Fees"))//||edt.Rows.Count>0)
                    continue;
                eda.Insert(ddr.dateofdischarge, allc.Value, allc.Key, pno, LoginManager.CurrentUser(Session));
            }*/
        }

        public void makereadonly()
        {
            txtdate.Enabled = false;
            drpdwnDschrgReason.Enabled = false;
            txtDischargingPhysician.Enabled = false;
            rdoPhysian.Enabled = false;
            rdoTreament.Enabled = false;
            txtChiefComplaint.Enabled = false;
            txtPhysicalFindings.Enabled = false;
            txtInvestigation.Enabled = false;
            txtTreatment.Enabled = false;
            txtOperation.Enabled = false;
            txtBiopsy.Enabled = false;
            txtFinalDiagnosis.Enabled = false;
            txtResult.Enabled = false;
            txtInstruction.Enabled = false;
            txtDischargeMedicine.Enabled = false;
            btnDischarge.Enabled = false;
            btnBill.Visible = true;
            btnPrint.Visible = true;
        }
        public void reset(object sender, EventArgs e)
        {
            txtdate.Enabled = true;
            drpdwnDschrgReason.Enabled = true;
            txtDischargingPhysician.Enabled = true;
            rdoPhysian.Enabled = true;
            rdoTreament.Enabled = true;
            txtChiefComplaint.Enabled = true;
            txtPhysicalFindings.Enabled = true;
            txtInvestigation.Enabled = true;
            txtTreatment.Enabled = true;
            txtOperation.Enabled = true;
            txtBiopsy.Enabled = true;
            txtFinalDiagnosis.Enabled = true;
            txtResult.Enabled = true;
            txtInstruction.Enabled = true;
            txtDischargeMedicine.Enabled = true;
            btnDischarge.Enabled = true;
            btnBill.Visible = false;
            btnPrint.Visible = false;
        }

        public void saveHalfForm(object sender, EventArgs e)
        {
            int patientno = Convert.ToInt32(Request.QueryString["patientno"]);
            IOPD.DataManager.DataSet1TableAdapters.tempDischargeTableAdapter tdts = new IOPD.DataManager.DataSet1TableAdapters.tempDischargeTableAdapter();
            if (dischargeUtilities.isPatientHalfDischarged(patientno))
            {
                tdts.UpdateSavedDischargeData(Convert.ToDateTime(txtdate.Text), "" + rdoPhysian.SelectedValue, "" + drpdwnDschrgReason.SelectedValue, "" + rdoTreament.SelectedValue, txtDischargingPhysician.Text, LoginManager.CurrentUser(Session), txtChiefComplaint.Text, txtPhysicalFindings.Text, txtInvestigation.Text, txtTreatment.Text, txtOperation.Text, txtBiopsy.Text, txtFinalDiagnosis.Text, txtResult.Text, txtInstruction.Text, txtDischargeMedicine.Text, patientno);
                Validation.setSuccess(lblErr, new Exception("!!! Discharge Details Update !!!"));
            }
            else
            {
                tdts.Insert1(patientno, Convert.ToDateTime(txtdate.Text), "" + rdoPhysian.SelectedValue, "" + drpdwnDschrgReason.SelectedValue, "" + rdoTreament.SelectedValue, txtDischargingPhysician.Text, LoginManager.CurrentUser(Session), txtChiefComplaint.Text, txtPhysicalFindings.Text, txtInvestigation.Text, txtTreatment.Text, txtOperation.Text, txtBiopsy.Text, txtFinalDiagnosis.Text, txtResult.Text, txtInstruction.Text, txtDischargeMedicine.Text);
                Validation.setSuccess(lblErr, new Exception("!!! Discharge Details Saved !!!"));
            }
        }
    }
}