using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WangJun.Yun;

namespace WangJun.AsyncAPI
{
    /// <summary>
    /// AsyncAPI 的摘要说明
    /// </summary>
    public class AsyncAPI : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //var param = HttpRequestParam.Parse(context);
            //context.Response.Headers.Add("Access-Control-Allow-Origin", "*"); //设置请求来源不受限制
            //context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Accept,X-Requested-With");
            //context.Response.Headers.Add("Access-Control-Allow-Methods", "PUT,POST,GET,DELETE,OPTIONS"); //请求方式
            try
            {
                this.Execute(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = CONST.application_json;
                context.Response.Write(new { Ex = ex.Message });
            }

        }

        /// <summary>
        /// 业务处理
        /// </summary>
        /// <param name="context"></param>
        public void Execute(HttpContext context)
        {
            var length = (int)context.Request.InputStream.Length;
            var buffer = new byte[length];
            context.Request.InputStream.Read(buffer, 0, length);
            var req = Encoding.UTF8.GetString(buffer); 
            context.Response.ContentType = "text/plain";
            var contentType = "application/json";
            var res = YunQueue.GetInst().Enqueue("", req);

            context.Response.ContentType = contentType;
            context.Response.Write(res.ToJson());
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