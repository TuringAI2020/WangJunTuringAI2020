using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.APITest
{
    /// <summary>
    /// 微信接口
    /// </summary>
    public class WeChatAPI
    {
        public static  WeChatAPI GetInstance() {
            var inst = new WeChatAPI();
            return inst;
        }
        public string GetToken() {
            var url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx0d5f15121f4d9cc3&secret=c2dd349ae5faf6267bf330b44a7f8d50";
            var http = new WebClient();
            var res = http.DownloadString(url);
            return res;
        }

        ///
    }
}
