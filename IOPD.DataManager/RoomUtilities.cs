using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOPD.DataManager
{
    public class RoomUtilities
    {

        public bool valid = false;
        public static string getName(object sno)
        {
            try
            {
                RoomName rn = new RoomName(Convert.ToInt32(sno));
                return rn.roomno;
            }
            catch (Exception)
            {

                return "";
            }

        }
        public static int getWard(object sno)
        {
            try
            {
                RoomName rn = new RoomName(Convert.ToInt32(sno));
                return rn.wardno;
            }
            catch
            {
                return -1;
            }
        }
        public static string getRoomTypeName(object roomtypeno)
        {
            try
            {
                RoomTypeName rt = new RoomTypeName(Convert.ToInt32(roomtypeno));

                return rt.roomtype;
            }
            catch
            {
                return "";
            }

        }

        public static string getroomname(int roomtypeno)
        {
            try
            {
                RoomTypeName name = new RoomTypeName(roomtypeno);
                if (!name.valid)
                    throw new Exception();
                return name.roomtype;
            }
            catch
            {
                return "";
            }

        }

    }


}
