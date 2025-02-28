using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Runtime.InteropServices;
using Utils;
using System.Data.SqlClient;
using System.Data;
using System.IO;



namespace HISPlus.Utils
{
    class WordUtils 
    {
        DataRow SelectedRow = null;
        Application WordApp = null;
        Document WordDoc = null;


        public WordUtils(DataRow selectedRow,Application wordApp,Document worDoc)
        {
            SelectedRow = selectedRow;
            WordApp = wordApp;
            WordDoc = worDoc;

        }

        public int Serial { get { return Int32.Parse(SelectedRow["Serial"].ToString()); } set { return; } }
        public string Date { get { return SelectedRow["OpDate"].ToString(); }  set { return; } }
        public string StartTime { get { return SelectedRow["StartTime"].ToString(); } set { return; } }
        
        public byte[] ReportFile
        {
            get
            {
                
                string path = Path.GetTempPath()+ Guid.NewGuid()+".dotx";
                FileStream filestream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                Application wordApp = new Application();
                Documents documents = wordApp.Documents;
                Document doc = documents.Add(path);

                doc = WordDoc;
                //WordDoc = doc;
               // doc.Close();
               // wordApp.Quit();
                
                doc.SaveAs2(FileName);
                filestream.Close();
                byte[] filestreamBytes = new byte[(System.IO.File.ReadAllBytes(path)).Length];
              //  int convertToInt = BitConverter.ToInt32(filestreamBytes, 0);
              //  filestream.Write(System.IO.File.ReadAllBytes(FileName), 0, convertToInt);
             //   filestream.Close();



               // byte[] content = File.ReadAllBytes(FileName);
                //WordDoc = doc;
                return filestreamBytes;
            }
        }

        public DateTime CreateTime { get { return DateTime.Now; } set { return; } }
        public int CreatorUserID { get { return Program.LoginUserID; } set { return; } }
        
        public bool HasSpecimen
        {
          get
            {
                if (Int32.Parse(SelectedRow["SpecimenYesNo"].ToString()) == 0 || SelectedRow["SpecimenYesNo"] == "")
                  return false;
               else
                  return true; 
            }
            set { return; }
        }
        
        public string PreOpDiagnosis { get { return SelectedRow["PreDiagnosis"].ToString(); } set { return; } }
        public string PostOpDiagnosis { get { return SelectedRow["PostDiagnosis"].ToString(); } set { return; } }
        public string KindOfOpretion { get { return SelectedRow["KindOfOperation"].ToString(); } set { return; } }
        public int SpecimenQty
        { 
            get
            {
                if (SelectedRow["SpecimenNumber"] != "")
                    return Int32.Parse(SelectedRow["SpecimenNumber"].ToString());
                else
                    return 0;
            } 
            set
            { 
                return;
            }
        }
        public string Indication { get { return SelectedRow["OpIndication"].ToString(); } set { return; } }
        public string Finding { get { return SelectedRow["OpFinding"].ToString(); } set { return; } }
        public string OpProcedure { get; set; }
        public string FileName { get; set; }

        
       

       // Microsoft.Office.Interop.Word.Application wordApp = null;
        //Document wordDoc = null;
        ContentControls contentControls = null;
        ContentControl contentControl = null;

        public Document CreateDocument()
        {
            
          
           
                Microsoft.Office.Interop.Word.Application wordAppCreate = null;
                wordAppCreate = WordApp;




                wordAppCreate.Visible = true;
                object missing = Missing.Value;
                object filename = @"E:\Projects\HIS+\HIS+App\HIS+App\HISPLU.dotx";
                FileName = filename.ToString();
                object readOnly = false;
                object isVisible = true;

                WordDoc = wordAppCreate.Documents.Open(ref filename, ref missing,
                            ref readOnly, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref isVisible, ref missing, ref missing,
                            ref missing, ref missing);
                WordDoc.Activate();
                //WordDoc = wordDoc;
                 WordApp.DocumentBeforeClose += WordApp_DocumentBeforeClose;
                wordAppCreate.DocumentBeforeSave += new ApplicationEvents4_DocumentBeforeSaveEventHandler(wordApp_DocumentBeforeSave);
                
                return WordDoc;
         
        }

        void WordApp_DocumentBeforeClose(Document Doc, ref bool Cancel)
        {

            OperationReportFormUC opc = new OperationReportFormUC();
            opc.BDocOpen = true;
        }

        void wordApp_DocumentBeforeSave(Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            try
            {
                if (!InsertOrEdit(Int32.Parse(SelectedRow["Serial"].ToString()), SelectedRow["OpDate"].ToString(), SelectedRow["BStartTime"].ToString()))
                    InsertToDB();
                else
                    UpdateDB();
            }
            catch { }
        }

        public bool InsertOrEdit(int serial, string opDate, string opStartTime)
        {
            DataRow drSelectSingle = null;
            DBHelper dbH = new DBHelper(ConnectionStrings.HisPlusDB);

            List<string> filters = new List<string>();
            if (serial != null)
                filters.Add(string.Format(" Serial ={0} ", serial));
            if (opDate != "")
                filters.Add(string.Format(" OpDate LIKE N'%{0}%' ", opDate));
            if (opStartTime != "")
                filters.Add(string.Format(" StartTime LIKE N'%{0}%' ", opStartTime));

            drSelectSingle = dbH.SelectSingle("OperationReport", string.Join((" and "), filters.ToArray()));

            if (drSelectSingle == null)
                return false;
            else
                return true;

        }

        public void SetCantentControl(DataRow selectRow)
        {
            string controlsList = string.Empty;
            DataRow SelectRow = selectRow;
            contentControls = WordDoc.ContentControls;
            for (int i = 1; i <= contentControls.Count; i++)
            {
                try
                {
                    OperationReportFormUC opc = new OperationReportFormUC();
                    contentControl = contentControls[i];
                    switch (contentControl.Title)
                    {
                        case "Attending":
                            contentControl.Range.Text = SelectRow["DoctorName"].ToString();
                            break;

                        case "NuerseOP":
                            contentControl.Range.Text = SelectRow["NurseName"].ToString();
                            break;

                        case "BegingTime":
                            contentControl.Range.Text = SelectRow["BStartTime"].ToString();
                            break;

                        case "EndTime":
                            contentControl.Range.Text = SelectRow["BEndTime"].ToString();
                            break;

                        //case "Word":
                        //        contentControl.Range.Text = opc.SelectRow[""].ToString();
                        //        break;

                        case "Room":
                            contentControl.Range.Text = SelectRow["Room"].ToString();
                            break;

                        //case "Bed":
                        //        contentControl.Range.Text = opc.SelectRow[""].ToString();
                        //        break;

                        case "Second":
                            contentControl.Range.Text = SelectRow["OPTName"].ToString();
                            break;

                        case "Date":
                            contentControl.Range.Text = SelectRow["OpDate"].ToString();
                            break;

                        case "Name":
                            contentControl.Range.Text = SelectRow["FName"].ToString();
                            break;

                        case "Age":
                            contentControl.Range.Text = SelectRow["Age"].ToString();
                            break;

                        case "First":
                            contentControl.Range.Text = SelectRow["FirstHelp"].ToString();
                            break;

                        case "KindAn":
                            {
                                switch (SelectRow["BType"].ToString())
                                {
                                    case "1":
                                        contentControl.Range.Text = "G.A";
                                        break;
                                    case "2":
                                        contentControl.Range.Text = "L.A";
                                        break;
                                    case "3":
                                        contentControl.Range.Text = "S.A";
                                        break;
                                    case "5":
                                        contentControl.Range.Text = "بی حسی";
                                        break;
                                }
                                break;
                            }

                        case "UnitNum":
                            contentControl.Range.Text = SelectRow["PRV_Code"].ToString();
                            break;

                        case "Famiy":
                            contentControl.Range.Text = SelectRow["LName"].ToString();
                            break;

                        case "Surgeon":
                            contentControl.Range.Text = SelectRow["DoctorName"].ToString();
                            break;

                        case "Anesthesiologist":
                            {
                                if (SelectRow["BTName"].ToString() == "-1")
                                    contentControl.Range.Text = "";
                                else
                                    contentControl.Range.Text = SelectRow["BTName"].ToString();
                                break;
                            }
                        case "PreOp":
                            contentControl.Range.Text = SelectRow["PreDiagnosis"].ToString();
                            break;

                        case "PostOp":
                            contentControl.Range.Text = SelectRow["PostDiagnosis"].ToString();
                            break;

                        //case "KindOp":
                        //        contentControl.Range.Text = opc.SelectRow["KindOfOperation"].ToString();
                        //        break;

                        case "SpecimentNo":
                            {
                                switch ((byte)SelectRow["SpecimenYesNo"])
                                {
                                    case 0:
                                        contentControl.Checked = true;
                                        break;
                                    case 1:
                                        contentControl.Checked = false;
                                        break;
                                }
                                break;
                            }

                        case "SpecimenYes":
                            {
                                switch ((byte)SelectRow["SpecimenYesNo"])
                                {
                                    case 0:
                                        contentControl.Checked = false;
                                        break;
                                    case 1:
                                        contentControl.Checked = true;
                                        break;
                                }



                                break;
                            }

                        case "SepecimentNum":
                            contentControl.Range.Text = SelectRow["SpecimenNumber"].ToString();
                            break;

                        case "Indcation":
                            contentControl.Range.Text = SelectRow["OpIndication"].ToString();
                            break;

                        case "Finding":
                            contentControl.Range.Text = SelectRow["OpFinding"].ToString();
                            break;


                    }
                    if (contentControl != null)
                        Marshal.ReleaseComObject(contentControl);
                }
                catch(Exception ex)
                {
                   
                }
            }
        }
        public void ReadContentControlValue(Document wordDoc)
        {
            string controlsList = string.Empty;

            contentControls = wordDoc.ContentControls;
            for (int i = 1; i <= contentControls.Count; i++)
            {
                OperationReportFormUC opc = new OperationReportFormUC();
                contentControl = contentControls[i];
                switch (contentControl.Title)
                {
                    case "BegingTime":
                        StartTime = opc.SelectRow["BStartTime"].ToString();
                        break;

                    case "Date":
                        Date = opc.SelectRow["OpDate"].ToString();
                        break;

                    case "PreOp":
                       PreOpDiagnosis = contentControl.Range.Text;
                        break;

                    case "PostOp":
                       PostOpDiagnosis = contentControl.Range.Text;
                        break;

                    case "KindOp":
                       KindOfOpretion = contentControl.Range.Text;
                        break;

                    case "SepecimentNum":
                        SpecimenQty = Int32.Parse(contentControl.Range.Text);
                        break;

                    case "Indcation":
                       Indication = contentControl.Range.Text;
                        break;

                    case "Finding":
                        Finding = contentControl.Range.Text;
                        break;

                    case "Procedure":
                        OpProcedure = contentControl.Range.Text;
                        break;

                }
                if (contentControl != null)
                    Marshal.ReleaseComObject(contentControl);
            }
        }
        public void InsertToDB ()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow drOperationReport = null;
            OperationReportFormUC orFormUC = new OperationReportFormUC();
            DBHelper dbh = new DBHelper(ConnectionStrings.HisPlusDB);
            //WordDoc.Close();
            drOperationReport = dbh.GetNewRow("OperationReport", out da);

            drOperationReport["Serial"] = Serial;
            drOperationReport["OpDate"] = Date;
            drOperationReport["StartTime"] = StartTime;
            drOperationReport["ReportFileData"] = ReportFile;
            drOperationReport["PreOpDiagnosis"] = PreOpDiagnosis;
            drOperationReport["PreOpDiagnosis"] = Finding;
            drOperationReport["PostOpDiagnosis"] = PostOpDiagnosis ;
            drOperationReport["KindOfOpretion"] = KindOfOpretion;
            drOperationReport["CreateTime"] = CreateTime;
            drOperationReport["CreatorUserID"] = 1;
            drOperationReport["HasSpecimen"] = HasSpecimen;
            drOperationReport["SpecimenQty"] = SpecimenQty;
            drOperationReport["Indication"] = Indication;
            drOperationReport["OpProcedure"] = OpProcedure;

            dbh.Insert(drOperationReport, da);
        }

        public void UpdateDB()
        {
            
                SqlDataAdapter da = new SqlDataAdapter();
                DataRow drSelectSingle = null;
                DBHelper dbh = new DBHelper(ConnectionStrings.HisPlusDB);

                List<string> filters = new List<string>();
                if (SelectedRow["Serial"] != null)
                    filters.Add(string.Format(" Serial ={0} ", SelectedRow["Serial"]));
                if (SelectedRow["OpDate"] != "")
                    filters.Add(string.Format(" OpDate LIKE N'%{0}%' ", SelectedRow["OpDate"]));
                if (SelectedRow["StartTime"] != "")
                    filters.Add(string.Format(" StartTime LIKE N'%{0}%' ", SelectedRow["StartTime"]));

                drSelectSingle = dbh.SelectSingle("OperationReport", string.Join((" and "), filters.ToArray()));
                drSelectSingle["OpProcedure"] = OpProcedure;
                dbh.Update(drSelectSingle, da, "OperationReport");
           
            

        }


        public DataRow _selectedRow { get; set; }
    }
}
