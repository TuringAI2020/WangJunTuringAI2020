namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class YunFav : YunForm
    {
        public static YunFav Parse(string jsonString)
        {

            var inst = JSON.ToObject<YunFav>(jsonString);

            return inst;
        }


        public override RES Save()
        {

            if (Guid.Empty == this.ID)
            {
                this.ID = Guid.NewGuid();
                this.CreateTime = DateTime.Now;
            }
            this.ServiceType = (int)ENUM.ServiceType.云收藏;

            var res = RES.New;
            var db = ModelEF.GetInst();
            var form = YunForm.Parse(this.ToJson());
            db.YunForm.Add(form);
            res.DATA = db.SaveChanges();
            return res;
        }

        public override RES SaveToTask()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunQueue.Add(new YunQueue { DATA = this.ToJson(), GroupName = Enum.GetName(typeof(ENUM.队列分组名称), ENUM.队列分组名称.YunFav待处理), Status = (int)ENUM.TaskStatus.待处理 });
            var resCode = db.SaveChanges();
            return res;
        }


        public RES SaveFromUrl()
        {
            var res = RES.New;
            var http = HTTP.GetInst(this.Url);
            http.AcceptEncoding = this.ValueA01;
            var html = http.GET();
            this.ContentType = "html";
            this.Content = html;
            this.Save();
            return res.SetAsOK();
        }

        public RES LoadList(string filter) {
            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunForm.
            return res.SetAsOK();
        }

    }
}
