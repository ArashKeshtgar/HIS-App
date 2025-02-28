using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace HISPlus
{
    public partial class MainForm : Form
    {
        Microsoft.Office.Interop.Word.Application _templateFileWordApp;

        public MainForm()
        {
            InitializeComponent();

     

           // ConnectionStrings.OpRoomDB = @"Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;Password=myPassword;";

           // var c = ConnectionStrings.OpRoomDB;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void uiEditOpReportTemplateMenuItem_Click(object sender, EventArgs e)
        {
            if (_templateFileWordApp == null)
                _templateFileWordApp = new Microsoft.Office.Interop.Word.Application();

            try
            {
                using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
                {
                    var templateTable = dbHelper.ExecuteQuery("select top 1 * from OperationReportTemplate");
                    string tempFilePath = Path.GetTempPath() + Guid.NewGuid() + ".docx";

                    if (templateTable.Rows.Count == 0)
                    {
                        WordHelper.CreateNewDocument(_templateFileWordApp);
                        WordHelper.WordDoc.SaveAs2(tempFilePath);
                    }
                    else
                    {
                        CreateOpReportTemplateFileFromDB(tempFilePath);
                        WordHelper.OpenDocument(_templateFileWordApp, tempFilePath);
                    }

                    _templateFileWordApp.Visible = true;
                    _templateFileWordApp.DocumentBeforeSave += wordApp_DocumentBeforeSave;
                    _templateFileWordApp.DocumentBeforeClose += templateFileWordApp_DocumentBeforeClose;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == WordHelper.WordDocumentIsAlreadyOpenMessage)
                    MessageBox.Show("ابتدا فایل قبلی را ببندید.");
            }
        }

        void templateFileWordApp_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document Doc, ref bool Cancel)
        {
            WordHelper.WordDoc = null;

            if (_templateFileWordApp != null)
            {
                _templateFileWordApp.Quit();
                _templateFileWordApp = null;
            }
        }

        void wordApp_DocumentBeforeSave(Microsoft.Office.Interop.Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            string oldFilePath = Path.GetTempPath() + Doc.Name; ;
            string tempFilePath2 = Path.GetTempPath() + Guid.NewGuid() + ".docx";
            Doc.Save();

            Doc.SaveAs(tempFilePath2);
            SaveOpReportTemplateToDB(oldFilePath);
        }

        void SaveOpReportTemplateToDB(string filePath)
        {
            byte[] fileBytes;
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read)) 
            {
                using (var reader = new BinaryReader(stream)) 
                {
                    fileBytes = reader.ReadBytes((int) stream.Length);       
                }          
            }

            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                string saveQuery = null;
                if (dbHelper.ExecuteScalarQuery<int>("select count(*) from OperationReportTemplate") == 0)
                    saveQuery = "insert into OperationReportTemplate (FileData) Values(@FileData)";
                else
                    saveQuery = "update OperationReportTemplate set FileData = @FileData";

                using (var saveSqlCommand = new SqlCommand(saveQuery, dbHelper.Connection)) 
                {
                    saveSqlCommand.Parameters.Add("@FileData", SqlDbType.VarBinary, fileBytes.Length).Value = fileBytes;
                    saveSqlCommand.ExecuteNonQuery();
                }
            }
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

        private void uiConfigDbConnectionsMenuItem_Click(object sender, EventArgs e)
        {
            DBConnectionSettingForm dbForm = new DBConnectionSettingForm();
            dbForm.ShowDialog();
        }

        private void uiDefoultTextMenuItem_Click(object sender, EventArgs e)
        {
            DefaultOpProceduresForm defaulForm = new DefaultOpProceduresForm();
            defaulForm.ShowDialog();
        }
    }
}
