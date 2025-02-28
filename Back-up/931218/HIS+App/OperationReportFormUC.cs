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

        Microsoft.Office.Interop.Word.Application _templateFileWordApp;

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
            if (_templateFileWordApp == null)
                _templateFileWordApp = new Microsoft.Office.Interop.Word.Application();

            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                try
                {
                    var templateTable = dbHelper.ExecuteQuery("select top 1 * from OperationReportTemplate");
                    string tempFilePath = Path.GetTempPath() + Guid.NewGuid() + ".docx";
                    if (templateTable.Rows.Count == 0)
                    {
                        MessageBox.Show("فایل الگو برای ایجاد گزارش وجود ندارد");
                        return;
                    }
                    else
                    {
                        CreateOpReportTemplateFileFromDB(tempFilePath);
                        WordHelper.OpenDocument(_templateFileWordApp, tempFilePath);
                        OperationReportFileManager operationReporetFile = new OperationReportFileManager(SelectedReportRow, _templateFileWordApp, WordHelper.WordDoc);
                        operationReporetFile.SetContentControl();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message == WordHelper.WordDocumentIsAlreadyOpenMessage)
                        MessageBox.Show("ابتدا فایل قبلی را ببندید.");
                }
            }

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


        public static void CreateOpReportTemplateFileFromDB(string filePath)
        {
            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                using (var sqlCommand = new SqlCommand(@"SELECT top 1 FileData FROM OperationReportTemplate", dbHelper.Connection))
                {
                    if (dbHelper.Connection.State == ConnectionState.Closed)
                        dbHelper.Connection.Open();

                    using (var sqlQueryResult = sqlCommand.ExecuteReader())
                    {
                        if (sqlQueryResult != null)
                        {
                            sqlQueryResult.Read();
                            var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                            sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                            {
                                fs.Write(blob, 0, blob.Length);
                            }
                        }
                    }
                }
            }
        }

    }
}
