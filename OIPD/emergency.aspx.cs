using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class emergency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            message.Text = "";
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            if (!this.IsPostBack)
            {
                drpdwnRef.SelectedIndex = 0;
                drpdwnHospital.Visible = false;
                txtreffered.Visible = false;
                lblHospital.Visible = false;
                lblDocNumber.Visible = false;
                txtDocNumber.Visible = false;
            }
            ipNumber.Text = PatientUtilities.getNewPatientIPNumber(System.DateTime.Now.AddHours(12.5));

        }

        protected void makeReadOnly(Object sender, EventArgs e)
        {
            try
            {
                string refference = "Self", doctorNo = "0";

                if (!rdoLst.Items[0].Selected && !rdoLst.Items[1].Selected && !rdoLst.Items[2].Selected)
                    throw new Exception("Please Select Geetanjali or Ayushman");

                if (drpdwndepart.SelectedIndex <= 0)
                    throw new Exception("Please Select Department");

                if (txtdate.Text.Equals(""))
                    throw new Exception("Please Select Date");

                if (txtfirstname.Text.Equals(""))
                    throw new Exception("Please Enter First Name");

                if (txtlastname.Text.Equals(""))
                    throw new Exception("Please Enter Last Name");

                if (txtYears.Text.Equals(""))
                    throw new Exception("Please Enter Age");

                if (txtMonths.Text.Equals(""))
                    throw new Exception("Please Enter Months");

                if (txtDays.Text.Equals(""))
                    throw new Exception("Please Enter Days");

                int index = dropdowngender.SelectedIndex;
                if (index <= 0)
                    throw new Exception("Please Select Gender");

                if (txtaddress.Text.Equals(""))
                    throw new Exception("Please Enter Address");

                if (txtfathersname.Text.Equals(""))
                    throw new Exception("Please Enter Father's/Husbands Name");

                if (txtMonths.Text.Equals(""))
                    throw new Exception("Please Enter Months");

                if (drpdwnRef.SelectedIndex == 0)
                {
                    refference = "" + drpdwnRef.SelectedValue;
                }
                else
                {
                    if (drpdwnRef.SelectedIndex == 1)
                    {
                        if (drpdwnHospital.SelectedIndex == 0)
                            throw new Exception("Please Select Refferal Hospital");
                        else
                            refference = drpdwnHospital.SelectedItem.Text;
                    }
                    else
                    {
                        if (drpdwnRef.SelectedIndex == 2)
                        {
                            if (txtreffered.Text.Equals(""))
                                throw new Exception("Please Give Name of Reffered Doctor");
                            else
                                refference = txtreffered.Text;
                        }
                    }
                    if (txtDocNumber.Text.Equals(""))
                        throw new Exception("Please Enter \"None\" if doctor's number is not available");
                    else
                        doctorNo = txtDocNumber.Text;
                }

                if (txtnumber.Text.Equals(""))
                    throw new Exception("Please Enter Patient's Mobile Number");

                if (rdoLst.SelectedIndex == 2 && drpdwntpalist.SelectedIndex == 0)
                {
                    throw new Exception("Please Select Valid TPA For Cashless Patient");
                }

                rdoLst.Enabled = false;
                drpdwndepart.Enabled = false;
                txtdate.Enabled = false;
                dropdowntitle.Enabled = false;
                txtfirstname.Enabled = false;
                txtlastname.Enabled = false;
                txtYears.Enabled = false;
                txtMonths.Enabled = false;
                txtDays.Enabled = false;
                dropdowngender.Enabled = false;
                txtaddress.Enabled = false;
                txtfathersname.Enabled = false;
                drpdwnRef.Enabled = false;
                txtreffered.Enabled = false;
                drpdwnHospital.Enabled = false;
                txtDocNumber.Enabled = false;
                txtnumber.Enabled = false;
                txtamount.Enabled = false;
                btnregister.Enabled = false;

                rdoLst.CssClass = rdoLst.CssClass + "w3-gray";
                drpdwndepart.CssClass = drpdwndepart.CssClass.Replace("w3-sand", "w3-gray");
                txtdate.CssClass = txtdate.CssClass.Replace("w3-sand", "w3-gray");
                dropdowntitle.CssClass = dropdowntitle.CssClass.Replace("w3-sand", "w3-gray");
                txtfirstname.CssClass = txtfirstname.CssClass.Replace("w3-sand", "w3-gray");
                txtlastname.CssClass = txtlastname.CssClass.Replace("w3-sand", "w3-gray");
                txtYears.CssClass = txtYears.CssClass.Replace("w3-sand", "w3-gray");
                txtMonths.CssClass = txtMonths.CssClass.Replace("w3-sand", "w3-gray");
                txtDays.CssClass = txtDays.CssClass.Replace("w3-sand", "w3-gray");
                dropdowngender.CssClass = dropdowngender.CssClass.Replace("w3-sand", "w3-gray");
                txtaddress.CssClass = txtaddress.CssClass.Replace("w3-sand", "w3-gray");
                txtfathersname.CssClass = txtfathersname.CssClass.Replace("w3-sand", "w3-gray");
                drpdwnRef.CssClass = drpdwnRef.CssClass.Replace("w3-sand", "w3-gray");
                txtreffered.CssClass = txtreffered.CssClass.Replace("w3-sand", "w3-gray");
                drpdwnHospital.CssClass = drpdwnHospital.CssClass.Replace("w3-sand", "w3-gray");
                txtDocNumber.CssClass = txtDocNumber.CssClass.Replace("w3-sand", "w3-gray");
                txtnumber.CssClass = txtnumber.CssClass.Replace("w3-sand", "w3-gray");
                txtamount.CssClass = txtamount.CssClass.Replace("w3-sand", "w3-gray");

                btnPrint.Visible = true;
                btnPrint.Enabled = true;

                DateTime dt = System.DateTime.Now;
                dt = dt.AddHours(12.50);
                DateTime date = Convert.ToDateTime((txtdate.Text) + " " + dt.Hour + ":" + dt.Minute + dt.ToString("tt"));

                int patientType = Convert.ToInt32(rdoLst.SelectedValue);

                int number = Convert.ToInt32(drpdwndepart.SelectedValue);

                int tpanumber = 0;
                if (rdoLst.SelectedIndex == 2)
                    tpanumber = Convert.ToInt32(drpdwntpalist.SelectedValue);
                else
                    tpanumber = 0;
                string firstname = txtfirstname.Text;
                string lastname = txtlastname.Text;
                int ageyears = Convert.ToInt32(txtYears.Text);
                int agemonths = Convert.ToInt32(txtMonths.Text);
                int agedays = Convert.ToInt32(txtDays.Text);

                string gen = dropdowngender.SelectedValue;
                string address = txtaddress.Text;
                string fathername = txtfathersname.Text;
                string mobileno = txtnumber.Text;
                int totalamount = Convert.ToInt32(txtamount.Text);
                string title = "" + dropdowntitle.SelectedValue;
                int sno = 0;
                {
                    IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter();
                    da.InsertQuery(number, date, firstname, lastname, agemonths, ageyears, gen, address, fathername, refference, mobileno, title, doctorNo, LoginManager.CurrentUser(Session), (date.AddDays(15)), 0, agedays, patientType, ipNumber.Text + "", tpanumber);
                    sno = (int)da.GetNewSnoWithIncreament();
                }
                {
                    IOPD.DataManager.DataSet1TableAdapters.expensesTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.expensesTableAdapter();
                    da.InsertQuery(date, totalamount, "Registration Fees", sno, LoginManager.CurrentUser(Session));
                    IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter pa = new IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter();
                    pa.InsertPayment(sno, date, totalamount, "Registration Fees", "Cash", "None", LoginManager.CurrentUser(Session));
                }

                btnPrint.NavigateUrl = "printPad.aspx?sno=" + sno;
            }
            catch (Exception ex)
            {
                Validation.setError(message, ex);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Validation.setError(message, ex);

            }

        }



        protected void btnreset_Click(object sender, EventArgs e)
        {

            rdoLst.Enabled = true;
            drpdwndepart.Enabled = true;
            txtdate.Enabled = true;
            dropdowntitle.Enabled = true;
            txtfirstname.Enabled = true;
            txtlastname.Enabled = true;
            txtYears.Enabled = true;
            txtMonths.Enabled = true;
            txtDays.Enabled = true;
            dropdowngender.Enabled = true;
            txtaddress.Enabled = true;
            txtfathersname.Enabled = true;
            txtreffered.Enabled = true;
            drpdwnHospital.Enabled = true;
            txtDocNumber.Enabled = true;
            txtnumber.Enabled = true;
            btnregister.Enabled = true;
            txtamount.Enabled = true;

            rdoLst.CssClass = rdoLst.CssClass.Replace("w3-gray", "");
            drpdwndepart.CssClass = drpdwndepart.CssClass.Replace("w3-gray", "w3-sand");
            txtdate.CssClass = txtdate.CssClass.Replace("w3-gray", "w3-sand");
            dropdowntitle.CssClass = dropdowntitle.CssClass.Replace("w3-gray", "w3-sand");
            txtfirstname.CssClass = txtfirstname.CssClass.Replace("w3-gray", "w3-sand");
            txtlastname.CssClass = txtlastname.CssClass.Replace("w3-gray", "w3-sand");
            txtYears.CssClass = txtYears.CssClass.Replace("w3-gray", "w3-sand");
            txtMonths.CssClass = txtMonths.CssClass.Replace("w3-gray", "w3-sand");
            txtDays.CssClass = txtDays.CssClass.Replace("w3-gray", "w3-sand");
            dropdowngender.CssClass = dropdowngender.CssClass.Replace("w3-gray", "w3-sand");
            txtaddress.CssClass = txtaddress.CssClass.Replace("w3-gray", "w3-sand");
            txtfathersname.CssClass = txtfathersname.CssClass.Replace("w3-gray", "w3-sand");
            drpdwnRef.CssClass = drpdwnRef.CssClass.Replace("w3-gray", "w3-sand");
            txtreffered.CssClass = txtreffered.CssClass.Replace("w3-gray", "w3-sand");
            drpdwnHospital.CssClass = drpdwnHospital.CssClass.Replace("w3-gray", "w3-sand");
            txtDocNumber.CssClass = txtDocNumber.CssClass.Replace("w3-gray", "w3-sand");
            txtnumber.CssClass = txtnumber.CssClass.Replace("w3-gray", "w3-sand");
            txtamount.CssClass = txtamount.CssClass.Replace("w3-gray", "w3-sand");

            btnPrint.Visible = false;
            btnPrint.Enabled = false;


            Validation.totalResetTextBoxes(txtaddress, txtYears, txtMonths, txtdate, txtDays, txtfathersname, txtfirstname, txtlastname, txtnumber, txtreffered, txtDocNumber);
            dropdowngender.SelectedIndex = 0;
            dropdowntitle.SelectedIndex = 0;
        }

        protected void drpdwnRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpdwnRef.SelectedIndex == 0)
            {
                drpdwnHospital.Visible = false;
                txtreffered.Visible = false;
                lblHospital.Visible = false;
                lblDocNumber.Visible = false;
                txtDocNumber.Visible = false;
            }

            if (drpdwnRef.SelectedIndex == 1)
            {
                drpdwnHospital.Visible = true;
                txtreffered.Visible = false;
                lblHospital.Visible = true;
                lblDocNumber.Visible = true;
                lblDocNumber.Text = "Hospital's Number";
                txtDocNumber.Visible = true;
                txtDocNumber.Text = "";
            }

            if (drpdwnRef.SelectedIndex == 2)
            {
                drpdwnHospital.Visible = false;
                txtreffered.Visible = true;
                lblHospital.Visible = true;
                lblDocNumber.Visible = true;
                lblDocNumber.Text = "Doctor's Number";
                txtDocNumber.Visible = true;
                txtDocNumber.Text = "";
            }
        }
        protected void drpdwnHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpdwnHospital.SelectedIndex == 0)
            {
                txtDocNumber.Text = "";
                return;
            }

            IOPD.DataManager.DataSet1TableAdapters.refferHospitalsTableAdapter rhta = new IOPD.DataManager.DataSet1TableAdapters.refferHospitalsTableAdapter();
            DataSet1.refferHospitalsDataTable rhdt = rhta.GetDataBySno(Convert.ToInt32("" + drpdwnHospital.SelectedValue));
            DataSet1.refferHospitalsRow rhr = (DataSet1.refferHospitalsRow)rhdt.Rows[0];
            txtDocNumber.Text = "" + rhr.contactno;
        }



        protected void btnAddTpa_Click(object sender, EventArgs e)
        {
            if (txtTpaName.Text.Equals("") || txtTpaName.Text.Equals(null))
            {
                lblMsgModal.Text = "Please Give TPA Name";
                return;
            }
            IOPD.DataManager.DataSet1TableAdapters.tpaTableAdapter tta = new IOPD.DataManager.DataSet1TableAdapters.tpaTableAdapter();
            tta.Insert1(txtTpaName.Text + "");
            drpdwntpalist.DataBind();
        }
        protected void rdoLst_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(rdoLst.SelectedValue);
            string type = "" + rdoLst.SelectedItem.Text;
            if (type.Equals("Cashless"))
            {
                tpaList.Visible = true;
            }
            else
            {
                tpaList.Visible = false;
            }
        }

    }
}