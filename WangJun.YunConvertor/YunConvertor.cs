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
    }
}
