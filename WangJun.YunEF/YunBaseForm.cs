namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunBaseForm")]
    public partial class YunBaseForm
    {
        public Guid ID { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public int Status { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(50)]
        public string AppID { get; set; }

        public Guid CreatorID { get; set; }

        public Guid PermissionID { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public Guid CategoryID { get; set; }

        public Guid? NextTaskID { get; set; }

        public Guid? ExtensionID { get; set; }
    }
}
