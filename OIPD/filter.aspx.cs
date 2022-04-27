using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class filter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            if (!this.IsPostBack)
            {
                filterUtils.listType = 1;
                filterUtils.patientType = 0;
                filterUtils.selectedDep = -1;
                filterUtils.selectedMonth = 0;
                filterUtils.selectedYear = 0;
                opdList(sender, e);
                mainGrid.DataSourceID = "SqlDataSource1";
                setYear();
            }
            else
            {
                filterUtils.selectedDep = Convert.ToInt32(ddDepartments.SelectedValue);
                filterUtils.selectedMonth = Convert.ToInt32(ddMonths.SelectedValue);
                filterUtils.selectedYear = Convert.ToInt32(ddYears.SelectedValue);
            }
        }

        public void setYear()
        {
            DateTime today = System.DateTime.Now.AddHours(12.5);
            ListItem l = new ListItem();
            l.Text = "Current";
            l.Value = "0";
            ddYears.Items.Add(l);
            for (int x = today.Year; x >= 2018; x--)
            {
                ListItem li = new ListItem();
                li.Text = "" + x;
                li.Value = "" + x;
                ddYears.Items.Add(li);
            }
        }

        protected void opdList(object sender, EventArgs e)
        {
            try
            {
                topopd.Attributes.Remove("class");
                topopd.Attributes.Add("class", "w3-col s4 back1 activeTop");
                topipd.Attributes.Remove("class");
                topipd.Attributes.Add("class", "w3-col s4 back2 inactiveTop");
                topdis.Attributes.Remove("class");
                topdis.Attributes.Add("class", "w3-col s4 back3 inactiveTop");
                filterUtils.listType = 1;
                if (filterUtils.selectedDep == -1)
                {
                    if (filterUtils.patientType == 0)
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) order by patientno desc";
                            }
                        }
                    }
                    else
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                        }
                        //SqlDataSource1.SelectCommand = "select * from opdform where (patientno>'1') and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                    }
                }
                else
                {
                    if (filterUtils.patientType == 0)
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                    }
                    else
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                    }
                }
                mainGrid.DataBind();
                setCount();
            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message);
            }
        }
        protected void ipdList(object sender, EventArgs e)
        {
            try
            {
                topipd.Attributes.Remove("CssClass");
                topipd.Attributes.Add("class", "w3-col s4 back2 activeTop");
                topopd.Attributes.Remove("class");
                topopd.Attributes.Add("class", "w3-col s4 back1 inactiveTop");
                topdis.Attributes.Remove("class");
                topdis.Attributes.Add("class", "w3-col s4 back3 inactiveTop");
                filterUtils.listType = 2;
                if (filterUtils.selectedDep == -1)
                {
                    if (filterUtils.patientType == 0)
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) order by patientno desc";
                            }
                        }
                    }
                    else
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                        }
                        //SqlDataSource1.SelectCommand = "select * from opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM currentbedpatients)) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                    }
                }
                else
                {
                    if (filterUtils.patientType == 0)
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                    }
                    else
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM ipdform)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                    }
                }
                mainGrid.DataBind();
                setCount();
                //SqlDataSource1.SelectCommand = "select * from opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM currentbedpatients)) order by patientno desc";

            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message);
            }
        }
        protected void disList(object sender, EventArgs e)
        {
            try
            {
                topdis.Attributes.Remove("class");
                topdis.Attributes.Add("class", "w3-col s4 back3 activeTop");
                topipd.Attributes.Remove("class");
                topipd.Attributes.Add("class", "w3-col s4 back2 inactiveTop");
                topopd.Attributes.Remove("class");
                topopd.Attributes.Add("class", "w3-col s4 back1 inactiveTop");
                filterUtils.listType = 3;
                if (filterUtils.selectedDep == -1)
                {
                    if (filterUtils.patientType == 0)
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) order by patientno desc";
                            }
                        }
                    }
                    else
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                            }
                        }
                        //SqlDataSource1.SelectCommand = "select * from opdform where (patientno>'1') and patienttype='" + filterUtils.patientType + "' order by patientno desc";
                    }
                }
                else
                {
                    if (filterUtils.patientType == 0)
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                    }
                    else
                    {
                        if (filterUtils.selectedMonth == 0)
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = "01/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = "12/31/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                        else
                        {
                            if (filterUtils.selectedYear == 0)
                            {
                                int crrYear = System.DateTime.Now.AddHours(12.5).Year;
                                string startDate = filterUtils.selectedMonth + "/01/" + crrYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, crrYear) + "/" + crrYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                            else
                            {
                                string startDate = filterUtils.selectedMonth + "/01/" + filterUtils.selectedYear + " 12:00:00 AM";
                                string endDate = filterUtils.selectedMonth + "/" + DateUtilities.GetDayInMonth(filterUtils.selectedMonth, filterUtils.selectedYear) + "/" + filterUtils.selectedYear + " 11:59:59 PM";
                                SqlDataSource1.SelectCommand = "select * from hospitals.opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) AND ((CAST(dateofentry as date) > '" + startDate + "') AND (CAST(dateofentry as date) < '" + endDate + "')) and patienttype='" + filterUtils.patientType + "' and (departmentno='" + filterUtils.selectedDep + "') order by patientno desc";
                            }
                        }
                    }
                }
                mainGrid.DataBind();
                setCount();
                //SqlDataSource1.SelectCommand = "select * from opdform where (patientno>'1') and (patientno IN (SELECT patientno FROM discharge)) order by patientno desc";

            }
            catch (Exception ex)
            {
                Response.Write("" + ex.Message);
            }
        }

        protected void allList(object sender, EventArgs e)
        {
            leftAll.Attributes.Remove("class");
            leftAll.Attributes.Add("class", "w3-padding-small backA activeLeft");
            leftGeet.Attributes.Remove("class");
            leftGeet.Attributes.Add("class", "w3-padding-small back1 inactiveLeft");
            leftAyush.Attributes.Remove("class");
            leftAyush.Attributes.Add("class", "w3-padding-small back2 inactiveLeft");
            leftCash.Attributes.Remove("class");
            leftCash.Attributes.Add("class", "w3-padding-small back3 inactiveLeft");
            filterUtils.patientType = 0;
            if (filterUtils.listType == 1)
            {
                opdList(sender, e);
            }
            else if (filterUtils.listType == 2)
            {
                ipdList(sender, e);
            }
            else
            {
                disList(sender, e);
            }
        }
        protected void geetList(object sender, EventArgs e)
        {
            leftAll.Attributes.Remove("class");
            leftAll.Attributes.Add("class", "w3-padding-small backA inactiveLeft");
            leftGeet.Attributes.Remove("class");
            leftGeet.Attributes.Add("class", "w3-padding-small back1 activeLeft");
            leftAyush.Attributes.Remove("class");
            leftAyush.Attributes.Add("class", "w3-padding-small back2 inactiveLeft");
            leftCash.Attributes.Remove("class");
            leftCash.Attributes.Add("class", "w3-padding-small back3 inactiveLeft");
            filterUtils.patientType = 1;
            if (filterUtils.listType == 1)
            {
                opdList(sender, e);
            }
            else if (filterUtils.listType == 2)
            {
                ipdList(sender, e);
            }
            else
            {
                disList(sender, e);
            }
        }
        protected void ayushList(object sender, EventArgs e)
        {
            leftAll.Attributes.Remove("class");
            leftAll.Attributes.Add("class", "w3-padding-small backA inactiveLeft");
            leftGeet.Attributes.Remove("class");
            leftGeet.Attributes.Add("class", "w3-padding-small back1 inactiveLeft");
            leftAyush.Attributes.Remove("class");
            leftAyush.Attributes.Add("class", "w3-padding-small back2 activeLeft");
            leftCash.Attributes.Remove("class");
            leftCash.Attributes.Add("class", "w3-padding-small back3 inactiveLeft");
            filterUtils.patientType = 2;
            if (filterUtils.listType == 1)
            {
                opdList(sender, e);
            }
            else if (filterUtils.listType == 2)
            {
                ipdList(sender, e);
            }
            else
            {
                disList(sender, e);
            }
        }
        protected void cashList(object sender, EventArgs e)
        {
            leftAll.Attributes.Remove("class");
            leftAll.Attributes.Add("class", "w3-padding-small backA inactiveLeft");
            leftGeet.Attributes.Remove("class");
            leftGeet.Attributes.Add("class", "w3-padding-small back1 inactiveLeft");
            leftAyush.Attributes.Remove("class");
            leftAyush.Attributes.Add("class", "w3-padding-small back2 inactiveLeft");
            leftCash.Attributes.Remove("class");
            leftCash.Attributes.Add("class", "w3-padding-small back3 activeLeft");
            filterUtils.patientType = 3;
            if (filterUtils.listType == 1)
            {
                opdList(sender, e);
            }
            else if (filterUtils.listType == 2)
            {
                ipdList(sender, e);
            }
            else
            {
                disList(sender, e);
            }
        }

        protected void ddDepartments_DataBound(object sender, EventArgs e)
        {
            ListItem li = new ListItem();
            li.Text = "All";
            li.Value = "-1";
            ddDepartments.Items.Insert(0, li);
        }
        protected void ddDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterUtils.selectedDep = Convert.ToInt32(ddDepartments.SelectedValue);
            if (filterUtils.listType == 1)
            {
                opdList(sender, e);
            }
            else if (filterUtils.listType == 2)
            {
                ipdList(sender, e);
            }
            else
            {
                disList(sender, e);
            }
            /*if (Convert.ToInt32(ddDepartments.SelectedValue) != -1)
            {
                SqlDataSource1.SelectCommand = "select * from opdform";
                if (filterUtils.listType == 2)
                {
                    SqlDataSource1.SelectCommand = SqlDataSource1.SelectCommand + " where (patientno > '1') and patienttype='" + filterUtils.patientType + "' and (patientno IN (SELECT patientno FROM currentbedpatients)) ";
                }
                else if (filterUtils.listType == 3)
                {
                    SqlDataSource1.SelectCommand = SqlDataSource1.SelectCommand + " where (patientno > '1') and patienttype='" + filterUtils.patientType + "' and (patientno IN (SELECT patientno FROM discharge)) ";
                }
                else
                {
                    SqlDataSource1.SelectCommand = SqlDataSource1.SelectCommand + " where (patientno> '1') and patienttype='" + filterUtils.patientType + "' ";
                }
                SqlDataSource1.SelectCommand = SqlDataSource1.SelectCommand + " and departmentno='" + ddDepartments.SelectedValue + "' order by patientno desc";
                mainGrid.DataBind();
            }
            else
            {
                filterUtils.selectedDep = -1; SqlDataSource1.SelectCommand = "select * from opdform";
                if (filterUtils.listType == 2)
                {
                    SqlDataSource1.SelectCommand = SqlDataSource1.SelectCommand + " where (patientno > '1') and patienttype='" + filterUtils.patientType + "' and (patientno IN (SELECT patientno FROM currentbedpatients))  order by patientno desc";
                }
                else if (filterUtils.listType == 3)
                {
                    SqlDataSource1.SelectCommand = SqlDataSource1.SelectCommand + " where (patientno > '1') and patienttype='" + filterUtils.patientType + "' and (patientno IN (SELECT patientno FROM discharge))  order by patientno desc";
                }
                else
                {
                    SqlDataSource1.SelectCommand = SqlDataSource1.SelectCommand + " where (patientno> '1') and patienttype='" + filterUtils.patientType + "'  order by patientno desc";
                }
                mainGrid.DataBind();
            }*/
        }

        protected void filterMonth(object sender, EventArgs e)
        {
            filterUtils.selectedMonth = Convert.ToInt32(ddMonths.SelectedValue);
            filterUtils.selectedYear = Convert.ToInt32(ddYears.SelectedValue);
            if (filterUtils.listType == 1)
            {
                opdList(sender, e);
            }
            else if (filterUtils.listType == 2)
            {
                ipdList(sender, e);
            }
            else
            {
                disList(sender, e);
            }
        }

        protected void setCount()
        {
            try
            {
                DataTable dt = ((DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty)).Table;
                casesCount.Text = dt.Rows.Count + " Cases";
                //Title = "" + dt.Rows.Count + " cases";
            }
            catch (Exception ex)
            {
                Response.Write("Count Err:- " + ex.Message);
            }
        }

    }
}