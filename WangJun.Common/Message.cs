using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.Common
{
    public class ReqMsg<T>
    {
        public string TargetClass { get; set; }
        public string Method { get; set; }
        public bool IsStaticClass { get; set; }
        public bool IsStaticMethod { get; set; }
        public T Param { get; set; }

        public static ReqMsg<T> Parse(string input) {
            var inst = JSON.ToObject<ReqMsg<T>>(input);
            return inst;
        }
    }
}
