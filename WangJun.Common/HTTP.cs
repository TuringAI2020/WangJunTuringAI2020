using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
   public class HTTP: WJ
    {
        public static HTTP GetInst(string url) {
            var inst = new HTTP();
            inst.Url = url;
            return inst;
        }
         

        public string Url { get; set; }

        public string AcceptEncoding { get; set; }

        /// <summary>
        /// GET 请求
        /// </summary>
        /// <returns></returns>
        public string GET() {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            http.DefaultRequestHeaders.Add("accept-encoding",this.AcceptEncoding);
            http.DefaultRequestHeaders.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8");
            http.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36");

            var task = http.GetAsync(this.Url);
            var res = task.Result.Content.ReadAsByteArrayAsync().Result;
            if (this.AcceptEncoding.ToLower().Contains("gzip")) {
                res = GZIP.Decompress(res);
            }
            var str = Encoding.UTF8.GetString(res);
            return str;

        }

        /// <summary>
        /// GET 获取数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="header"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Get(string url, Dictionary<string, string> headers)
        {
            var http = new HttpClient();
            var resGzip = false;
            if (!string.IsNullOrWhiteSpace(url))
            {
                if (null != headers)
                {
                    foreach (var item in headers)
                    {
                        http.DefaultRequestHeaders.Add(item.Key, item.Value);
                        if (!resGzip && item.Value.Contains("gzip"))
                        {
                            resGzip = item.Value.Contains("gzip");
                        }
                    }
                }



                var task = http.GetAsync(url);
                var res = task.Result.Content.ReadAsByteArrayAsync().Result;
                if (resGzip)
                {
                    res = GZIP.Decompress(res);
                }
                var str = Encoding.UTF8.GetString(res);
                return str;
            }
            return null;
        }
    }
}
