using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class RoomTypeName
    {
        public int roomtypeno;
        public string roomtype;
        public bool valid = false;
        public RoomTypeName(int roomtypeno, string roomtype)
        {
            this.roomtypeno = roomtypeno;
            this.roomtype = roomtype;
            valid = true;
        }
        public RoomTypeName(int roomtypeno)
        {
            try
            {
                DataSet1TableAdapters.roomtypesTableAdapter da = new DataSet1TableAdapters.roomtypesTableAdapter();
                DataSet1.roomtypesDataTable dt = da.GetDataByRoomTypeNo(roomtypeno);
                DataSet1.roomtypesRow dr = (DataSet1.roomtypesRow)dt.Rows[0];
                this.roomtypeno = dr.roomtypeno;
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
