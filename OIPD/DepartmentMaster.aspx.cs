using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class DepartmentMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = LoginManager.ProtectPage(Session, Response);
            if (!b)
                return;
            else
            {
                if (LoginManager.IsClerkLoggedIn(Session))
                    Response.Redirect("unauthorizedPage.aspx");
            }


        }
        protected void buttonsubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string name = txtdepartname.Text;
                string description = txtdescription.Text;
                IOPD.DataManager.DataSet1TableAdapters.departmentsTableAdapter da = new IOPD.DataManager.DataSet1TableAdapters.departmentsTableAdapter();
                da.InsertQuery(name, description);
                Validation.makeLabelVisible(lblMessage);
                Validation.setSuccess(lblMessage, "Department Added");
                GridView1.DataBind();


            }
            catch
            {

            }
        }
        protected void buttonreset_Click(object sender, EventArgs e)
        {
            Validation.makeLabelInVisible(lblMessage);
            Validation.totalResetTextBoxes(txtdepartname, txtdescription);
        }
        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            try
            {
                if (e.Exception == null)
                {
                    Validation.setSuccess(lblMessage, "Department Updated");
                    return;
                }
                throw e.Exception;
            }
            catch (Exception ex)
            {
                Validation.setError(lblMessage, ex);
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;

            }
        }
        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            try
            {
                if (e.Exception == null)
                {
                    Validation.setSuccess(lblMessage, "Department Deleted");
                    return;
                }
                throw e.Exception;
            }
            catch (Exception ex)
            {
                Validation.setError(lblMessage, ex);
                e.ExceptionHandled = true;


            }
        }
    }
}