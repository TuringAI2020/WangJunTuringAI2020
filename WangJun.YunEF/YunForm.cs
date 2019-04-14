namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunForm")]
    public partial class YunForm
    {
        public Guid ID { get; set; }

        public int? Status { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? FormType { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public string ValueS01 { get; set; }

        public string ValueS02 { get; set; }

        public string ValueS03 { get; set; }

        public Guid? MD5 { get; set; }

        public int? ValueI01 { get; set; }

        public int? ValueI02 { get; set; }

        public DateTime? UpdateTime { get; set; }

        public Guid? CreatorID { get; set; }

        public Guid? UpdaterID { get; set; }

        public Guid? SourceID { get; set; }

        public Guid? PermissionGroupID { get; set; }

        public byte[] BinData { get; set; }

        public int? ValueI03 { get; set; }

        public int? ValueI04 { get; set; }

        public Guid? ParentNodeID { get; set; }
    }
}
