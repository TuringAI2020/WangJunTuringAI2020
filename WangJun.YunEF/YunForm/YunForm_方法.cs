namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

 
    public partial class YunForm 
    {
        public static YunForm Parse(string jsonString) {
            var inst = JSON.ToObject<YunForm>(jsonString);
            return inst;
        }

        public virtual string ToJson()
        {
            var res = JSON.ToJson(this);
            return res;
        }

        public virtual RES Save() {

            if (Guid.Empty == this.ID) {
                this.ID = Guid.NewGuid();
            }
;

            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunForms.Add(this);
            db.SaveChanges();
            return res;
        }

        public virtual RES SaveToTask()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunQueues.Add(new YunQueue { DATA = this.ToJson(), GroupName = Enum.GetName(typeof(ENUM.队列分组名称),ENUM.队列分组名称.YunForm待处理), Status =(int)ENUM.TaskStatus.待处理});
            var resCode = db.SaveChanges();
            return res;
        }

        public RES LoadList()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();

            var query = from item in db.YunForms where 100 <= item.Content.Length select item;
            res.DATA = query.ToList();
            return res.SetAsOK();
        }
    }
}
