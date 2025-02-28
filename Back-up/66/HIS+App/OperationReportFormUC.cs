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
using HISPlus.Utils;
using Microsoft.Office.Interop.Word;
using System.Data.SqlClient;

namespace HISPlus
{
    public partial class OperationReportFormUC : UserControl
    {

        public bool BDocOpen { get; set; }

        public DataRow SelectRow
        {
            get
            {
                if (uiOPGrid.CurrentRow == null)
                    return null;
                return ((System.Data.DataRowView)(uiOPGrid.CurrentRow.DataBoundItem)).Row;
            }
        }
        public OperationReportFormUC()
        {
            InitializeComponent();

            Microsoft.Office.Interop.Word.Document wordDoc = new Microsoft.Office.Interop.Word.Document();
            
            //wordDoc.Application
        }

        public void FillGrid()
        {
            List<string> filters = new List<string>();

            if (uiSerialSearchTxt.Text != "")
                filters.Add(string.Format("Serial ={0} ", uiSerialSearchTxt.Text));
            DBHelper dbh = new DBHelper(ConnectionStrings.OpRoomDB);
            uiOPGrid.DataSource = dbh.Select("V_JDoctor", string.Join(" and ", filters.ToArray()));
        }

        private void TextBoxsesBind()
        {
            if (SelectRow != null)
            {
                uiNameTxt.Text = SelectRow["FName"].ToString();
                uiFamilyTxt.Text = SelectRow["LName"].ToString();
                uiPrv_code.Text = SelectRow["PRV_Code"].ToString();
                uiSerialTxt.Text = SelectRow["Serial"].ToString();
            }
        }

        private void uiSearchButton_Click(object sender, EventArgs e)
        {
            FillGrid();
            
        }


        private void uiOPGrid_SelectionChanged(object sender, EventArgs e)
        {

            TextBoxsesBind();
        }

   
        private void uiSerialSearchTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                FillGrid();
        }

        

        private void ShowOpReportFile()
        {
            try
            {
                Document wordDoc = new Document();
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                WordUtils wordUtils = new WordUtils(SelectRow, wordApp, wordDoc);

               
               wordDoc = wordUtils.CreateDocument();
               if (wordDoc != null)
                   wordUtils.SetCantentControl(SelectRow);
               else
               {
                   return;
               }

               //if (!wordUtils.InsertOrEdit(Int32.Parse(SelectRow["Serial"].ToString()), SelectRow["OpDate"].ToString(), SelectRow["StartTime"].ToString()))
               //    wordUtils.InsertToDB();
               //else
               //    wordUtils.UpdateDB();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"خطا در بارگذاری");
            }
         
        }


        private void uiShowReport_Click(object sender, EventArgs e)
        {
           
            ShowOpReportFile();
        }

   
    }
}
