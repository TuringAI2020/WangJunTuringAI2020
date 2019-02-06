namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunQRCode")]
    public partial class YunQRCode
    {
        public Guid ID { get; set; }

        [StringLength(50)]
        public string QRCode { get; set; }

        public int? Status { get; set; }

        public Guid? OrderID { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? CheckInStartTime { get; set; }

        public DateTime? CheckInEndTime { get; set; }

        public DateTime? ExpiryTime { get; set; }

        public int? QRCodeType { get; set; }
    }
}
