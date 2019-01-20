namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
     
    public partial class YunFile
    {
        public virtual RES Save()
        {

            if (Guid.Empty == this.ID)
            {
                this.ID = Guid.NewGuid();
            }
;

            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunFiles.Add(this);
            db.SaveChanges();
            return res;
        }
    }
}
