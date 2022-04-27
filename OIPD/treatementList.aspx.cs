using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class treatementList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            if (!this.IsPostBack)
            {
                txtStartDate.Text = DateUtilities.dateFormat("1/1/2018 12:00");
                DateTime dt = System.DateTime.Now;
                dt = dt.AddHours(12.50);
                txtEndDate.Text = "" + dt;
            }
        }
    }
}