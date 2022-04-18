using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace IOPD.DataManager
{
    public class LoginManager
    {
        private static string loginpage = "Login.aspx", homepage = "Home.aspx";
        public static bool adminLoggedIn;
        public static bool userLoggedIn;
        public static string loggedInUser;
        public static string currentuser;
        public static string getRandomPrefix()
        {

            return "GLC";
        }

        public static string addNewUser(String userName, int userType, String password)
        {
            try
            {
                DataSet1TableAdapters.siteusersTableAdapter suta = new DataSet1TableAdapters.siteusersTableAdapter();
                DataSet1.siteusersDataTable sudt = suta.GetDataByUserName(userName);
                if (sudt.Rows.Count != 0)
                    return "User Already Exists Change User Name";
                suta.InsertQuery(userName, password, "active", userType);
                return "Success";
            }
            catch (Exception ex)
            {
                return "" + ex.Message;
            }
        }

        public static bool ProtectPage(HttpSessionState session, HttpResponse response)
        {

            try
            {
                if (IsUserLoggedIn(session))
                    return true;
                response.Redirect(loginpage);
                return false;
            }
            catch
            {
                return false;

            }
        }

        public static bool IsUserNameAndPasswordCorrect(string username, string password)
        {

            try
            {
                DataSet1TableAdapters.siteusersTableAdapter da = new DataSet1TableAdapters.siteusersTableAdapter();
                DataSet1.siteusersDataTable dt = da.GetDataByUserNameAndPassword(username, password);
                if (dt.Rows.Count == 0)
                    return false;
                DataSet1.siteusersRow dr = (DataSet1.siteusersRow)dt.Rows[0];
                if (!dr.username.Equals(username))
                    return false;
                if (!dr.password.Equals(password))
                    return false;
                if (!dr.status.Equals("active"))
                    return false;
                return true;


            }
            catch
            {
                return false;
            }

        }


        public static bool logIn(string userName, string password, HttpResponse response, HttpSessionState session)
        {
            try
            {
                bool b = IsUserNameAndPasswordCorrect(userName, password);
                if (!b)
                {
                    //response.Redirect(loginpage);
                    return b;
                }
                session["username"] = userName;
                string usertype = checkUserType(userName);
                session["usertype"] = usertype;

                response.Redirect(homepage);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsUserLoggedIn(HttpSessionState session)
        {
            if (session["username"] == null)
                return false;
            return true;
        }
        public static string CurrentUser(HttpSessionState session)
        {
            if (session["username"] == null)
                return "";
            return "" + session["username"];
        }

        public static bool IsClerkLoggedIn(HttpSessionState session)
        {
            if (("" + session["usertype"]).Equals("clerk"))
                return true;
            return false;
        }
        public static bool IsAdminLoggedIn(HttpSessionState session)
        {
            if (("" + session["usertype"]).Equals("admin"))
                return true;
            return false;

        }



        public static string checkUserType(string userName)
        {
            try
            {
                DataSet1TableAdapters.siteusersTableAdapter da = new DataSet1TableAdapters.siteusersTableAdapter();
                DataSet1.siteusersDataTable sdt = da.GetDataByUserName(userName);
                DataSet1.siteusersRow sur = (DataSet1.siteusersRow)sdt.Rows[0];
                int uType = sur.usertype;

                DataSet1TableAdapters.usertypeTableAdapter utta = new DataSet1TableAdapters.usertypeTableAdapter();
                DataSet1.usertypeDataTable utdt = utta.GetDataBySno(uType);
                DataSet1.usertypeRow utr = (DataSet1.usertypeRow)utdt.Rows[0];
                return utr.type;
            }
            catch
            {
                return "";
            }
        }

        public static bool logout(HttpSessionState session, HttpResponse response)
        {
            try
            {
                session.Abandon();
                response.Redirect(loginpage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
