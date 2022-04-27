using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class printPathBill : System.Web.UI.Page
    {
        int totalExpenses = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErr.Text = "";
            try
            {
                bool b = LoginManager.ProtectPage(Session, Response);
                if (!b)
                    return;

                int sno = Convert.ToInt32(Request.QueryString["sno"]);
                if (!this.IsPostBack)
                {
                    xraypathUtils.serial = xraypathUtils.getNewSerial();
                    receiptNo.Text = "" + xraypathUtils.serial;
                    if (sno != 0)
                    {
                        IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.opdformTableAdapter();
                        DataSet1.opdformDataTable dt = da.GetDataByPatientNo(sno);
                        if (dt.Rows.Count == 0)
                            Response.Write("Enter Valid Sno");
                        DataSet1.opdformRow dr = (DataSet1.opdformRow)dt.Rows[0];
                        Patient patient = new Patient(sno);
                        DepartmentValidation dept = new DepartmentValidation(patient.departmentno);
                        String departName = dept.Departname;

                        lbllastname.Text = patient.firstname + " " + patient.lastname;
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
                        makeReadOnly();
                    }
                    printForm.Visible = false;
                    btnEdit.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message);
                printForm.Visible = false;
            }
        }

        public void addTest(object sender, EventArgs e)
        {
            lblErr.Text = "";
            edit(sender, e);
            try
            {
                if (txtTest.Text.Trim().Equals(""))
                    throw new Exception("Give Test Name");
                if (txtAmount.Text.Trim().Equals(""))
                    throw new Exception("Give Test Amount");

                IOPD.DataManager.DataSet1TableAdapters.xraypathpetientTableAdapter dd = new IOPD.DataManager.DataSet1TableAdapters.xraypathpetientTableAdapter();

                DataSet1.xraypathpetientDataTable dt = dd.GetDataBySno(xraypathUtils.serial);
                if (dt.Rows.Count == 0)
                {
                    if (check_errors())
                    {
                        string name, father, age, gender, address, mobile, reffered;
                        name = "" + lbllastname.Text;
                        father = "" + lblfather_w_o.Text;
                        age = "" + lblage.Text;
                        gender = "" + lblgender.Text;
                        address = "" + lbladdress.Text;
                        mobile = "" + lblmobileNumber.Text;
                        reffered = "" + lblrefFrom.Text;
                        dd.InsertQuery(name, father, age, gender, address, mobile, reffered);

                        string testname = "" + txtTest.Text;
                        string amount = "" + txtAmount.Text;

                        dt = dd.GetDataBySno(xraypathUtils.serial);

                        IOPD.DataManager.DataSet1TableAdapters.xraypathTestsTableAdapter xpt = new IOPD.DataManager.DataSet1TableAdapters.xraypathTestsTableAdapter();
                        xpt.InsertQuery(xraypathUtils.serial, testname, amount);
                        setTotal(xraypathUtils.serial);
                        txtTest.Text = "";
                        txtAmount.Text = "";
                    }
                }
                else
                {
                    if (check_errors())
                    {
                        DataSet1.xraypathpetientRow dr = (DataSet1.xraypathpetientRow)dt.Rows[0];
                        int sno = dr.sno;

                        string testname = "" + txtTest.Text;
                        string amount = "" + txtAmount.Text;
                        totalExpenses = totalExpenses + Convert.ToInt32("" + amount);
                        IOPD.DataManager.DataSet1TableAdapters.xraypathTestsTableAdapter xpt = new IOPD.DataManager.DataSet1TableAdapters.xraypathTestsTableAdapter();
                        xpt.InsertQuery(sno, testname, amount);
                        setTotal(sno);
                        txtTest.Text = "";
                        txtAmount.Text = "";
                    }
                }
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                lblErr.Text = "Add-:" + ex.Message;
            }
        }

        public void doneEditing(object sender, EventArgs e)
        {
            try
            {
                if (check_errors())
                {
                    setTotal(xraypathUtils.serial);

                    makeReadOnly();
                    lblErr.Text = "";

                    dateOfEntry.BorderWidth = 0;
                    dateOfEntry.ReadOnly = true;

                    lblrefFrom.BorderWidth = 0;
                    lblrefFrom.ReadOnly = true;

                    takeTests.Visible = false;
                    btnDone.Visible = false;
                    printForm.Visible = true;
                    btnEdit.Visible = true;
                }
                else
                    lblErr.Text = "Fill Empty Fields";
            }
            catch (Exception ex)
            {
                lblErr.Text = "" + ex.Message;
            }
        }

        public void edit(object sender, EventArgs e)
        {
            dateOfEntry.BorderWidth = 1;
            dateOfEntry.BorderColor = System.Drawing.Color.Black;
            dateOfEntry.ReadOnly = false;

            lblrefFrom.BorderWidth = 1;
            lblrefFrom.BorderColor = System.Drawing.Color.Black;
            lblrefFrom.ReadOnly = false;

            lbllastname.BorderWidth = 1;
            lbllastname.BorderColor = System.Drawing.Color.Black;
            lbllastname.ReadOnly = false;

            lblfather_w_o.BorderWidth = 1;
            lblfather_w_o.BorderColor = System.Drawing.Color.Black;
            lblfather_w_o.ReadOnly = false;

            lblage.BorderWidth = 1;
            lblage.BorderColor = System.Drawing.Color.Black;
            lblage.ReadOnly = false;

            lblgender.BorderWidth = 1;
            lblgender.BorderColor = System.Drawing.Color.Black;
            lblgender.ReadOnly = false;

            lbladdress.BorderWidth = 1;
            lbladdress.BorderColor = System.Drawing.Color.Black;
            lbladdress.ReadOnly = false;

            lblmobileNumber.BorderWidth = 1;
            lblmobileNumber.BorderColor = System.Drawing.Color.Black;
            lblmobileNumber.ReadOnly = false;

            takeTests.Visible = true;
            btnDone.Visible = true;
            printForm.Visible = false;
            btnEdit.Visible = false;
        }

        public bool check_errors()
        {
            lblErr.Text = "";
            try
            {
                if (dateOfEntry.Text.Trim().Equals(""))
                {
                    dateOfEntry.BorderColor = System.Drawing.Color.Red;
                    throw new Exception("Select Date");
                }

                if (lbllastname.Text.Trim().Equals(""))
                {
                    lbllastname.BorderColor = System.Drawing.Color.Red;
                    throw new Exception("Enter Name");
                }

                if (lblfather_w_o.Text.Trim().Equals(""))
                {
                    lblfather_w_o.BorderColor = System.Drawing.Color.Red;
                    throw new Exception("Enter Father/Husband Name");
                }

                if (lblage.Text.Trim().Equals(""))
                {
                    lblage.BorderColor = System.Drawing.Color.Red;
                    throw new Exception("Enter Age");
                }

                if (lblgender.Text.Trim().Equals(""))
                {
                    lblgender.BorderColor = System.Drawing.Color.Red;
                    throw new Exception("Enter Gender");
                }

                if (lbladdress.Text.Trim().Equals(""))
                {
                    lbladdress.BorderColor = System.Drawing.Color.Red;
                    throw new Exception("Enter Address");
                }

                if (lblmobileNumber.Text.Trim().Equals(""))
                {
                    lblmobileNumber.BorderColor = System.Drawing.Color.Red;
                    throw new Exception("Enter Mobile Number");
                }
                string mob = "" + lblmobileNumber.Text;
                if (mob.Length > 10)
                {
                    lblmobileNumber.BorderColor = System.Drawing.Color.Red;
                    throw new Exception("Mobile Number Should Not Exceed 10 Digits");
                }
                if (mob.Length < 10)
                {
                    lblmobileNumber.BorderColor = System.Drawing.Color.Red;
                    throw new Exception("Mobile Number Should Be of 10 Digits");
                }

                if (lblrefFrom.Text.Trim().Equals(""))
                {
                    lblrefFrom.BorderColor = System.Drawing.Color.Red;
                    throw new Exception("Enter Reffered From if reffered by no one write Self");
                }
                return true;
            }
            catch (Exception ex)
            {
                lblErr.Text = "" + ex.Message;
                return false;
            }
        }
        public void makeReadOnly()
        {
            lbllastname.BorderWidth = 0;
            lbllastname.ReadOnly = true;

            lblfather_w_o.BorderWidth = 0;
            lblfather_w_o.ReadOnly = true;

            lblage.BorderWidth = 0;
            lblage.ReadOnly = true;

            lblgender.BorderWidth = 0;
            lblgender.ReadOnly = true;

            lbladdress.BorderWidth = 0;
            lbladdress.ReadOnly = true;

            lblmobileNumber.BorderWidth = 0;
            lblmobileNumber.ReadOnly = true;
        }
        public void setTotal(int sno)
        {
            try
            {
                int total = 0;
                IOPD.DataManager.DataSet1TableAdapters.xraypathTestsTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.xraypathTestsTableAdapter();
                DataSet1.xraypathTestsDataTable dt = da.GetDataByXrayPatientNo(sno);
                if (dt.Rows.Count == 0)
                    total = 0;
                else
                {
                    for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        DataSet1.xraypathTestsRow dr = (DataSet1.xraypathTestsRow)dt.Rows[x];
                        total += Convert.ToInt32("" + dr.amount);
                    }
                }

                lblTotal.Text = "<i class=\"fa fa-inr\"></i>" + total + "/-";
                lblTotalInWords.Text = "" + Validation.ConvertNumbertoWords(total) + " RUPEES ONLY";
            }
            catch (Exception ex)
            {
                lblErr.Text = "ttl-: " + ex;
            }
        }
    }
}