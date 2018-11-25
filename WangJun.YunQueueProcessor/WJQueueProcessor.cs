using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.Yun
{
    public class WJQueueProcessor
    {
        class GroupByRes {
           public string GroupName{get;set;}
            public int Count { get; set; }
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="groupName"></param>
        public void Proc(string groupName) {
            var db = new ModelEF();


            while (0 < db.YunQueue.Count())
            {
                var res = db.Database.SqlQuery<YunQueue>("DEQUEUE @GroupName", new SqlParameter[] {new SqlParameter("@GroupName", groupName) }).ToList();
                db.Database.Connection.Close();
                if (groupName == "云文档")
                {
                    foreach (var item in res)
                    {
                        var data = YunDocument.Parse(item.DATA);
                        data.Save();
                    }
                }
                else if ( Enum.GetName( typeof(ENUM.队列分组名称), ENUM.队列分组名称.YunForm待处理)== groupName) {
                    foreach (var item in res)
                    {
                        var data = YunForm.Parse(item.DATA);
                        data.Save();
                    }
                }
                if (groupName == "云评论")
                {
                    foreach (var item in res)
                    {
                        var data = YunDocument.Parse(item.DATA);
                        data.Save();
                    }
                }

                Console.WriteLine("已处理" + DateTime.Now);
            }
        }

        /// <summary>
        /// 自动化处理
        /// </summary>
        public void AutoProc() {
            var db = new ModelEF();

            var q =( from p in db.YunQueue group p by p.GroupName into g select new GroupByRes() { GroupName= g.Key,  Count=g.Count(p => p.Status == 0) }).ToList();
            foreach (var item in q)
            { 
                Task.Run(()=> {
                    Console.WriteLine(Task.CurrentId);
                    this.Proc(item.GroupName);

                });
            }
        }
    }
}
