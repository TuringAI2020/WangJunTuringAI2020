namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class YunDocument
    {
        public static YunDocument Parse(string jsonString) {
            var inst = JSON.ToObject<YunDocument>(jsonString);
            return inst;
        }

        public string ToJson() {
            return JSON.ToJson(this);
        }

        public RES Save() {
            var res = RES.New;
            var db = ModelEF.GetInst();
            if (this.ID == Guid.Empty) {
                this.ID = Guid.NewGuid();
            }
            db.YunDocuments.Add(this);
            db.SaveChanges();
            return res;
        }

        public RES Remove() {
            var res = RES.New;
            var db = ModelEF.GetInst();
            var data_db = db.YunDocuments.FirstOrDefault(p=>p.ID == this.ID);
            db.YunDocuments.Remove(data_db);
            db.SaveChanges();
            return res.SetAsOK();
        }

        public RES Load()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            var data_db = db.YunDocuments.FirstOrDefault(p => p.ID == this.ID);
            db.YunDocuments.Remove(data_db);
            db.SaveChanges();
            return res.SetAsOK();
        }
    }
}
