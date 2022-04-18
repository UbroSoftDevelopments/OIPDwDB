using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class bedUtilities
    {
        public static string allotBed(int patientno, int bedno, DateTime date, string comments, string user)
        {
            try
            {
                DataSet1TableAdapters.bedmasterTableAdapter bmdt = new DataSet1TableAdapters.bedmasterTableAdapter();
                DataSet1TableAdapters.bedallotmentTableAdapter bata = new DataSet1TableAdapters.bedallotmentTableAdapter();

                bmdt.UpdatedBedPatient(patientno, bedno);
                bata.InsertQuery(bedno, patientno, date, comments, user);

                return "successfull";
            }
            catch
            {
                return "unsuccessfull";
            }
        }
        public static string leaveBed(int bedno, DateTime date, int patientno, string comments, string user)
        {
            try
            {
                DataSet1TableAdapters.bedmasterTableAdapter bmdt = new DataSet1TableAdapters.bedmasterTableAdapter();
                DataSet1TableAdapters.bedallotmentTableAdapter bata = new DataSet1TableAdapters.bedallotmentTableAdapter();
                DataSet1TableAdapters.bedleavingTableAdapter blta = new DataSet1TableAdapters.bedleavingTableAdapter();

                bmdt.UpdatedBedPatient(1, bedno);
                DataSet1.bedallotmentDataTable badt = bata.GetDataByBedNo(bedno);
                for (int i = 0; i < badt.Rows.Count; i++)
                {
                    DataSet1.bedallotmentRow bar = (DataSet1.bedallotmentRow)badt.Rows[i];
                    DataSet1.bedleavingDataTable bldt = blta.GetDataByAllotmentNo(bar.sno);
                    if (bldt.Rows.Count > 0)
                        continue;
                    else
                        blta.Insert(bar.sno, date, comments, patientno, user);
                }
                return "successfull";
            }
            catch (Exception ex)
            {
                return "" + ex.Message;
            }
        }

        public static string transferBed(int oldBedNo, int newBedno, int patientno, DateTime date, string comments, string user)
        {
            try
            {
                String res = leaveBed(oldBedNo, date, patientno, comments, user);
                if (res.Equals("unsuccessfull"))
                    return res;
                allotBed(patientno, newBedno, date, comments, user);
                return "successfull";
            }
            catch
            {
                return "unsuccessfull";
            }
        }
        public static int totalbeds()
        {
            DataSet1TableAdapters.bedmasterTableAdapter bmta = new DataSet1TableAdapters.bedmasterTableAdapter();
            DataSet1.bedmasterDataTable bmdt = bmta.GetData();
            return bmdt.Rows.Count;
        }
    }
}
