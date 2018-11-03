using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;
using WangJun.YunEF;

namespace WangJun.APITest
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ModelEF();

            for (int k = 0; k < 100 * 10000; k++)
            {
                var q = WJQueue.GetQueue("汪俊" + k % 100);
                var res = q.Enqueue(new string('J', 2048));
                var ef = db.YunQueue.Add(new YunQueue() { DATA = new string('J', 2048), GroupName = "汪俊" + k % 100, Status = 0 });
                db.SaveChanges();
                Console.WriteLine(k);
            }

    }
}
 
     
}
