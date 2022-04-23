using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class PrintPad : System.Web.UI.Page
    {
        int sno = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerr.Text = "";
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            if (Request.QueryString.HasKeys())
            {
                sno = Convert.ToInt32(Request.QueryString["sno"]);
            }
        }
        protected void assign(object sender, EventArgs e)
        {
            try
            {
                /*if (txtdoc.Text.ToString().Equals(""))
                    throw new Exception("Enter Doctors Name");*/
                hypPrint.Visible = true;
                hypPrint.NavigateUrl = "pad.aspx?sno=" + sno + "&docname=" + txtdoc.Text;
            }
            catch (Exception ex)
            {
                Validation.setError(lblerr, ex);
            }
        }
    }
}