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

namespace HISPlus
{
    public partial class OperationReportFormUC : UserControl
    {
        public DataRow SelectedReportRow
        {
            get
            {
                if (uiOpReportsGrid.CurrentRow == null)
                    return null;
                return ((System.Data.DataRowView)(uiOpReportsGrid.CurrentRow.DataBoundItem)).Row;
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

                uiOpReportsGrid.DataSource = receptions;
                AdjustReceptionsGrid();
            }
        }

        private void ClearForm()
        {
            uiName.Text = "";
            uiFamily.Text = "";
            uiPrv_code.Text = "";
            uiSerial.Text = "";

            uiOpReportsGrid.DataSource = null;
            uiOpReportsGrid.Rows.Clear();
        }

        void AdjustReceptionsGrid()
        {
            foreach(DataGridViewColumn column in uiOpReportsGrid.Columns)
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

        private void ShowOpReportFile()
        {
            //try
            //{
            //    Document wordDoc = new Document();
            //    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            //    WordUtils wordUtils = new WordUtils(SelectRow, wordApp, wordDoc);
            //    string fileName = @"E:\Projects\HIS+\HIS+App\HIS+App\HISPLU.docx";

            //    wordDoc = wordUtils.CreateDocument(fileName);
            //   if (wordDoc != null)
            //       wordUtils.SetCantentControl(SelectRow);
            //   else
            //   {
            //       return;
            //   }

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message,"خطا در بارگذاری");
            //}
         
        }

        private void uiShowReport_Click(object sender, EventArgs e)
        {
           
            ShowOpReportFile();
        }

   
    }
}
