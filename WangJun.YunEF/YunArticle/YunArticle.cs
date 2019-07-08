namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
     
    public partial class YunArticle
    {
        #region 保存一个文档
        /// <summary>
        /// 保存一个文档
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>

        public RES SaveArticle(string title, string content,int status=0)
        {
            try
            {

                var inst = new YunArticle();
                inst.ID = Guid.NewGuid();
                inst.Status = status;
                inst.Title = title;
                inst.Content = content;
                var db = ModelEF.GetInst();
                db.YunArticles.Add(inst);
                db.SaveChangesAsync();
                return RES.OK(inst);
            }
            catch (Exception ex)
            {
                return RES.FAIL();
            }
        }
        #endregion

        #region 从url中保存一个原始文章
        /// <summary>
        /// 从url中保存一个原始文章
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public RES SaveArticleFromUrl(string url,string headers)
        {
            try
            {
                var content = HTTP.Get(url, string.IsNullOrWhiteSpace(headers) ? null: JSON.ToObject<Dictionary<string, string>>(headers));
                var inst = new YunArticle();
                inst.ID = Guid.NewGuid();
                inst.Status = (int)ENUM.实体状态.不可用;
                inst.Title = null;
                inst.Url = url;
                inst.Content = content;
                inst.CreateTime = DateTime.Now;
                inst.UpdateTime = DateTime.Now;
                var db = ModelEF.GetInst();
                db.YunArticles.Add(inst);
                db.SaveChangesAsync();
                return RES.OK(inst);
            }
            catch (Exception ex)
            {
                return RES.FAIL(ex.Message);

            }
        }
        #endregion
    }
}
