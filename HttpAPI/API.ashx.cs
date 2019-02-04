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
    public partial class API : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //var param = HttpRequestParam.Parse(context);

            if (context.IsWebSocketRequest)
            {
                this.WebSocketProc(context);
            }
            else if (0 < context.Request.Files.Count&&"SaveToSQLServer" == context.Request.QueryString["m"]) {
                new YunFile().SaveToSQLServer();
            }
            else if (0 < context.Request.Files.Count&&"SaveToDisk" == context.Request.QueryString["m"])
            {
                var filePath = new YunFile().SaveFromHttp();
                context.Response.Write(filePath);
            } 
            else
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*"); //设置请求来源不受限制
                context.Response.Headers.Add("Access-Control-Allow-Headers", "X-Requested-With");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "PUT,POST,GET,DELETE,OPTIONS"); //请求方式
                this.Execute(context);
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
            if (typeof(YunForm).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunForm>.Parse(str);
                reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, null);
            }
            else if (typeof(HTTP).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<HTTP>.Parse(str);
                object res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, null);
                str = res.ToString();
            }
            else if (typeof(REDIS).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<REDIS>.Parse(str);
                object res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray);
                str = res.ToString();
            }
            else if (typeof(ModelEF).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<ModelEF>.Parse(str);
                object res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray);
                str = res.ToString();
            }
            else if (typeof(YunConvertor).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunConvertor>.Parse(str);
                object res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray);
                str =JSON.ToJson(res);
                contentType = CONST.application_json;
            }
            else if (typeof(YunFile).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunFile>.Parse(str);
                object res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray);
                str = res.ToString();
            }
            else if (typeof(YunDocument).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunDocument>.Parse(str);
                object res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray);
                str = res.ToString();
            }
            else if (typeof(YunSpider).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunSpider>.Parse(str);
                RES res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray) as RES;
                str = res.ToJson();
                contentType= CONST.application_json;
            }
            else if (typeof(YunRelation).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunRelation>.Parse(str);
                RES res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray) as RES;
                str = res.ToJson();
                contentType = CONST.application_json;
            }
            else if (typeof(MAIL).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<MAIL>.Parse(str);
                RES res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray) as RES;
                str = res.ToJson();
                contentType = CONST.application_json;
            }
            else if (typeof(YunQueue).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunQueue>.Parse(str);
                RES res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray) as RES;
                str = res.ToJson();
                contentType = CONST.application_json;
            }
            else if (typeof(YunOrder).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunOrder>.Parse(str);
                RES res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray) as RES;
                str = res.ToJson();
                contentType = CONST.application_json;
            }
            context.Response.ContentType = contentType;
            context.Response.Write(str);
        }


        #region WebSocket处理

        private static List<WebSocket> clientSockList = new List<WebSocket>();
        
        
        /// <summary>
        /// WebSocket处理
        /// </summary>
        /// <param name="context"></param>
        public void WebSocketProc(HttpContext context)
        {
            if (null != context && context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(async p =>
                {
                    var socket = p.WebSocket;
                    clientSockList.Add(socket);
                    //进入一个无限循环，当web socket close是循环结束
                    while (true)
                    {
                        var buffer = new ArraySegment<byte>(new byte[1024]);
                        var receivedResult = await socket.ReceiveAsync(buffer, CancellationToken.None);//对web socket进行异步接收数据
                        if (receivedResult.MessageType == WebSocketMessageType.Close)
                        {
                            await socket.CloseAsync(WebSocketCloseStatus.Empty, string.Empty, CancellationToken.None);//如果client发起close请求，对client进行ack
                            break;
                        }

                        if (socket.State == System.Net.WebSockets.WebSocketState.Open)
                        {
                            string recvMsg = Encoding.UTF8.GetString(buffer.Array, 0, receivedResult.Count) + "来自服务器"+DateTime.Now;
                            var recvBytes = Encoding.UTF8.GetBytes(recvMsg);
                            var sendBuffer = new ArraySegment<byte>(recvBytes);

                            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
                        }
                    }
                });
            }
        }
        #endregion

        #region 文件处理

        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}