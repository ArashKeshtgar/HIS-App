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


namespace HISPlus.Utils
{
    class WordUtils
    {
        public string PreOpDiagnosis { get; set; }
        public string PostOpDiagnosis { get; set; }
        public string BegingTime { get; set; }
        public string KindOfOpretion { get; set; }
        public string SpecimenQty { get; set; }
        public string Date { get; set; }
        public string Indication { get; set; }
        public string Finding { get; set; }
        public string OpProcedure { get; set; }

        public string FileName { get; set; }

       // Microsoft.Office.Interop.Word.Application wordApp = null;
        //Document wordDoc = null;
        ContentControls contentControls = null;
        ContentControl contentControl = null;

        public Document CreateDocument(Application wordApp, Document wordDoc)
        {
            wordApp = new Microsoft.Office.Interop.Word.Application();
            Document WordDoc = new Document();
            wordApp.Visible = true;
            object missing = Missing.Value;
            object filename = @"E:\Projects\HIS+\HIS+App\HIS+App\HISPLU.dotx";
            FileName = filename.ToString();
            object readOnly = false;
            object isVisible = true;

            wordDoc = wordApp.Documents.Open(ref filename, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);
            wordDoc.Activate();
            WordDoc = wordDoc;
            return WordDoc;

        }

        public void SetCantentControl(Document wordDoc,DataRow selectRow)
        {
            string controlsList = string.Empty;
            DataRow SelectRow = selectRow;
            contentControls = wordDoc.ContentControls;
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
                        BegingTime = opc.SelectRow["BStartTime"].ToString();
                        break;

                    case "Date":
                        Date = opc.SelectRow["Date"].ToString();
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
                        SpecimenQty = contentControl.Range.Text;
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
            DataRow drOperationReportFileData = null;
            OperationReportFormUC orFormUC = new OperationReportFormUC();
            DBHelper dbh = new DBHelper(ConnectionStrings.HisPlusDB);

            drOperationReport = dbh.GetNewRow("OperationReport", out da);
            drOperationReportFileData = dbh.GetNewRow("OperationReportTemplate",out da);

            drOperationReportFileData["FileData"] = dbh.InsertFileDataToDB(FileName);

            drOperationReport["Serial"] = orFormUC.SelectRow["Serial"];
            drOperationReport["Date"] = Date;
            drOperationReport["StartTime"] = BegingTime;
            drOperationReport["ReportFileDataID"] = 1;
            drOperationReport["PreOpDiagnosis"] = PreOpDiagnosis;
            drOperationReport["PreOpDiagnosis"] = 
            drOperationReport["PostOpDiagnosis"] = PostOpDiagnosis ;
            drOperationReport["KindOfOpretion"] = KindOfOpretion;
            //drOperationReport["HasSpecimen"] = has
            //drOperationReport[""]
            drOperationReport["SpecimenQty"] = SpecimenQty;
            drOperationReport["Indication"] = Indication;
            drOperationReport["OpProcedure"] = OpProcedure;
            dbh.Insert(drOperationReport, da);
        }

        public void UpdateDB()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow drSelectSingle = null;
            OperationReportFormUC orFormUC = new OperationReportFormUC();
            DBHelper dbh = new DBHelper(ConnectionStrings.HisPlusDB);

            List<string> filters = new List<string>();
            if (orFormUC.SelectRow["Serial"] != null)
                filters.Add(string.Format(" Serial ={0} ", orFormUC.SelectRow["Serial"]));
            if (orFormUC.SelectRow["OpDate"] != "")
                filters.Add(string.Format(" Date LIKE N'%{0}%' ", orFormUC.SelectRow["OpDate"]));
            if (orFormUC.SelectRow["StartTime"] != "")
                filters.Add(string.Format(" StartTime LIKE N'%{0}%' ", orFormUC.SelectRow["StartTime"]));

            drSelectSingle = dbh.SelectSingle("OperationReport",string.Join((" and "),filters.ToArray()));
            drSelectSingle["OpProcedure"] = OpProcedure;
            dbh.Update(drSelectSingle, da, "OperationReport");

        }

    }
}
