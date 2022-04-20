using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class DepartmentValidation
    {


        public static string GetDepartmentNameByDepartmentNo(object departmentno)
        {

            try
            {
                DepartmentValidation dv = new DepartmentValidation(Convert.ToInt32(departmentno));
                return dv.Departname;
            }
            catch
            {
                return "";
            }
        }

        int departmentno;
        string departname, description;
        bool valid = false;
        public DepartmentValidation(int departmentno, string departname, string description)
        {
            this.departmentno = departmentno;
            this.departname = departname;
            this.description = description;
            valid = true;

        }
        public DepartmentValidation(int departmentno)
        {
            try
            {
                DataSet1TableAdapters.departmentsTableAdapter dt = new DataSet1TableAdapters.departmentsTableAdapter();
                DataSet1.departmentsDataTable da = dt.GetDataBy(departmentno);
                DataSet1.departmentsRow dr = (DataSet1.departmentsRow)da.Rows[0];
                this.departmentno = dr.departmentno;
                this.departname = dr.departname;
                this.description = dr.description;
                valid = true;
            }
            catch {

                valid = false;
            }



        }
        public bool Valid
        {
            get {
                return valid;
            }

        }
        public int Departmentno
        {
            get {
                return departmentno;

            }
        }
        public string Departname
        {
            get
            {
                return departname;

            }
        }
        public string Description
        {
            get
            {
                return description;

            }
        }
    }
    
}
