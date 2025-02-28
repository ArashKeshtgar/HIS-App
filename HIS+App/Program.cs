using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace HISPlus
{
    static class Program
    {
        public static SystemUser LoginUser;

        public static string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().FullName.Split(',')[1].Replace("Version=", "").Trim();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static bool CheckVersion()
        {
            var dbVersion = HisPlusDbHelper.GetDbVersion();
            if (dbVersion != Program.Version)
            {
                MessageBox.Show(string.Format("این نسخه برنامه قابل استفاده نمیباشد. لطفا نسخه {0} را اجرا نمایید.", dbVersion), "خطا");
                return false;
            }
            else
                return true;
        }

        public static DateTime GetServerTime()
        {
            using (var hisPlusDb = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                return hisPlusDb.ExecuteScalarQuery<DateTime>("select GetDate()");
            }
        }
    }
}
