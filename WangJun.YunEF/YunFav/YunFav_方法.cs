namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [NotMapped]
    public partial class YunFav : YunForm
    {
        public new static YunFav Parse(string jsonString)
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
            this.ServiceType = (int)ENUM.ServiceType.���ղ�;

            var res = RES.New;
            var db = ModelEF.GetInst();
            var form = YunForm.Parse(this.ToJson());
            db.YunForms.Add(form);
            res.DATA = db.SaveChanges();
            return res;
        }

        public override RES SaveToTask()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunQueues.Add(new YunQueue { DATA = this.ToJson(), GroupName = Enum.GetName(typeof(ENUM.���з�������), ENUM.���з�������.YunFav������), Status = (int)ENUM.TaskStatus.������ });
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



    }
}
