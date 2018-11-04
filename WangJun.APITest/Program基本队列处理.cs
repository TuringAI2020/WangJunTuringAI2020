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
            WJQueueProcessor processor = new WJQueueProcessor();
            processor.AutoProc(); 
            Console.ReadKey();
        }
    }
} 
