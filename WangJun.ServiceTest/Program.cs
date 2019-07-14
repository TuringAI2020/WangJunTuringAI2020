using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //new YunToDo().SaveToDo("","第一个","测试赛");
            new YunJob().StartJob("作业名称", "参数");
            Console.ReadKey();
        }
    }
}
