namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
     
    public partial class YunQueue
    {
        public RES SaveToTask(WJ wj)
        {
            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunQueues.Add(new YunQueue { DATA = wj.ToJson(), GroupName = Enum.GetName(typeof(ENUM.���з�������), ENUM.���з�������.YunForm������), Status = (int)ENUM.TaskStatus.������ });
            var resCode = db.SaveChanges();
            return res;
        }
    }
}
