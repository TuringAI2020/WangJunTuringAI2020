﻿using System;
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
    public class API : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                this.WebSocketProc(context);
            }
            else if (0 < context.Request.Files.Count)
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

        public void Execute(HttpContext context)
        {
            var length = (int)context.Request.InputStream.Length;
            var buffer = new byte[length];
            context.Request.InputStream.Read(buffer, 0, length);
            var str = Encoding.UTF8.GetString(buffer);
            var reqCheck = ReqMsg<object>.Parse(str);
            context.Response.ContentType = "text/plain";
            if (typeof(YunForm).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunForm>.Parse(str);
                reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, null);
            }
            else if (typeof(YunFav).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunFav>.Parse(str);
                var res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray);
                str = JSON.ToJson(res);
                context.Response.ContentType = "application/json";
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
                str = res.ToString();
            }
            else if (typeof(YunFile).Name == reqCheck.TargetClass)
            {
                var reqMsg = ReqMsg<YunFile>.Parse(str);
                object res = reqMsg.Param.GetType().GetMethod(reqCheck.Method).Invoke(reqMsg.Param, reqMsg.InputParamArray);
                str = res.ToString();
            }


            context.Response.Write(str);
        }

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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}