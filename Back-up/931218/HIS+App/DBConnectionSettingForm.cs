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
            TestConnection(uiOpRoomConnectionString.Text);
        }

        private void uiHisPlusConnectionTest_Click(object sender, EventArgs e)
        {
            TestConnection(uiHISPlusConnectionString.Text);
        }

        private void uiSaveButton_Click(object sender, EventArgs e)
        {
            ConnectionStrings.OpRoomDB = uiOpRoomConnectionString.Text;
            ConnectionStrings.HisPlusDB = uiHISPlusConnectionString.Text;

            this.Close();
        }

        void TestConnection(string connectionString)
        {
            try
            {
               using (var db = new DBHelper(connectionString))
                {
                    db.ExecuteQuery("select 'Connection Check'");
                    MessageBox.Show("اتصال با موفقیت انجام شد.");
                }
            }
            catch (Exception ex)
            {
                var errorDetails = ex.Message;
                if (ex.InnerException != null)
                    errorDetails += "\r\n" + ex.InnerException.Message;

                MessageBox.Show("خطا در اتصال:\r\n" + errorDetails);
            }
        }

    
    }
}
