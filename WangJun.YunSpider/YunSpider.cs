using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.Yun
{
    /// <summary>
    /// 云蜘蛛
    /// </summary>
    public class YunSpider
    {
        public static YunSpider GetInst() {
            var inst = new YunSpider();
            return inst;
        }
        /// <summary>
        /// 获取头条的原始文章
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetTouTiaoArticle(string url)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            headers.Add("accept-encoding", "gzip, deflate, br");
            headers.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8");
            headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36");

            var res = HTTP.Get(url, headers);
            return res;

        }

        #region 将头条文章保存到数据库中
        /// <summary>
        /// 将头条文章保存到数据库中
        /// </summary>
        /// <param name="ur"></param>
        /// <returns></returns>
        public RES SaveTouTiaoArticleToDB(string url)
        {
            var res = RES.New;
            var article = YunSpider.GetInst().GetTouTiaoArticle(url);
            res = new YunForm { Html = article,    SourceUrl = url, SourceName = CONST.今日头条 }.Save();
            return res.SetAsOK(article);
        }
        #endregion
    }
}
