using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class receivePayments : System.Web.UI.Page
    {
        int totalPayments = 0, totalExpenses = 0, totalDiscounts = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool b = LoginManager.ProtectPage(Session, Response);
                if (!b)
                    return;
                int sno = Convert.ToInt32("" + Request.QueryString["patientno"]);

                Patient patient = new Patient(Convert.ToInt32(sno));
                if (!patient.isValidPatient())
                {
                    Response.Write("Invalid Patient");
                    return;
                    //Response.Redirect("payments.aspx");
                }

                this.BindExpensesGrid(sno);

                IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter pta = new IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter();
                DataSet1.paymentsDataTable pdt = pta.GetDataByPatientno(sno);
                if (pdt.Rows.Count == 0)
                {
                    GridView1.Visible = false;
                }
                else
                {
                    GridView1.Visible = true;
                    this.BindPaymentsGrid();
                }
                this.BindDiscountsGrid();
                setAmountDue();
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message);
                //Response.Redirect("payments.aspx");
            }
        }

        public void setAmountDue()
        {
            try
            {
                if (totalExpenses > (totalPayments + totalDiscounts))
                {
                    lblamount.Text = "<b>Amount Due -:</b>";
                    int due = totalExpenses - (totalPayments + totalDiscounts);
                    lblDueAmount.Text = " <b>" + due.ToString() + "/-</b>";
                }
                else
                {
                    if (totalExpenses < (totalPayments + totalDiscounts))
                    {
                        lblamount.Text = "<b>Amount Extra -:</b>";
                        int excess = (totalPayments + totalDiscounts) - totalExpenses;
                        lblDueAmount.Text = " <b>" + excess.ToString() + "/-</b>";
                    }
                    else
                    {
                        lblamount.Text = "<b>Amount Due -:</b>";
                        int excess = (totalPayments + totalDiscounts) - totalExpenses;
                        lblDueAmount.Text = " <b>" + excess.ToString() + "/-</b>";
                        bttnPrintBill.Visible = true;
                        bttnPrintBill.NavigateUrl = "printPaymentBill.aspx?patientno=" + Request.QueryString["patientno"];
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "" + ex.Message;
            }
        }

        private void BindExpensesGrid(int sno)
        {
            chargesUtilities.getAllChargesAtOnce(sno, GridView);
            totalExpenses = chargesUtilities.totalExpenses;
        }
        private void BindPaymentsGrid()
        {
            IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter eta = new IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter();
            DataSet1.paymentsDataTable edt = eta.GetDataByPatientno(Convert.ToInt32("" + Request.QueryString["patientno"]));
            int total = 0;
            for (int x = 0; x < edt.Rows.Count; x++)
            {
                DataSet1.paymentsRow er = (DataSet1.paymentsRow)edt.Rows[x];
                total = total + Convert.ToInt32("" + er.amount);
            }
            totalPayments = total;
            GridView1.FooterRow.Cells[1].Text = "Total";
            GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            GridView1.FooterRow.Cells[2].Text = "<i class=\"fa fa-inr\"/> <b>" + total.ToString() + "/-</b>";
            GridView1.FooterRow.Cells[2].CssClass = "w3-large";
        }

        private void BindDiscountsGrid()
        {
            int total = 0;
            IOPD.DataManager.DataSet1TableAdapters.discountdataTableAdapter dta = new IOPD.DataManager.DataSet1TableAdapters.discountdataTableAdapter();
            DataSet1.discountdataDataTable ddt = dta.GetDataByPatientno(Convert.ToInt32("" + Request.QueryString["patientno"]));
            if (ddt.Rows.Count <= 0)
            {
                total = 0;
                totalDiscounts = 0;
                return;
            }
            else
            {
                for (int x = 0; x < ddt.Rows.Count; x++)
                {
                    DataSet1.discountdataRow ddr = (DataSet1.discountdataRow)ddt.Rows[x];
                    total += (int)ddr.discountamount;
                }
            }
            totalDiscounts = total;
            grdDiscounts.FooterRow.Cells[1].Text = "Total";
            grdDiscounts.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            grdDiscounts.FooterRow.Cells[2].Text = "<i class=\"fa fa-inr\"/> <b>" + total.ToString() + "/-</b>";
            grdDiscounts.FooterRow.Cells[2].CssClass = "w3-large";
        }

        public void showPaymentsOption(Object Sender, EventArgs e)
        {
            paymentOptions.Visible = true;
            bttnShowPay.Enabled = false;
            bttnShowPay.CssClass = bttnShowPay.CssClass.Replace("w3-purple", "w3-gray");
        }

        public void checkData(Object sender, EventArgs e)
        {
            try
            {
                if (txtDate.Text.Equals(""))
                    throw new Exception("Please Enter date");
                if (txtAmount.Text.Equals(""))
                    throw new Exception("Please Enter the amount");
                if (drpdwnMode.SelectedIndex == 0)
                    throw new Exception("Please select a valid payment mode");
                if (txtModeData.Text.Equals(""))
                    throw new Exception("Please Enter payment data");
                if (txtComments.Text.Equals(""))
                    throw new Exception("Give Some Description");

                txtAmount.Enabled = false;
                drpdwnMode.Enabled = false;
                txtModeData.Enabled = false;
                txtComments.Enabled = false;
                bttnAccept.Enabled = false;
                bttnAccept.CssClass = bttnAccept.CssClass.Replace("w3-purple", "w3-gray");
                bttnCancel.Text = "Home";
                bttnPrintBill.Visible = true;

                DateTime dat = System.DateTime.Now;
                dat = dat.AddHours(12.50);
                DateTime dt = Convert.ToDateTime((txtDate.Text) + " " + dat.Hour + ":" + dat.Minute + dat.ToString("tt"));

                addToPayments(Convert.ToInt32("" + Request.QueryString["patientno"]), dt, Convert.ToInt32("" + txtAmount.Text), txtComments.Text, "" + drpdwnMode.SelectedValue, txtModeData.Text);

                GridView.DataBind();
                GridView1.DataBind();
                this.BindExpensesGrid(Convert.ToInt32("" + Request.QueryString["patientno"]));
                this.BindPaymentsGrid();
                if (!GridView1.Visible)
                    GridView1.Visible = true;
                setAmountDue();
                bttnPrintBill.NavigateUrl = "printPaymentBill.aspx?patientno=" + Request.QueryString["patientno"];
            }
            catch (Exception ex)
            {
                Validation.setError(lblErr, ex);
            }
        }

        public void addToPayments(int patientno, DateTime dateOfEntry, int amount, string comments, string mode, string modeData)
        {
            IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter pta = new IOPD.DataManager.DataSet1TableAdapters.paymentsTableAdapter();
            pta.InsertPayment(patientno, dateOfEntry, amount, comments, mode, modeData, LoginManager.CurrentUser(Session));
        }

        public void reset(Object Sender, EventArgs e)
        {
            if (bttnCancel.Text.Equals("Cancel"))
                Response.Redirect("receivePayments.aspx?patientno=" + Request.QueryString["patientno"]);
            else
            {
                Response.Redirect("home.aspx");
            }

        }

        protected void drpdwnMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = drpdwnMode.SelectedIndex;
            if (x == 0)
            {
                lblModeData.Visible = false;
                lblModeData.Text = "";
                txtModeData.Visible = false;
                txtModeData.Text = "";
            }
            else if (x == 1)
            {
                lblModeData.Visible = false;
                lblModeData.Text = "";
                txtModeData.Visible = false;
                txtModeData.Text = "None";
            }
            else if (x == 2)
            {
                lblModeData.Visible = true;
                lblModeData.Text = "<b>Cheque Number</b>";
                txtModeData.Visible = true;
                txtModeData.Text = "";
                txtModeData.Attributes.Add("placeholder", "Enter Cheque Number");
            }
            else if (x == 3)
            {
                lblModeData.Visible = true;
                lblModeData.Text = "<b>Credit Card Number</b>";
                txtModeData.Visible = true;
                txtModeData.Text = "";
                txtModeData.Attributes.Add("placeholder", "Enter Credit Card Number");
            }
            else if (x == 4)
            {
                lblModeData.Visible = true;
                lblModeData.Text = "<b>Debit Card Number</b>";
                txtModeData.Visible = true;
                txtModeData.Text = "";
                txtModeData.Attributes.Add("placeholder", "Enter Debit Card Number");
            }
            string discountcomment = txtDiscComment.Text.ToString();
        }

        public void acceptDiscount(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscDate.Text.Trim().Equals(""))
                    throw new Exception("Please Select Discount");
                if (txtDiscAmount.Text.Trim().Equals(""))
                    throw new Exception("Please Enter Discount Amount");
                if (txtDiscComment.Text.Trim().Equals(""))
                    throw new Exception("Please Give Some Description");
                double discAmount;
                try
                {
                    discAmount = Convert.ToDouble(txtDiscAmount.Text);
                }
                catch
                {
                    Validation.setError(lblDiscErr, "Please Enter Valid Discount Amount");
                    return;
                }
                DateTime dateOfDiscount = Convert.ToDateTime(txtDiscDate.Text);
                string discountcomment = txtDiscComment.Text.ToString();
                IOPD.DataManager.DataSet1TableAdapters.discountdataTableAdapter dta = new IOPD.DataManager.DataSet1TableAdapters.discountdataTableAdapter();
                dta.Insert1(Convert.ToInt32("" + Request.QueryString["patientno"]), discAmount, dateOfDiscount, discountcomment);
                GridView.DataBind();
                GridView1.DataBind();
                grdDiscounts.DataBind();

                this.BindExpensesGrid(Convert.ToInt32("" + Request.QueryString["patientno"]));
                this.BindPaymentsGrid();
                this.BindDiscountsGrid();

                setAmountDue();
                Validation.setSuccess(lblDiscErr, "Discount Added Successfully");
            }
            catch (Exception ex)
            {
                Validation.setError(lblDiscErr, ex);
            }
        }
    }
}