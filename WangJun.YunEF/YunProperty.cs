namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunProperty")]
    public partial class YunProperty
    {
        public Guid ID { get; set; }

        public Guid? EntityID { get; set; }

        public int? ReadCount { get; set; }

        public int? FollowCount { get; set; }

        public int? LikeCount { get; set; }

        public int? FavCount { get; set; }

        public int? Status { get; set; }
    }
}
