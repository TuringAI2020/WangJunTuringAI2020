namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunCategory")]
    public partial class YunCategory
    {
        public Guid? ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ParentName { get; set; }

        [StringLength(50)]
        public string RootName { get; set; }

        [Key]
        public Guid ParentID { get; set; }

        public Guid? RootID { get; set; }

        public Guid? PermissionGroupID { get; set; }

        [StringLength(50)]
        public string PermissionGroupName { get; set; }

        public int? ServiceType { get; set; }
    }
}
