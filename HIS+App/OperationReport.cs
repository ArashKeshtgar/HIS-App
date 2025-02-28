using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HISPlus
{
    public class OperationReport
    {
        private DataRow _operationReportRow;

        public OperationReport(DataRow operationReportRow)
        {
            _operationReportRow = operationReportRow;
        }

        public int Serial
        {
            get
            {
                return int.Parse(_operationReportRow["Serial"].ToString());
            }
            set
            {
                _operationReportRow["Serial"] = value;
            }
        }

        public string OpDate
        {
            get
            {
                return _operationReportRow["OpDate"].ToString();
            }
            set
            {
                _operationReportRow["OpDate"] = value;
            }
        }

        public string StartTime
        {
            get
            {
                return _operationReportRow["StartTime"].ToString();
            }
            set
            {
                _operationReportRow["StartTime"] = value;
            }
        }

        public DateTime? CreateTime
        {
            get
            {
                return _operationReportRow["CreateTime"] == DBNull.Value ? (DateTime?)null
                    : _operationReportRow.Field<DateTime>("CreateTime");
            }
            set
            {
                if (value == null)
                    _operationReportRow["CreateTime"] = DBNull.Value;
                else
                    _operationReportRow["CreateTime"] = value;
            }
        }

        public int? CreatorUserID
        {
            get
            {
                return _operationReportRow["CreatorUserID"] == DBNull.Value ? (int?)null
                    : int.Parse(_operationReportRow["CreatorUserID"].ToString());
            }
            set
            {
                if (value == null)
                    _operationReportRow["CreatorUserID"] = DBNull.Value;
                else
                    _operationReportRow["CreatorUserID"] = value;
            }
        }

        public DateTime? LastModifyTime
        {
            get
            {
                return _operationReportRow["LastModifyTime"] == DBNull.Value ? (DateTime?)null
                    : _operationReportRow.Field<DateTime>("LastModifyTime");
            }
            set
            {
                if (value == null)
                    _operationReportRow["LastModifyTime"] = DBNull.Value;
                else
                    _operationReportRow["LastModifyTime"] = value;
            }
        }

        public int? LastModifyUserID
        {
            get
            {
                return _operationReportRow["LastModifyUserID"] == DBNull.Value ? (int?)null
                    : int.Parse(_operationReportRow["LastModifyUserID"].ToString());
            }
            set
            {
                if (value == null)
                    _operationReportRow["LastModifyUserID"] = DBNull.Value;
                else
                    _operationReportRow["LastModifyUserID"] = value;
            }
        }

        public string PreOpDiagnosis
        {
            get
            {
                return _operationReportRow["PreOpDiagnosis"].ToString();
            }
            set
            {
                if (value == null)
                    _operationReportRow["PreOpDiagnosis"] = DBNull.Value;
                else
                    _operationReportRow["PreOpDiagnosis"] = value;
            }
        }

        public string PostOpDiagnosis
        {
            get
            {
                return _operationReportRow["PostOpDiagnosis"].ToString();
            }
            set
            {
                if (value == null)
                    _operationReportRow["PostOpDiagnosis"] = DBNull.Value;
                else
                    _operationReportRow["PostOpDiagnosis"] = value;
            }
        }

        public string KindOfOpretion
        {
            get
            {
                return _operationReportRow["KindOfOperation"].ToString();
            }
            set
            {
                if (value == null)
                    _operationReportRow["KindOfOperation"] = DBNull.Value;
                else
                    _operationReportRow["KindOfOperation"] = value;
            }
        }

        public bool? HasSpecimen
        {
            get
            {
                return _operationReportRow.Field<bool?>("HasSpecimen");
            }
            set
            {
                if (value == null)
                    _operationReportRow["HasSpecimen"] = DBNull.Value;
                else
                    _operationReportRow["HasSpecimen"] = value;
            }
        }

        public int? SpecimenNumber
        {
            get
            {
                return _operationReportRow["SpecimenNumber"] == DBNull.Value ? (int?)null
                    : int.Parse(_operationReportRow["SpecimenNumber"].ToString());
            }
            set
            {
                if (value == null)
                    _operationReportRow["SpecimenNumber"] = DBNull.Value;
                else
                    _operationReportRow["SpecimenNumber"] = value;
            }
        }

        public string OpProcedure
        {
            get
            {
                return _operationReportRow["OpProcedure"].ToString();
            }
            set
            {
                if (value == null)
                    _operationReportRow["OpProcedure"] = DBNull.Value;
                else
                    _operationReportRow["OpProcedure"] = value;
            }
        }

    }
}
