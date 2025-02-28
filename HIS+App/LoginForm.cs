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
            Login();
        }

        private void Login()
        {
            DBHelper dbh = new DBHelper(ConnectionStrings.HisPlusDB);

            DataTable usersTable = dbh.Select("SystemUser", string.Format("IsActive = 1 and UserName = '{0}' and Password = '{1}'", uiUseNameTxt.Text, uiPasswordTxt.Text));

            if (usersTable.Rows.Count == 0)
            {
                MessageBox.Show("نام کاربری یا کلمه عبور اشتباه است یا کاربر غیر فعال میباشد.");
            }
            else
            {
                Program.LoginUser = new SystemUser(usersTable.Rows[0]);
                DialogResult = DialogResult.OK;
            }

        }

        private void uiPasswordTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Login();
        }
    }
}
