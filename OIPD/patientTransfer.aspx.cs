using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class patientTransfer : System.Web.UI.Page
    {
        int oldbed, selectedWardNo, selectedRoomNo, selectedBedNo, patientno;
        Patient patient;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool b = LoginManager.ProtectPage(Session, Response);
                if (!b)
                    return;

                lblMessage.Text = "";
                if (!this.IsPostBack)
                {
                    patientno = Convert.ToInt32("" + Request.QueryString["patientno"]);
                    patient = new Patient(patientno);
                    lblPatient.Text = patient.title + " " + patient.firstname + " " + patient.lastname;
                    //lblDate.Text = "" + patient.dateofentry.Day + "/" + patient.dateofentry.Month + "/" + patient.dateofentry.Year;
                    PatientUtilities.getPatientBedDetails(patientno);
                    lblWard.Text = "" + PatientUtilities.wardname;
                    lblRoom.Text = "" + PatientUtilities.roomno;
                    lblBed.Text = "" + PatientUtilities.bedno;
                    lblDepart.Text = patient.getDepartmentName();

                    IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter ita = new IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter();
                    DataSet1.ipdformDataTable idt = ita.GetDataByPatientNo(patientno);
                    DataSet1.ipdformRow ir = (DataSet1.ipdformRow)idt.Rows[0];
                    lblReason.Text = "" + ir.comments;
                    lblDate.Text = "" + ir.dateofentry.Day + "/" + ir.dateofentry.Month + "/" + ir.dateofentry.Year;

                    IOPD.DataManager.DataSet1TableAdapters.doctorslistTableAdapter dlta = new IOPD.DataManager.DataSet1TableAdapters.doctorslistTableAdapter();
                    DataSet1.doctorslistRow dlr = (DataSet1.doctorslistRow)dlta.GetDataByDoctorNo(ir.doctorno).Rows[0];
                    lblDoctor.Text = dlr.doctorname;

                    IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter wmta = new IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter();
                    DataSet1.wardmasterDataTable wmdt = wmta.GetData();
                    int x = wmdt.Rows.Count;
                    drpdwnWard.Items.Insert(0, new ListItem("---Select---", "-1"));
                    for (int a = 0; a < x; a++)
                    {
                        DataSet1.wardmasterRow wmr = (DataSet1.wardmasterRow)wmdt.Rows[a];
                        drpdwnWard.Items.Insert(a + 1, new ListItem("" + wmr.wardname, "" + wmr.wardno));
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "" + ex.Message;
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
            drpdwnRoom.Items.Insert(0, new ListItem("---Select---", "-1"));
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
            drpdwnBed.Items.Insert(0, new ListItem("---Select---", "-1"));
            for (int a = 0; a < y; a++)
            {
                DataSet1.bedmasterRow bmr = (DataSet1.bedmasterRow)bmdt.Rows[a];
                drpdwnBed.Items.Insert(a + 1, new ListItem("" + bmr.bedno, "" + bmr.sno));
            }
        }
        protected void bttnadmit_Click(object sender, EventArgs e)
        {
            patientno = Convert.ToInt32("" + Request.QueryString["patientno"]);
            if ((txtReason.Text).Equals(""))
            {
                lblMessage.Text = "Give a Valid Reason";
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
            selectedBedNo = Convert.ToInt32("" + drpdwnBed.SelectedValue);
            if (drpdwnBed.SelectedIndex == -1 || drpdwnBed.SelectedIndex == 0)
            {
                lblMessage.Text = "Select Bed No.";
                return;
            }
            if (txtDate.Text.Equals("") || txtDate.Text.Equals(null))
            {
                lblMessage.Text = "Please Select Date";
                return;
            }
            if (trhour.Text.Equals("") || trhour.Text.Equals(null))
            {
                lblMessage.Text = "Please Select Hour";
                return;
            }
            if (trmin.Text.Equals("") || trmin.Text.Equals(null))
            {
                lblMessage.Text = "Please Select Minute";
                return;
            }
            int hour = Convert.ToInt32("" + trhour.Text);
            int min = Convert.ToInt32("" + trmin.Text);
            DateTime d = Convert.ToDateTime(txtDate.Text + "");
            string amPM = "";
            if (hour >= 12)
            {
                amPM = "PM";
                hour = hour - 12;
            }
            else
                amPM = "AM";
            DateTime dt = Convert.ToDateTime(d.Month + "/" + d.Day + "/" + d.Year + " " + (hour) + ":" + (min) + ":00 " + amPM);

            IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter ita = new IOPD.DataManager.DataSet1TableAdapters.ipdformTableAdapter();
            oldbed = PatientUtilities.bedsno;
            String res = bedUtilities.leaveBed(oldbed, dt, patientno, txtReason.Text, LoginManager.CurrentUser(Session));
            if (res.Equals("successfull"))
            {
                res = bedUtilities.allotBed(patientno, selectedBedNo, dt, txtReason.Text, LoginManager.CurrentUser(Session));
                ita.UpdateBedOnTransfer(selectedBedNo, Convert.ToInt32(Request.QueryString["patientno"]));
                if (res.Equals("successfull"))
                {
                    Response.Redirect("home.aspx");
                }
                else
                    lblMessage.Text = res;
            }
            else
                lblMessage.Text = res + "/" + oldbed + "/" + patientno;

        }
    }
}