namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALog")]
    public partial class ALog
    {
        public int ID { get; set; }

        public DateTime? CreateTime { get; set; }

        public string Position { get; set; }

        public string Msg { get; set; }

        public string Param { get; set; }

        public string Remark { get; set; }

        public string Summary { get; set; }

        [StringLength(50)]
        public string AppID { get; set; }

        [StringLength(50)]
        public string AppName { get; set; }

        public int? TypeID { get; set; }

        [StringLength(50)]
        public string TypeName { get; set; }
    }
}
