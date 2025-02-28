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
using System.Windows.Forms;

namespace HISPlus
{
    class OperationReportFileManager
    {
        private ReceptionData _reception = null;
        public static string DocUniqueID;
        static Document _wordDoc;
        OpReportDocContentControls _contentControls;
        public static string ReportFilePath;


        public OperationReportFileManager(DataRow receptionRow)
        {
            _reception = new ReceptionData(receptionRow);
        }

        public void ShowOpReportFile()
        {
            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                if (dbHelper.ExecuteScalarQuery<int>("select count(*) from OperationReportTemplate") == 0)
                {
                    MessageBox.Show("فایل الگو برای ایجاد گزارش وجود ندارد");
                    return;
                }
            }

            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {   
                string tempFilePath = Path.GetTempPath() + Guid.NewGuid() + ".docx";
              

                var opReportRow = dbHelper.SelectSingle("OperationReport",
                    string.Format("Serial = {0} and OpDate = '{1}' and StartTime = '{2}'", _reception.Serial, _reception.OpDate, _reception.StartTime));

                if (opReportRow == null)
                {
                    dbHelper.CreateFileFromDB(tempFilePath, @"SELECT top 1 FileData FROM OperationReportTemplate");
                    ReportFilePath = tempFilePath;
                }
                else
                {
                    dbHelper.CreateFileFromDB(
                        tempFilePath,
                        string.Format(@"SELECT ReportFileData FROM OperationReport where Serial = {0} and OpDate = '{1}' and StartTime = '{2}'",
                            _reception.Serial, _reception.OpDate, _reception.StartTime));
                }

                try
                {
                    WordHelper.OpenDocument(tempFilePath);
                    _wordDoc = WordHelper.WordDoc;
                    DocUniqueID = WordHelper.GetDocumentUniqueID(_wordDoc);
                    _contentControls = new OpReportDocContentControls(_wordDoc);
                    WordHelper.WordApp.Visible = true;

                    if (opReportRow == null)
                    {
                        SetContentControls();
                       
                    }
                    else
                    {
                        
                    }
                        
                }
                catch (Exception ex)
                {
                    if (ex.Message == WordHelper.WordDocumentIsAlreadyOpenMessage)
                        MessageBox.Show("ابتدا فایل قبلی را ببندید.");
                    else
                        MessageBox.Show(ex.Message);
                }
            }
        }

        public DataRow SetDetailReportRow(DataRow detailReportRow)
        {
            DBHelper dbHelper = new DBHelper(ConnectionStrings.HisPlusDB);
            InsertDetailReportToDB insertDetailReportToDB = new InsertDetailReportToDB(detailReportRow);
            insertDetailReportToDB.Serial = _reception.Serial;
            insertDetailReportToDB.StartTime = _reception.StartTime;
            insertDetailReportToDB.OpDate = _reception.OpDate;
            insertDetailReportToDB.ReportFileData = dbHelper.SaveOpReportToDB(ReportFilePath, _wordDoc);
            insertDetailReportToDB.CreateTime = DateTime.Now.ToString();
            insertDetailReportToDB.CreatorUserID = 1;
            insertDetailReportToDB.PreOpDiagnosis = _reception.PreDiagnosis;
            insertDetailReportToDB.PostOpDiagnosis = _reception.PostDiagnosis;
            insertDetailReportToDB.KindOfOpretion = _reception.KindOfOperation;
            insertDetailReportToDB.SpecimenQty = int.Parse(_reception.SpecimenNumber.ToString());
            insertDetailReportToDB.Indication = _reception.OpIndication;
            insertDetailReportToDB.OpProcedure = _reception.PreDiagnosis;

            DataRow _detailReportRow = detailReportRow;
            return _detailReportRow;

        }

        public class InsertDetailReportToDB
        {
            DataRow _reportDetailRow = null;
            
            public InsertDetailReportToDB(DataRow reportDetailRow)
            {
                _reportDetailRow = reportDetailRow;
            }

            private string GetColumnName(string columnName)
            {
                for (int i = 0; i <= _reportDetailRow.Table.Columns.Count-1; i++)
                {
                    if (_reportDetailRow.Table.Columns[i].ToString() == columnName)
                        return _reportDetailRow.Table.Columns[i].ToString();
                }

                return null;
            }

            private object GetColumnValue(string columnName)
            {
                var contentControl = GetColumnName(columnName);
                var result = _reportDetailRow.Table.Columns;
                return result;
            }

            private void SetColumnlValue(string columnName, string value)
            {
                var contentControl = GetColumnName(columnName);
                columnName = value;
            }

            private void SetColumnlValue(string columnName, int value)
            {
                var contentControl = GetColumnName(columnName);
                columnName = value.ToString();
            }


            public int Serial
            {
                get
                {
                    return Int32.Parse(GetColumnName("Serial").ToString());
                }
                set
                {
                   SetColumnlValue("Serial", value);
                }
            }

            public string OpDate
            {
                get
                {
                    return GetColumnName("OpDate").ToString();
                }
                set
                {
                    SetColumnlValue("OpDate", value.ToString());
                }
            }

            public string StartTime
            {
                get
                {
                    return GetColumnName("StartTime").ToString();
                }
                set
                {
                    SetColumnlValue("StartTime", value.ToString());
                }
            }

            public byte[] ReportFileData
            {
                get
                {
                    return null;
                }
                set
                {
                    SetColumnlValue("ReportFileData", value.ToString());
                }
            }

            public string CreateTime
            {
                get
                {
                    return GetColumnName("CreateTime").ToString();
                }
                set
                {
                    SetColumnlValue("CreateTime", value.ToString());
                }
            }

            public int CreatorUserID
            {
                get
                {
                    return int.Parse(GetColumnName("CreatorUserID").ToString());
                }
                set
                {
                    SetColumnlValue("CreatorUserID", value.ToString());
                }
            }

            public string LastModifyTime
            {
                get
                {
                    return GetColumnName("LastModifyTime").ToString();
                }
                set
                {
                    SetColumnlValue("LastModifyTime", value.ToString());
                }
            }

            public int LastModifyUserID
            {
                get
                {
                    return int.Parse(GetColumnName("LastModifyUserID").ToString());
                }
                set
                {
                    SetColumnlValue("LastModifyUserID", value.ToString());
                }
            }

            public string PreOpDiagnosis
            {
                get
                {
                    return GetColumnName("PreOpDiagnosis").ToString();
                }
                set
                {
                    SetColumnlValue("PreOpDiagnosis", value.ToString());
                }
            }

            public string PostOpDiagnosis
            {
                get
                {
                    return GetColumnName("PostOpDiagnosis").ToString();
                }
                set
                {
                    SetColumnlValue("PostOpDiagnosis", value.ToString());
                }
            }

            public string KindOfOpretion
            {
                get
                {
                    return GetColumnName("KindOfOpretion").ToString();
                }
                set
                {
                    SetColumnlValue("KindOfOpretion", value.ToString());
                }
            }

            public string HasSpecimen
            {
                get
                {
                    return GetColumnName("HasSpecimen").ToString();
                }
                set
                {
                    SetColumnlValue("HasSpecimen", value.ToString());
                }
            }

            public int SpecimenQty
            {
                get
                {
                    return int.Parse(GetColumnName("SpecimenQty").ToString());
                }
                set
                {
                    SetColumnlValue("SpecimenQty", value.ToString());
                }
            }

            public string Indication
            {
                get
                {
                    return GetColumnName("Indication").ToString();
                }
                set
                {
                    SetColumnlValue("Indication", value.ToString());
                }
            }

            public string OpProcedure
            {
                get
                {
                    return GetColumnName("OpProcedure").ToString();
                }
                set
                {
                    SetColumnlValue("OpProcedure", value.ToString());
                }
            }
            
        }
    

        private void SetContentControls()
        {
            _contentControls.AttendingPhysician = _reception.DoctorName;
            _contentControls.NurseOfOpRoom = _reception.NurseName;
            _contentControls.BeginningTime = _reception.StartTime;
            _contentControls.EndTime = _reception.EndTime;
            _contentControls.Room = _reception.Room;
            _contentControls.SecondAssistant = 
            _contentControls.Date = _reception.OpDate;
            _contentControls.Name = _reception.FName;
            _contentControls.Age = _reception.Age;
            _contentControls.FirstAssistant = _reception.FirstHelp;
            _contentControls.SecondAssistant = _reception.SecondAsistant;
            _contentControls.KindOfAnesthesia = _reception.BType;
            _contentControls.FamilyName = _reception.LName;
            _contentControls.Surgeon = _reception.DoctorName;
            _contentControls.Anesthesiologist = _reception.DoctorName;

        }

        private void GetContentControls()
        {
            
        }

        void wordApp_DocumentBeforeSave(Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            

            

            //try
            //{
            //    if (!InsertOrEdit(Int32.Parse(_reception["Serial"].ToString()), _reception["OpDate"].ToString(), _reception["BStartTime"].ToString()))
            //        InsertToDB();
            //    else
            //        UpdateDB();
            //}
            //catch
            //{ 
            //}
        }

        //public bool InsertOrEdit(int serial, string opDate, string opStartTime)
        //{
        //    DataRow drSelectSingle = null;
        //    DBHelper dbH = new DBHelper(ConnectionStrings.HisPlusDB);

        //    List<string> filters = new List<string>();
        //    if (serial != null)
        //        filters.Add(string.Format(" Serial ={0} ", serial));
        //    if (opDate != "")
        //        filters.Add(string.Format(" OpDate LIKE N'%{0}%' ", opDate));
        //    if (opStartTime != "")
        //        filters.Add(string.Format(" StartTime LIKE N'%{0}%' ", opStartTime));

        //    drSelectSingle = dbH.SelectSingle("OperationReport", string.Join((" and "), filters.ToArray()));

        //    if (drSelectSingle == null)
        //        return false;
        //    else
        //        return true;

        //}

        //public void ReadContentControlValue(Document wordDoc)
        //{
        //    string controlsList = string.Empty;

        //    _contentControls = wordDoc.ContentControls;
        //    for (int i = 1; i <= _contentControls.Count; i++)
        //    {
        //        OperationReportFormUC opc = new OperationReportFormUC();
        //        contentControl = _contentControls[i];
        //        switch (contentControl.Title)
        //        {
        //            case "BegingTime":
        //                StartTime = opc.SelectedReceptionRow["BStartTime"].ToString();
        //                break;

        //            case "Date":
        //                Date = opc.SelectedReceptionRow["OpDate"].ToString();
        //                break;

        //            case "PreOp":
        //                PreOpDiagnosis = contentControl.Range.Text;
        //                break;

        //            case "PostOp":
        //                PostOpDiagnosis = contentControl.Range.Text;
        //                break;

        //            case "KindOp":
        //                KindOfOpretion = contentControl.Range.Text;
        //                break;

        //            case "SepecimentNum":
        //                SpecimenQty = Int32.Parse(contentControl.Range.Text);
        //                break;

        //            case "Indcation":
        //                Indication = contentControl.Range.Text;
        //                break;

        //            case "Finding":
        //                Finding = contentControl.Range.Text;
        //                break;

        //            case "Procedure":
        //                OpProcedure = contentControl.Range.Text;
        //                break;

        //        }
        //        if (contentControl != null)
        //            Marshal.ReleaseComObject(contentControl);
        //    }
        //}

        //public void InsertToDB()
        //{
        
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataRow drOperationReport = null;
        //    OperationReportFormUC orFormUC = new OperationReportFormUC();
     
        //    DBHelper dbh = new DBHelper(ConnectionStrings.HisPlusDB);
        //    drOperationReport = dbh.GetNewRow("OperationReport", out da); 
            
        //    drOperationReport["Serial"] = Serial;
        //    drOperationReport["OpDate"] = Date;
        //    drOperationReport["StartTime"] = StartTime;
        //    drOperationReport["ReportFileData"] = ReportFile;
        //    drOperationReport["PreOpDiagnosis"] = PreOpDiagnosis;
        //    drOperationReport["PreOpDiagnosis"] = Finding;
        //    drOperationReport["PostOpDiagnosis"] = PostOpDiagnosis ;
        //    drOperationReport["KindOfOpretion"] = KindOfOpretion;
        //    drOperationReport["CreateTime"] = CreateTime;
        //    drOperationReport["CreatorUserID"] = 1;
        //    drOperationReport["HasSpecimen"] = HasSpecimen;
        //    drOperationReport["SpecimenQty"] = SpecimenQty;
        //    drOperationReport["Indication"] = Indication;
        //    drOperationReport["OpProcedure"] = OpProcedure;

        //    dbh.Insert(drOperationReport, da);
        //}

        //public void UpdateDB()
        //{
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        DataRow drSelectSingle = null;
        //        DBHelper dbh = new DBHelper(ConnectionStrings.HisPlusDB);

        //        List<string> filters = new List<string>();
        //        if (_reception["Serial"] != null)
        //            filters.Add(string.Format(" Serial ={0} ", _reception["Serial"]));
        //        if (_reception["OpDate"] != "")
        //            filters.Add(string.Format(" OpDate LIKE N'%{0}%' ", _reception["OpDate"]));
        //        if (_reception["StartTime"] != "")
        //            filters.Add(string.Format(" StartTime LIKE N'%{0}%' ", _reception["StartTime"]));

        //        drSelectSingle = dbh.SelectSingle("OperationReport", string.Join((" and "), filters.ToArray()));
        //        drSelectSingle["OpProcedure"] = OpProcedure;
        //        dbh.Update(drSelectSingle, da, "OperationReport");
        //}

        private class ReceptionData
        {
            private DataRow _receptionRow;

            public ReceptionData(DataRow receptionRow)
            {
                _receptionRow = receptionRow;
            }


            private string GetDoctorName(int code)
            {
                if (code != -1)
                    using (DBHelper opRoomDb = new DBHelper(ConnectionStrings.OpRoomDB))
                    {
                        return opRoomDb.SelectSingle("Doctor", "Code = " + code)["Name"].ToString();
                    }
                else
                    return null;
            }

            private string GetNurseName(int nurse_Code)
            {
                using (DBHelper opRoomDb = new DBHelper(ConnectionStrings.OpRoomDB))
                {
                    return opRoomDb.SelectSingle("Nurse", "Code = " + nurse_Code)["Name"].ToString();
                }
            }

            private string GetSecondAssistantName(int otDoc_Code)
            {
                using (DBHelper opRoomDb = new DBHelper(ConnectionStrings.OpRoomDB))
                {
                    return opRoomDb.SelectSingle("OPTecnisian", "Code = " + otDoc_Code)["Name"].ToString();
                }
            }


            public int Serial
            {
                get
                {
                    return Int32.Parse(_receptionRow["Serial"].ToString());
                }
            }

            public string OpDate
            {
                get
                {
                    return _receptionRow["OpDate"].ToString();
                }
            }

            public string EndTime
            {
                get
                {
                    return _receptionRow["EndTime"].ToString();
                }
            }

            public string FName
            {
                get
                {
                    return _receptionRow["FName"].ToString();
                }
            }

            public string LName
            {
                get
                {
                    return _receptionRow["LName"].ToString();
                }
            }

            public string Age
            {
                get
                {
                    return _receptionRow["Age"].ToString();
                }
            }

            public string StartTime
            {
                get
                {
                    return _receptionRow["StartTime"].ToString();
                }
            }

            public string DoctorName
            {
                get
                {
                   return GetDoctorName(int.Parse(_receptionRow["JDoc_Code"].ToString()));
                }
            }

            public string SecondAsistant
            {
                get
                {
                    return GetSecondAssistantName(int.Parse(_receptionRow["OTDoc_Code"].ToString()));
                }
            }

            public string NurseName
            {
                get
                {
                    if (int.Parse(_receptionRow["FreeNurse"].ToString()) != 0)
                        return GetNurseName(int.Parse(_receptionRow["FreeNurse"].ToString()));
                    else
                        return "";
                }
            }

            public string FirstHelp
            {
                get
                {
                    if (int.Parse(_receptionRow["JHelp_Code"].ToString()) != -1)
                        return GetDoctorName(int.Parse(_receptionRow["JHelp_Code"].ToString()));
                    else
                        return "";
                }
            }

            public string Room
            {
                get
                {
                    return _receptionRow["Room"].ToString();
                }
            }

            public string OPTName
            {
                get
                {
                    return _receptionRow["OPTName"].ToString();
                }
            }

            public string BType
            {
                get
                {
                    if (_receptionRow["BType"].ToString() != "5")
                    {
                        switch (_receptionRow["BType"].ToString())
                        {
                            case "1":
                                return "G.A";

                            case "2":
                                return "L.A";

                            case "3":
                                return "S.A";
                        }
                    }
                    return "بی حسی";
                        
                }
            }

            public bool HasSpecimen
            {
                get
                {
                    if (Int32.Parse(_receptionRow["SpecimenYesNo"].ToString()) == 0 || _receptionRow["SpecimenYesNo"] == "")
                        return false;
                    else
                        return true;
                }
            }

            public string PreDiagnosis
            {
                get
                {
                    if (_receptionRow["PreDiagnosis"].ToString() != null)
                        return _receptionRow["PreDiagnosis"].ToString();
                    else
                        return "";
                }
            }

            public string PostDiagnosis
            {
                get
                {
                    if (_receptionRow["PostDiagnosis"].ToString() != "")
                        return _receptionRow["PostDiagnosis"].ToString();
                    else
                        return "";
                }
            }

            public string KindOfOperation
            {
                get
                {
                    if (_receptionRow["KindOfOperation"].ToString() != "")
                        return _receptionRow["KindOfOperation"].ToString();
                    else
                        return "";
                }
            }

            public string SpecimenNumber
            {
                get
                {
                    if (_receptionRow["SpecimenNumber"].ToString() != "")
                        return _receptionRow["SpecimenNumber"].ToString();
                    else
                        return "0";
                }
            }

            public string OpIndication
            {
                get
                {
                    return _receptionRow["OpIndication"].ToString();
                }
            }

            public string OpFinding
            {
                get
                {
                    return _receptionRow["OpFinding"].ToString();
                }
            }
        }

        private class OpReportDocContentControls
        {
            private Document _wordDoc;

            public OpReportDocContentControls(Document wordDoc)
            {
                _wordDoc = wordDoc;
            }

            private ContentControl GetContentControl(string controlTag)
            {
                for (int i = 1; i <= _wordDoc.ContentControls.Count; i++)
                {
                    if (_wordDoc.ContentControls[i].Tag == controlTag)
                        return _wordDoc.ContentControls[i];
                }

                return null;
            }
            
            private object GetContentControlValue(string controlTag)
            {
                var contentControl = GetContentControl(controlTag);
                var result = contentControl.Range.Text;
                Marshal.ReleaseComObject(contentControl);
                return result;
            }

            private void SetContentControlValue(string controlTag, string value)
            {
                var contentControl = GetContentControl(controlTag);
                contentControl.Range.Text = value;
                Marshal.ReleaseComObject(contentControl);
            }

            public string AttendingPhysician
            {
                get
                {
                    return GetContentControlValue("Attending Physician").ToString();
                }
                set
                {
                    SetContentControlValue("Attending Physician", value.ToString());
                }
            }

            public string NurseOfOpRoom
            {
                get
                {
                    return GetContentControlValue("Nurse of Op Room").ToString();
                }
                set
                {
                    SetContentControlValue("Nurse of Op Room", value.ToString());
                }
            }

            public string BeginningTime
            {
                get
                {
                    return GetContentControlValue("Beginning Time").ToString();
                }
                set
                {
                    SetContentControlValue("Beginning Time", value.ToString());
                }
            }

            public string EndTime
            {
                get
                {
                    return GetContentControlValue("End Time").ToString();
                }
                set
                {
                    SetContentControlValue("End Time", value.ToString());
                }
            }
            
            public string Room
            {
                get
                {
                    return GetContentControlValue("Room").ToString();
                }
                set
                {
                    SetContentControlValue("Room", value.ToString());
                }
            }

            public string SecondAssistant
            {
                get
                {
                    return GetContentControlValue("Second Assistant").ToString();
                }
                set
                {
                    SetContentControlValue("Second Assistant", value.ToString());
                }
            }

            public string Date
            {
                get
                {
                    return GetContentControlValue("Date").ToString();
                }
                set
                {
                    SetContentControlValue("Date", value.ToString());
                }
            }

            public string Name
            {
                get
                {
                    return GetContentControlValue("Name").ToString();
                }
                set
                {
                    SetContentControlValue("Name", value.ToString());
                }
            }

            public string Age
            {
                get
                {
                    return GetContentControlValue("Age").ToString();
                }
                set
                {
                    SetContentControlValue("Age", value.ToString());
                }
            }

            public string FirstAssistant
            {
                get
                {
                    return GetContentControlValue("First Assistant").ToString();
                }
                set
                {
                    SetContentControlValue("First Assistant", value.ToString());
                }
            }

            public string KindOfAnesthesia
            {
                get
                {
                    return GetContentControlValue("Kind of Anesthesia").ToString();
                }
                set
                {
                    SetContentControlValue("Kind of Anesthesia", value.ToString());
                }
            }

            public string UnitNumber
            {
                get
                {
                    return GetContentControlValue("Unit Number").ToString();
                }
                set
                {
                    SetContentControlValue("Unit Number", value.ToString());
                }
            }

            public string FamilyName
            {
                get
                {
                    return GetContentControlValue("Family Name").ToString();
                }
                set
                {
                    SetContentControlValue("Family Name", value.ToString());
                }
            }

            public string Surgeon
            {
                get
                {
                    return GetContentControlValue("Surgeon").ToString();
                }
                set
                {
                    SetContentControlValue("Surgeon", value.ToString());
                }
            }

            public string Anesthesiologist
            {
                get
                {
                    return GetContentControlValue("Anesthesiologist").ToString();
                }
                set
                {
                    SetContentControlValue("Anesthesiologist", value.ToString());
                }
            }

            public string SurgeonInFooter
            {
                get
                {
                    return GetContentControlValue("Surgeon In Footer").ToString();
                }
                set
                {
                    SetContentControlValue("Surgeon In Footer", value.ToString());
                }
            }

            public string PerOpDiagnosis
            {
                get
                {
                    return GetContentControlValue("PerOpDiagnosis").ToString();
                }
                set
                {
                    SetContentControlValue("PerOpDiagnosis", value.ToString());
                }
            }

            public string PostOpDiagnosis
            {
                get
                {
                    return GetContentControlValue("PostOpDiagnosis").ToString();
                }
                set
                {
                    SetContentControlValue("PostOpDiagnosis", value.ToString());
                }
            }

            public string KindOfOperation
            {
                get
                {
                    return GetContentControlValue("KindOfOperation").ToString();
                }
                set
                {
                    SetContentControlValue("KindOfOperation", value.ToString());
                }
            }

            public string SpecimentNo
            {
                get
                {
                    return GetContentControlValue("SpecimentNo").ToString();
                }
                set
                {
                    SetContentControlValue("SpecimentNo", value.ToString());
                }
            }

            public string SpecimenYes
            {
                get
                {
                    return GetContentControlValue("SpecimenYes").ToString();
                }
                set
                {
                    SetContentControlValue("SpecimenYes", value.ToString());
                }
            }

            public string SepecimentNum
            {
                get
                {
                    return GetContentControlValue("SepecimentNum").ToString();
                }
                set
                {
                    SetContentControlValue("SepecimentNum", value.ToString());
                }
            }

            public string Indcation
            {
                get
                {
                    return GetContentControlValue("Indcation").ToString();
                }
                set
                {
                    SetContentControlValue("Indcation", value.ToString());
                }
            }

            public string Finding
            {
                get
                {
                    return GetContentControlValue("Finding").ToString();
                }
                set
                {
                    SetContentControlValue("Finding", value.ToString());
                }
            }

            public string Procedure
            {
                get
                {
                    return GetContentControlValue("Procedure").ToString();
                }
                set
                {
                    SetContentControlValue("Procedure", value.ToString());
                }
            }

        }
    }
}
