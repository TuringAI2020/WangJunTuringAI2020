using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WangJun.SelfHostAPI;
using WangJun.Yun;

namespace WangJun.APITest
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 微信测试
            {
                var inst = WeChatAPI.GetInstance();
                //#region 基础支持
                //var token = inst.GetToken();
                //Console.WriteLine("获取Token {0}",token);

                //var returnUrl = inst.GetWeChatUrl();
                //Console.WriteLine("获取跳转链接 {0}", returnUrl);

                //#endregion  

                Console.WriteLine($"获取微信服务器IP地址 -" + inst.GetWeChatServerIpList());
            }

            #endregion

            Console.WriteLine("全部结束");
            Console.ReadKey();
            return;
        }
    }
} 
