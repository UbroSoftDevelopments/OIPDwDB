using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class patientData : System.Web.UI.Page
    {
        Patient patient;
        int totalPayments = 0, totalExpenses = 0, totaldiscounts = 0, patientno;
        protected void Page_Load(object sender, EventArgs e)
        {

            /*bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;*/
            if (!Request.QueryString.HasKeys())
            {
                Response.Redirect("searchPatient.aspx");
                return;
            }
            patientno = Convert.ToInt32("" + Request.QueryString["patientno"]);
            patient = new Patient(patientno);

            opdDetailsClick(sender, e);
        }
        public void setAmountDue()
        {
            if (totalExpenses > (totalPayments + totaldiscounts))
            {
                lblamount.Text = "<b>Amount Due -:</b>";
                int due = totalExpenses - (totalPayments + totaldiscounts);
                lblDueAmount.Text = " <b>" + due.ToString() + "/-</b>";
            }
            else
                if (totalExpenses < (totalPayments + totaldiscounts))
            {
                lblamount.Text = "<b>Amount Extra -:</b>";
                int excess = (totalPayments + totaldiscounts) - totalExpenses;
                lblDueAmount.Text = " <b>" + excess.ToString() + "/-</b>";
            }
            else
            {
                lblamount.Text = "<b>Amount Due -:</b>";
                int excess = (totalPayments + totaldiscounts) - totalExpenses;
                lblDueAmount.Text = " <b>" + excess.ToString() + "/-</b>";
            }
        }

        private void BindPaymentsGrid()
        {
            IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter eta = new IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter();
            DataSet1.paymentsDataTable edt = eta.GetDataByPatientno(Convert.ToInt32("" + Request.QueryString["patientno"]));
            int total = 0;
            for (int x = 0; x < edt.Rows.Count; x++)
            {
                DataSet1.paymentsRow er = (DataSet1.paymentsRow)edt.Rows[x];
                total = total + Convert.ToInt32("" + er.amount);
            }
            totalPayments = total;
            GridView1.FooterRow.Cells[1].Text = "Total";
            GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            GridView1.FooterRow.Cells[2].Text = "<i class=\"fa fa-inr\"/> <b>" + total.ToString() + "/-</b>";
            GridView1.FooterRow.Cells[2].CssClass = "w3-large";
        }
        private void BindDiscountsGrid()
        {
            int total = 0;
            IOPD.DataManager.DataSet1TableAdapters.discountdataTableAdapter dta = new IOPD.DataManager.DataSet1TableAdapters.discountdataTableAdapter();
            DataSet1.discountdataDataTable ddt = dta.GetDataByPatientno(Convert.ToInt32("" + Request.QueryString["patientno"]));
            if (ddt.Rows.Count <= 0)
            {
                total = 0;
                totaldiscounts = 0;
                return;
            }
            else
            {
                for (int x = 0; x < ddt.Rows.Count; x++)
                {
                    DataSet1.discountdataRow ddr = (DataSet1.discountdataRow)ddt.Rows[x];
                    total += (int)ddr.discountamount;
                }
            }
            totaldiscounts = total;
            GridView3.FooterRow.Cells[1].Text = "Total";
            GridView3.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            GridView3.FooterRow.Cells[2].Text = "<i class=\"fa fa-inr\"/> <b>" + total.ToString() + "/-</b>";
            GridView3.FooterRow.Cells[2].CssClass = "w3-large";
        }
        private void bindTotalCharges()
        {
            int pno = Convert.ToInt32("" + Request.QueryString["patientno"]);
            chargesUtilities.getAllChargesAtOnce(pno, totalCharges);
            totalExpenses = chargesUtilities.totalExpenses;
        }

        public void opdDetailsClick(object sender, EventArgs e)
        {
            btnOPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonClicked w3-text-white tealDark w3-large";
            btnIPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnDischargeDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnTreatementDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnDocuments.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnAmountDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";

            opdData.Visible = true;
            ipdData.Visible = false;
            dischargeData.Visible = false;
            treatementData.Visible = false;
            documentData.Visible = false;
            amountData.Visible = false;

            if (!patient.isValidPatient())
            {
                opdData.InnerHtml = "<b>No Such Patient Found</b>";
                return;
            }
            lblIPNumber.Text = patient.ipnumber;
            lblPatientType.Text = patient.getPatientTypeName(patient.patienttype);
            lblPatient.Text = patient.title + " " + patient.firstname + " " + patient.lastname;
            lblDate.Text = patient.dateofentry + "";
            lblGender.Text = patient.gender;
            lblAge.Text = patient.ageyears + "Y " + patient.agemonths + "M " + patient.agedays + "D";
            lblAddress.Text = patient.address;
            lblMobile.Text = patient.mobileno;
            lblDepart.Text = patient.getDepartmentName();
            lblRef.Text = patient.referredfrom;

            IOPD.DataManager.DataSet1TableAdapters.patientDocsTableAdapter pdta = new IOPD.DataManager.DataSet1TableAdapters.patientDocsTableAdapter();
            DataSet1.patientDocsDataTable pddt = pdta.GetDataByPatientNoAndDocName(patientno, "profile");
            if (pddt.Rows.Count != 0)
            {
                DataSet1.patientDocsRow pdr = (DataSet1.patientDocsRow)pddt.Rows[0];
                imgPatientPic.Src = pdr.docSource;
            }

        }
        public void ipdDetailsClick(object sender, EventArgs e)
        {
            btnIPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonClicked w3-text-white tealDark w3-large";
            btnOPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnDischargeDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnTreatementDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnDocuments.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnAmountDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";

            opdData.Visible = false;
            ipdData.Visible = true;
            dischargeData.Visible = false;
            treatementData.Visible = false;
            documentData.Visible = false;
            amountData.Visible = false;

            IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter ita = new IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter();
            DataSet1.ipdformDataTable idt = ita.GetDataByPatientNo(patientno);
            if (idt.Rows.Count != 0)
            {
                DataSet1.ipdformRow ir = (DataSet1.ipdformRow)idt.Rows[0];
                int sno = ir.bedno;
                PatientUtilities.getPatientBedDetailsByBed(sno);
                lblWard.Text = "" + PatientUtilities.wardname;
                lblRoom.Text = "" + PatientUtilities.roomno;
                lblBed.Text = "" + PatientUtilities.bedno;
                lblReason.Text = "" + ir.comments;
                lblDoctor.Text = PatientUtilities.getDoctorIncharge(patientno);
                lblIPDDate.Text = DateUtilities.dateFormat(ir.dateofentry + "");
                IOPD.DataManager.DataSet1TableAdapters.packageTableAdapter pta = new IOPD.DataManager.DataSet1TableAdapters.packageTableAdapter();
                DataSet1.packageDataTable pdt = pta.GetDataByPatientno(patientno);
                if (pdt.Rows.Count <= 0)
                    lblChargedAs.Text = "Normal";
                else
                {
                    DataSet1.packageRow pr = (DataSet1.packageRow)pdt.Rows[0];
                    lblChargedAs.Text = "" + pr.packagename + "-Rs." + pr.packageamount;
                }
            }
            else
            {
                ipdData.InnerHtml = "<b>No IPD Data Found Of This Patient</b>";
            }
        }
        public void dischargeDetailsClick(object sender, EventArgs e)
        {
            btnDischargeDetails.CssClass = "w3-padding-24 w3-border-0 buttonClicked w3-text-white tealDark w3-large";
            btnIPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnOPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnTreatementDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnDocuments.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnAmountDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";

            opdData.Visible = false;
            ipdData.Visible = false;
            dischargeData.Visible = true;
            treatementData.Visible = false;
            documentData.Visible = false;
            amountData.Visible = false;

            IOPD.DataManager.DataSet1TableAdapters.dischargeTableAdapter dta = new IOPD.DataManager.DataSet1TableAdapters.dischargeTableAdapter();
            DataSet1.dischargeDataTable ddt = dta.GetDataByPatientno(patientno);
            if (ddt.Rows.Count != 0)
            {
                DataSet1.dischargeRow dr = (DataSet1.dischargeRow)ddt.Rows[0];
                lblDischargeDate.Text = DateUtilities.dateFormat(dr.dateofdischarge);
                lblDischargeApproved.Text = "" + dr.approved;
                lblDischargeTreat.Text = "" + dr.furthertreatment;
                lblDischargeReason.Text = "" + dr.reason;
                lblDischargeBy.Text = "" + dr.dischargingphysician;

                lblChiefComplain.Text = "" + dr.chiefComplaint;
                lblPhysical.Text = "" + dr.physicalFindings;
                lblInvestigation.Text = "" + dr.investigation;
                lblTreatement.Text = "" + dr.treatement;
                lblOperation.Text = "" + dr.operation;
                lblBiopsy.Text = "" + dr.biopsyReport;
                lblFinal.Text = "" + dr.finalDiagonosis;
                lblResult.Text = "" + dr.result;
                lblInstruction.Text = "" + dr.instruction;
                lblDischargeMedicine.Text = "" + dr.dischargemedicine;
            }
            else
            {
                dischargeData.InnerHtml = "<b>No Discharge Data Found Of This Patient</b>";
            }
        }
        public void treatementDetailsClick(object sender, EventArgs e)
        {
            btnTreatementDetails.CssClass = "w3-padding-24 w3-border-0 buttonClicked w3-text-white tealDark w3-large";
            btnIPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnDischargeDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnOPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnDocuments.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnAmountDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";

            opdData.Visible = false;
            ipdData.Visible = false;
            dischargeData.Visible = false;
            treatementData.Visible = true;
            documentData.Visible = false;
            amountData.Visible = false;
        }
        public void documentDetailsClick(object sender, EventArgs e)
        {
            btnDocuments.CssClass = "w3-padding-24 w3-border-0 buttonClicked w3-text-white tealDark w3-large";
            btnIPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnDischargeDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnTreatementDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnOPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnAmountDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";

            opdData.Visible = false;
            ipdData.Visible = false;
            dischargeData.Visible = false;
            treatementData.Visible = false;
            documentData.Visible = true;
            amountData.Visible = false;

            IOPD.DataManager.DataSet1TableAdapters.patientDocsTableAdapter pdta = new IOPD.DataManager.DataSet1TableAdapters.patientDocsTableAdapter();
            DataSet1.patientDocsDataTable pddt = pdta.GetDocsByPatientNo(patientno);
            if (pddt.Rows.Count <= 0)
            {
                documentData.InnerHtml = "<b>No Documents Found Of This Patient<br /><a TARGET='_blank' href='upload.aspx?sno=" + patientno + "' class='w3-button w3-teal'>Click Here</a> to Upload</b>";
            }
            else
            {
                string output = "" +
                "<div class='w3-padding w3-xlarge w3-center w3-teal'>" +
                    "<b>DOCUMENTS</b>" +
                "</div>" +
                "<br style='line-height:0.5' />" +
                "<div class='w3-circle w3-black w3-card-2' style='height:3px'></div>" +
                "<br style='line-height:0.5' /><div>";
                for (int i = 0; i < pddt.Rows.Count; i++)
                {
                    DataSet1.patientDocsRow pdr = (DataSet1.patientDocsRow)pddt.Rows[i];
                    string docName = pdr.docName;
                    string src = pdr.docSource;
                    src = src.Replace(" ", "%20");
                    if (docName.Equals("profile"))
                        continue;
                    string downloadLink = "<a download href='" + src + "' class='w3-button w3-purple w3-text-small'><i class='fa fa-arrow-down'> </i></a>&nbsp;&nbsp;";
                    string deleteButton = "<div id='del' onclick='checking(\"" + pdr.sno + "\")' class='w3-button w3-purple w3-text-small'><i class='fa fa-trash'> </i></div><br /><br style='line-height:0.5' />";
                    output += "<div class='w3-col s3 w3-padding w3-center'><div class='w3-card-4'><label>" + docName + "</label><br /><img onclick='displayImage(\"" + src + "\")' src=" + src + " alt=" + docName + " style='cursor:pointer' width='100%'><br />" + downloadLink + deleteButton + "</div></div>";
                }
                output += "</div><div class='w3-clear'>&nbsp;</div>";
                documentData.InnerHtml = output;
            }
        }
        public void amountDetailsClick(object sender, EventArgs e)
        {
            btnAmountDetails.CssClass = "w3-padding-24 w3-border-0 buttonClicked w3-text-white tealDark w3-large";
            btnIPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnDischargeDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnTreatementDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnDocuments.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";
            btnOPDDetails.CssClass = "w3-padding-24 w3-border-0 buttonUnclicked w3-text-white w3-teal w3-large";

            opdData.Visible = false;
            ipdData.Visible = false;
            dischargeData.Visible = false;
            treatementData.Visible = false;
            documentData.Visible = false;
            amountData.Visible = true;

            this.bindTotalCharges();
            IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter pta = new IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter();
            DataSet1.paymentsDataTable pdt = pta.GetDataByPatientno(patientno);
            if (pdt.Rows.Count == 0)
            {
                GridView1.Visible = false;
            }
            else
            {
                GridView1.Visible = true;
                this.BindPaymentsGrid();
            }
            this.BindDiscountsGrid();
            setAmountDue();
        }

        [WebMethod]
        public static string removeDocument(string doc)
        {
            int docNumber = Convert.ToInt32(doc);
            IOPD.DataManager.DataSet1TableAdapters.patientDocsTableAdapter pdta = new IOPD.DataManager.DataSet1TableAdapters.patientDocsTableAdapter();
            pdta.DeleteQuery(docNumber);
            //btn.Text = "Clicked";
            return "success";
        }
    }
}