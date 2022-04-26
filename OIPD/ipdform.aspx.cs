using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class ipdform : System.Web.UI.Page
    {
        int selectedWardNo, selectedRoomNo, selectedBedNo, selectedDoctor, patientNo;
        protected void Page_Load(object sender, EventArgs e)
        {

            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;

            lblMessage.Text = "";
            if (!this.IsPostBack)
            {
                try
                {
                    String sno = Request.QueryString["patientno"];
                    gotoChangeDepart.NavigateUrl = "changeDepartment.aspx?patientno=" + sno;

                    Patient patient = new Patient(Convert.ToInt32(sno));
                    if (!patient.isValidPatient())
                        Response.Redirect("ipdregistration.aspx");
                    patientNo = Convert.ToInt32(sno);

                    IOPD.DataManager.DataSet1TableAdapters.doctorslistTableAdapter dlta = new IOPD.DataManager.DataSet1TableAdapters.doctorslistTableAdapter();
                    DataSet1.doctorslistDataTable dldt = dlta.GetData();
                    int w = dldt.Rows.Count;
                    for (int a = 0; a < w; a++)
                    {
                        DataSet1.doctorslistRow dlr = (DataSet1.doctorslistRow)dldt.Rows[a];
                        drpdwnDoctors.Items.Insert(a, new ListItem("" + dlr.doctorname, "" + dlr.doctorno));
                    }

                    IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter wmta = new IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter();
                    DataSet1.wardmasterDataTable wmdt = wmta.GetData();
                    int x = wmdt.Rows.Count;
                    drpdwnWard.Items.Insert(0, new ListItem("-----Select Ward-----", "-1"));
                    for (int a = 0; a < x; a++)
                    {
                        DataSet1.wardmasterRow wmr = (DataSet1.wardmasterRow)wmdt.Rows[a];
                        drpdwnWard.Items.Insert(a + 1, new ListItem("" + wmr.wardname, "" + wmr.wardno));
                    }
                }
                catch
                {
                    Response.Redirect("ipdregistration.aspx");
                }
            }
        }
        protected void drpdwnWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpdwnRoom.Items.Clear();
            drpdwnBed.Items.Clear();
            IOPD.DataManager.DataSet1TableAdapters.roommasterTableAdapter rmta = new IOPD.DataManager.DataSet1TableAdapters.roommasterTableAdapter();
            selectedWardNo = Convert.ToInt32("" + drpdwnWard.SelectedValue);
            if (selectedWardNo == -1)
                return;
            DataSet1.roommasterDataTable rmdt = rmta.GetDataByWardNo(selectedWardNo);
            int y = rmdt.Rows.Count;
            drpdwnRoom.Items.Insert(0, new ListItem("-----Select Room-----", "-1"));
            for (int a = 0; a < y; a++)
            {
                DataSet1.roommasterRow rmr = (DataSet1.roommasterRow)rmdt.Rows[a];
                drpdwnRoom.Items.Insert(a + 1, new ListItem("" + rmr.roomno, "" + rmr.sno));
            }
        }
        protected void drpdwnRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpdwnBed.Items.Clear();
            IOPD.DataManager.DataSet1TableAdapters.bedmasterTableAdapter bmta = new IOPD.DataManager.DataSet1TableAdapters.bedmasterTableAdapter();
            selectedRoomNo = Convert.ToInt32("" + drpdwnRoom.SelectedValue);
            if (selectedBedNo == -1)
                return;
            DataSet1.bedmasterDataTable bmdt = bmta.GetVacantBedByRoomNo(selectedRoomNo);
            int y = bmdt.Rows.Count;
            drpdwnBed.Items.Insert(0, new ListItem("-----Select Bed-----", "-1"));
            for (int a = 0; a < y; a++)
            {
                DataSet1.bedmasterRow bmr = (DataSet1.bedmasterRow)bmdt.Rows[a];
                drpdwnBed.Items.Insert(a + 1, new ListItem("" + bmr.bedno, "" + bmr.sno));
            }
        }
        protected void bttnadmit_Click(object sender, EventArgs e)
        {
            int pType = Convert.ToInt32("" + rdoPatientType.SelectedValue);
            if (pType != 1)
            {
                if (txtPackageAmount.Text.Equals(" ") || txtPackageAmount.Text.Equals(null) || Convert.ToInt32(txtPackageAmount.Text) == 0)
                    lblMessage.Text = "Please Give Package Amount";
            }
            if ((txtReason.Text).Equals(""))
            {
                lblMessage.Text = "Give a Valid Reason";
                return;
            }
            if ((txtDate.Text).Equals(""))
            {
                lblMessage.Text = "Select a valid date";
                return;
            }
            selectedDoctor = Convert.ToInt32("" + drpdwnDoctors.SelectedValue);
            if (drpdwnWard.SelectedIndex == -1 || drpdwnWard.SelectedIndex == 0)
            {
                lblMessage.Text = "Select Ward";
                return;
            }
            if (drpdwnWard.SelectedIndex == -1 || drpdwnWard.SelectedIndex == 0)
            {
                lblMessage.Text = "Select Ward";
                return;
            }
            if (drpdwnRoom.SelectedIndex == -1 || drpdwnRoom.SelectedIndex == 0)
            {
                lblMessage.Text = "Select Room";
                return;
            }

            if (drpdwnBed.SelectedIndex == -1 || drpdwnBed.SelectedIndex == 0)
            {
                lblMessage.Text = "Select Bed No.";
                return;
            }

            selectedBedNo = Convert.ToInt32("" + drpdwnBed.SelectedValue);
            txtReason.Enabled = false;
            drpdwnDoctors.Enabled = false;
            txtDate.Enabled = false;
            drpdwnWard.Enabled = false;
            drpdwnRoom.Enabled = false;
            drpdwnBed.Enabled = false;

            txtReason.CssClass = txtReason.CssClass.Replace("w3-sand", "w3-gray");
            txtDate.CssClass = txtDate.CssClass.Replace("w3-sand", "w3-gray"); ;
            drpdwnDoctors.CssClass = drpdwnDoctors.CssClass.Replace("w3-sand", "w3-gray");
            drpdwnWard.CssClass = drpdwnWard.CssClass.Replace("w3-sand", "w3-gray");
            drpdwnRoom.CssClass = drpdwnRoom.CssClass.Replace("w3-sand", "w3-gray");
            drpdwnBed.CssClass = drpdwnBed.CssClass.Replace("w3-sand", "w3-gray");


            DateTime dat = System.DateTime.Now;
            dat = dat.AddHours(12.50);
            DateTime dt = Convert.ToDateTime((txtDate.Text) + " " + dat.Hour + ":" + dat.Minute + dat.ToString("tt"));

            int sno = Convert.ToInt32(Request.QueryString["patientno"]);
            selectedRoomNo = Convert.ToInt32("" + drpdwnRoom.SelectedValue);
            selectedBedNo = Convert.ToInt32("" + drpdwnBed.SelectedValue);

            IOPD.DataManager.DataSet1TableAdapters.bedmasterTableAdapter bmta = new IOPD.DataManager.DataSet1TableAdapters.bedmasterTableAdapter();
            DataSet1.bedmasterDataTable bmdt = bmta.GetDataBySno(selectedBedNo);
            DataSet1.bedmasterRow bmr = (DataSet1.bedmasterRow)bmdt.Rows[0];
            bedUtilities.allotBed(sno, selectedBedNo, dt, txtReason.Text, LoginManager.CurrentUser(Session));


            IOPD.DataManager.DataSet1TableAdapters.expensesTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.expensesTableAdapter();
            if (pType == 1)
            {
                da.InsertQuery(dt, 500, "IPD Fees", sno, LoginManager.CurrentUser(Session));
            }
            else
            {
                int amount = Convert.ToInt32(txtPackageAmount.Text);
                string type = "";
                if (pType == 2)
                    type = "Daily Charges";
                else
                    type = "Total Charge";
                IOPD.DataManager.DataSet1TableAdapters.packageTableAdapter pta = new IOPD.DataManager.DataSet1TableAdapters.packageTableAdapter();
                pta.InsertQuery(sno, type, amount);
            }

            IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter ita = new IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter();
            ita.InsertQuery(sno, dt, selectedBedNo, txtReason.Text, selectedDoctor, LoginManager.CurrentUser(Session));

            //divPrint.Visible = true;
            bttnadmit.Enabled = false;
            bttnPrint.Visible = true;
            bttnPrint.NavigateUrl = "printIPD.aspx?sno=" + sno;
        }
        public void goBack(object sender, EventArgs e)
        {
            Response.Redirect("ipdregistration.aspx");
        }
    }
}