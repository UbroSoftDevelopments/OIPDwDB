using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class printReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                bool b = LoginManager.ProtectPage(Session, Response);
                if (!b)
                    return;

                int sno = Convert.ToInt32(Request.QueryString["sno"]);
                IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter();
                DataSet1.opdformDataTable dt = da.GetDataByPatientNo(sno);
                if (dt.Rows.Count == 0)
                    Response.Write("Enter Valid Sno");
                DataSet1.opdformRow dr = (DataSet1.opdformRow)dt.Rows[0];
                Patient patient = new Patient(sno);
                DepartmentValidation dept = new DepartmentValidation(patient.departmentno);
                String departName = dept.Departname;


                regNumber.Text = RegistrationUtilities.GetRegistrationNo(sno);
                dateOfEntry.Text = "" + patient.dateofentry;
                lblfirstname.Text = "" + patient.firstname;
                lbllastname.Text = "" + patient.lastname;
                lblfather_w_o.Text = "" + patient.fathername;
                int month = patient.agemonths;
                int days = patient.agedays;
                String ageLabelText;

                ageLabelText = patient.ageyears + "Yr " + month + "Mn " + days + "Day";
                lblage.Text = ageLabelText;
                lblgender.Text = "" + patient.gender;
                lbladdress.Text = "" + patient.address;
                lblmobileNumber.Text = "" + patient.mobileno;
                lblrefFrom.Text = "" + patient.referredfrom;

                if (!patient.referredfrom.Equals("Self"))
                {
                    lblreferer.Text = "<b>Reffer Number -:</b>";
                    lblrefnumber.Text = patient.doctorno;
                }

                expenses ex = new expenses(patient.patientno);
                receiptNo.Text = "" + ex.getReceiptNo();

                lbldepartment.Text = departName;
                lblamount.Text = "<i class=\"fa fa-inr\"/> " + ex.getAmount() + "/-";
                lblamtInWords.Text = "<b>" + Validation.ConvertNumbertoWords(ex.getAmount()) + " RUPEES ONLY</b>";
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message);
            }

        }
    }
}