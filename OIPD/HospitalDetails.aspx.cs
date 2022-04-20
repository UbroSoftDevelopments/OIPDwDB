using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class HospitalDetails : System.Web.UI.Page
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
        }
        public void getOPDPatients(object sender, EventArgs e)
        {
            if (patientOPDDiv.Visible)
            {
                patientOPDDiv.Visible = false;
                btnOPDPatientDetails.Text = "OPD Patients Data<b><i class='fa fa-angle-down w3-circle highlight w3-right w3-gray w3-text-light-gray w3-hover-text-gray w3-padding'></i></b>";
                //patientData.InnerHtml = "";
            }
            else
            {
                patientOPDDiv.Visible = true;
                btnOPDPatientDetails.Text = "OPD Patients Data<b><i class='fa fa-angle-up w3-circle highlight w3-right w3-gray w3-text-light-gray w3-hover-text-gray w3-padding'></i></b>";
                rdoListTime1_SelectedIndexChanged(sender, e);
            }
        }
        protected void rdoListTime1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(rdoListTime1.SelectedValue);
                IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter ota = new IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter();
                DataSet1.opdformDataTable odt;
                DateTime from, to;
                int geetaCounter = 0, ayushCounter = 0, cashCounter = 0;
                DateTime dt = System.DateTime.Now;
                dt = dt.AddHours(12.5);
                switch (value)
                {
                    case 1:
                        {
                            from = dt;
                            to = dt;
                            odt = ota.GetDataByWithinDateSpan(from, to);
                            break;
                        }
                    case 2:
                        {
                            to = dt;
                            TimeSpan ts = System.TimeSpan.FromDays(7.0);
                            dt = dt.Subtract(ts);
                            from = dt;
                            odt = ota.GetDataByWithinDateSpan(from, to);
                            break;
                        }
                    case 3:
                        {
                            to = dt;
                            from = Convert.ToDateTime(dt.Month + "/1/" + dt.Year);
                            odt = ota.GetDataByWithinDateSpan(from, to);
                            lblmsg.Text = from + " - " + to;
                            break;
                        }
                    case 4:
                        {
                            odt = ota.GetData();
                            break;
                        }
                    default:
                        {
                            throw new Exception();
                        }
                }
                if (odt.Rows.Count <= 0)
                {
                    lblOPDGeetanjaliPatients.InnerHtml = "<br /><b>Geetanjali<br />Patients<br />0 Patients</b><br /><br />";
                    lblOPDAyushmanPatients.InnerHtml = "<br /><b>Ayushman<br />Patients<br />0 Patients</b><br /><br />";
                    lblOPDCashlessPatients.InnerHtml = "<br /><b>Cashless<br />Patients<br />0 Patients</b><br /><br />";
                    return;
                }
                for (int i = 0; i < odt.Rows.Count; i++)
                {
                    DataSet1.opdformRow or = (DataSet1.opdformRow)odt.Rows[i];
                    if (or.patientno == 1)
                        continue;
                    if (or.patienttype == 1)
                        geetaCounter++;
                    else if (or.patienttype == 2)
                        ayushCounter++;
                    else
                        cashCounter++;
                }
                lblOPDGeetanjaliPatients.InnerHtml = "<br /><b>Geetanjali<br>Patients<br />" + geetaCounter + " Patients</b><br /><br />";
                lblOPDAyushmanPatients.InnerHtml = "<br /><b>Ayushman<br>Patients<br />" + ayushCounter + " Patients</b><br /><br />";
                lblOPDCashlessPatients.InnerHtml = "<br /><b>Cashless<br>Patients<br />" + cashCounter + " Patients</b><br /><br />";
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }

        public void getIPDPatients(object sender, EventArgs e)
        {
            if (patientIPDDiv.Visible)
            {
                patientIPDDiv.Visible = false;
                btnIPDPatientDetails.Text = "IPD Patients Data<b><i class='fa fa-angle-down w3-circle highlight w3-right w3-gray w3-text-light-gray w3-hover-text-gray w3-padding'></i></b>";
                //patientData.InnerHtml = "";
            }
            else
            {
                patientIPDDiv.Visible = true;
                btnIPDPatientDetails.Text = "IPD Patients Data<b><i class='fa fa-angle-up w3-circle highlight w3-right w3-gray w3-text-light-gray w3-hover-text-gray w3-padding'></i></b>";
                rdoListTime2_SelectedIndexChanged(sender, e);
            }
        }
        protected void rdoListTime2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(rdoListTime2.SelectedValue);
                IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter ita = new IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter();
                DataSet1.ipdformDataTable idt;
                DateTime from, to;
                int geetaCounter = 0, ayushCounter = 0, cashCounter = 0;
                DateTime dt = System.DateTime.Now;
                dt = dt.AddHours(12.5);
                switch (value)
                {
                    case 1:
                        {
                            from = dt;
                            to = dt;
                            idt = ita.GetPatientsWithinDate(from, to);
                            break;
                        }
                    case 2:
                        {
                            to = dt;
                            TimeSpan ts = System.TimeSpan.FromDays(7.0);
                            dt = dt.Subtract(ts);
                            from = dt;
                            idt = ita.GetPatientsWithinDate(from, to);
                            break;
                        }
                    case 3:
                        {
                            to = dt;
                            from = Convert.ToDateTime(dt.Month + "/1/" + dt.Year);
                            idt = ita.GetPatientsWithinDate(from, to);
                            break;
                        }
                    case 4:
                        {
                            idt = ita.GetData();
                            break;
                        }
                    default:
                        {
                            throw new Exception();
                        }
                }
                if (idt.Rows.Count <= 0)
                {
                    lblIPDGeetanjaliPatients.InnerHtml = "<br /><b>Geetanjali<br />Patients<br />0 Patients</b><br /><br />";
                    lblIPDAyushmanPatients.InnerHtml = "<br /><b>Ayushman<br />Patients<br />0 Patients</b><br /><br />";
                    lblIPDCashlessPatients.InnerHtml = "<br /><b>Cashless<br />Patients<br />0 Patients</b><br /><br />";
                    return;
                }
                for (int i = 0; i < idt.Rows.Count; i++)
                {
                    DataSet1.ipdformRow ir = (DataSet1.ipdformRow)idt.Rows[i];
                    int pt = Patient.getPatienType(ir.patientno);
                    /*if (pt == 1)
                        continue;*/
                    if (pt == 1)
                        geetaCounter++;
                    else if (pt == 2)
                        ayushCounter++;
                    else
                        cashCounter++;
                }
                lblIPDGeetanjaliPatients.InnerHtml = "<br /><b>Geetanjali<br>Patients<br />" + geetaCounter + " Patients</b><br /><br />";
                lblIPDAyushmanPatients.InnerHtml = "<br /><b>Ayushman<br>Patients<br />" + ayushCounter + " Patients</b><br /><br />";
                lblIPDCashlessPatients.InnerHtml = "<br /><b>Cashless<br>Patients<br />" + cashCounter + " Patients</b><br /><br />";
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }

        public void getDisPatients(object sender, EventArgs e)
        {
            if (patientDisDiv.Visible)
            {
                patientDisDiv.Visible = false;
                btnDisPatientDetails.Text = "Discharged Patients Data<b><i class='fa fa-angle-down w3-circle highlight w3-right w3-gray w3-text-light-gray w3-hover-text-gray w3-padding'></i></b>";
                //patientData.InnerHtml = "";
            }
            else
            {
                patientDisDiv.Visible = true;
                btnDisPatientDetails.Text = "Discharged Patients Data<b><i class='fa fa-angle-up w3-circle highlight w3-right w3-gray w3-text-light-gray w3-hover-text-gray w3-padding'></i></b>";
                rdoListTime3_SelectedIndexChanged(sender, e);
            }
        }
        protected void rdoListTime3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(rdoListTime3.SelectedValue);
                IOPD.DataManager.DataSet1TableAdapters.dischargeTableAdapter dta = new IOPD.DataManager.DataSet1TableAdapters.dischargeTableAdapter();
                DataSet1.dischargeDataTable ddt;
                DateTime from, to;
                int geetaCounter = 0, ayushCounter = 0, cashCounter = 0;
                DateTime dt = System.DateTime.Now;
                dt = dt.AddHours(12.5);
                switch (value)
                {
                    case 1:
                        {
                            from = dt;
                            to = dt;
                            ddt = dta.GetDataWithinDate(from, to);
                            break;
                        }
                    case 2:
                        {
                            to = dt;
                            TimeSpan ts = System.TimeSpan.FromDays(7.0);
                            dt = dt.Subtract(ts);
                            from = dt;
                            ddt = dta.GetDataWithinDate(from, to);
                            break;
                        }
                    case 3:
                        {
                            to = dt;
                            from = Convert.ToDateTime(dt.Month + "/1/" + dt.Year);
                            ddt = dta.GetDataWithinDate(from, to);
                            break;
                        }
                    case 4:
                        {
                            ddt = dta.GetData();
                            break;
                        }
                    default:
                        {
                            throw new Exception();
                        }
                }
                if (ddt.Rows.Count <= 0)
                {
                    lblDisGeetanjaliPatients.InnerHtml = "<br /><b>Geetanjali<br />Patients<br />0 Patients</b><br /><br />";
                    lblDisAyushmanPatients.InnerHtml = "<br /><b>Ayushman<br />Patients<br />0 Patients</b><br /><br />";
                    lblDisCashlessPatients.InnerHtml = "<br /><b>Cashless<br />Patients<br />0 Patients</b><br /><br />";
                    return;
                }
                for (int i = 0; i < ddt.Rows.Count; i++)
                {
                    DataSet1.dischargeRow dr = (DataSet1.dischargeRow)ddt.Rows[i];
                    int pt = Patient.getPatienType(dr.patientno);
                    /*if (pt == 1)
                        continue;*/
                    if (pt == 1)
                        geetaCounter++;
                    else if (pt == 2)
                        ayushCounter++;
                    else
                        cashCounter++;
                }
                lblDisGeetanjaliPatients.InnerHtml = "<br /><b>Geetanjali<br>Patients<br />" + geetaCounter + " Patients</b><br /><br />";
                lblDisAyushmanPatients.InnerHtml = "<br /><b>Ayushman<br>Patients<br />" + ayushCounter + " Patients</b><br /><br />";
                lblDisCashlessPatients.InnerHtml = "<br /><b>Cashless<br>Patients<br />" + cashCounter + " Patients</b><br /><br />";
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }
    }
}