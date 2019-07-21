namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunFormInst")]
    public partial class YunFormInst
    {
        public Guid ID { get; set; }

        public Guid? TemplateID { get; set; }

        [StringLength(50)]
        public string TemplateName { get; set; }

        public Guid? PropertyID { get; set; }

        [StringLength(50)]
        public string PropertyName { get; set; }

        public int? PropertySort { get; set; }

        public string PropertyValueString { get; set; }

        public long? PropertyValueLong { get; set; }

        public DateTime? PropertyValueDateTime { get; set; }

        public decimal? PropertyValueDecimal { get; set; }

        public int? PropertyType { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? Status { get; set; }

        public Guid? InstanceID { get; set; }

        public Guid? CategoryID { get; set; }
    }
}
