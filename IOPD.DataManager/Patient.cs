using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class Patient
    {
        public int patientno, departmentno, ageyears, agemonths, agedays, totalrenews, patienttype;
        public DateTime dateofentry, nextrenewdate;
        public string firstname, lastname, gender, address, fathername, referredfrom, mobileno, title, doctorno, user, ipnumber;

        public Boolean valid = false;

        public Patient(int patientno)
        {
            DataSet1TableAdapters.opdformTableAdapter da = new DataSet1TableAdapters.opdformTableAdapter();
            DataSet1.opdformDataTable dt = da.GetDataByPatientNo(patientno);
            if (dt.Rows.Count != 0)
                valid = true;
            else
                valid = false;
            if (valid)
            {
                DataSet1.opdformRow dr = (DataSet1.opdformRow)dt.Rows[0];
                this.patientno = dr.patientno;
                this.departmentno = dr.departmentno;
                this.dateofentry = dr.dateofentry;
                this.firstname = dr.firstname;
                this.lastname = dr.lastname;
                this.gender = dr.gender;
                this.address = dr.address;
                this.fathername = dr.fathername;
                this.referredfrom = dr.referredfrom;
                this.mobileno = dr.mobileno;
                this.title = dr.title;
                this.agedays = dr.agedays;
                this.agemonths = dr.agemonths;
                this.ageyears = dr.ageyears;
                this.doctorno = dr.doctorno;
                this.user = dr.currentuser;
                this.totalrenews = dr.totalrenews;
                this.nextrenewdate = dr.nextrenewdate;
                this.ipnumber = dr.ipnumber;
                this.patienttype = dr.patienttype;
            }
        }
        public bool isValidPatient()
        {
            return valid;
        }
        public string getDepartmentName()
        {
            DataSet1TableAdapters.departmentsTableAdapter dta = new DataSet1TableAdapters.departmentsTableAdapter();
            DataSet1.departmentsDataTable ddt = dta.GetDataBy(departmentno);
            DataSet1.departmentsRow dr = (DataSet1.departmentsRow)ddt.Rows[0];
            return dr.departname;
        }
        public static string getPatientname(int patientno)
        {
            Patient patient = new Patient(patientno);
            return patient.firstname + " " + patient.lastname;
        }
        public static string getPatientage(int patientno)
        {
            Patient patient = new Patient(patientno);
            return patient.ageyears + "y " + patient.agemonths + "m";
        }
        public static int getPatienType(int patientno)
        {
            Patient p = new Patient(patientno);
            return p.patienttype;
        }

        public string getPatientTypeName(int patientType)
        {
            DataSet1TableAdapters.patient_typeTableAdapter ptta = new DataSet1TableAdapters.patient_typeTableAdapter();
            DataSet1.patient_typeDataTable ptdt = ptta.GetDataBySno(patientType);
            DataSet1.patient_typeRow ptr = (DataSet1.patient_typeRow)ptdt.Rows[0];
            return ptr.type_of_patient;
        }
        public static string getPatientIPNumber(int pno)
        {
            Patient p = new Patient(pno);
            return p.ipnumber;
        }
    }
}
