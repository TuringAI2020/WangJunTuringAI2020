namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class YunOrder
    {
        /// <summary>
        /// 关联的消费码
        /// </summary>
        [NotMapped]
        public List<YunQRCode> QRCodeList { get; set; }
    }
}
