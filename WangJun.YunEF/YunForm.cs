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

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(2048)]
        public string SourceUrl { get; set; }

        public string Html { get; set; }

        public string PlainText { get; set; }

        public string SummaryText { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string StatusText { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public Guid? CreatorID { get; set; }

        [StringLength(50)]
        public string CreatorName { get; set; }

        public Guid? UpdaterID { get; set; }

        [StringLength(50)]
        public string UpdaterName { get; set; }

        public Guid? SourceID { get; set; }

        [StringLength(50)]
        public string SourceName { get; set; }

        public Guid? PermissionGroupID { get; set; }

        [StringLength(50)]
        public string PermissionGroupName { get; set; }

        public byte[] BinData { get; set; }

        public Guid? MD5 { get; set; }

        public int? FormType { get; set; }

        [StringLength(50)]
        public string FormTypeName { get; set; }
    }
}
