namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunComment")]
    public partial class YunComment
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [StringLength(50)]
        public string ContentType { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? Status { get; set; }

        public Guid? CreateorID { get; set; }

        [StringLength(50)]
        public string CreatorName { get; set; }

        public Guid? UpdaterID { get; set; }

        [StringLength(50)]
        public string UpdateName { get; set; }

        [StringLength(50)]
        public string SourceName { get; set; }

        [StringLength(2048)]
        public string Url { get; set; }

        public Guid? ParentID { get; set; }

        [StringLength(50)]
        public string ParentName { get; set; }

        public Guid? RootID { get; set; }

        [StringLength(50)]
        public string RootName { get; set; }

        public int? SortValue1 { get; set; }

        public int? SortValue2 { get; set; }

        public Guid? PermissionGroupID { get; set; }

        [StringLength(50)]
        public string PermissionGroupName { get; set; }

        public int? ServiceType { get; set; }

        [StringLength(50)]
        public string KeyA01 { get; set; }

        public int? ValueA01 { get; set; }

        [StringLength(50)]
        public string KeyA02 { get; set; }

        public int? ValueA02 { get; set; }

        [StringLength(50)]
        public string KeyA03 { get; set; }

        public int? ValueA03 { get; set; }
    }
}
