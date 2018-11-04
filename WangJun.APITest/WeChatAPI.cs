using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

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

        public static string HttpGet(string url) {
            var http = new WebClient();
            http.Encoding = Encoding.UTF8;
            var res = http.DownloadString(url);
            return res;
        }

        public static string HttpPost(string url,string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            var http = new WebClient();
            http.Encoding = Encoding.UTF8;
            http.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //http.Headers[HttpRequestHeader.ContentLength] = bytes.Length.ToString();
            var res = http.UploadData(url, bytes);
            return Encoding.UTF8.GetString(res);
        }

        public string GetToken() {
            var url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx0d5f15121f4d9cc3&secret=c2dd349ae5faf6267bf330b44a7f8d50";
            var res = WeChatAPI.HttpGet(url);
            var token = JSON.ToObject<Dictionary<string, object>>(res)["access_token"];
            return token.ToString();
        }

        ///获取用户列表
        public List<string> GetUserList() {
            var list = new List<string>();
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}", this.GetToken(), string.Empty);
            var res = WeChatAPI.HttpGet(url);
            res = JSON.GetValue(res, "data", "openid");
             list = JSON.ToObject<List<string>>(res);
            return list;
        }

        public List<string> GetUserInfoList() {
            var list = new List<string>();
            var openIdList = this.GetUserList();
            foreach (var openId in openIdList)
            {
                var userInfo = this.GetUserInfo(openId);
                list.Add(userInfo);
            }
            return list;
        }

        public string GetUserInfo(string openId)
        {
            var url =string.Format( "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN",this.GetToken(),openId);
            var res = WeChatAPI.HttpGet(url);
            return res;

        }
        public string CreateMenu() {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}",this.GetToken());
            var data= "{\"button\": [{\"type\": \"click\",\"name\": \"汪俊\",\"key\": \"V1002_TODAY_MUSIC\"}]}";
            var res = WeChatAPI.HttpPost(url,data);
            return res;

        }
    }
}
