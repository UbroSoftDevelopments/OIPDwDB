using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class extraIncome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (txtDate.Text.Trim().Equals(""))
                    throw new Exception("Please Select Valid Date");
                if (txtAmount.Text.Trim().Equals("") || Convert.ToDouble(txtAmount.Text) <= 0)
                    throw new Exception("Please Enter Valid Amount");
                if (txtParticulars.Text.Trim().Equals(""))
                    throw new Exception("Please Enter Source of Income or Some Particulars");
                string particulars = txtParticulars.Text;
                double amount = Convert.ToDouble(txtAmount.Text);
                DateTime dt = Convert.ToDateTime(txtDate.Text);

                IOPD.DataManager.DataSet1TableAdapters.extraIncomesTableAdapter dtAdapt = new IOPD.DataManager.DataSet1TableAdapters.extraIncomesTableAdapter();
                dtAdapt.Insert1(Session["username"] + "", particulars, amount, dt);

                //DataSet2TableAdapters.extraincomeTableAdapter eita = new DataSet2TableAdapters.extraincomeTableAdapter();
                //eita.Insert(particulars, amount, dt);
                Validation.setSuccess(lblMsg, "Income Added Successfully");
            }
            catch (Exception ex)
            {
                Validation.setError(lblMsg, ex);
            }
        }
    }
}