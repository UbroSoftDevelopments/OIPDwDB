using IOPD.DataManager;
using System;

namespace OIPD
{
    public partial class departmentlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            DateTime now = System.DateTime.Now;
            now = now.AddHours(12.50);
            bool startRangeHour = (now.Hour <= 8);// && ((now.ToString("tt")).Equals("AM"));
            bool startRangeMin = (now.Minute >= 1);// && ((now.ToString("tt")).Equals("AM"));
            bool endRangeHour = (now.Hour >= 14);// && ((now.ToString("tt")).Equals("PM"));
            bool endRangeMin = (now.Minute >= 1);// && ((now.ToString("tt")).Equals("AM"));
                                                 //Title = "" + startRangeHour + "   " + endRangeHour + "   " + now + " " + now.ToString("tt");
            if (startRangeHour)
            {
                if (!startRangeMin)
                    Response.Redirect("emergency.aspx");
            }
            else if (endRangeHour)
            {
                if (endRangeMin)
                    Response.Redirect("emergency.aspx");
            }
        }
    }
}