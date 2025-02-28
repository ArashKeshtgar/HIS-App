using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace HISPlus
{
    public static class ConnectionStrings
    {
        public static string OpRoomDB
        {
            get
            {
                string encryptedValue = AppSettingsManager.GetSetting("OpRoomDBConnectionString");
                if (!string.IsNullOrEmpty(encryptedValue))
                    return CryptographyUtils.AESCryptography.DecryptStringAES(encryptedValue, "452654645");
                else
                    return null;
            }
            set
            {
                string encryptedValue = "";
                if (!string.IsNullOrEmpty(value))
                    encryptedValue = CryptographyUtils.AESCryptography.EncryptStringAES(value, "452654645");
                AppSettingsManager.SetSetting("OpRoomDBConnectionString", encryptedValue);
            }
        }

        public static string HisPlusDB
        {
            get
            {
                string encryptedValue = AppSettingsManager.GetSetting("HisPlusConnectionString");
                if (!string.IsNullOrEmpty(encryptedValue))
                    return CryptographyUtils.AESCryptography.DecryptStringAES(encryptedValue, "452654645");
                else
                    return null;
            }
            set
            {
                string encryptedValue = "";
                if (!string.IsNullOrEmpty(value))
                    encryptedValue = CryptographyUtils.AESCryptography.EncryptStringAES(value, "452654645");
                AppSettingsManager.SetSetting("HisPlusConnectionString", encryptedValue);
            }
        }
      
    }
}
