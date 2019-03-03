using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    /// <summary>
    /// 云商品服务
    /// </summary>
    public class YunCommodityService
    {
        /// <summary>
        /// 云订单
        /// </summary>
        /// <returns></returns>
        public static YunCommodityService GetInst()
        {
            var inst = new YunCommodityService();
            return inst;
        }

        /// <summary>
        /// 检索一个商品信息 ID,Code
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public RES Get(string keyword)
        {

            return YunCommodity.GetInst().Get(keyword);
        }

        ///检测商品是否存在
        public RES Exsit(string keyword)
        {
            return YunCommodity.GetInst().Exsit(keyword);
        }
        /// 
        ///保存一个商品
        public RES Save(string data)
        {
            var commodity = JSON.ToObject<YunCommodity>(data);
            return YunCommodity.GetInst().Save(commodity);
        }
        ///删除商品
        public RES Remove(string keyword)
        {
            return YunCommodity.GetInst().Remove(keyword);
        }


        ///下架
        public RES OffShelves(string keyword)
        {
            return YunCommodity.GetInst().OffShelves(keyword);
        }

        /// 
        ///上架
        public RES OnShelves(string keyword)
        {
            return YunCommodity.GetInst().OnShelves(keyword);
        }
        ///检测关联订单信息
        public RES RefOrderCount(string keyword)
        {
            return YunCommodity.GetInst().RefOrderCount(keyword);
        }

        public RES LoadList(string filter=null) {
            return YunCommodity.GetInst().LoadList((int)ENUM.ServiceType.云商品);
        }
          
    }
}
