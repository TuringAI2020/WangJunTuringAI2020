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
            var res = HTTP.POST("http://localhost:6003/LogAPI.ashx", null, JSON.ToJson(new
            {
                TargetClass = "YunLog",
                Method = "Save",
                Param = new { },
                InputParamArray = new string[] {  JSON.ToJson(new { Remark="Test111"}) }
            }));
            Console.ReadKey();
        }
    }
}
