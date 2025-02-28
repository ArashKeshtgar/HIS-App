using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HISPlus
{
    public class OpReportDocContentControlsManager
    {
        private Document _wordDoc;

        public OpReportDocContentControlsManager(Document wordDoc)
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

            throw new Exception(string.Format("Content Control With Tag = \"{0}\" Not Found", controlTag));
        }
            
        private object GetContentControlValue(string controlTag)
        {
            ContentControl contentControl = null;
            try
            {
                contentControl = GetContentControl(controlTag);
                if (contentControl.Type == WdContentControlType.wdContentControlCheckBox)
                    return contentControl.Checked;
                else 
                    return contentControl.Range.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in SetContentControlValue (controlTag = \"{0}\"):\r\n{1}", controlTag, ex.Message));
            }
            finally
            {
                if (contentControl != null)
                    Marshal.ReleaseComObject(contentControl);
            }
        }

        private void SetContentControlValue(string controlTag, object value)
        {
            ContentControl contentControl = null;
            try
            {
                contentControl = GetContentControl(controlTag);

                if (contentControl.Type == WdContentControlType.wdContentControlCheckBox)
                    contentControl.Checked = (bool)value;
                else
                    contentControl.Range.Text = value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error in SetContentControlValue (controlTag = \"{0}\", value = \"{1}\"):\r\n{2}", controlTag, value, ex.Message));
            }
            finally
            {
                if (contentControl != null)
                    Marshal.ReleaseComObject(contentControl);
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

        public string OpDate
        {
            get
            {
                return GetContentControlValue("OpDate").ToString();
            }
            set
            {
                SetContentControlValue("OpDate", value.ToString());
            }
        }

        public string StartTime
        {
            get
            {
                return GetContentControlValue("Start Time").ToString();
            }
            set
            {
                SetContentControlValue("Start Time", value.ToString());
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

        public string FatherName
        {
            get
            {
                return GetContentControlValue("Father Name").ToString();
            }
            set
            {
                SetContentControlValue("Father Name", value.ToString());
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

        public string KindOfOperation
        {
            get
            {
                return GetContentControlValue("Kind Of Operation").ToString();
            }
            set
            {
                SetContentControlValue("Kind Of Operation", value.ToString());
            }
        }

        public string OperationType
        {
            get
            {
                return GetContentControlValue("Operation Type").ToString();
            }
            set
            {
                SetContentControlValue("Operation Type", value.ToString());
            }
        }

        public string PreOpDiagnosis
        {
            get
            {
                return GetContentControlValue("PRE OP. DIAGNOSIS").ToString();
            }
            set
            {
                SetContentControlValue("PRE OP. DIAGNOSIS", value.ToString());
            }
        }

        public string PostOpDiagnosis
        {
            get
            {
                return GetContentControlValue("POST OP. DIAGNOSIS").ToString();
            }
            set
            {
                SetContentControlValue("POST OP. DIAGNOSIS", value.ToString());
            }
        }

        public string KindOfOperation2
        {
            get
            {
                return GetContentControlValue("KIND OF OPERATION (2)").ToString();
            }
            set
            {
                SetContentControlValue("KIND OF OPERATION (2)", value.ToString());
            }
        }

        public bool Speciment_No
        {
            get
            {
                return (bool)GetContentControlValue("SPECIMEN_No");
            }
            set
            {
                SetContentControlValue("SPECIMEN_No", value);
            }

        }

        public bool Specimen_Yes
        {
            get
            {
                return (bool)GetContentControlValue("SPECIMEN_Yes");
            }
            set
            {
                SetContentControlValue("SPECIMEN_Yes", value);
            }
        }

        public string Sepeciment_Number
        {
            get
            {
                return GetContentControlValue("SPECIMEN_Number").ToString();
            }
            set
            {
                SetContentControlValue("SepecimentNum", value.ToString());
            }
        }

        public string Procedure
        {
            get
            {
                return GetContentControlValue("PROCEDURE").ToString();
            }
            set
            {
                SetContentControlValue("PROCEDURE", value.ToString());
            }
        }

        public string Footer_Surgeon
        {
            get
            {
                return GetContentControlValue("Footer_Surgeon").ToString();
            }
            set
            {
                SetContentControlValue("Footer_Surgeon", value.ToString());
            }
        }    
    }
}
