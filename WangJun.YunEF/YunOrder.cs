namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunOrder")]
    public partial class YunOrder
    {
        public Guid ID { get; set; }

        public Guid? OrderID { get; set; }

        public Guid? GroupID { get; set; }

        public Guid? GoodsID { get; set; }

        public Guid? SourceID { get; set; }

        public int? Status { get; set; }

        public int? Count { get; set; }

        public Guid? PayID { get; set; }

        public Guid? ConsumerID { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
