using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using Microsoft.Office.Interop.Word;
using System.Data.SqlClient;
using System.IO;

namespace HISPlus
{
    public partial class OperationReportFormUC : UserControl
    {


        public DataRow SelectedReceptionRow
        {
            get
            {
                if (uiReceptionsGrid.CurrentRow == null)
                    return null;
                return ((System.Data.DataRowView)(uiReceptionsGrid.CurrentRow.DataBoundItem)).Row;
            }
        }



        public OperationReportFormUC()
        {
            InitializeComponent();
        }

        private void LoadFormData()
        {
            int serial = -1;

            if (uiSerialSearchTextBox.Text != "")
            {
                if (!int.TryParse(uiSerialSearchTextBox.Text, out serial))
                    serial = -1;
            }

            if (serial == -1)
            {
                ClearForm();
                return;
            }

            using (var dbHelper = new DBHelper(ConnectionStrings.OpRoomDB))
            {
                var receptions = dbHelper.Select("Reception", string.Format("Serial = {0}", serial));

                if (receptions.Rows.Count == 0)
                {
                    ClearForm();
                    return;
                }

                var lastReception = receptions.Rows[receptions.Rows.Count - 1];

                uiSerial.Text = lastReception["Serial"].ToString();
                uiName.Text = lastReception["FName"].ToString();
                uiFamily.Text = lastReception["LName"].ToString();
                uiPrv_code.Text = lastReception["PRV_Code"].ToString();

                uiReceptionsGrid.DataSource = receptions;
                AdjustReceptionsGrid();
            }
        }

        private void ClearForm()
        {
            uiName.Text = "";
            uiFamily.Text = "";
            uiPrv_code.Text = "";
            uiSerial.Text = "";

            uiReceptionsGrid.DataSource = null;
            uiReceptionsGrid.Rows.Clear();
        }

        void AdjustReceptionsGrid()
        {
            foreach(DataGridViewColumn column in uiReceptionsGrid.Columns)
            {
                if (!column.DataPropertyName.IsIn("OpDate", "StartTime", "EndTime"))
                    column.Visible = false;
            }
        }

        private void uiSearchButton_Click(object sender, EventArgs e)
        {
            LoadFormData();
        }
   
        private void uiSerialSearchTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                LoadFormData();
        }

        private void uiShowReport_Click(object sender, EventArgs e)
        {
            if (SelectedReceptionRow == null)
            {
                MessageBox.Show("ابتدا یک سطر کنید", "خطا");
                return;
            }

            var opReportMgr = new OperationReportFileManager(SelectedReceptionRow);
            opReportMgr.ShowOpReportFile();
            WordHelper.WordApp.DocumentBeforeSave += WordApp_DocumentBeforeSave;
        }

        void WordApp_DocumentBeforeSave(Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            var opReportMgr = new OperationReportFileManager(SelectedReceptionRow);

            if (WordHelper.GetDocumentUniqueID(Doc) != OperationReportFileManager.DocUniqueID)
                return;

            SqlDataAdapter da = new SqlDataAdapter();
            DBHelper dbHelper = new DBHelper(ConnectionStrings.HisPlusDB);
            DataRow insertReportRow = dbHelper.GetNewRow("OperationReport", out da);
            dbHelper.Insert(opReportMgr.SetDetailReportRow(insertReportRow), da);
        }
    }
}
