namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
 
    public partial class YunFav:YunForm
    {
        public static YunFav Parse(string jsonString) {
            var inst = JSON.ToObject<YunFav>(jsonString);
            return inst;
        }
         

        public override RES Save() {

            if (Guid.Empty == this.ID) {
                this.ID = Guid.NewGuid();
            }
        ;this.ServiceType = (int)ENUM.ServiceType.���ղ�;

            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunForm.Add(this);
            db.SaveChanges();
            return res;
        }

        public  override RES SaveToTask()
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunQueue.Add(new YunQueue { DATA = this.ToJson(), GroupName = Enum.GetName(typeof(ENUM.���з�������),ENUM.���з�������.YunFav������), Status =(int)ENUM.TaskStatus.������});
            var resCode = db.SaveChanges();
            return res;
        }


    }
}
