using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
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

        /// <summary>
        /// 成功结果
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public RES SetAsOK(object data = null, string msg = "成功")
        {
            this.SUCCESS = true;
            if (null != data)
            {
                this.DATA = data;
            }
            this.MESSAGE = msg;
            return this;
        }

        /// <summary>
        /// 失败结果
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public RES SetAsFail(object data = null, string msg = "失败")
        {
            this.SUCCESS = false;
            this.DATA = data;
            this.MESSAGE = msg;
            return this;
        }

        /// <summary>
        /// 转换为JSON
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JSON.ToJson(this);
        }
    }

}
