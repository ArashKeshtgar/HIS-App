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
using System.Data.SqlClient;
using System.Data;

namespace HISPlus
{
    public partial class DefaultOpProcedureEditForm : Form
    {

        DataRow _currentRow = null;
        int _doctorCode;

        public DefaultOpProcedureEditForm(DataRow editingRow)
        {
            InitializeComponent();

            _currentRow = editingRow;

            _doctorCode = int.Parse(_currentRow["DoctorCode"].ToString());
            uiDoctorNameTextBox.Text = OpRoomDbHelper.GetDoctorName(_doctorCode);
            uiOperationCombo.Text = _currentRow["OperationName"].ToString();
            uiDefaultText.Text = _currentRow["DefaultText"].ToString();
            uiOperationCombo.Enabled = false;
        }
        
        public DefaultOpProcedureEditForm(int doctorCode)
        {
            InitializeComponent();

            _doctorCode = doctorCode;

            using (var db = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                _currentRow = db.GetNewRow("OperationDefaultText");
            }
            
            uiDoctorNameTextBox.Text = OpRoomDbHelper.GetDoctorName(doctorCode);

            uiOperationCombo.DisplayMember = "ItemValue";
            uiOperationCombo.ValueMember = "ItemText";

            uiDefaultText.Text = null;
        }

        private void uiSaveButton_Click(object sender, EventArgs e)
        {
            DBHelper dbhHIS = new DBHelper(ConnectionStrings.HisPlusDB);

            _currentRow["DoctorCode"] = _doctorCode;
            _currentRow["OperationName"] = uiOperationCombo.Text;
            _currentRow["DefaultText"] = uiDefaultText.Text;

            try
            {
                if (_currentRow.RowState == System.Data.DataRowState.Added)
                {
                    dbhHIS.Insert(_currentRow);
                }
                else
                {
                    dbhHIS.Update(_currentRow, "OperationDefaultText");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                    MessageBox.Show("آیتمی با این مشخصات قبلا ثبت شده است.", "خطا");
                else
                    MessageBox.Show(ex.Message, "خطا");
            }
        }

        private void uiOperationCombo_ItemsRequested(object sender, EventArgs e)
        {
            using (DBHelper opRoomDb = new DBHelper(ConnectionStrings.OpRoomDB))
            {
                var query = string.Format("select distinct OpName ItemValue, OpName ItemText from Reception where isnull(OpName, '') <> '' and {0}",
                    MiscUtils.GetGoogleLikeSqlWhereExpression(uiOperationCombo.Text, "OpName", false));
                uiOperationCombo.DataSource = opRoomDb.ExecuteQuery(query);
            }

        }

    }
}
