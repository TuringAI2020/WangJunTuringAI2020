using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;
using WangJun.YunEF;

namespace WangJun.Yun
{
    public class WJQueueProcessor
    {
        public void Proc() {
            var db = new ModelEF();


            while (0 < db.YunQueue.Count())
            {
                var res = db.Database.SqlQuery<YunQueue>("DEQUEUE @GroupName", new SqlParameter[] {new SqlParameter("@GroupName",string.Empty)}).ToList();
                //var minID = db.YunQueue.Min(p => p.ID);
                //var ef = db.YunQueue.First(p => p.ID == minID);
                //db.YunQueue.Remove(ef);
                //db.SaveChanges();
                Console.WriteLine("已处理" + DateTime.Now);
            }

                

       
        }
    }
}
