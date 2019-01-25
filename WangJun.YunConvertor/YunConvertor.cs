using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public class YunConvertor
    {
        public static YunConvertor Current {
            get {
                var inst = new YunConvertor();
                return inst;
            }
        }

        public string ToBase64String(string input) {
            return BASE64.ToBase64String(input);
        }

        public string FromBase64String(string input)
        {
            return BASE64.FromBase64String(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ToMD5(string input) {
            return MD5.ToMD5(input);
        }

        public string ToSHA1(string input)
        {
            return SHA1.ToSHA1(input);
        }

        public string ToHMACSHA1(string secret, string mk)
        {
            return HMACSHA1.ToHMACSHA1(  secret,   mk);
        }

        public string NewGUID(long count=1) {
            var list = new StringBuilder();
            for (int k = 0; k < Math.Abs(count) % 1000; k++)
            {
                list.AppendLine(Guid.NewGuid().ToString());
            }
            return list.ToString();
        }

        public string AllHanZI() {
            return HANZI.GetAll();
        }


        public string TimeNow() {
            return DATETIME.Now();
        }

        public List<KeyValuePair<string, int>> WordAnalyse(string input)
        {
            return WordAnalysor.Analyse(input);
        }


    }
}
