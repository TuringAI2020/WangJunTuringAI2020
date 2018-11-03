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
            WJQueueProcessor processor = new WJQueueProcessor();
            processor.Proc();

            Task.Run(()=> { processor.Proc(); });
            Console.ReadKey();
        }
    }
} 
