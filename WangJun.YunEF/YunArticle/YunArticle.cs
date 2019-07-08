namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
     
    public partial class YunArticle
    {
        #region ����һ���ĵ�
        /// <summary>
        /// ����һ���ĵ�
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

        #region ��url�б���һ��ԭʼ����
        /// <summary>
        /// ��url�б���һ��ԭʼ����
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
                inst.Status = (int)ENUM.ʵ��״̬.������;
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
