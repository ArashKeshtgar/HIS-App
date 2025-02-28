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
        SqlDataAdapter _dataAdapter;

        public DefaultOpProcedureEditForm(DataRow editingRow)
        {
            InitializeComponent();

            _currentRow = editingRow;

            _doctorCode = int.Parse(_currentRow["DoctorCode"].ToString());
            uiDoctorNameTextBox.Text = GetDoctorName(_doctorCode);
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
                _currentRow = db.GetNewRow("OperationDefaultText", out _dataAdapter);
            }
            
            uiDoctorNameTextBox.Text = GetDoctorName(doctorCode);
            AdjustOperationCombo();
            uiDefaultText.Text = null;
        }

        private string GetDoctorName(int code)
        {
            using (DBHelper opRoomDb = new DBHelper(ConnectionStrings.OpRoomDB))
            {
                return opRoomDb.SelectSingle("Doctor", "Code = " + code)["Name"].ToString();
            }
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
                    dbhHIS.Insert(_currentRow, _dataAdapter);
                }
                else
                {
                    _dataAdapter = new SqlDataAdapter();
                    dbhHIS.Update(_currentRow, _dataAdapter, "OperationDefaultText");
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


        void AdjustOperationCombo()
        {
            using (DBHelper db = new DBHelper(ConnectionStrings.OpRoomDB))
            {
                uiOperationCombo.DataSource = db.ExecuteQuery("select Name from OpName");
                uiOperationCombo.DisplayMember = "Name";
                uiOperationCombo.ValueMember = "Name";
            }
           
        }

    }
}
