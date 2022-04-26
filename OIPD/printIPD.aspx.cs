using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            int sno = Convert.ToInt32(Request.QueryString["sno"]);

            Patient patient = new Patient(sno);
            DepartmentValidation dept = new DepartmentValidation(patient.departmentno);
            String departName = dept.Departname;

            regNumber.Text = RegistrationUtilities.GetRegistrationNo(sno);

            IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter ita = new IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter();
            DataSet1.ipdformDataTable idt = ita.GetDataByPatientNo(sno);
            DataSet1.ipdformRow ir = (DataSet1.ipdformRow)idt.Rows[0];
            DateTime dt = (ir.dateofentry);
            receiptNo.Text = "" + ir.sno;
            dateOfEntry.Text = "" + dt.Day + "/" + dt.Month + "/" + dt.Year + " " + dt.Hour + ":" + dt.Minute + " " + dt.ToString("tt");
            lblfirstname.Text = patient.firstname;
            lbllastname.Text = patient.lastname;
            lblfather_w_o.Text = patient.fathername;

            int month = patient.agemonths;
            int days = patient.agedays;
            String ageLabelText;
            ageLabelText = patient.ageyears + "Yr " + month + "Mn " + days + "Day";
            lblage.Text = ageLabelText;
            lblgender.Text = patient.gender;
            lbladdress.Text = "" + patient.address;
            lblmobileNumber.Text = "" + patient.mobileno;
            lblrefFrom.Text = "" + patient.referredfrom;

            if (!patient.referredfrom.Equals("Self"))
            {
                lblreferer.Text = "<b>Reffer Number -:</b>";
                lblrefnumber.Text = patient.doctorno;
            }

            lbldepartment.Text = departName;
            lblamount.Text = "<i class=\"fa fa-inr\"/> 500 /-";
            lblamtInWords.Text = "<b>" + Validation.ConvertNumbertoWords(500) + " RUPEES ONLY</b>";

            IOPD.DataManager.DataSet1TableAdapters.doctorslistTableAdapter dlta = new IOPD.DataManager.DataSet1TableAdapters.doctorslistTableAdapter();
            DataSet1.doctorslistDataTable dldt = dlta.GetDataByDoctorNo(ir.doctorno);
            DataSet1.doctorslistRow dlr = (DataSet1.doctorslistRow)dldt.Rows[0];


            IOPD.DataManager.DataSet1TableAdapters.bedmasterTableAdapter bmta = new IOPD.DataManager.DataSet1TableAdapters.bedmasterTableAdapter();
            DataSet1.bedmasterDataTable bmdt = bmta.GetDataByPatientNo(sno);
            DataSet1.bedmasterRow bmr = (DataSet1.bedmasterRow)bmdt.Rows[0];

            IOPD.DataManager.DataSet1TableAdapters.roommasterTableAdapter rmta = new IOPD.DataManager.DataSet1TableAdapters.roommasterTableAdapter();
            DataSet1.roommasterDataTable rmdt = rmta.GetDataBySno(bmr.roomno);
            DataSet1.roommasterRow rmr = (DataSet1.roommasterRow)rmdt.Rows[0];

            IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter wmta = new IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter();
            DataSet1.wardmasterDataTable wmdt = wmta.GetDataBy(rmr.wardno);
            DataSet1.wardmasterRow wmr = (DataSet1.wardmasterRow)wmdt.Rows[0];


            lblWardNo.Text = "" + wmr.wardname;
            lblRoomNo.Text = "" + rmr.roomno;
            lblBedNo.Text = "" + bmr.bedno;
            lblReason.Text = "" + ir.comments;
            lblDoctor.Text = "" + dlr.doctorname;
        }
    }
}