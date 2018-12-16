using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WangJun.Yun;

namespace WangJun.PCWeb.YunAPI
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

            var method = context.Request.HttpMethod;
            var res = new RES { MESSAGE = "尚未处理" , SUCCESS=false };
            if ("GET" == method) {
                var m = context.Request["m"];
                if ("0001" == m) {
                    res.DATA = Guid.NewGuid();
                }
            }
            res.MESSAGE = "成功处理";
            context.Response.ContentType = "application/json";
            context.Response.Write(JSON.ToJson(res));
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