using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.APITest
{
    public static class 七彩福星
    {
        public static void 计算() {
            for (int k = 0; k < 1000*10000; k++)
            {
                var guidArr = Guid.NewGuid().ToByteArray();
                var val = Math.Abs(BitConverter.ToInt32(guidArr, (k + 4) % 12));
                if (400 * 10000 <= val && val <= 9999999)
                {
                    Console.WriteLine(val);
                }
 
            }
         }
    }
}
