using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
   public class HTTP
    {
        public string Encode { get; set; }

        public Dictionary<string, string> Header = new Dictionary<string, string>();

        public string Url { get; set; }

        public string AcceptContentType { get; set; }

        public string Get() {
            var http = new WebClient();
            http.Encoding = Encoding.UTF8;
            if (this.Encode == "utf8") {
                
            }

            var res = http.DownloadString(this.Url);
            return res;
        }
    }
}
