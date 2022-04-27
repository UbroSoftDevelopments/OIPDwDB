using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class upload : System.Web.UI.Page
    {
        Patient p;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool b = LoginManager.ProtectPage(Session, Response);
                if (!b)
                    return;
                int sno = Convert.ToInt32(Request.QueryString["sno"]);
                p = new Patient(sno);
                lblpIpNumber.Text = "<b>IP Number :-</b><br />" + p.ipnumber;
                lblpName.Text = "<b>Patient Name :-</b><br />" + p.firstname + " " + p.lastname;
                lblpAge.Text = "<b>Patient Age :-</b><br />" + p.ageyears + "Y " + p.agemonths + "M " + p.agedays + "D";
                lblpAddress.Text = "<b>Address :-</b><br />" + p.address;

                IOPD.DataManager.DataSet1TableAdapters.patientDocsTableAdapter pdta = new IOPD.DataManager.DataSet1TableAdapters.patientDocsTableAdapter();
                DataSet1.patientDocsDataTable pddt = pdta.GetDataByPatientNoAndDocName(sno, "profile");
                if (pddt.Rows.Count != 0)
                {
                    chkProfile.Enabled = false;
                    chkProfile.CssClass = chkProfile.CssClass + " w3-text-gray w3-disabled";
                }
            }
            catch (Exception ex)
            {
                Validation.setError(lblErr, ex);
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (!files.HasFile)
                    throw new Exception("First Select Any File To Upload.");
                if (txtDocName.Text.Trim().Equals(""))
                    throw new Exception("Please Enter Document Name");

                string docName = "" + txtDocName.Text;
                string folderText = "documents/" + Convert.ToInt32(Request.QueryString["sno"]) + "/" + docName;
                string folder = Server.MapPath(folderText);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                string src = folder + "/" + files.FileName;
                if (File.Exists(src))
                    throw new Exception("A file with this name already exists.");
                else
                    files.SaveAs(src);
                IOPD.DataManager.DataSet1TableAdapters.patientDocsTableAdapter pdta = new IOPD.DataManager.DataSet1TableAdapters.patientDocsTableAdapter();
                pdta.Insert1(Convert.ToInt32(Request.QueryString["sno"]), folderText + "/" + files.FileName, docName);
                Validation.setSuccess(lblErr, "Document Uploded Successfully");
            }
            catch (Exception ex)
            {
                Validation.setError(lblErr, ex);
            }
        }
        public void changedEvent(object sender, EventArgs e)
        {
            if (chkProfile.Checked)
            {
                lblDocName.Visible = false;
                txtDocName.Visible = false;
                txtDocName.Text = "profile";
            }
            else
            {
                lblDocName.Visible = true;
                txtDocName.Visible = true;
                txtDocName.Text = "";
            }
        }
    }
}