using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HISPlus
{
    public class SystemUser
    {
        private DataRow _systemUserRow;

        public SystemUser(DataRow systemUserRow)
        {
            _systemUserRow = systemUserRow;
        }

        public int ID
        {
            get
            {
                return _systemUserRow.Field<int>("ID");
            }
            set
            {
                _systemUserRow["ID"] = value;
            }
        }

        public string UserName
        {
            get
            {
                return _systemUserRow["UserName"].ToString();
            }
        }

        public string RealName
        {
            get
            {
                return _systemUserRow["RealName"].ToString();
            }
        }

        public string Password
        {
            get
            {
                return _systemUserRow["Password"].ToString();
            }
        }

        public bool IsActive
        {
            get
            {
                return _systemUserRow.Field<bool>("IsActive");
            }
            set
            {
                _systemUserRow["IsActive"] = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return _systemUserRow.Field<bool>("IsAdmin");
            }
            set
            {
                _systemUserRow["IsAdmin"] = value;
            }
        }    
    }
}
