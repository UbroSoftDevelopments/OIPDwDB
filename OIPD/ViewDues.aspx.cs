using System;
using System.Data;
using IOPD.DataManager;

namespace OIPD
{
    public partial class ViewDues : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IP Number");
            dt.Columns.Add("Patient Name");
            dt.Columns.Add("Amount Applied");
            dt.Columns.Add("Amount Paid");
            dt.Columns.Add("Amount Discount");
            dt.Columns.Add("Amount Due");
            double totalDue = 0;
            IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter ota = new IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter();
            DataSet1.opdformDataTable odt = ota.GetData();
            for (int i = odt.Rows.Count - 1; i >= 0; i--)
            {
                DataSet1.opdformRow or = (DataSet1.opdformRow)odt.Rows[i];
                chargesUtilities.getAllChargesAtOnce(or.patientno, grdDues);
                int totalChargesAplied = chargesUtilities.totalExpenses;
                int totalPaid = chargesUtilities.getTotalPayments(or.patientno);
                double discount = chargesUtilities.getTotalDiscounts(or.patientno);
                double amount_due = totalChargesAplied - (totalPaid + discount);
                if (amount_due > 0)
                {
                    totalDue += amount_due;
                    DataRow dr = dt.NewRow();
                    dr[0] = or.ipnumber;
                    dr[1] = or.title + " " + or.firstname + " " + or.lastname;
                    dr[2] = totalChargesAplied;
                    dr[3] = totalPaid;
                    dr[4] = discount;
                    dr[5] = amount_due;
                    dt.Rows.Add(dr);
                }
            }
            grdDues.DataSource = dt;
            grdDues.DataBind();
            lblTotalDues.Text = "Total Rs." + totalDue + "/- Due";
        }
    }
}