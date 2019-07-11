namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunFormRow")]
    public partial class YunFormRow
    {
        public Guid ID { get; set; }

        public Guid? TemplateID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ValueType { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? Status { get; set; }
    }
}
