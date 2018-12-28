using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.Yun
{
    /// <summary>
    /// Redis服务
    /// </summary>
    public partial class REDIS
    {
        #region 队列操作
        ///队列是否存在
        ///入队
        ///出队
        ///清理队列
        public RES ExsitQueue(string queueName) {
            return this.HasKey(queueName);
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public RES Enqueue(string queueName, object value)
        {
            var res = RES.New;
            var db = this.GetRedis();
            res.DATA = db.ListRightPush(queueName, JSON.ToJson(value));
            return res.SetAsOK();
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public RES Dequeue(string queueName)
        {
            var res = RES.New;

            var db = this.GetRedis();
            res.DATA = db.ListLeftPop(queueName);
            return res;
        }

        /// <summary>
        /// 队列长度
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public RES QueueLength(string queueName) {
            var res = RES.New;

            var db = this.GetRedis();
            res.DATA = db.ListLength(queueName);
            return res;
        }


        /// <summary>
        /// 清空队列
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public RES ClearQueue(string queueName) {
            return this.RemoveFromDB(queueName);
        }
        #endregion


    }
}
