﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public class WJ
    {
        public virtual string ToJson() {
            var res = JSON.ToJson(this);
            return res;
        }
    }
}