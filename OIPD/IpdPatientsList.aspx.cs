using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class IpdPatientsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrMsg.Text = "";
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
        }
        protected void searching(object sender, EventArgs e)
        {
            try
            {
                string name = txtPatientNumber.Text;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "" + ex.Message;
            }
        }
        protected void bttnAddCharges_Click(object sender, EventArgs e)
        {
            try
            {
                IOPD.DataManager.DataSet1TableAdapters.expensesTableAdapter dda = new IOPD.DataManager.DataSet1TableAdapters.expensesTableAdapter();
                IOPD.DataManager.DataSet1TableAdapters.bedmasterTableAdapter bmta = new IOPD.DataManager.DataSet1TableAdapters.bedmasterTableAdapter();
                IOPD.DataManager.DataSet1TableAdapters.currentbedpatientsTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.currentbedpatientsTableAdapter();
                DataSet1.currentbedpatientsDataTable dt = da.GetData();
                if (dt.Rows.Count == 0)
                    lblErrMsg.Text = "No Patients are admitted";
                foreach (DataSet1.currentbedpatientsRow dr in dt.Rows)
                {
                    IOPD.DataManager.DataSet1TableAdapters.packageTableAdapter pta = new IOPD.DataManager.DataSet1TableAdapters.packageTableAdapter();
                    DataSet1.packageDataTable pdt = pta.GetDataByPatientno(dr.patientno);
                    if (pdt.Rows.Count > 0)
                    {
                        DataSet1.packageRow pr = (DataSet1.packageRow)pdt.Rows[0];
                        string type = pr.packagename;
                        if (type.Equals("Total Charge"))
                            continue;
                        else
                        {
                            DataSet1.expensesDataTable done = dda.GetDataByChargeName(dr.patientno, type);
                            DateTime sys = System.DateTime.Now;
                            sys = sys.AddHours(12.50);
                            if (done.Rows.Count != 0)
                            {
                                for (int x = 0; x < done.Rows.Count; x++)
                                {
                                    DataSet1.expensesRow doneR = (DataSet1.expensesRow)done.Rows[x];
                                    string crDate = sys.Day + "/" + sys.Month + "/" + sys.Year;
                                    string exDate = doneR.dateofexpense.Day + "/" + doneR.dateofexpense.Month + "/" + doneR.dateofexpense.Year;
                                    if (crDate.Equals(exDate))
                                        break;
                                    else
                                        dda.InsertQuery(sys, pr.packageamount, type, dr.patientno, LoginManager.CurrentUser(Session));
                                }
                            }
                            else
                            {
                                dda.InsertQuery(sys, pr.packageamount, type, dr.patientno, LoginManager.CurrentUser(Session));
                            }
                        }
                        continue;
                    }
                    IOPD.DataManager.DataSet1TableAdapters.chargesTableAdapter cta = new IOPD.DataManager.DataSet1TableAdapters.chargesTableAdapter();
                    PatientUtilities.getPatientBedDetails(dr.patientno);
                    DataSet1.chargesDataTable cdt = cta.GetDataByWardName(PatientUtilities.wardname);
                    for (int i = 0; i < cdt.Rows.Count; i++)
                    {
                        DateTime sys = System.DateTime.Now;
                        sys = sys.AddHours(12.50);
                        DataSet1.chargesRow cr = (DataSet1.chargesRow)cdt.Rows[i];
                        DataSet1.expensesDataTable done = dda.GetDataByChargeName(dr.patientno, cr.chargeName);
                        if (done.Rows.Count != 0)
                        {
                            for (int x = 0; x < done.Rows.Count; x++)
                            {
                                DataSet1.expensesRow doneR = (DataSet1.expensesRow)done.Rows[x];
                                string crDate = sys.Day + "/" + sys.Month + "/" + sys.Year;
                                string exDate = doneR.dateofexpense.Day + "/" + doneR.dateofexpense.Month + "/" + doneR.dateofexpense.Year;
                                if (crDate.Equals(exDate))
                                    break;
                                else
                                    dda.InsertQuery(sys, cr.amount, cr.chargeName, dr.patientno, LoginManager.CurrentUser(Session));
                            }
                        }
                        else
                        {
                            dda.InsertQuery(sys, cr.amount, cr.chargeName, dr.patientno, LoginManager.CurrentUser(Session));
                        }
                        DataSet1.bedmasterDataTable bmdt = bmta.GetDataBySno(dr.bedno);
                        DataSet1.bedmasterRow br = (DataSet1.bedmasterRow)bmdt.Rows[0];
                        PatientUtilities.getPatientBedDetailsByBed(br.sno);
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "" + ex.Message;
            }
        }
    }
}