using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class xraypathUtils
    {
        public xraypathUtils()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static int serial;
        public static int getNewSerial()
        {
            DataSet1TableAdapters.xraypathpetientTableAdapter dt = new DataSet1TableAdapters.xraypathpetientTableAdapter();
            DataSet1.xraypathpetientDataTable dd = dt.GetData();
            if (dd.Rows.Count == 0)
                return 1;
            else
            {
                DataSet1.xraypathpetientRow dr = (DataSet1.xraypathpetientRow)dd.Rows[0];
                int sno = dr.sno;
                return sno + 1;
            }
        }
    }
}
