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

            
            for (int k = 0; k < 10000; k++)
            {var id = ORDER.NewOrderID;
                Console.WriteLine(id);
            }
            Console.ReadKey();
        }
    }
} 
