using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class printPaymentBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            int sno = Convert.ToInt32("" + Request.QueryString["patientno"]);
            Patient patient = new Patient(sno);
            regNumber.Text = RegistrationUtilities.GetRegistrationNo(sno);

            IOPD.DataManager.DataSet1TableAdapters.dischargeTableAdapter dta = new IOPD.DataManager.DataSet1TableAdapters.dischargeTableAdapter();
            DataSet1.dischargeDataTable ddt = dta.GetDataByPatientno(sno);
            if (ddt.Rows.Count != 0)
                billHead.InnerText = "      Bill      ";
            else
                billHead.InnerText = "      Estimated Bill      ";

            IOPD.DataManager.DataSet1TableAdapters.expensesTableAdapter eta = new IOPD.DataManager.DataSet1TableAdapters.expensesTableAdapter();
            DataSet1.expensesDataTable edt = eta.GetDataByPatientNo(sno);
            IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter pta = new IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter();
            DataSet1.paymentsDataTable pdt = pta.GetDataByPatientno(sno);
            DateTime dt = System.DateTime.Now;
            dt = dt.AddHours(12.50);
            string lastPaymentDate = "" + dt;

            lblfirstname.Text = patient.firstname;
            lbllastname.Text = patient.lastname;
            lblfather_w_o.Text = patient.fathername;
            int totalExp = 0, totalPay = 0;
            /*for (int i = 0; i < edt.Rows.Count; i++)
            {
                DataSet1.expensesRow er = (DataSet1.expensesRow)edt.Rows[i];
                lblExpDate.Text += DateUtilities.dateFormat(er.dateofexpense)+"<br/>";
                lblExpPart.Text +=""+ er.comments+"<br/>";
                lblExpAmt.Text += ""+er.amount+"<br/>";
                totalExp += Convert.ToInt32(er.amount);
            }*/
            chargesUtilities.getAllChargesAtOnce(sno, gvExpenses);
            totalExp = chargesUtilities.totalExpenses;

            for (int i = 0; i < pdt.Rows.Count; i++)
            {
                DataSet1.paymentsRow er = (DataSet1.paymentsRow)pdt.Rows[i];
                lblpyDate.Text += DateUtilities.dateFormat(er.dateofpayment) + "<br/>";
                lblpyPart.Text += "" + er.comments + "<br/>";
                lblpyAmt.Text += "" + er.amount + "<br/>";
                if (i == pdt.Rows.Count - 1)
                    lastPaymentDate = DateUtilities.dateFormat(er.dateofpayment);
                totalPay += Convert.ToInt32(er.amount);
            }
            dateOfEntry.Text = "" + lastPaymentDate;
            //lblExpTotalAmt.Text = ""+totalExp;
            double totalDiscount = 0;
            IOPD.DataManager.DataSet1TableAdapters.discountdataTableAdapter discta = new IOPD.DataManager.DataSet1TableAdapters.discountdataTableAdapter();
            DataSet1.discountdataDataTable discdt = discta.GetDataByPatientno(sno);
            if (discdt.Rows.Count != 0)
            {
                for (int x = 0; x < discdt.Rows.Count; x++)
                {
                    DataSet1.discountdataRow discr = (DataSet1.discountdataRow)discdt.Rows[x];
                    totalDiscount += discr.discountamount;
                }
            }

            lblpyTotalAmt.Text = "" + totalPay;

            if (totalDiscount > 0)
            {
                gvExpenses.ShowFooter = true;
                gvExpenses.FooterRow.Cells[1].Text = "Discount<br /><b>Net Total</b>";
                gvExpenses.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                gvExpenses.FooterRow.Cells[2].Text = "-" + totalDiscount + "<br /><b>" + (totalExp - totalDiscount) + "</b>";
            }
            else
                gvExpenses.ShowFooter = false;

            if (totalExp > (totalPay + totalDiscount))
            {
                lblDueExtra.Text = "<b>Amount Due -:</b>";
                int due = totalExp - (totalPay + (int)totalDiscount);
                lblDueExtraAmount.Text = " <b>" + due.ToString() + "/-</b>";
            }
            else
                if (totalExp < (totalPay + totalDiscount))
            {
                lblDueExtra.Text = "<b>Amount Extra -:</b>";
                int excess = (totalPay + (int)totalDiscount) - totalExp;
                lblDueExtraAmount.Text = " <b>" + excess.ToString() + "/-</b>";
            }
            else
            {
                lblDueExtra.Text = "<b>Amount Due -:</b>";
                int excess = (totalPay + (int)totalDiscount) - totalExp;
                lblDueExtraAmount.Text = " <b>" + excess.ToString() + "/-</b>";
            }

        }
    }
}