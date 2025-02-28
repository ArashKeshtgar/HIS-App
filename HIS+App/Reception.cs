using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HISPlus
{
    public class Reception
    {
        private DataRow _receptionRow;

        public Reception(DataRow receptionRow)
        {
            _receptionRow = receptionRow;
        }

        public string PRV_Code
        {
            get
            {
                return _receptionRow["PRV_Code"].ToString();
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

        public string StartTime
        {
            get
            {
                return _receptionRow["StartTime"].ToString();
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

        public string Father
        {
            get
            {
                return _receptionRow["Father"].ToString();
            }
        }

        public string Age
        {
            get
            {
                return _receptionRow["Age"].ToString();
            }
        }

        public int? JDoc_Code
        {
            get
            {
                return _receptionRow["JDoc_Code"] == null ? (int?)null
                    : int.Parse(_receptionRow["JDoc_Code"].ToString());
            }
        }

        public int? JHelp_Code
        {
            get
            {
                return _receptionRow["JHelp_Code"] == null ? (int?)null
                    : int.Parse(_receptionRow["JHelp_Code"].ToString());
            }
        }

        public int? OTDoc_Code
        {
            get
            {
                return _receptionRow["OTDoc_Code"] == null ? (int?)null
                    : int.Parse(_receptionRow["OTDoc_Code"].ToString());
            }
        }

        public int? BMDoc_Code
        {
            get
            {
                return _receptionRow["BMDoc_Code"] == null ? (int?)null
                    : int.Parse(_receptionRow["BMDoc_Code"].ToString());
            }
        }

        public int? FreeNurse
        {
            get
            {
                return _receptionRow["FreeNurse"] == null ? (int?)null
                    : int.Parse(_receptionRow["FreeNurse"].ToString());
            }
        }

        public string Room
        {
            get
            {
                return _receptionRow["Room"].ToString();
            }
        }

        public int? BType
        {
            get
            {
                return _receptionRow["BType"] == null ? (int?)null
                    : int.Parse(_receptionRow["BType"].ToString());
            }
        }

        public string BType_Title
        {
            get
            {
                switch (BType)
                {
                    case null:
                        return null;
                    case 1:
                        return "G.A";
                    case 2:
                        return "L.A";
                    case 3:
                        return "S.A";
                    case 5:
                        return "بی حسی";
                    default:
                        throw new Exception("Invalid BType!");
                }
            }
        }

        public string OpName
        {
            get
            {
                return _receptionRow["OpName"].ToString();
            }
        }
    }
}
