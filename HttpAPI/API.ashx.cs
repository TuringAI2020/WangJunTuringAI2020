using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WangJun.Common;
using WangJun.Yun;

namespace HttpAPI
{
    /// <summary>
    /// API 的摘要说明
    /// </summary>
    public class API : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*"); //设置请求来源不受限制
            context.Response.Headers.Add("Access-Control-Allow-Headers", "X-Requested-With");
            context.Response.Headers.Add("Access-Control-Allow-Methods", "PUT,POST,GET,DELETE,OPTIONS"); //请求方式
            this.Execute(context);


        }

        public void Execute(HttpContext context)
        {
            var length = (int)context.Request.InputStream.Length;
            var buffer = new byte[length];
            context.Request.InputStream.Read(buffer, 0, length);
            var str = Encoding.UTF8.GetString(buffer);
            var reqMsg = ReqMsg<YunForm>.Parse(str);
            reqMsg.Param.SaveToTask();
            context.Response.ContentType = "text/plain";
            context.Response.Write(str);
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