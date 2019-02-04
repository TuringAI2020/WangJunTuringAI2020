using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    /// <summary>
    /// 汪俊云队列
    /// </summary>
    public class YunQueue
    {
        /// <summary>
        /// 获取一个队列实例
        /// </summary>
        /// <returns></returns>
        public static YunQueue GetInst(string queueName="")
        {
            var inst = new YunQueue();
            return inst;
        }

        /// <summary>
        /// 入队列
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public RES Enqueue(string queueName,string data)
        {
            var res = RES.New;
            var db = REDIS.CreateInstance();
            res = db.Enqueue(queueName, data);
            return res.SetAsOK();
        }

        /// <summary>
        /// 出队列
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public RES Dequeue(string queueName)
        {
            var res = RES.New;
            var db = REDIS.CreateInstance();
            res = db.Dequeue(queueName);
            return res.SetAsOK();
        }
    }
}
