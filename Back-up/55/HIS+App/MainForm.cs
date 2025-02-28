using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace HISPlus
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            

           // ConnectionStrings.OpRoomDB = @"Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;Password=myPassword;";

           // var c = ConnectionStrings.OpRoomDB;
        }

        private void تنظیماتصالبهدیتابیسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBConnectionSettingForm dbForm = new DBConnectionSettingForm();
            dbForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

     


    }
}
