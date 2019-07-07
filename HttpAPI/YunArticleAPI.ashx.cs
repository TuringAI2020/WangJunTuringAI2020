using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Web;
using WangJun.Common;
using WangJun.Yun;

namespace HttpAPI
{
    /// <summary>
    /// API 的摘要说明
    /// </summary>
    public partial class YunArticleAPI : IHttpHandler
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
            var str = Encoding.UTF8.GetString(buffer);
            var reqCheck = ReqMsg<object>.Parse(str);
            context.Response.ContentType = "text/plain";
            var contentType = "text/plain"; 
            if (typeof(YunArticle).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunArticle>.Parse(str);
                RES res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray) as RES;
                str = res.ToJson();
                contentType = CONST.application_json;
            }
            context.Response.ContentType = contentType;
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