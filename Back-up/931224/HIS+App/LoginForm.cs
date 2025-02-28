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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void uiLoginButton_Click(object sender, EventArgs e)
        {
            DBHelper dbh = new DBHelper(ConnectionStrings.HisPlusDB);

            DataTable usersTable = dbh.Select("SystemUser", string.Format("UserName = '{0}' and Password = '{1}'", uiUseNameTxt.Text, uiPasswordTxt.Text));

            if (usersTable.Rows.Count == 0)
            {
                MessageBox.Show("نام کاربری یا کلمه عبور اشتباه است.");
            }
            else
            {
                Program.LoginUserRow = usersTable.Rows[0];
                DialogResult = DialogResult.OK;
                MainForm dbForm = new MainForm();
                dbForm.ShowDialog();
                this.Close();
            }
        }

        private void uiPasswordTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                DialogResult = DialogResult.OK;
        }
    }
}
