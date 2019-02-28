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

        /// <summary>
        /// 同步保存一个对象
        /// </summary>
        /// <returns></returns>
        public virtual RES Save()
        {
            var res = RES.New;

            if (Guid.Empty == this.ID) {
                this.ID = Guid.NewGuid();
                this.CreateTime = DateTime.Now;
            }
;

            var db = ModelEF.GetInst();
            db.YunForms.Add(this);
            db.SaveChanges();
            return res;
        } 

        public RES Remove()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            var data_db = db.YunForms.FirstOrDefault(p => p.ID == this.ID);
            db.YunForms.Remove(data_db);
            db.SaveChanges();
            return res.SetAsOK();
        }

        public RES LoadList()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();

            var query = from item in db.YunForms  select item;
            res.DATA = query.ToList();
            return res.SetAsOK();
        }

        public void InitialDateTime()
        {
            if (!this.CreateTime.HasValue)
            {
                this.CreateTime = DateTime.Now;
            }

            if (!this.UpdateTime.HasValue)
            {
                this.UpdateTime = this.CreateTime;
            }

        }

    }
}
