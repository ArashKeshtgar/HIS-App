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
        private DataRow _editingOpReportRow;
        private Reception _reception = null;
        string _docUniqueID;
        Document _wordDoc;
        OpReportDocContentControlsManager _contentControlsMgr;
        bool _fileIsOpenedWithError = false;

        public OperationReportFileManager(DataRow receptionRow)
        {
            _reception = new Reception(receptionRow);
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
                try
                {
                    bool shouldSetContentControlsValues = false;

                    string tempFilePath = Path.GetTempPath() + Guid.NewGuid() + ".docx";

                    _editingOpReportRow = LoadOpReportRow();

                    if (_editingOpReportRow == null)
                    {
                        dbHelper.CreateFileFromDB(tempFilePath, @"SELECT top 1 FileData FROM OperationReportTemplate");
                        shouldSetContentControlsValues = true;
                    }
                    else
                    {
                        if (_editingOpReportRow["ReportFileData"] == DBNull.Value)//For some reason FileData is not set
                        {
                            dbHelper.CreateFileFromDB(tempFilePath, @"SELECT top 1 FileData FROM OperationReportTemplate");
                            shouldSetContentControlsValues = true;
                        }
                        else
                        {
                            dbHelper.CreateFileFromDB(
                                tempFilePath,
                                string.Format(@"SELECT ReportFileData FROM OperationReport where Serial = {0} and OpDate = '{1}' and StartTime = '{2}'",
                                    _reception.Serial, _reception.OpDate, _reception.StartTime));
                            shouldSetContentControlsValues = false;
                        }
                    }

                    _fileIsOpenedWithError = false;

                    WordHelper.OpenDocument(tempFilePath);
                    _wordDoc = WordHelper.WordDoc;
                    _docUniqueID = WordHelper.GetDocumentUniqueID(_wordDoc);
                    WordHelper.WordApp.DocumentBeforeSave += WordApp_DocumentBeforeSave;
                    _contentControlsMgr = new OpReportDocContentControlsManager(_wordDoc);
                    WordHelper.WordApp.Visible = true;

                    if (shouldSetContentControlsValues)
                        SetContentControls();
                }
                catch (Exception ex)
                {
                    _fileIsOpenedWithError = true;

                    if (ex.Message == WordHelper.WordDocumentIsAlreadyOpenMessage)
                        MessageBox.Show("ابتدا فایل قبلی را ببندید.");
                    else
                        MessageBox.Show(ex.Message);
                }
            }
        }

        private DataRow LoadOpReportRow()
        {
            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                return dbHelper.SelectSingle("OperationReport",
                    string.Format("Serial = {0} and OpDate = '{1}' and StartTime = '{2}'",
                        _reception.Serial, _reception.OpDate, _reception.StartTime));
            }
        }

        private void SetContentControls()
        {
            _contentControlsMgr.UnitNumber = _reception.PRV_Code;
            _contentControlsMgr.Name = _reception.FName;
            _contentControlsMgr.FamilyName = _reception.LName;
            _contentControlsMgr.FatherName = FixContentControlValue(_reception.Father);
            _contentControlsMgr.Age = FixContentControlValue(_reception.Age);
            _contentControlsMgr.Room = FixContentControlValue(_reception.Room);
            if (_reception.JDoc_Code != null && _reception.JDoc_Code != 0 &&_reception.JDoc_Code != -1)
                _contentControlsMgr.AttendingPhysician = OpRoomDbHelper.GetDoctorName((int)_reception.JDoc_Code);
            if (_reception.FreeNurse != null && _reception.FreeNurse != 0 && _reception.FreeNurse != -1)
                _contentControlsMgr.NurseOfOpRoom = OpRoomDbHelper.GetNurseName((int)_reception.FreeNurse);
            if (_reception.JDoc_Code != null && _reception.JDoc_Code != 0 && _reception.JDoc_Code != -1)
                _contentControlsMgr.Surgeon = OpRoomDbHelper.GetDoctorName((int)_reception.JDoc_Code);
            if (_reception.JHelp_Code != null && _reception.JHelp_Code != 0 && _reception.JHelp_Code != -1)
                _contentControlsMgr.FirstAssistant = OpRoomDbHelper.GetDoctorName((int)_reception.JHelp_Code);
            if (_reception.OTDoc_Code != null && _reception.OTDoc_Code != 0 && _reception.OTDoc_Code != -1)
                _contentControlsMgr.SecondAssistant = OpRoomDbHelper.GetOPTecnisianName((int)_reception.OTDoc_Code);
            _contentControlsMgr.BeginningTime = _reception.StartTime;
            _contentControlsMgr.EndTime = _reception.EndTime;
            if (_reception.BMDoc_Code != null && _reception.BMDoc_Code != 0 && _reception.BMDoc_Code != -1)
                _contentControlsMgr.Anesthesiologist = OpRoomDbHelper.GetDoctorName((int)_reception.BMDoc_Code);
            _contentControlsMgr.KindOfAnesthesia = FixContentControlValue(_reception.BType_Title);
            _contentControlsMgr.OpDate = _reception.OpDate;
            _contentControlsMgr.KindOfOperation = _reception.OpName;
            //_contentControlsMgr.OperationType = ???

            _contentControlsMgr.Procedure = FixContentControlValue(GetDefaultProcedureText());
            _contentControlsMgr.Footer_Surgeon = OpRoomDbHelper.GetDoctorName((int)_reception.JDoc_Code);
        }

        private string GetDefaultProcedureText()
        {
            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                var foundRow = dbHelper.SelectSingle("OperationDefaultText", 
                    string.Format("DoctorCode = {0} and OperationName = N'{1}'", _reception.JDoc_Code, _reception.OpName));
                if (foundRow != null)
                    return foundRow["DefaultText"].ToString();
                else return "";
            }
        }

        private string FixContentControlValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return " ";
            else
                return value.Replace("\r\n", "\v");
        }

        void WordApp_DocumentBeforeSave(Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            if (string.IsNullOrEmpty(_docUniqueID) 
                || WordHelper.GetDocumentUniqueID(Doc) != _docUniqueID)
                return;

            if (_fileIsOpenedWithError)
            {
                MessageBox.Show("بدلیل وجود خطا در باز نمودن فایل امکان ذخیره وجود ندارد.", "خطا");
                return;
            }

            try
            {
                if (_editingOpReportRow != null)//Update
                {
                    var opReport = new OperationReport(_editingOpReportRow);
                    opReport.LastModifyTime = Program.GetServerTime();
                    opReport.LastModifyUserID = Program.LoginUser.ID;

                    SetUserEnteredValues(opReport);

                    using (var hisPlusDb = new DBHelper(ConnectionStrings.HisPlusDB))
                    {
                        hisPlusDb.Update(_editingOpReportRow, "OperationReport");
                    }
                }
                else//Insert
                {
                    using (var hisPlusDb = new DBHelper(ConnectionStrings.HisPlusDB))
                    {
                        DataRow newOpReportRow = null;
                        newOpReportRow = hisPlusDb.GetNewRow("OperationReport");
                        var opReport = new OperationReport(newOpReportRow);

                        opReport.Serial = _reception.Serial;
                        opReport.OpDate = _reception.OpDate;
                        opReport.StartTime = _reception.StartTime;
                        opReport.CreateTime = Program.GetServerTime();
                        opReport.CreatorUserID = Program.LoginUser.ID;

                        SetUserEnteredValues(opReport);

                        hisPlusDb.InsertIntoOperationReport(newOpReportRow);
                    }                    
                }

                SaveOpReportFileToDB();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا");
            }
        }

        private void SetUserEnteredValues(OperationReport opReport)
        {
            if (_contentControlsMgr.Specimen_Yes)
                opReport.HasSpecimen = true;
            else if (_contentControlsMgr.Speciment_No)
                opReport.HasSpecimen = false;
            else
                opReport.HasSpecimen = null;

            opReport.KindOfOpretion = _contentControlsMgr.KindOfOperation2;
            opReport.OpProcedure = _contentControlsMgr.Procedure;
            opReport.PostOpDiagnosis = _contentControlsMgr.PostOpDiagnosis;
            opReport.PreOpDiagnosis = _contentControlsMgr.PreOpDiagnosis;

            int? specimenNumber = null;
            if (!string.IsNullOrEmpty(_contentControlsMgr.Sepeciment_Number.Trim()))
            {
                try
                {
                    specimenNumber = int.Parse(_contentControlsMgr.Sepeciment_Number.Trim());
                }
                catch(Exception ex)
                {
                    throw new Exception("Specimen Number is Invalid.");
                }
            }
            opReport.SpecimenNumber = specimenNumber;
        }

        void SaveOpReportFileToDB()
        {
            string oldFilePath = Path.GetTempPath() + _wordDoc.Name;
            string tempFilePath2 = Path.GetTempPath() + Guid.NewGuid() + ".docx";
            _wordDoc.Save();
            _wordDoc.SaveAs(tempFilePath2);
            //_docUniqueID = WordHelper.GetDocumentUniqueID(_wordDoc);//Because File Name Changes After SaveAs

            byte[] fileBytes;
            using (var stream = new FileStream(oldFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    fileBytes = reader.ReadBytes((int)stream.Length);
                }
            }

            using (var dbHelper = new DBHelper(ConnectionStrings.HisPlusDB))
            {
                string saveQuery = "update OperationReport set ReportFileData = @ReportFileData "
                    + string.Format("where Serial = {0} and OpDate = '{1}' and StartTime = '{2}'", _reception.Serial, _reception.OpDate, _reception.StartTime);

                using (var saveSqlCommand = new SqlCommand(saveQuery, dbHelper.Connection))
                {
                    if (dbHelper.Connection.State == ConnectionState.Closed)
                        dbHelper.Connection.Open();
                    saveSqlCommand.Parameters.Add("@ReportFileData", SqlDbType.VarBinary, fileBytes.Length).Value = fileBytes;
                    saveSqlCommand.ExecuteNonQuery();
                }
            }

            _editingOpReportRow = LoadOpReportRow();//After First Save, Always we are in Edit Mode
        }
    }
}
