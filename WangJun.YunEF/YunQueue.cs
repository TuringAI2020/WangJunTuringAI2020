namespace WangJun.YunEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunQueue")]
    public partial class YunQueue
    {
        public int ID { get; set; }

        public string DATA { get; set; }

        [StringLength(500)]
        public string GroupName { get; set; }

        public int? Status { get; set; }
    }
}
