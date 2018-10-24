using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI
{
    /// <summary>
    /// WeChat 的摘要说明
    /// </summary>
    public class WeChat : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var signature = context.Request["signature"];
            var timestamp = context.Request["timestamp"];
            var nonce = context.Request["nonce"];
            var echostr = context.Request["echostr"];
            File.WriteAllText(string.Format("{0}/{1}.txt",context.Server.MapPath("~"), DateTime.Now.ToString("yyyyMMddhhmmss")), context.Request.RawUrl);
            context.Response.ContentType = "text/plain";
            context.Response.Write(echostr);
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