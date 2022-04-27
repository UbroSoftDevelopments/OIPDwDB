using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOPD.DataManager;

namespace OIPD
{
    public partial class generateID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addStaff(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim().Equals(""))
                    throw new Exception("Please Enter Staff Name");
                if (txtDesignation.Text.Trim().Equals(""))
                    throw new Exception("Please Enter Post");
                if (txtDob.Text.Trim().Equals(""))
                    throw new Exception("Please Date of Birth");
                if (txtMobile.Text.Trim().Equals(""))
                    throw new Exception("Please Enter Mobile Number");
                if (txtEmail.Text.Trim().Equals(""))
                    throw new Exception("Please Enter Email ID");
                if (txtBloodGroup.Text.Trim().Equals(""))
                    throw new Exception("Please Enter Staff Blood Group");
                if (!uploadPic.HasFile)
                    throw new Exception("Please Upload Photo");

                string src = savePhoto();
                if (src.Trim().Equals(""))
                    return;
                string name = txtName.Text.Trim();
                string designation = txtDesignation.Text.Trim();
                DateTime dob = Convert.ToDateTime(txtDob.Text);
                string mobile_number = txtMobile.Text.Trim();
                string emailid = txtEmail.Text.Trim();
                string bloodgroup = txtBloodGroup.Text.Trim();

                IOPD.DataManager.DataSet1TableAdapters.staffTableAdapter sta = new IOPD.DataManager.DataSet1TableAdapters.staffTableAdapter();
                sta.InsertQuery(name, src, designation, dob, mobile_number, emailid, bloodgroup);

                Validation.setSuccess(lblMsg, "Staff Added Successfully");
                grdStaff.DataBind();
            }
            catch (Exception ex)
            {
                Validation.setError(lblMsg, ex);
            }
        }

        public string savePhoto()
        {
            string folderText = "IDPic/" + txtName.Text.Trim() + txtDesignation.Text.Trim();
            string folder = Server.MapPath(folderText);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            string src = folderText + "/" + uploadPic.FileName;
            if (File.Exists(src))
            {
                Validation.setError(lblMsg, "A file with this name already exists.");
                return "";
            }
            else
            {
                Bitmap pic = imgUtilities.getResizedImage(uploadPic, 200, 250);
                pic.Save(folder + "/" + uploadPic.FileName);
                //files.SaveAs(src);
            }
            return src;
        }
    }
}