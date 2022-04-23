using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class prescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.HasKeys())
            {
                int treatNo = Convert.ToInt32(Request.QueryString["treatno"]);
                int pno;
                if (treatNo != 0)
                {
                    IOPD.DataManager.DataSet1TableAdapters.treatementTableAdapter tta = new IOPD.DataManager.DataSet1TableAdapters.treatementTableAdapter();
                    DataSet1.treatementDataTable tdt = tta.GetDataBySno(treatNo);
                    DataSet1.treatementRow tr = (DataSet1.treatementRow)tdt.Rows[0];
                    pno = tr.patientno;
                    Patient p = new Patient(pno);
                    txtName.Text = p.firstname + " " + p.lastname;
                    txtAge.Text = p.ageyears + "Y " + p.agemonths + "M " + p.agedays + "D";
                    txtAddress.Text = p.address;
                    txtDate.Text = DateUtilities.onlyDateFormat(tr.dateOfEntry + "");
                    txtPresType.Text = tr.nameOfTreatement;
                    txtPresData.InnerText = tr.details;
                }
                else
                {
                    pno = Convert.ToInt32(Request.QueryString["pNo"]);
                    Patient p = new Patient(pno);
                    txtName.Text = p.firstname + " " + p.lastname;
                    txtAge.Text = p.ageyears + "Y " + p.agemonths + "M " + p.agedays + "D";
                    txtAddress.Text = p.address;
                }
            }
        }
    }
}