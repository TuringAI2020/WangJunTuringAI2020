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
            db.YunQueues.Add(new YunQueue { DATA = wj.ToJson(), GroupName = Enum.GetName(typeof(ENUM.队列分组名称), ENUM.队列分组名称.YunForm待处理), Status = (int)ENUM.TaskStatus.待处理 });
            var resCode = db.SaveChanges();
            return res;
        }
    }
}
