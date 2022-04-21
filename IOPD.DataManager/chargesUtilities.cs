using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace IOPD.DataManager
{
    public static class chargesUtilities
    {
      
        public static DateTime noon = Convert.ToDateTime((System.DateTime.Now.AddHours(12.5)).Month + "/" + (System.DateTime.Now.AddHours(12.5)).Day + "/" + (System.DateTime.Now.AddHours(12.5)).Year + " 12:00:00 PM");
        public static int totalExpenses = 0;
        public static void addChargesToPatient(int patientno, HttpSessionState session, DateTime expDate)
        {
            DataSet1TableAdapters.expensesTableAdapter eta = new DataSet1TableAdapters.expensesTableAdapter();

            if (isPatientUnderPackage(patientno))
            {
                DataSet1TableAdapters.packageTableAdapter pta = new DataSet1TableAdapters.packageTableAdapter();
                DataSet1.packageDataTable pdt = pta.GetDataByPatientno(patientno);
                DataSet1.packageRow pr = (DataSet1.packageRow)pdt.Rows[0];
                if (!pr.packagename.Equals("Daily"))
                    return;
                else
                {
                    eta.InsertQuery(expDate, pr.packageamount, pr.packagename, patientno, LoginManager.CurrentUser(session));
                }
            }
            else
            {
                PatientUtilities.getPatientBedDetails(patientno);

                DataSet1TableAdapters.bedmasterTableAdapter bta = new DataSet1TableAdapters.bedmasterTableAdapter();
                DataSet1.bedmasterDataTable bdt = bta.GetDataByPatientNo(patientno);
                DataSet1.bedmasterRow br = (DataSet1.bedmasterRow)bdt.Rows[0];
                int bedCharge = br.bedcharge;

                eta.InsertQuery(expDate, bedCharge, "Bed Charge", patientno, LoginManager.CurrentUser(session));

                DataSet1TableAdapters.chargesTableAdapter cta = new DataSet1TableAdapters.chargesTableAdapter();
                DataSet1.chargesDataTable cdt = cta.GetDataByWardName(PatientUtilities.wardname);
                for (int x = 0; x < cdt.Rows.Count; x++)
                {
                    DataSet1.chargesRow cr = (DataSet1.chargesRow)cdt.Rows[x];
                    string chargename = cr.chargeName;
                    int amount = cr.amount;
                    eta.InsertQuery(expDate, amount, chargename, patientno, LoginManager.CurrentUser(session));
                }
            }
        }

        public static bool isPatientUnderPackage(int patientno)
        {
            DataSet1TableAdapters.packageTableAdapter pta = new DataSet1TableAdapters.packageTableAdapter();
            DataSet1.packageDataTable pdt = pta.GetDataByPatientno(patientno);
            if (pdt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static int totalCharges;
        public static bool isTotalPackageAdded = false;
        public static GridView getAllChargesAtOnce(int patientno, GridView gv)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Charge Name");
            dt.Columns.Add("Amount");
            try
            {
                int totalAmount = 0;
                DataSet1TableAdapters.expensesTableAdapter eta = new DataSet1TableAdapters.expensesTableAdapter();
                DataSet1.expensesDataTable edt = eta.GetDataByPatientNo(patientno);

                for (int i = 0; i < edt.Rows.Count; i++)
                {
                    DataSet1.expensesRow er = (DataSet1.expensesRow)edt.Rows[i];
                    DataRow dr = dt.NewRow();
                    dr["Date"] = er.dateofexpense.Day + "/" + er.dateofexpense.Month + "/" + er.dateofexpense.Year;
                    dr["Charge Name"] = er.comments;
                    dr["Amount"] = er.amount;
                    totalAmount += er.amount;
                    dt.Rows.Add(dr);
                }

                if (isPatientDischarged(patientno))
                {
                    goto last;
                }

                DataSet1TableAdapters.chargesTableAdapter cta = new DataSet1TableAdapters.chargesTableAdapter();

                if (isAdmitted(patientno) && !isPatientDischarged(patientno))
                {
                    DataSet1TableAdapters.ipdformTableAdapter ita = new DataSet1TableAdapters.ipdformTableAdapter();
                    DataSet1.ipdformDataTable idt = ita.GetDataByPatientNo(patientno);
                    DataSet1.ipdformRow idr = (DataSet1.ipdformRow)idt.Rows[0];

                    DataSet1TableAdapters.bedleavingTableAdapter blta = new DataSet1TableAdapters.bedleavingTableAdapter();

                    DataSet1TableAdapters.bedallotmentTableAdapter bata = new DataSet1TableAdapters.bedallotmentTableAdapter();
                    DataSet1.bedallotmentDataTable badt = bata.GetDataByPatientNo(patientno);
                    for (int i = 0; i < badt.Rows.Count; i++)
                    {
                        DataSet1.bedallotmentRow bar = (DataSet1.bedallotmentRow)badt.Rows[i];
                        DataSet1.bedleavingDataTable bldt = blta.GetDataByAllotmentNo(bar.sno);
                        if (bldt.Rows.Count > 0)
                        {
                            DataSet1.bedleavingRow blr = (DataSet1.bedleavingRow)bldt.Rows[0];
                            DateTime from = bar.dateofallotment;
                            DateTime to = blr.dateofleaving;
                            noon = Convert.ToDateTime(to.Month + "/" + to.Day + "/" + to.Year + " " + to.Hour + ":" + to.Minute + ":" + to.Second + "PM");
                            DateTime start = Convert.ToDateTime(from.Month + "/" + from.Day + "/" + from.Year);
                            DateTime end = Convert.ToDateTime(to.Month + "/" + to.Day + "/" + to.Year);
                            TimeSpan ts = end.Subtract(start);
                            int days = ts.Days;
                            int compare = DateTime.Compare(to, noon);
                            if (compare >= 0)
                            {
                                days = days + 1;
                            }
                            if (isPatientUnderPackage(patientno))
                            {
                                /*for (int a = 0; a < dt.Rows.Count; a++)
                                {
                                    DataRow dr = dt.Rows[a];
                                    if (dr[1].Equals("Total Charge"))
                                    {
                                        isTotalPackageAdded = true;
                                        break;
                                    }
                                }*/
                                if (getPackageType(patientno).Equals("Total Charge") && !isTotalPackageAdded)
                                {
                                    DataSet1TableAdapters.packageTableAdapter pta = new DataSet1TableAdapters.packageTableAdapter();
                                    DataSet1.packageDataTable pdt = pta.GetDataByPatientno(patientno);
                                    if (pdt.Rows.Count == 1)
                                    {
                                        from = Convert.ToDateTime(idr.dateofentry);
                                        to = System.DateTime.Now.AddHours(12.5);
                                    }
                                    DataRow dr = dt.NewRow();
                                    dr["Date"] = from.Day + "/" + from.Month + "/" + from.Year + " - " + to.Day + "/" + to.Month + "/" + to.Year;
                                    dr["Charge Name"] = getPackageType(patientno);
                                    dr["Amount"] = getPackageAmount(patientno);
                                    totalAmount += getPackageAmount(patientno);
                                    dt.Rows.Add(dr);
                                    isTotalPackageAdded = true;
                                }
                                else
                                {
                                    if (!(getPackageType(patientno).Equals("Total Charge")))
                                    {
                                        DataRow dr = dt.NewRow();
                                        dr["Date"] = from.Day + "/" + from.Month + "/" + from.Year + " - " + to.Day + "/" + to.Month + "/" + to.Year;
                                        dr["Charge Name"] = getPackageType(patientno) + "(Rs." + getPackageAmount(patientno) + " X " + days + ")";
                                        dr["Amount"] = getPackageAmount(patientno) * days;
                                        totalAmount += (getPackageAmount(patientno) * days);
                                        dt.Rows.Add(dr);
                                    }
                                }
                            }
                            else
                            {
                                string wardName = PatientUtilities.getWardNameByBedNo(bar.bedno);
                                DataSet1.chargesDataTable cdt = cta.GetDataByWardName(wardName);
                                DataRow row = dt.NewRow();
                                row["Charge Name"] = wardName;
                                dt.Rows.Add(row);
                                for (int x = 0; x < cdt.Rows.Count; x++)
                                {
                                    DataRow dr = dt.NewRow();
                                    DataSet1.chargesRow cr = (DataSet1.chargesRow)cdt.Rows[x];
                                    dr["Date"] = from.Day + "/" + from.Month + "/" + from.Year + " - " + to.Day + "/" + to.Month + "/" + to.Year;
                                    dr["Charge Name"] = cr.chargeName + "(Rs." + cr.amount + " X " + days + ")";
                                    dr["Amount"] = cr.amount * days;
                                    totalAmount += (cr.amount * days);
                                    dt.Rows.Add(dr);
                                }
                            }
                        }
                        else
                        {
                            DateTime from = bar.dateofallotment;
                            if (badt.Rows.Count > 1)
                            {
                                int com = DateTime.Compare(from, Convert.ToDateTime(from.Month + "/" + from.Day + "/" + from.Year + " 12:00:00 PM"));
                                if (com >= 0)
                                {
                                    from = from.AddDays(1);
                                }
                            }
                            DateTime to = System.DateTime.Now.AddHours(12.5);
                            DateTime start = Convert.ToDateTime(from.Month + "/" + from.Day + "/" + from.Year);
                            DateTime end = Convert.ToDateTime(to.Month + "/" + to.Day + "/" + to.Year);
                            TimeSpan ts = end.Subtract(start);
                            int days = ts.Days;
                            int compare = DateTime.Compare(to, noon);
                            if (compare >= 0)
                            {
                                days = days + 1;
                            }
                            if (isPatientUnderPackage(patientno))
                            {
                                if (getPackageType(patientno).Equals("Total Charge"))
                                {
                                    DataRow dr = dt.NewRow();
                                    dr["Date"] = from.Day + "/" + from.Month + "/" + from.Year + " - " + to.Day + "/" + to.Month + "/" + to.Year;
                                    dr["Charge Name"] = getPackageType(patientno);
                                    dr["Amount"] = getPackageAmount(patientno);
                                    totalAmount += getPackageAmount(patientno);
                                    dt.Rows.Add(dr);
                                }
                                else
                                {
                                    DataRow dr = dt.NewRow();
                                    dr["Date"] = from.Day + "/" + from.Month + "/" + from.Year + " - " + to.Day + "/" + to.Month + "/" + to.Year;
                                    dr["Charge Name"] = getPackageType(patientno) + " (Rs." + getPackageAmount(patientno) + " X " + days + " Days)";
                                    dr["Amount"] = getPackageAmount(patientno) * days;
                                    totalAmount += (getPackageAmount(patientno) * days);
                                    dt.Rows.Add(dr);
                                }
                            }
                            else
                            {
                                string wardName = PatientUtilities.getWardNameByBedNo(bar.bedno);
                                DataSet1.chargesDataTable cdt = cta.GetDataByWardName(wardName);
                                DataRow row = dt.NewRow();
                                row["Charge Name"] = wardName;
                                dt.Rows.Add(row);
                                for (int x = 0; x < cdt.Rows.Count; x++)
                                {
                                    DataRow dr = dt.NewRow();
                                    DataSet1.chargesRow cr = (DataSet1.chargesRow)cdt.Rows[x];
                                    dr["Date"] = from.Day + "/" + from.Month + "/" + from.Year + " - " + to.Day + "/" + to.Month + "/" + to.Year;
                                    dr["Charge Name"] = cr.chargeName + " (Rs." + cr.amount + " X " + days + " Days)";
                                    dr["Amount"] = cr.amount * days;
                                    totalAmount += (cr.amount * days);
                                    dt.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }
                else
                {
                    /*DataRow drrr = dt.NewRow();
                    drrr["Charge Name"] = "Here Else = ";
                    drrr["Amount"] = "1";
                    dt.Rows.Add(drrr);*/
                }

            last: DataRow drr = dt.NewRow();
                drr["Charge Name"] = "Total";
                drr["Amount"] = totalAmount;
                dt.Rows.Add(drr);
                totalExpenses = totalAmount;
                gv.DataSource = dt;
                gv.DataBind();
                return gv;
            }
            catch (Exception ex)
            {
                DataRow dr = dt.NewRow();
                dr["Charge Name"] = "" + ex.Message;
                dr["Date"] = "Error";
                dt.Rows.Add(dr);

                gv.DataSource = dt;
                gv.DataBind();
                return gv;
            }
        }

        public static bool doDischargeEntries(int patientno, string currentUser)
        {
            try
            {
                DataSet1TableAdapters.expensesTableAdapter eta = new DataSet1TableAdapters.expensesTableAdapter();

                if (!isPatientDischarged(patientno))
                {
                    goto last;
                }

                DataSet1TableAdapters.chargesTableAdapter cta = new DataSet1TableAdapters.chargesTableAdapter();

                if (isAdmitted(patientno) && isPatientDischarged(patientno))
                {
                    DataSet1TableAdapters.ipdformTableAdapter ita = new DataSet1TableAdapters.ipdformTableAdapter();
                    DataSet1.ipdformDataTable idt = ita.GetDataByPatientNo(patientno);
                    DataSet1.ipdformRow idr = (DataSet1.ipdformRow)idt.Rows[0];

                    DataSet1TableAdapters.bedleavingTableAdapter blta = new DataSet1TableAdapters.bedleavingTableAdapter();

                    DataSet1TableAdapters.bedallotmentTableAdapter bata = new DataSet1TableAdapters.bedallotmentTableAdapter();
                    DataSet1.bedallotmentDataTable badt = bata.GetDataByPatientNo(patientno);
                    for (int i = 0; i < badt.Rows.Count; i++)
                    {
                        DataSet1.bedallotmentRow bar = (DataSet1.bedallotmentRow)badt.Rows[i];
                        DataSet1.bedleavingDataTable bldt = blta.GetDataByAllotmentNo(bar.sno);
                        if (bldt.Rows.Count > 0)
                        {
                            DataSet1.bedleavingRow blr = (DataSet1.bedleavingRow)bldt.Rows[0];
                            DateTime from = bar.dateofallotment;
                            DateTime to = blr.dateofleaving;
                            noon = Convert.ToDateTime(to.Month + "/" + to.Day + "/" + to.Year + " " + to.Hour + ":" + to.Minute + ":" + to.Second + "PM");
                            DateTime start = Convert.ToDateTime(from.Month + "/" + from.Day + "/" + from.Year);
                            DateTime end = Convert.ToDateTime(to.Month + "/" + to.Day + "/" + to.Year);
                            TimeSpan ts = end.Subtract(start);
                            int days = ts.Days;
                            int compare = DateTime.Compare(to, noon);
                            if (compare >= 0)
                            {
                                days = days + 1;
                            }
                            if (isPatientUnderPackage(patientno))
                            {
                                if (getPackageType(patientno).Equals("Total Charge"))
                                {
                                    eta.InsertQuery(to, getPackageAmount(patientno), getPackageType(patientno), patientno, currentUser);
                                }
                                else
                                {
                                    eta.InsertQuery(to, (getPackageAmount(patientno) * days), getPackageType(patientno) + "(Rs." + getPackageAmount(patientno) + " X " + days + ")", patientno, currentUser);
                                }
                            }
                            else
                            {
                                string wardName = PatientUtilities.getWardNameByBedNo(bar.bedno);
                                DataSet1.chargesDataTable cdt = cta.GetDataByWardName(wardName);
                                for (int x = 0; x < cdt.Rows.Count; x++)
                                {
                                    DataSet1.chargesRow cr = (DataSet1.chargesRow)cdt.Rows[x];
                                    eta.InsertQuery(to, (cr.amount * days), cr.chargeName + "(Rs." + cr.amount + " X " + days + ")", patientno, currentUser);
                                }
                            }
                        }
                        else
                        {
                            DateTime from = bar.dateofallotment;
                            if (badt.Rows.Count > 1)
                            {
                                int com = DateTime.Compare(from, Convert.ToDateTime(from.Month + "/" + from.Day + "/" + from.Year + " 12:00:00 PM"));
                                if (com >= 0)
                                {
                                    from = from.AddDays(1);
                                }
                            }
                            DateTime to = System.DateTime.Now;
                            DateTime start = Convert.ToDateTime(from.Month + "/" + from.Day + "/" + from.Year);
                            DateTime end = Convert.ToDateTime(to.Month + "/" + to.Day + "/" + to.Year);
                            TimeSpan ts = end.Subtract(start);
                            int days = ts.Days;
                            int compare = DateTime.Compare(to, noon);
                            if (compare >= 0)
                            {
                                days = days + 1;
                            }
                            if (isPatientUnderPackage(patientno))
                            {
                                if (getPackageType(patientno).Equals("Total Charge"))
                                {
                                    eta.InsertQuery(to, getPackageAmount(patientno), getPackageType(patientno), patientno, currentUser);
                                }
                                else
                                {
                                    eta.InsertQuery(to, getPackageAmount(patientno), getPackageType(patientno) + "(Rs." + getPackageAmount(patientno) + " X " + days + ")", patientno, currentUser);
                                }
                            }
                            else
                            {
                                string wardName = PatientUtilities.getWardNameByBedNo(bar.bedno);
                                DataSet1.chargesDataTable cdt = cta.GetDataByWardName(wardName);
                                for (int x = 0; x < cdt.Rows.Count; x++)
                                {
                                    DataSet1.chargesRow cr = (DataSet1.chargesRow)cdt.Rows[x];
                                    eta.InsertQuery(to, (cr.amount * days), cr.chargeName + "(Rs." + cr.amount + " X " + days + ")", patientno, currentUser);
                                }
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }

            last: return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool isPatientDischarged(int patientno)
        {
            DataSet1TableAdapters.dischargeTableAdapter dta = new DataSet1TableAdapters.dischargeTableAdapter();
            DataSet1.dischargeDataTable ddt = dta.GetDataByPatientno(patientno);
            if (ddt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static bool isAdmitted(int patientno)
        {
            DataSet1TableAdapters.ipdformTableAdapter ita = new DataSet1TableAdapters.ipdformTableAdapter();
            DataSet1.ipdformDataTable idt = ita.GetDataByPatientNo(patientno);
            if (idt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static string getPackageType(int patientno)
        {
            DataSet1TableAdapters.packageTableAdapter pta = new DataSet1TableAdapters.packageTableAdapter();
            DataSet1.packageDataTable pdt = pta.GetDataByPatientno(patientno);
            DataSet1.packageRow pr = (DataSet1.packageRow)pdt.Rows[0];
            return pr.packagename;
        }
        public static int getPackageAmount(int patientno)
        {
            DataSet1TableAdapters.packageTableAdapter pta = new DataSet1TableAdapters.packageTableAdapter();
            DataSet1.packageDataTable pdt = pta.GetDataByPatientno(patientno);
            DataSet1.packageRow pr = (DataSet1.packageRow)pdt.Rows[0];
            return pr.packageamount;
        }

        public static int getTotalPayments(int patientNo)
        {
            DataSet1TableAdapters.paymentsTableAdapter pta = new DataSet1TableAdapters.paymentsTableAdapter();
            DataSet1.paymentsDataTable pdt = pta.GetDataByPatientno(patientNo);
            if (pdt.Rows.Count <= 0)
                return 0;
            else
            {
                int pays = 0;
                for (int i = 0; i < pdt.Rows.Count; i++)
                {
                    DataSet1.paymentsRow pr = (DataSet1.paymentsRow)pdt.Rows[i];
                    pays += pr.amount;
                }
                return pays;
            }
        }
        public static double getTotalDiscounts(int patientNo)
        {
            DataSet1TableAdapters.discountdataTableAdapter dta = new DataSet1TableAdapters.discountdataTableAdapter();
            DataSet1.discountdataDataTable ddt = dta.GetDataByPatientno(patientNo);
            if (ddt.Rows.Count <= 0)
                return 0;
            else
            {
                double discount = 0;
                for (int i = 0; i < ddt.Rows.Count; i++)
                {
                    DataSet1.discountdataRow dr = (DataSet1.discountdataRow)ddt.Rows[i];
                    discount += dr.discountamount;
                }
                return discount;
            }
        }

    }
}
