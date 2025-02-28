using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace HISPlus
{
    public static class OpRoomDbHelper
    {
        public static string GetDoctorName(int code)
        {
            using (DBHelper opRoomDb = new DBHelper(ConnectionStrings.OpRoomDB))
            {
                var doctorRow = opRoomDb.SelectSingle("Doctor", "Code = " + code);
                if (doctorRow == null)
                    throw new Exception(string.Format("Doctor with Code = {0} Does Not Exist.", code));
                else
                    return doctorRow["Name"].ToString();
            }
        }

        public static string GetNurseName(int code)
        {
            using (DBHelper opRoomDb = new DBHelper(ConnectionStrings.OpRoomDB))
            {
                var nurseRow = opRoomDb.SelectSingle("Nurse", "Code = " + code);
                if (nurseRow == null)
                    throw new Exception(string.Format("Nurse with Code = {0} Does Not Exist.", code));
                else
                    return nurseRow["Name"].ToString();
            }
        }

        public static string GetBTecnisianName(int code)
        {
            using (DBHelper opRoomDb = new DBHelper(ConnectionStrings.OpRoomDB))
            {
                var bTecnisianRow = opRoomDb.SelectSingle("BTecnisian", "Code = " + code);
                if (bTecnisianRow == null)
                    throw new Exception(string.Format("BTecnisian with Code = {0} Does Not Exist.", code));
                else
                    return bTecnisianRow["Name"].ToString();
            }
        }

        public static string GetOPTecnisianName(int code)
        {
            using (DBHelper opRoomDb = new DBHelper(ConnectionStrings.OpRoomDB))
            {
                var oPTecnisianRow = opRoomDb.SelectSingle("OPTecnisian", "Code = " + code);
                if (oPTecnisianRow == null)
                    throw new Exception(string.Format("OPTecnisian with Code = {0} Does Not Exist.", code));
                else
                    return oPTecnisianRow["Name"].ToString();
            }
        }

    }
}
