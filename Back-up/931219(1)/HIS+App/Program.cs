using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HISPlus
{
    static class Program
    {
        public static DataRow LoginUserRow
        {
            get;
            set;
        }

        public static int LoginUserID
        {
            get
            {
                return int.Parse(LoginUserRow["ID"].ToString());
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
            //Application.Run(new MainForm());
            Application.Run(new MainForm());
        }
    }
}
