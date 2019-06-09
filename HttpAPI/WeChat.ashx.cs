using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WangJun.Yun;

namespace HttpAPI
{
    /// <summary>
    /// WeChat 的摘要说明
    /// </summary>
    public class WeChat : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                var echostr = context.Request.QueryString["echostr"];
                var r = context.Request.QueryString["r"];
                var code = context.Request.QueryString["code"];

                var json = JSON.StreamToJson(context.Request.InputStream,Encoding.UTF8);
                var data = new { Url = context.Request.Url, Data = json };
                var path = string.Format("{0}/{1}", context.Server.MapPath("~"), "input");
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                System.IO.File.WriteAllText(string.Format("{0}/{1}.txt",path, DateTime.Now.ToString("yyyyMMddhhmmss")), JSON.ToJson(data),Encoding.UTF8);
                context.Response.Write("OK");


                if (!string.IsNullOrWhiteSpace(echostr))
                {
                    context.Response.Write(echostr);
                    return;
                }
                else if (!string.IsNullOrWhiteSpace(code))
                {
                    context.Response.Write(WeChatAPI.GetInstance().GetTokenByCode(code));
                    return;
                }
                else
                { 
                }
                context.Response.Write(echostr);
            }
            catch (Exception ex) {
                var json = JSON.ToJson(context.Request.InputStream);
                var data = new { Url = context.Request.Url, Data = json };
                var path = string.Format("{0}/{1}", context.Server.MapPath("~"), "input");
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                System.IO.File.WriteAllText(path, ex.Message);
                context.Response.Write("OK");
                context.Response.Write(ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}