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
        string _templateDocUniqueID;

        public MainForm()
        {
            InitializeComponent();

            if (HisPlusDbHelper.CheckDbConnection())
            {
                using (var loginForm = new LoginForm())
                {
                    loginForm.ShowDialog();
                    if (Program.LoginUser == null)
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                MessageBox.Show("امکان اتصال به دیتابیس وجود ندارد. لطفا تنظیمات دیتابیس را بررسی نمایید.", "خطا");
                using (var dbConnectionsSettingForm = new DBConnectionSettingForm())
                {
                    dbConnectionsSettingForm.ShowDialog();
                    Environment.Exit(0);
                }
            }
        }

        private void uiEditOpReportTemplateMenuItem_Click(object sender, EventArgs e)
        {
            if (!Program.CheckVersion())
                return;

            if (!Program.LoginUser.IsAdmin)
            {
                MessageBox.Show(Messages.PermissionToItemIsDenied);
                return;
            }

            try
            {
                using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
                {
                    var templateTable = dbHelper.ExecuteQuery("select top 1 * from OperationReportTemplate");
                    string tempFilePath = Path.GetTempPath() + Guid.NewGuid() + ".docx";

                    if (templateTable.Rows.Count == 0)
                    {
                        WordHelper.CreateNewDocument();
                        WordHelper.WordDoc.SaveAs2(tempFilePath);
                    }
                    else
                    {
                        CreateOpReportTemplateFileFromDB(tempFilePath);
                        WordHelper.OpenDocument(tempFilePath);
                    }

                    _templateDocUniqueID = WordHelper.GetDocumentUniqueID(WordHelper.WordDoc);

                    WordHelper.WordApp.Visible = true;
                    WordHelper.WordApp.DocumentBeforeSave += wordApp_DocumentBeforeSave;
                    WordHelper.BeforeCloseWordDoc+=WordHelper_BeforeCloseWordDoc;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == WordHelper.WordDocumentIsAlreadyOpenMessage)
                    MessageBox.Show("ابتدا فایل قبلی را ببندید.");
            }
        }

        void WordHelper_BeforeCloseWordDoc(Microsoft.Office.Interop.Word.Document Doc, ref bool Cancel)
        {
            
        }

        void wordApp_DocumentBeforeSave(Microsoft.Office.Interop.Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            if (string.IsNullOrEmpty(_templateDocUniqueID) || 
                WordHelper.GetDocumentUniqueID(Doc) != _templateDocUniqueID)
                return;

            string oldFilePath = Path.GetTempPath() + Doc.Name;
            string tempFilePath2 = Path.GetTempPath() + Guid.NewGuid() + ".docx";
            Doc.Save();
            Doc.SaveAs(tempFilePath2);
            //_templateDocUniqueID = WordHelper.GetDocumentUniqueID(Doc);//Because File Name Changes After SaveAs
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
                    if (dbHelper.Connection.State == ConnectionState.Closed)
                        dbHelper.Connection.Open();

                    saveSqlCommand.Parameters.Add("@FileData", SqlDbType.VarBinary, fileBytes.Length).Value = fileBytes;
                    saveSqlCommand.ExecuteNonQuery();
                }
            }
        }

        public static void CreateOpReportTemplateFileFromDB(string filePath)
        {
            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                dbHelper.CreateFileFromDB(filePath, @"SELECT top 1 FileData FROM OperationReportTemplate");
            }
        }

        private void uiConfigDbConnectionsMenuItem_Click(object sender, EventArgs e)
        {
            if (!Program.LoginUser.IsAdmin)
            {
                MessageBox.Show(Messages.PermissionToItemIsDenied);
                return;
            }

            using (var dbForm = new DBConnectionSettingForm())
            {
                dbForm.ShowDialog();
            }
        }

        private void uiDefoultTextMenuItem_Click(object sender, EventArgs e)
        {
            if (!Program.CheckVersion())
                return;

            if (!Program.LoginUser.IsAdmin)
            {
                MessageBox.Show(Messages.PermissionToItemIsDenied);
                return;
            }

            using (var defaulForm = new DefaultOpProceduresForm())
            {
                defaulForm.ShowDialog();
            }
        }
    }
}
