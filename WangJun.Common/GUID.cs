using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public static class GUID
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsGuid(string input)
        {
            var guid = Guid.Empty;
            return Guid.TryParse(input, out guid);
        }
    }
}
