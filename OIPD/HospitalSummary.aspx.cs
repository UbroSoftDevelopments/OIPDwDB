using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class HospitalSummary : System.Web.UI.Page
    {
        int filterType = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            if (!this.IsPostBack)
            {
                DateTime today = System.DateTime.Now.AddHours(12.5);
                dt.Value = /*"11/28/2019";*/DateUtilities.onlyDateFormat(today);
                monthFilter.Visible = false;
                dateFilter.Visible = false;
                dateRangeFilter.Visible = false;
                for (int i = today.Year; i >= 2019; i--)
                {
                    ListItem li = new ListItem();
                    li.Text = "" + i;
                    li.Value = "" + i;
                    if (i == today.Year)
                        li.Selected = true;
                    drpDwnYear.Items.Add(li);
                }
                grdHospSummary.DataSourceID = "SqlDataSource1";
                grdHospSummary.DataBind();
            }
        }
        protected void drpDwnSumType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(drpDwnSumType.SelectedValue);
            switch (val)
            {
                case 0:
                    {
                        monthFilter.Visible = false;
                        dateRangeFilter.Visible = false;
                        dateFilter.Visible = false;
                        dt.Value = DateUtilities.onlyDateFormat(System.DateTime.Now.AddHours(12.5));
                        filterType = 0;
                        btnFilter_Click(sender, e);
                        break;
                    }
                case 1:
                    {
                        monthFilter.Visible = false;
                        dateRangeFilter.Visible = false;
                        dateFilter.Visible = true;
                        filterType = 1;
                        break;
                    }
                case 2:
                    {
                        monthFilter.Visible = false;
                        dateRangeFilter.Visible = true;
                        dateFilter.Visible = false;
                        filterType = 2;
                        break;
                    }
                case 3:
                    {
                        monthFilter.Visible = true;
                        dateRangeFilter.Visible = false;
                        dateFilter.Visible = false;
                        filterType = 3;
                        break;
                    }
            }
        }

        int m = 0;
        public void setTotal(object sender, EventArgs e)
        {
            //Title = "Rs. " + m + "/-";
            ttlEarning.Text = "Total :- Rs. " + m + "/-";
        }
        public void onRowBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                m += int.Parse(e.Row.Cells[3].Text);
            }
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";


            try
            {
                filterType = Convert.ToInt32(drpDwnSumType.SelectedValue);
                switch (filterType)
                {
                    case 0:
                        {
                            grdHospSummary.DataSourceID = "SqlDataSource1";
                            grdHospSummary.DataBind();
                            break;
                        }
                    case 1:
                        {
                            if (txtOnDate.Text.Trim().Equals(""))
                                throw new Exception("Please Enter Date");
                            else
                            {
                                dt.Value = DateUtilities.onlyDateFormat(txtOnDate.Text);
                                grdHospSummary.DataSourceID = "SqlDataSource1";
                                grdHospSummary.DataBind();
                            }
                            break;
                        }
                    case 2:
                        {
                            if (txtFrom.Text.Trim().Equals(""))
                                throw new Exception("Please Enter Starting Date");
                            else
                            if (txtTo.Text.Trim().Equals(""))
                                throw new Exception("Please Enter End Date");
                            else
                            {
                                from.Value = DateUtilities.onlyDateFormat(txtFrom.Text);
                                to.Value = DateUtilities.onlyDateFormat(txtTo.Text);
                                grdHospSummary.DataSourceID = "SqlDataSource2";
                                grdHospSummary.DataBind();
                            }
                            break;
                        }
                    case 3:
                        {
                            int month = Convert.ToInt32(drpDwnMonth.SelectedValue);
                            int year = Convert.ToInt32(drpDwnYear.SelectedValue);
                            int days = DateUtilities.GetDayInMonth(month, year);
                            from.Value = DateUtilities.onlyDateFormat(month + "/01/" + year);
                            to.Value = DateUtilities.onlyDateFormat(month + "/" + days + "/" + year);
                            grdHospSummary.DataSourceID = "SqlDataSource2";
                            grdHospSummary.DataBind();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                lblErr.Text = "" + ex.Message;
                //Validation.setError(lblErr, ex);
            }
        }
    }
}