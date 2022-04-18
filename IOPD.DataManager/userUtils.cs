using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace IOPD.DataManager
{
   public class userUtils
    {
        public static List<TextBox> txtData = new List<TextBox>();
        public static List<TextBox> txtAmt = new List<TextBox>();
        public static string pass = "";
        public userUtils()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string getusertype(int sno)
        {
            DataSet1TableAdapters.usertypeTableAdapter uta = new DataSet1TableAdapters.usertypeTableAdapter();
            DataSet1.usertypeDataTable udt = uta.GetDataBySno(sno);
            DataSet1.usertypeRow ur = (DataSet1.usertypeRow)udt.Rows[0];
            return ur.type;
        }
        public static string getuserstatus(string user)
        {
            DataSet1TableAdapters.siteusersTableAdapter sta = new DataSet1TableAdapters.siteusersTableAdapter();
            DataSet1.siteusersDataTable sdt = sta.GetDataByUserName(user);
            DataSet1.siteusersRow sr = (DataSet1.siteusersRow)sdt.Rows[0];
            if (sr.status.Equals("active"))
                return "Make Inactive";
            else
                return "Make Active";
        }
    }
}
