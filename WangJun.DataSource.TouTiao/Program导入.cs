using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using WangJun.Yun;

namespace WangJun.DataSource.TouTiao
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"D:\INPUT\2.txt", Encoding.UTF8).ToList();
            lines.ForEach((p) =>
            {
                try
                {
                    var arr = p.Split(new char[] { ',' });
                    if (2 <= arr.Length && arr[1].ToLower().StartsWith("http"))
                    {
                        var url = arr[1];
                        url = url.Replace("group/", "a");
                        var headers = new Dictionary<string, string>();
                        headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                        headers.Add("accept-encoding", "gzip, deflate, br");
                        headers.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8");
                        headers.Add("cache-control", "max-age=0");
                        headers.Add("referer", "https://www.toutiao.com/");
                        headers.Add("upgrade-insecure-requests", " 1");
                        headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36");

                        var res = HTTP.POST("http://localhost:6002/YunArticleAPI.ashx", null, JSON.ToJson(new
                        {
                            TargetClass = "YunArticle",
                            Method = "SaveArticleFromUrl",
                            Param = new { },
                            InputParamArray = new string[] { url, JSON.ToJson(headers) }
                        }));
                        Console.WriteLine($"已处理{url} {res}"); 
                        Thread.Sleep(new Random().Next(300, 1000));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{p}  {ex.Message}");
                }
            });

            Console.ReadKey();
        }
    }
}
