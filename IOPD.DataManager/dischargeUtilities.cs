using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class dischargeUtilities
    {
        public dischargeUtilities()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static bool isPatientHalfDischarged(int patientno)
        {
            DataSet1TableAdapters.tempDischargeTableAdapter tdta = new DataSet1TableAdapters.tempDischargeTableAdapter();
            DataSet1.tempDischargeDataTable tddt = tdta.GetHalfDischargedData(patientno);
            if (tddt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static void deleteDischargedPatient(int patientno)
        {
            DataSet1TableAdapters.tempDischargeTableAdapter tdta = new DataSet1TableAdapters.tempDischargeTableAdapter();
            tdta.DeleteDischargedPatient(patientno);
        }
    }
}
