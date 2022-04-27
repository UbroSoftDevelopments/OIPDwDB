using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
	public partial class dischargedPatient : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
        }
        protected void searching(object sender, EventArgs e)
        {
            try
            {
                string name = txtPatientNumber.Text;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "" + ex.Message;
            }
        }
    }
}