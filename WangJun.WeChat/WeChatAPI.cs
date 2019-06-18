using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    /// <summary>
    /// 微信接口
    /// </summary>
    public class WeChatAPI
    {
        protected string appId = "wx9fca62f653562c17";
        protected string appSecret= "7d4f27f667d79d23347e121d9e35e13d";
        public static WeChatAPI GetInstance() {
            var inst = new WeChatAPI();
            return inst;
        }

        public static string HttpGet(string url) {
            var http = new WebClient();
            http.Encoding = Encoding.UTF8;
            var res = http.DownloadString(url);
            return res;
        }

        public static string HttpPost(string url, string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            var http = new WebClient();
            http.Encoding = Encoding.UTF8;
            http.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //http.Headers[HttpRequestHeader.ContentLength] = bytes.Length.ToString();
            var res = http.UploadData(url, bytes);
            return Encoding.UTF8.GetString(res);
        }





        //public List<string> GetUserInfoList() {
        //    var list = new List<string>();
        //    var openIdList = this.GetUserList();
        //    foreach (var openId in openIdList)
        //    {
        //        var userInfo = this.GetUserInfo(openId);
        //        list.Add(userInfo);
        //    }
        //    return list;
        //}


        public string CreateMenu() {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", this.GetToken());
            var data = "{\"button\": [{\"type\": \"click\",\"name\": \"汪俊\",\"key\": \"V1002_TODAY_MUSIC\"}]}";
            var res = WeChatAPI.HttpPost(url, data);
            return res;

        }

        public string GetWeChatUrl()
        {
            var appId = "wx0d5f15121f4d9cc3";
            var returnUrl = "http%3a%2f%2fapi01.vipgz1.idcfengye.com%2fWeChat.ashx";
            var scope = "snsapi_base";
            return string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state=test#wechat_redirect", appId, returnUrl,scope);
        }

        public string GetTokenByCode(string code)
        {
            var appId = "wx0d5f15121f4d9cc3";
            var secret = "c2dd349ae5faf6267bf330b44a7f8d50"; 
            var url =  string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",appId,secret,code);
            return WeChatAPI.HttpGet(url);

        }

        #region 基础支持

        #region 获取access_token
        /// <summary>
        /// 获取access_token [OK]
        /// </summary>
        /// <returns></returns>
        public string GetToken()
            {
                var url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}",this.appId,this.appSecret);
                var res = WeChatAPI.HttpGet(url);
            Console.WriteLine(res);
                var token = JSON.ToObject<Dictionary<string, object>>(res)["access_token"];
                return token.ToString();
            }
        #endregion

        #region 获取微信服务器IP地址
        /// <summary>
        /// 获取微信服务器IP地址 [OK]
        /// </summary>
        /// <returns></returns>
        public string GetWeChatServerIpList() {
            var url = $"https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={this.GetToken()}";
            var res = WeChatAPI.HttpGet(url);
            Console.WriteLine(res);
            return res;
        }
        #endregion

        #endregion

        #region 接收消息

        #endregion

        #region 发送消息

        #endregion

        #region 用户管理

        #region 获取用户列表
        /// <summary>
        /// 获取用户列表 [OK]
        /// </summary>
        /// <returns></returns>
        public string GetUserList()
        {
            var list = new List<string>();
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}", this.GetToken(), string.Empty);
            var res = WeChatAPI.HttpGet(url);
            Console.WriteLine(res);
            return res;
        }
        #endregion

        #region 获取用户基本信息
        /// <summary>
        /// 获取用户基本信息 [OK]
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public string GetUserInfo()
        {
            var openId = "olMck1QEOgWG-pyofd1vhQJ1_kbk";
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", this.GetToken(), openId);
            var res = WeChatAPI.HttpGet(url);
            Console.WriteLine(res);
            return res;
        }
        #endregion

        #region 设置用户备注名
        /// <summary>
        /// 设置用户备注名 [OK]
        /// </summary>
        /// <returns></returns>
        public string UpdateUserRemark()
        {
            var url = $"https://api.weixin.qq.com/cgi-bin/user/info/updateremark?access_token=" + this.GetToken();
            var postData = new
            {
                openid = "olMck1QEOgWG-pyofd1vhQJ1_kbk",
                remark = "汪俊"
            };
            var res = WeChatAPI.HttpPost(url, JSON.ToJson(postData));
            return res;
        }
        #endregion


        #endregion

        #region 推广支持

        #endregion

        #region 界面丰富

        #endregion

        #region 素材管理

        #endregion

        #region 智能接口

        #endregion

        #region 设备功能

        #endregion

        #region 多客服

        #endregion

        #region 网页帐号

        #endregion

        #region 基础接口

        #endregion

        #region 分享接口

        #endregion

        #region 图像接口

        #endregion

        #region 音频接口

        #endregion

        #region 智能接口

        #endregion

        #region 设备信息	

        #endregion

        #region 地理位置

        #endregion

        #region 界面操作

        #endregion
    }
}
