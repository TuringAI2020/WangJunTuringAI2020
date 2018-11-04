namespace WangJun.Yun
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

        [Required]
        public string DATA { get; set; }

        [Required]
        [StringLength(500)]
        public string GroupName { get; set; }

        public int Status { get; set; }
    }
}
