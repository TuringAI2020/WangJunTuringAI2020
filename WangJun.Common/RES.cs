using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Common
{
    public class RES
    {
        public bool SUCCESS { get; set; }

        public int CODE { get; set; }

        public string MESSAGE { get; set; }

        public object DATA { get; set; }

        public static RES New
        {
            get
            {
                var inst = new RES();
                return inst;
            }
        }

        public RES SetAsOK() {
            this.SUCCESS = true;
            return this;
        }
    }

}
