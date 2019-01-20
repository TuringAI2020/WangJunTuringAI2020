using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WangJun.Yun
{
    public class HttpRequestParam
    {
        public Dictionary<string, object> GetQueryParam { get; set; }

        public Dictionary<string, object> PostFormParam { get; set; }

        public Dictionary<string, object> PostJsonStreamParam { get; set; }

        public static HttpRequestParam Parse(HttpContext context) {
            var inst = new HttpRequestParam();
            var stream = context.Request.InputStream;
            var encoding = context.Request.ContentEncoding;
            var rawUrl = context.Request.RawUrl;
            var contentType = context.Request.ContentType;
            if (null != stream)
            {
                if (null == encoding)
                {
                    encoding = Encoding.UTF8;
                }


                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                var str = encoding.GetString(bytes).Trim();
                if (CONST.application_json == contentType && (str.StartsWith("{") && str.EndsWith("}")) || (str.StartsWith("[") && str.EndsWith("]")))
                {
                    var streamData = JSON.ToObject<Dictionary<string, object>>(str);
                    inst.PostJsonStreamParam = streamData;
                }
                else if (contentType == CONST.application_x_www_form_urlencoded && str.Contains("="))
                {
                    var array = str.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                    inst.PostFormParam = new Dictionary<string, object>();
                    foreach (var item in array)
                    {
                        var pair = item.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        if (2 == pair.Length)
                        {
                            inst.PostFormParam.Add(pair[0], pair[1]);
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(rawUrl) && rawUrl.Contains("?") && rawUrl.Contains("&") && rawUrl.Contains("="))
                {
                    var array = str.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in array)
                    {
                        var pair = item.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        if (2 == pair.Length)
                        {
                            inst.GetQueryParam.Add(pair[0], pair[1]);
                        }
                    }
                }

            }

            return inst;
        }
    }
     
}
