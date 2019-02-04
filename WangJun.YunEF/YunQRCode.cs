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

        [StringLength(10)]
        public string Status { get; set; }

        [StringLength(10)]
        public string OrderID { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(10)]
        public string CheckInStartTime { get; set; }

        [StringLength(10)]
        public string CheckInEndTime { get; set; }

        [StringLength(10)]
        public string ExpiryTime { get; set; }

        public int? QRCodeType { get; set; }
    }
}
