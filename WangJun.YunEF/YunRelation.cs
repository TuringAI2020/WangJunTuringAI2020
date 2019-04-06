namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunRelation")]
    public partial class YunRelation
    {
        public Guid ID { get; set; }

        public Guid? RootID { get; set; }

        public Guid? ParentID { get; set; }

        [StringLength(10)]
        public string PermissionGroupID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Status { get; set; }

        public int? Type { get; set; }

        public Guid? CreatorID { get; set; }

        public Guid? UpdaterID { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
