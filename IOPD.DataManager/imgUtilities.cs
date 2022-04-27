using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace IOPD.DataManager
{
    public class imgUtilities
    {
        public imgUtilities()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static Bitmap getResizedImage(FileUpload FileUpload1, int width, int height)
        {
            Stream stream = FileUpload1.PostedFile.InputStream;

            Bitmap image = new Bitmap(stream);

            Bitmap target = new Bitmap(width, height);
            Graphics graphic = Graphics.FromImage(target);
            graphic.DrawImage(image, 0, 0, width, height);
            return target;
        }
    }
}
