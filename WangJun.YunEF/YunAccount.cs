namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunAccount")]
    public partial class YunAccount
    {
        public Guid ID { get; set; }

        [StringLength(50)]
        public string LoginID { get; set; }

        public Guid? MainLoginID { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
