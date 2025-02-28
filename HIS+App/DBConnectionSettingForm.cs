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
    public partial class DBConnectionSettingForm : Form
    {
        public DBConnectionSettingForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            uiOpRoomConnectionString.Text = ConnectionStrings.OpRoomDB;
            uiHISPlusConnectionString.Text = ConnectionStrings.HisPlusDB;
        }

        private void uiOpRoomConnectionTest_Click(object sender, EventArgs e)
        {
            TestConnection(uiOpRoomConnectionString.Text, true);
        }

        private void uiHisPlusConnectionTest_Click(object sender, EventArgs e)
        {
            TestConnection(uiHISPlusConnectionString.Text, true);
        }

        private void uiSaveButton_Click(object sender, EventArgs e)
        {
            if (!TestConnection(uiHISPlusConnectionString.Text, false) || !TestConnection(uiOpRoomConnectionString.Text, false))
            {
                MessageBox.Show("امکان اتصال به حداقل یکی از دیتابیس ها وجود ندارد. لطفا تنظیمات اتصال را کنترل کنید.", "خطا");
                return;
            }

            ConnectionStrings.OpRoomDB = uiOpRoomConnectionString.Text;
            ConnectionStrings.HisPlusDB = uiHISPlusConnectionString.Text;

            if (!Program.CheckVersion())
                return;
            
            this.Close();
        }

        bool TestConnection(string connectionString, bool showMessage)
        {
            try
            {
                using (var db = new DBHelper(connectionString))
                {
                    db.ExecuteQuery("select 'Connection Check'");
                    if (showMessage)
                        MessageBox.Show("اتصال با موفقیت انجام شد.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                var errorDetails = ex.Message;
                if (ex.InnerException != null)
                    errorDetails += "\r\n" + ex.InnerException.Message;
                if (showMessage)
                    MessageBox.Show("خطا در اتصال:\r\n" + errorDetails);
                return false;
            }
        }

    
    }
}
