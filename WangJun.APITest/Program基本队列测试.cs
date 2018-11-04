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
            var db = new ModelEF();

            for (int k = 0; k < 100; k++)
            {
                var q = WJQueue.GetQueue("汪俊" + k % 100);
                var res = q.Enqueue(new string('J', 2048));
                var data = new YunDocument { Title = string.Format("汪俊文档{0}", k), Content = new string('J', 512), ID = Guid.NewGuid(), CreateTime = DateTime.Now };
                var ef = db.YunQueue.Add(new YunQueue() { DATA = data.ToJson(), GroupName = "汪俊" + k % 5, Status = 0 });
                db.SaveChanges();
                Console.WriteLine(k);
            }

    }
}
 
     
}
