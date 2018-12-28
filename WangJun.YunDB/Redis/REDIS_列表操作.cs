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
        #endregion


    }
}
