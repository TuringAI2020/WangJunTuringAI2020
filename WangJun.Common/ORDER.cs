using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    /// <summary>
    /// 
    /// </summary>
    public static class ORDER
    {
        /// <summary>
        /// 获取一个新订单号
        /// </summary>
        public static string NewOrderID
        {
            get
            {
                var timePrefix = DateTime.Now.ToString("yyyyMMddhhmmss");
                var id = string.Format("{0}{1}", timePrefix, Guid.NewGuid());
                var md5_8 = MD5.ToMD5_16(id).Substring(4,4);
                var intSubfix = BitConverter.ToUInt32(Encoding.ASCII.GetBytes(md5_8), 0);
                return string.Format("{0}{1:d10}", timePrefix, intSubfix);
            }
        }

        /// <summary>
        /// 用订单号创建一个Key
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static Guid OrderIDToGuid(string orderId)
        {
            if (!string.IsNullOrWhiteSpace(orderId))
            {
                var bytes = MD5.ToMD5(orderId);
                return new Guid(bytes);
            }
            return Guid.Empty;

        }

        /// <summary>
        /// 创建一个新的消费码
        /// </summary>
        public static string NewQrCode(string)
        {
            var 
        }
    }
}
