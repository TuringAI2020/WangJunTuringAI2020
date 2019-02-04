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
        #region 列表操作
        /// <summary>
        /// 列表操作
        /// </summary>
        /// <param name="listName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public RES LoadList(string listName,int pageIndex,int pageSize,string filter)
        {
            var res = RES.New;

            return res.SetAsOK();
        }

        /// <summary>
        /// 设置列表
        /// </summary>
        /// <param name="listName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public RES SetList(string listName,IEnumerable<object> list)
        {
            var res = RES.New;


            if (null != list)
            {
                var db = this.GetRedis();
                foreach (var item in list)
                {
                    if (item is string && null != item && !string.IsNullOrWhiteSpace(item.ToString()))
                    {
                         db.ListRightPush(listName, item.ToString());
                    }
                    else
                    {
                        db.ListRightPush(listName, JSON.ToJson(item));
                    }
                }
            }

            return res.SetAsOK();

        }

        #endregion


    }
}
