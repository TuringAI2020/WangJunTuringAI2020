﻿using System;
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

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int PageCount
        {
            get
            {
                if (0 < PageSize)
                {
                    return (0 == TotalCount % PageSize) ? TotalCount / PageSize : 1 + (TotalCount / PageSize);
                }
                return 0;
            }
        }

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
        /// 失败结果
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static RES FAIL(object data = null, string msg = "失败")
        {
            var res = new RES();
            res.SUCCESS = false;
            res.DATA = data;
            res.MESSAGE = msg;
            return res;
        }

        /// <summary>
        /// 成功结果
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static RES OK(object data = null, string msg = "成功")
        {
            var res = new RES();
            res.SUCCESS = true;
            res.DATA = data;
            res.MESSAGE = msg;
            return res;
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
