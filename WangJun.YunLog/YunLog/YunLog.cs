using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.Yun
{
    public class YunLog
    {
        public RES Save(string json)
        {
            try
            {
                var logItem = JSON.ToObject<ALog>(json);
                var db = ModelEF.GetInst();
                db.ALogs.Add(logItem);
                db.SaveChangesAsync();
                return RES.OK();
            }
            catch (Exception e)
            {
                return RES.FAIL(e.Message);
            }
        }


    }
}
