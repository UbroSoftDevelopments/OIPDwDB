using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class roommaster : System.Web.UI.Page
    {
        int number;
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


                number = Convert.ToInt32(Request.QueryString["wardno"]);

                IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.wardmasterTableAdapter();
                DataSet1.wardmasterDataTable dt = da.GetDataBy(number);
                DataSet1.wardmasterRow dr = (DataSet1.wardmasterRow)dt.Rows[0];
                string name = dr.wardname;
                lblwardname.Text = name;
                lblgridviewheading.Text = "Rooms Available In " + name;
            }
            catch
            {

                Response.Redirect("wardmaster.aspx");
            }

        }
        protected void buttonsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string roomnumber = txtroomno.Text;
                if (ddTypes.SelectedIndex < 0)
                    throw new Exception("Select a roomtype");
                int roomtype = Convert.ToInt32(ddTypes.SelectedValue);
                IOPD.DataManager.DataSet1TableAdapters.roommasterTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.roommasterTableAdapter();
                da.InsertQuery(number, roomnumber, roomtype);

                Validation.setSuccess(lblMessage, "Success");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Validation.setError(lblMessage, ex);
            }

        }
        protected void buttonreset_Click(object sender, EventArgs e)
        {
            Validation.totalResetTextBoxes(txtroomno);
            Validation.makeLabelInVisible(lblMessage);
        }
        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            try
            {
                if (e.Exception != null)
                    throw e.Exception;
                Validation.setSuccess(lblMessage, "Success");
            }
            catch (Exception ex)
            {
                Validation.setError(lblMessage, ex);
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;
            }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //    int roomtype =Convert.ToInt32( e.NewValues["roomtype"]);
            //    if (roomtype == 1)
            //    {

            //        Validation.setError(lblMessage, "Error");
            //        e.Cancel = true;
            //        return;
            //    }
        }
    }
}