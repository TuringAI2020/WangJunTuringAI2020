using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.RedisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();
            IServer svr = redis.GetServer("localhost", 6379);
            db.StringSet("WangJun", "汪俊");
            Console.WriteLine(db.StringGet("WangJun"));
            Console.WriteLine(db.KeyExists("WangJun"));
            Console.WriteLine(db.KeyExists("WangJun2"));
            
            for (int k = 0; k < 10; k++)
            {
                Console.WriteLine(db.StringIncrement("Count", 0.7));
                //Console.ReadKey();
            }
            Console.WriteLine(db.KeyDelete("WangJun"));
            Console.WriteLine(db.KeyExists("WangJun"));
            Console.WriteLine(redis.GetStatus());
            for (int k = 0; k < 20; k++)
            {
                Console.WriteLine(db.ListLeftPush("list", "汪俊" + k));
            }
            Console.WriteLine(db.ListLength("list"));

            for (int k = 0; k < 20; k++)
            {
                Console.WriteLine(db.ListLeftPop("list"));
            }

            Console.WriteLine(db.SetAdd("WangJun11", "汪俊11"));
            Console.WriteLine(db.SetAdd("WangJun11", "汪俊12"));
            Console.WriteLine(db.SetLength("WangJun11"));
            db.SetMembers("WangJun11").ToList().ForEach((p)=> {
                Console.WriteLine(p);
            });
            db.SortedSetAdd

            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
