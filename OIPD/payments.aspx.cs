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
    public partial class payments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            if(!this.IsPostBack)*/
            getPayablePatients();
        }

        public void getPayablePatients()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IP No");
            dt.Columns.Add("Department");
            dt.Columns.Add("Patient Type");
            dt.Columns.Add("Date");
            dt.Columns.Add("Name");
            dt.Columns.Add("Age");
            DataColumn col = new DataColumn();
            dt.Columns.Add("Action");
            IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter ota = new IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter();
            DataSet1.opdformDataTable odt = ota.GetData();
            for (int i = odt.Rows.Count - 1; i >= 0; i--)
            {
                DataSet1.opdformRow or = (DataSet1.opdformRow)odt.Rows[i];
                chargesUtilities.getAllChargesAtOnce(or.patientno, tempGrid);
                int totalChargesAplied = chargesUtilities.totalExpenses;
                int totalPaid = chargesUtilities.getTotalPayments(or.patientno);
                double discount = chargesUtilities.getTotalDiscounts(or.patientno);
                double amount_due = totalChargesAplied - (totalPaid + discount);
                if (amount_due != 0)
                {
                    Patient p = new Patient(or.patientno);
                    DataRow dr = dt.NewRow();
                    dr[0] = p.ipnumber;
                    dr[1] = p.getDepartmentName();
                    dr[2] = p.getPatientTypeName(p.patienttype);
                    dr[3] = DateUtilities.onlyDateFormat(p.dateofentry + "");
                    dr[4] = p.title + " " + p.firstname + " " + p.lastname;
                    dr[5] = p.ageyears + "Y " + p.agemonths + "M " + p.agedays + "D";
                    dr[6] = p.patientno;
                    dt.Rows.Add(dr);
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            /*for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //HyperLink hl = new HyperLink();
                //hl.Text = "Receive Payments";
                //Response.Write(GridView1.Rows[0].Cells[5]+"<br />");
                //hl.NavigateUrl = "receivePayments.aspx?patientno=" + GridView1.Rows[i].Cells[5].Text;
                //GridView1.Rows[i].Cells[5].Controls.Add(hl);
            }*/
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HyperLink hl = new HyperLink();
            hl.Text = "Receive Payments";
            hl.NavigateUrl = "receivePayments.aspx?patientno=" + e.Row.Cells[6].Text;
            if (!(e.Row.Cells[6].Text).Equals("Action"))
                e.Row.Cells[6].Controls.Add(hl);
        }
    }
}