﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public static class ENUM
    {

        public enum TaskStatus {
            待处理 = 0,


            正常处理中 = 2,

             超时处理中 = 3,

             首次处理出错 = -1,

             多次处理出错 = -2,
             处理失败 = -10000,

             处理完毕 = 1
        }

        public enum 队列分组名称 {
            YunForm待处理=0x0001,
        }
    }
}