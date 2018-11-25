using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public partial class ModelEF : DbContext
    {
        public static ModelEF GetInst() {
            var inst = new ModelEF();
            return inst;
        }
    }
}
