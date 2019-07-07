namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunArticle")]
    public partial class YunArticle
    {
        public Guid ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? Status { get; set; }

        [StringLength(2048)]
        public string Url { get; set; }
    }
}
