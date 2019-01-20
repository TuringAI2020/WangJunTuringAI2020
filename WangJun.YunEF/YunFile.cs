namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunFile")]
    public partial class YunFile
    {
        public Guid ID { get; set; }

        public byte[] Data { get; set; }
    }
}
