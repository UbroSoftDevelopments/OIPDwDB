using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class Renewal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;

        }
        protected void searching(object sender, EventArgs e)
        {
        }
        protected void check(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int sno = Convert.ToInt32(bt.CommandArgument);
            IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter();
            DataSet1.opdformDataTable dt = da.GetDataByPatientNo(sno);
            DataSet1.opdformRow dr = (DataSet1.opdformRow)dt.Rows[0];
            DateTime renewDate = dr.nextrenewdate;
            DateTime dat = System.DateTime.Now;
            dat = dat.AddHours(12.50);
            bool b = renewDate < dat;
            //lblErrMsg.Text = System.DateTime.Now+" RenD="+ renewDate+" Val=" + b;
            if (b)
            {
                Response.Redirect("renewform.aspx?sno=" + dr.patientno);
            }
            else
            {
                lblErrMsg.Text = "This form is valid till " + DateUtilities.dateFormat(renewDate);
            }
        }
    }
}