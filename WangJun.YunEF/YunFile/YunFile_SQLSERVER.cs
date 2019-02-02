namespace WangJun.Yun
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;


    [NotMapped]
    public partial class YunFile : YunForm
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

            this.BinData = bytes;
            var res = RES.New;
            var db = ModelEF.GetInst();
            db.YunForms.Add(this);
            db.SaveChanges();
            return res;
        }
    }
}
