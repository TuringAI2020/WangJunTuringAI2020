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
            new YunToDo().SaveToDo("","第一个","测试赛");
            
        }
    }
}
