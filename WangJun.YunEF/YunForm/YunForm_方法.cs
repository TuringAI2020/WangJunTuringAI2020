namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
 
    public partial class YunForm
    {
        public static YunForm Parse(string jsonString) {
            var inst = JSON.ToObject<YunForm>(jsonString);
            return inst;
        }

        public string ToJson() {
            return JSON.ToJson(this);
        }

        public RES Save() {
            var res = RES.New;
            var db = new ModelEF();
            db.YunForm.Add(this);
            db.SaveChanges();
            return res;
        }
    }
}
