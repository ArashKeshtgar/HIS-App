using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace HISPlus
{
    public static class HisPlusDbHelper
    {
        public static string GetDbVersion()
        {
            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                return dbHelper.ExecuteScalarQuery<string>("select Value from Settings where Name = 'Version'");
            }
        }

        public static bool CheckDbConnection()
        {
            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                return dbHelper.CheckDbConnection();
            }
        }
    }
}
