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
    public partial class DefaultOpProceduresForm : Form
    {
        private DataRow _selectedRow
        {
            get
            {
                if (uiDefaltTextGrid.CurrentRow == null)
                    return null;
                return ((System.Data.DataRowView)(uiDefaltTextGrid.CurrentRow.DataBoundItem)).Row;
            }
        }

        public DefaultOpProceduresForm()
        {
            InitializeComponent();
            uiDeleteButton.Enabled = false;

            uiDoctorComboBox.DisplayMember = "ItemText";
            uiDoctorComboBox.ValueMember = "Code";
        }

        void FillGrid()
        {
            using (DBHelper hisDbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                if (!string.IsNullOrEmpty(uiDoctorComboBox.Text))
                {
                    try
                    {
                        uiDefaltTextGrid.DataSource =
                            hisDbHelper.Select("OperationDefaultText", string.Format("DoctorCode = {0}", uiDoctorComboBox.SelectedValue));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "خطا");
                    }
                }
                else
                    uiDefaltTextGrid.DataSource = null;
            }
        }
        private void DefaultReportForm_Load(object sender, EventArgs e)
        {
            
        }

        private void uiNewButton_Click(object sender, EventArgs e)
        {
            using (var editForm = new DefaultOpProcedureEditForm(Convert.ToInt32(uiDoctorComboBox.SelectedValue)))
            {
                editForm.ShowDialog();
            }
            
            FillGrid();
        }

        private void uiShowButton_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void uiDeleteButton_Click(object sender, EventArgs e)
        {
            if (DialogUtils.ShowConfirm("سوال", "آیا با حذف موافقید؟"))
            {
                DBHelper dbhHIS = new DBHelper(ConnectionStrings.HisPlusDB);
                dbhHIS.Delete("OperationDefaultText", _selectedRow["ID"].ToString());
                FillGrid();
            }
        }

        private void uiDefaltTextGrid_SelectionChanged(object sender, EventArgs e)
        {
            uiDeleteButton.Enabled = true;
        }

        private void uiEditButton_Click(object sender, EventArgs e)
        {
            if (_selectedRow == null)
            {
                MessageBox.Show("سطری انتخاب نشده است.");
                return;
            }

            DefaultOpProcedureEditForm editForm = new DefaultOpProcedureEditForm(_selectedRow);
            editForm.Show();
        }

        private void uiDoctorComboBox_ItemsRequested(object sender, EventArgs e)
        {
            using (DBHelper opRoomDb = new DBHelper(ConnectionStrings.OpRoomDB))
            {
                var query = string.Format("select Code, replace(Name, '-', ' ') ItemText from Doctor where {0}", 
                    MiscUtils.GetGoogleLikeSqlWhereExpression(uiDoctorComboBox.Text, "replace(Name, '-', ' ')", false));
                uiDoctorComboBox.DataSource = opRoomDb.ExecuteQuery(query);
            }
        }

        private void uiDoctorComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FillGrid();
        }
    }
}
