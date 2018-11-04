using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.YunMessage
{
    /// <summary>
    /// 消息包
    /// </summary>
    public class WJMessage
    {
        public object Header { get; set; }

        public string Body { get; set; }
    }
}
