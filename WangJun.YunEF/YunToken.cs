namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunToken")]
    public partial class YunToken
    {
        public Guid ID { get; set; }

        [StringLength(50)]
        public string AppID { get; set; }

        [StringLength(500)]
        public string AppSecret { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(500)]
        public string Token { get; set; }

        public DateTime TokenExpireTime { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? Status { get; set; }

        public int? Type { get; set; }

        [StringLength(10)]
        public string LoginID { get; set; }
    }
}
