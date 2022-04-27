using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class bedmaster : System.Web.UI.Page
    {
        int roomno, wardno;
        string roomname;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                bool b = LoginManager.ProtectPage(Session, Response);
                if (!b)
                    return;
                else
                {
                    if (LoginManager.IsClerkLoggedIn(Session))
                        Response.Redirect("unauthorizedPage.aspx");
                }

                roomno = Convert.ToInt32(Request.QueryString["sno"]);
                IOPD.DataManager.DataSet1TableAdapters.roommasterTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.roommasterTableAdapter();
                DataSet1.roommasterDataTable dt = da.GetDataBySno(roomno);
                DataSet1.roommasterRow dr = (DataSet1.roommasterRow)dt.Rows[0];
                roomname = dr.roomno;
                lblroomname.Text = roomname;
                wardno = dr.wardno;
                IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter ta = new IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter();
                DataSet1.wardmasterDataTable wt = ta.GetDataBy(wardno);
                DataSet1.wardmasterRow wr = (DataSet1.wardmasterRow)wt.Rows[0];
                string name = wr.wardname;
                lblwardname.Text = name;
                lblname.Text = "Beds In Room No. " + roomname;

            }
            catch
            {

                Response.Redirect("roommaster.aspx");
            }

        }
        protected void buttonsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string number = txtbedno.Text;
                if (number.Equals("") || number.Equals(null))
                    throw new Exception("Please Enter The Bed No.");
                int charge = Convert.ToInt32("" + txtBedCharge.Text);
                if (charge <= 0)
                    throw new Exception("Please Enter Valid Bed Charge");
                IOPD.DataManager.DataSet1TableAdapters.bedmasterTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.bedmasterTableAdapter();
                da.InsertQuery(roomno, number, 1, charge);
                Validation.makeLabelVisible(lblMessage);
                Validation.setSuccess(lblMessage, "Successfully Entered");
                GridView1.DataBind();



            }
            catch (Exception ex)
            {
                Validation.setError(lblMessage, ex.Message);

            }
        }
        protected void buttonreset_Click(object sender, EventArgs e)
        {
            Validation.totalResetTextBoxes(txtbedno);
            Validation.makeLabelInVisible(lblMessage);
        }
    }
}