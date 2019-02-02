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

        public Guid? GroupID { get; set; }

        [StringLength(50)]
        public string GroupName { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Type { get; set; }

        [StringLength(50)]
        public string TypeName { get; set; }

        public int? Sort01 { get; set; }

        [StringLength(50)]
        public string KeyA01 { get; set; }

        public int? ValueA01 { get; set; }
    }
}
