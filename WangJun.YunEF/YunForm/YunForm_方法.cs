namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
 
    public partial class YunForm:WJ
    {
        public static YunForm Parse(string jsonString) {
            var inst = JSON.ToObject<YunForm>(jsonString);
            return inst;
        }
         

        public RES Save() {

            if (Guid.Empty == this.ID) {
                this.ID = Guid.NewGuid();
            }
;

            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunForm.Add(this);
            db.SaveChanges();
            return res;
        }

        public RES SaveToTask()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunQueue.Add(new YunQueue { DATA = this.ToJson(), GroupName = Enum.GetName(typeof(ENUM.���з�������),ENUM.���з�������.YunForm������), Status =(int)ENUM.TaskStatus.������});
            var resCode = db.SaveChanges();
            return res;
        }
    }
}
