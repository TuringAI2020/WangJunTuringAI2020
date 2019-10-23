using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public class CallbackEventAgrs : EventArgs
    {
        public object DATA { get; set; }

        public string DataType { get; set; }

        public string Msg { get; set; }
    }
}
