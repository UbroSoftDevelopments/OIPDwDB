using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class PatientUtilities
    {
        public static int bedsno;
        public static string roomno, wardname, bedno;
        public static string getpatientname(int patientno)
        {
            try
            {
                if (patientno <= 1)
                    return "Vacant";
                Patient patient = new Patient(patientno);
                return patient.firstname + " " + patient.lastname;
            }
            catch (Exception ex)
            {

                return "" + ex;
            }
        }
        public static void getPatientBedDetails(int patientno)
        {
            try
            {
                DataSet1TableAdapters.bedmasterTableAdapter bmta = new DataSet1TableAdapters.bedmasterTableAdapter();
                DataSet1TableAdapters.roommasterTableAdapter rmta = new DataSet1TableAdapters.roommasterTableAdapter();
                DataSet1TableAdapters.wardmasterTableAdapter wmta = new DataSet1TableAdapters.wardmasterTableAdapter();

                DataSet1.bedmasterDataTable bmdt = bmta.GetDataByPatientNo(patientno);
                DataSet1.bedmasterRow bmr = (DataSet1.bedmasterRow)bmdt.Rows[0];
                bedno = bmr.bedno;
                bedsno = bmr.sno;

                DataSet1.roommasterDataTable rmdt = rmta.GetDataBySno(bmr.roomno);
                DataSet1.roommasterRow rmr = (DataSet1.roommasterRow)rmdt.Rows[0];
                roomno = rmr.roomno;

                DataSet1.wardmasterDataTable wmdt = wmta.GetDataBy(rmr.wardno);
                DataSet1.wardmasterRow wmr = (DataSet1.wardmasterRow)wmdt.Rows[0];
                wardname = wmr.wardname;
            }
            catch
            {

            }
        }
        public static void getPatientBedDetailsByBed(int sno)
        {
            try
            {
                DataSet1TableAdapters.bedmasterTableAdapter bmta = new DataSet1TableAdapters.bedmasterTableAdapter();
                DataSet1TableAdapters.roommasterTableAdapter rmta = new DataSet1TableAdapters.roommasterTableAdapter();
                DataSet1TableAdapters.wardmasterTableAdapter wmta = new DataSet1TableAdapters.wardmasterTableAdapter();

                DataSet1.bedmasterDataTable bmdt = bmta.GetDataBySno(sno);
                DataSet1.bedmasterRow bmr = (DataSet1.bedmasterRow)bmdt.Rows[0];
                bedno = bmr.bedno;
                bedsno = bmr.sno;

                DataSet1.roommasterDataTable rmdt = rmta.GetDataBySno(bmr.roomno);
                DataSet1.roommasterRow rmr = (DataSet1.roommasterRow)rmdt.Rows[0];
                roomno = rmr.roomno;

                DataSet1.wardmasterDataTable wmdt = wmta.GetDataBy(rmr.wardno);
                DataSet1.wardmasterRow wmr = (DataSet1.wardmasterRow)wmdt.Rows[0];
                wardname = wmr.wardname;
            }
            catch
            {

            }
        }
        public static String getDoctorIncharge(int patientno)
        {
            try
            {
                DataSet1TableAdapters.ipdformTableAdapter ita = new DataSet1TableAdapters.ipdformTableAdapter();
                DataSet1.ipdformDataTable idt = ita.GetDataByPatientNo(patientno);
                DataSet1.ipdformRow ir = (DataSet1.ipdformRow)idt.Rows[0];

                DataSet1TableAdapters.doctorslistTableAdapter dlta = new DataSet1TableAdapters.doctorslistTableAdapter();
                DataSet1.doctorslistDataTable dldt = dlta.GetDataByDoctorNo(ir.doctorno);
                DataSet1.doctorslistRow dlr = (DataSet1.doctorslistRow)dldt.Rows[0];
                return dlr.doctorname;
            }
            catch (Exception ex)
            {
                return "" + ex.Message;
            }
        }
        public static int gettodaystotalopd()
        {
            DataSet1TableAdapters.opdformTableAdapter dt = new DataSet1TableAdapters.opdformTableAdapter();
            DateTime today = System.DateTime.Now.AddHours(12.50);
            int patients = Convert.ToInt32(dt.GetPatientCountByDate(today));
            return patients;
        }
        public static int gettodaystotalipd()
        {
            DataSet1TableAdapters.ipdformTableAdapter dt = new DataSet1TableAdapters.ipdformTableAdapter();
            DateTime today = System.DateTime.Now.AddHours(12.50); ;
            int patients = Convert.ToInt32(dt.GetIpdCountByDate(today));
            return patients;
        }
        public static int gettodaystotaldischarge()
        {
            DataSet1TableAdapters.dischargeTableAdapter dt = new DataSet1TableAdapters.dischargeTableAdapter();
            DateTime today = System.DateTime.Now.AddHours(12.50); ;
            int patients = Convert.ToInt32(dt.GetDischargeCountByDate(today));
            return patients;
        }
        public static int gettotalemptybeds()
        {
            DataSet1TableAdapters.bedmasterTableAdapter dt = new DataSet1TableAdapters.bedmasterTableAdapter();
            DateTime today = System.DateTime.Now;
            int beds = Convert.ToInt32(dt.GetEmptyBedsCount());
            return beds;
        }
        
        public static string getNewPatientIPNumber(DateTime dt)
        {
            DataSet1TableAdapters.opdformTableAdapter ota = new DataSet1TableAdapters.opdformTableAdapter();
            //DataSet1.opdformDataTable odt=ota.GetData();
            //DataSet1.opdformRow or=(DataSet1.opdformRow)odt.Rows[odt.Rows.Count-1];
            //DateTime dt=System.DateTime.Now;
            return "GLC/" + dt.Year + "/" + (dt.Month) + "/" + dt.Day + "/" + ((int)ota.GetNewSnoWithIncreament() + 1);
         
        }
      
        public static string getWardNameByBedNo(int sno)
        {
            DataSet1TableAdapters.bedmasterTableAdapter bmta = new DataSet1TableAdapters.bedmasterTableAdapter();
            DataSet1TableAdapters.roommasterTableAdapter rmta = new DataSet1TableAdapters.roommasterTableAdapter();
            DataSet1TableAdapters.wardmasterTableAdapter wmta = new DataSet1TableAdapters.wardmasterTableAdapter();

            DataSet1.bedmasterDataTable bmdt = bmta.GetDataBySno(sno);
            DataSet1.bedmasterRow bmr = (DataSet1.bedmasterRow)bmdt.Rows[0];
            bedno = bmr.bedno;
            bedsno = bmr.sno;

            DataSet1.roommasterDataTable rmdt = rmta.GetDataBySno(bmr.roomno);
            DataSet1.roommasterRow rmr = (DataSet1.roommasterRow)rmdt.Rows[0];
            roomno = rmr.roomno;

            DataSet1.wardmasterDataTable wmdt = wmta.GetDataBy(rmr.wardno);
            DataSet1.wardmasterRow wmr = (DataSet1.wardmasterRow)wmdt.Rows[0];
            wardname = wmr.wardname;
            return wardname;
        }
        public static void updatePatientDepartment(int patientno, int departmentno)
        {
            DataSet1TableAdapters.opdformTableAdapter ota = new DataSet1TableAdapters.opdformTableAdapter();
            ota.UpdateDepartmentByPatientNo(departmentno, patientno);
        }
    }
}
