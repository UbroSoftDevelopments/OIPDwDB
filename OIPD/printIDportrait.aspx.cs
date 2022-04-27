using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class printIDportrait : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int sno = Convert.ToInt32(Request.QueryString["sno"]);
            IOPD.DataManager.DataSet1TableAdapters.staffTableAdapter sta = new IOPD.DataManager.DataSet1TableAdapters.staffTableAdapter();
            DataSet1.staffDataTable sdt = sta.GetDataBySno(sno);
            if (sdt.Rows.Count <= 0)
                Response.Redirect("generateID.aspx");
            DataSet1.staffRow sr = (DataSet1.staffRow)sdt.Rows[0];
            lblName.Text = sr.name;
            lblMobile.Text = sr.mobile_number;
            lblEmail.Text = sr.emailid;
            lblDesign.Text = sr.designation;
            lblDob.Text = DateUtilities.onlyDateFormat(sr.dob);
            staffPhoto.Src = sr.photo;
            lblBloodGroup.Text = sr.bloodgroup;
        }
    }
}