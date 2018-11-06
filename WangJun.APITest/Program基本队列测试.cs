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

            for (int k = 0; k < 1000; k++)
            {
                //var q = WJQueue.GetQueue("汪俊" + k % 100);
                //var res = q.Enqueue(new string('J', 2048));
                 db.YunQueue.Add(new YunQueue() { DATA = JSON.ToJson(new YunForm { ID=Guid.NewGuid() , CreateTime=DateTime.Now, KeyA01="姓名" , ValueA01="汪俊"+k,ValueB01=new Random().Next(20,80) , KeyB01="年龄" , ServiceType=1   }), GroupName = "云表单", Status = 0 });
                 db.YunQueue.Add(new YunQueue() { DATA = JSON.ToJson(new YunComment { ID = Guid.NewGuid(), CreateTime = DateTime.Now, ServiceType = 1, ParentID = Guid.NewGuid() }), GroupName = "云评论", Status = 0 });
                 db.YunQueue.Add(new YunQueue() { DATA = JSON.ToJson(new YunDocument { ID = Guid.NewGuid(), CreateTime = DateTime.Now, Title = "文章名"+k, Content = new string('A',512), ServiceType = 1 }), GroupName = "云文档", Status = 0 });

                db.SaveChanges();
                Console.WriteLine(k);
            }

    }
}
 
     
}
