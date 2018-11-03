using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Common;

namespace WangJun.Yun
{
    /// <summary>
    /// 基本队列
    /// </summary>
    public class WJQueue
    {
        protected static Dictionary<string, WJQueue> coreData = new Dictionary<string, WJQueue>();
        public Queue<string> jsonQueueData = new Queue<string>();
        public static WJQueue CreateInstance(string name="") {
            var inst = new WJQueue();
            if (!coreData.ContainsKey(name)) {
                coreData.Add(name, inst);
            }
            return inst;
        }

        public static WJQueue GetQueue(string name) {
            if (coreData.ContainsKey(name))
            {
                return coreData[name];
            }
            else {
                return WJQueue.CreateInstance(name);
            }
        }
        /// <summary>
        /// 入队
        /// </summary>
        /// <returns></returns>
        public RES Enqueue(string json) {
            var res = RES.New; 
            this.jsonQueueData.Enqueue(json);
            return res.SetAsOK() ;
        }

        public RES Dequeue() {
            var res = RES.New;
             this.jsonQueueData.Dequeue();
            return res.SetAsOK();
        }

        public RES Clear() {
            var res = RES.New;
            this.jsonQueueData.Clear();
            return res.SetAsOK();
        }


    }
}
