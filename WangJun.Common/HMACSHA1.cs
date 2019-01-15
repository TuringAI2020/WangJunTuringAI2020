using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WangJun.Yun
{
    public static class HMACSHA1
    {
        /// <summary>
        /// HMACSHA1  加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string ToHMACSHA1(string secret, string mk)
        {
            var hmacsha1 = new System.Security.Cryptography.HMACSHA1();
            hmacsha1.Key = Encoding.UTF8.GetBytes(secret);
            byte[] dataBuffer = Encoding.UTF8.GetBytes(mk);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
