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
        public static string NewOrderID
        {
            get
            {
                var id = string.Format("{0}",DateTime.Now.ToString("yyyyMMddhhmmssfff"));

                return id;
            }
        }
    }
}
