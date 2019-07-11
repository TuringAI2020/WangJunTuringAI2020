namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunFormTemplate")]
    public partial class YunFormTemplate
    {
        public Guid ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? Status { get; set; }
    }
}
