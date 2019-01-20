namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class YunFile
    {
        public virtual RES SaveToSQLServer()
        {

            if (Guid.Empty == this.ID)
            {
                this.ID = Guid.NewGuid();
            }
            HttpPostedFile file = HttpContext.Current.Request.Files[0];

  var bytes = new byte[(int)file.InputStream.Length];
            file.InputStream.Read(bytes, 0, bytes.Length);

            this.Data = bytes;
            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunFiles.Add(this);
            db.SaveChanges();
            return res;
        }
    }
}
