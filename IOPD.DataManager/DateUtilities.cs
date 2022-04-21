using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class DateUtilities
    {

        private static DateTime defaultdate = new DateTime(1900, 1, 1);
        public static string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public static string[] fullmonths = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public static int getInt(string str)
        {
            str = ("" + str).Trim();
            if (str.Equals(""))
                return -1;
            return Convert.ToInt32(str);
        }
        public static string dateFormat(DateTime date)
        {
            if (date == defaultdate)
                return "";
            //date = date.AddHours(12.50);
            return "" + date.Day + "-" + months[date.Month - 1] + "-" + date.Year + " " + date.Hour + ":" + date.Minute + " " + date.ToString("tt");
        }
        public static string dateFormat(object date)
        {
            try
            {
                DateTime dt = Convert.ToDateTime("" + date);
                return dateFormat(dt);
            }
            catch
            {
                return dateFormat(defaultdate);
            }
        }

        public static string onlyDateFormat(object date)
        {
            try
            {
                DateTime dt = Convert.ToDateTime("" + date);
                return dt.Day + "-" + months[dt.Month - 1] + "-" + dt.Year;
            }
            catch
            {
                return dateFormat(defaultdate);
            }
        }


        public static DateTime getDate(string date)
        {
            date = ("" + date.Trim());
            if (date.Equals(""))
                return defaultdate;
            return Convert.ToDateTime(date);
        }
        public static DateTime getMidnight(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static int dateDiffer(object startDate)
        {
            DateTime start = Convert.ToDateTime(startDate);
            DateTime today = System.DateTime.Now;
            today = today.AddHours(12.50);
            double total = (today - start).TotalDays;
            int tt = (int)total;
            return tt;
        }

        public static DateTime DefaultDate
        {
            get
            {
                return defaultdate;
            }
        }
        public static bool IsLeapYear(int Year)
        {
            if (Year % 400 == 0)

                return true;

            if ((Year % 4 == 0) && (Year % 100 != 0))
                return true;
            return false;
        }
        public static int GetDayInMonth(int Month, int Year)
        {
            if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                return 31;

            if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                return 30;

            if (IsLeapYear(Year))

                return 29;

            return 28;
        }
    }
}
