using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class RegistrationUtilities
    {
        public static string GetRegistrationNo(int patientno)
        {
            try
            {
                //Patient patient = new Patient(patientno);
                DataSet1TableAdapters.opdformTableAdapter ota = new DataSet1TableAdapters.opdformTableAdapter();
                DataSet1.opdformDataTable odt = ota.GetDataByPatientNo(patientno);
                DataSet1.opdformRow or = (DataSet1.opdformRow)odt.Rows[0];
                //string regnoformat="{0}/{1}/{2}/{3}/{4}";
                //string output=string.Format(regnoformat,LoginManager.getRandomPrefix(),(patient.dateofentry.Year%100),patient.dateofentry.Month,patient.dateofentry.Day,patient.patientno+936);
                return or.ipnumber;//output;
            }
            catch (Exception ex)
            {
                return "" + ex.Message;
            }
        }

        public static string GetPatientNo(string patientid)
        {

            try
            {
                string[] parts = patientid.Split(new char[] { '/' });
                return parts[parts.Length - 1];
            }
            catch
            {
                return "";
            }
        }
    }
}
