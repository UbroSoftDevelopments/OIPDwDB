using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace IOPD.DataManager
{
    public class Validation
    {
        public static string prevPage;
        public static string ConvertNumbertoWords(long number)
        {
            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " LAKHS ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "") words += "AND ";
                var units = new[]
            {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
                var tens = new[]
            {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
                if (number < 20) words += units[number];
                else
                {
                    words += tens[number / 10];
                    if ((number % 10) > 0) words += " " + units[number % 10];
                }
            }
            return words;
        }

        public static bool isPasswordOk(string password)
        {
            if (password.Length < 6)
                return false;
            else
                return true;
        }
        private static List<TextBox> textboxes;

        public static List<TextBox> GetList()
        {
            List<TextBox> textboxes = new List<TextBox>();
            return textboxes;
        }
        public static void addTextBoxes(List<TextBox> textboxes, TextBox txt)
        {
            textboxes.Add(txt);

        }

        public static void throwException(string message, params System.Web.UI.WebControls.TextBox[] textboxes)
        {
            foreach (TextBox txt in textboxes)
                txt.CssClass += " w3-red";
            throw new Exception(message);
        }
        public static void totalResetTextBoxes(params System.Web.UI.WebControls.TextBox[] textboxes)
        {
            foreach (TextBox txt in textboxes)
            {
                txt.Text = "";
                txt.CssClass = txt.CssClass.Replace("w3-red", "");
            }
        }

        public static void colorResetTextBoxes(params System.Web.UI.WebControls.TextBox[] textboxes)
        {
            foreach (TextBox txt in textboxes)
            {
                //  txt.Text = "";
                txt.CssClass = txt.CssClass.Replace("w3-red", "");
            }
        }
        public static void totalResetLabels(params System.Web.UI.WebControls.Label[] labels)
        {
            foreach (Label lbl in labels)
            {
                lbl.Text = "Messages";
                lbl.CssClass = lbl.CssClass.Replace("w3-red", "");
                lbl.CssClass = lbl.CssClass.Replace("w3-green", "");
            }
        }
        public static void makeLabelVisible(params System.Web.UI.WebControls.Label[] labels)
        {
            foreach (Label lbl in labels)
            {

                lbl.CssClass = lbl.CssClass.Replace("w3-hide", "");

            }
        }
        public static void makeLabelInVisible(params System.Web.UI.WebControls.Label[] labels)
        {
            foreach (Label lbl in labels)
            {

                lbl.CssClass = lbl.CssClass + " w3-hide ";

            }
        }

        public static void makeTextBoxVisible(params System.Web.UI.WebControls.TextBox[] labels)
        {
            foreach (TextBox lbl in labels)
            {

                lbl.CssClass = lbl.CssClass.Replace("w3-hide", "");

            }
        }
        public static void makeTextBoxInVisible(params System.Web.UI.WebControls.TextBox[] labels)
        {
            foreach (TextBox lbl in labels)
            {

                lbl.CssClass = lbl.CssClass + " w3-hide ";

            }
        }

        public static int adjustHigh(int n, int limit)
        {
            if (n > limit)
                return limit;
            return n;
        }


        public static int adjustLow(int n, int limit)
        {
            if (n < limit)
                return limit;
            return n;
        }
        public static void resetTextBoxes(params System.Web.UI.WebControls.TextBox[] textboxes)
        {
            foreach (TextBox txt in textboxes)
            {
                txt.CssClass = txt.CssClass.Replace("w3-red", "");
                txt.CssClass = txt.CssClass.Replace("w3-green", "");
            }
        }
        public static int getInt(string str)
        {
            try
            {
                str = ("" + str).Trim();
                return Convert.ToInt32(str);
            }
            catch
            {
                return -1;
            }
        }
        public static bool isInteger(string str)
        {
            try
            {
                str = ("" + str).Trim();
                Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void setError(Label lbl, string message)
        {
            lbl.Text = message;
            lbl.CssClass = lbl.CssClass.Replace("w3-red", "");
            lbl.CssClass = lbl.CssClass.Replace("w3-green", "");
            lbl.CssClass += " w3-red";
        }
        public static void setError(Label lbl, Exception ex)
        {
            setError(lbl, ex.Message);
        }
        public static void setSuccess(Label lbl, string message)
        {
            lbl.Text = message;
            lbl.CssClass = lbl.CssClass.Replace("w3-red", "");
            lbl.CssClass = lbl.CssClass.Replace("w3-green", "");
            lbl.CssClass += " w3-green";
        }
        public static void setSuccess(Label lbl, Exception ex)
        {
            setError(lbl, ex.Message);
        }
        public static string errorStringFromNumber(int n)
        {
            if (n < 0)
                return "";
            else
                return "" + n;
        }
    }
}
