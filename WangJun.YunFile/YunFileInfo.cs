using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public class YunFileInfo
    {
        public int Blocksize { get { return 1024 * 1024 * 10; } }
        public string[] MD5Array { get; set; } 
        public string FileMD5 { get; set; }
        public string OriginFileName { get; set; }
        public string Extension { get; set; }
    }
}
