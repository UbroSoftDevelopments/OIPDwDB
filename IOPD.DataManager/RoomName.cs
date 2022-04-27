using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class RoomName
    {
        public int sno, wardno, roomtype;
        public string roomno;
        public bool valid = false;
        public RoomName(int sno, int wardno, string roomno, int roomtype)
        {
            this.sno = sno;
            this.wardno = wardno;
            this.roomno = roomno;
            this.roomtype = roomtype;
            valid = true;

        }
        public RoomName(int sno)
        {
            try
            {
                DataSet1TableAdapters.roommasterTableAdapter da = new DataSet1TableAdapters.roommasterTableAdapter();
                DataSet1.roommasterDataTable dt = da.GetDataBySno(sno);
                DataSet1.roommasterRow dr = (DataSet1.roommasterRow)dt.Rows[0];
                this.sno = dr.sno;
                this.wardno = dr.wardno;
                this.roomno = dr.roomno;
                this.roomtype = dr.roomtype;

                valid = true;
            }
            catch
            {

                valid = false;
            }
        }
    }
}
