using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public class HttpRequestParam
    {
        public Dictionary<string, object> GetQueryParam { get; set; }

        public Dictionary<string, object> PostFormParam { get; set; }

        public Dictionary<string, object> PostJsonStreamParam { get; set; }

        public static HttpRequestParam Parse(Stream stream,Encoding encoding=null) {
            var inst = new HttpRequestParam();
            if (null != stream)
            {
                if (null == encoding)
                {
                    encoding = Encoding.UTF8;
                }

                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                var str = encoding.GetString(bytes).Trim();
                if ((str.StartsWith("{") && str.EndsWith("}")) || (str.StartsWith("[") && str.EndsWith("]")))
                {
                    var streamData = JSON.ToObject<Dictionary<string, object>>(str);
                    inst.PostJsonStreamParam = streamData;
                }
                else if (str.Contains("="))
                {
                    var array = str.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in array)
                    {

                    }
                }
            }

            return inst;
        }
    }
     
}
