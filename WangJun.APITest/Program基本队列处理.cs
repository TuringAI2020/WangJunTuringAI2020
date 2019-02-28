using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.APITest
{
    class Program
    {
        static void Main(string[] args)
        {

            var allChar = HANZI.GetAll();
            ///创建1000个商品
            for (int k = 0; k < 10000; k++)
            {
                var res = YunCommodityService.GetInst().Save(JSON.ToJson(new YunCommodity { ID=Guid.NewGuid(), ValueS01 = allChar.Substring(3+k % 3000, 1+k % 20), CreatorID=Guid.NewGuid(), CreatorName=allChar.Substring(k,k%4) }));
                YunCommodityService.GetInst().OnShelves((res.DATA as YunForm).ID.ToString());
                Console.WriteLine(k);
            }
            Console.ReadKey();
        }
    }
} 
