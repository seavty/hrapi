using HRApi.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApi.Utils.Helper
{
    public static class SystemHelper
    {
        public static bool IsValidToken(string token)
        {
            using (HR_DHLEntities db = new HR_DHLEntities())
            {
                string encryptToken = EncryptString(token);
                return db.tblEmployees.Any(x => x.empl_Deleted == null && x.empl_Token == encryptToken);
            }
        }

        //-> encrypt string
        public static string EncryptString(string pwd)
        {
            CryptLib _crypt = new CryptLib();
            string plainText = pwd;
            string iv = "Xsoft";// CryptLib.GenerateRandomIV(16); //16 bytes = 128 bits
            string key = CryptLib.getHashSha256("@XSoft201701", 31); //32 bytes = 256 bits

            return _crypt.encrypt(plainText, key, iv);

        }

    }
}