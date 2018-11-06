namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunService")]
    public partial class YunService
    {
        public Guid ID { get; set; }

        public int? ServiceType { get; set; }

        [StringLength(10)]
        public string ServiceName { get; set; }
    }
}
