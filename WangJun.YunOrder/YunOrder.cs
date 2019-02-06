using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public class YunOrderService
    {
        /// <summary>
        /// 云订单
        /// </summary>
        /// <returns></returns>
        public static YunOrderService GetInst()
        {
            var inst = new YunOrderService();
            return inst;
        }

        /// <summary>
        /// 保存商品信息
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public RES SaveGoods(string json)
        {
            var res = RES.New;
            if (!string.IsNullOrWhiteSpace(json))
            {
                var yunForm = YunForm.Parse(json);
                yunForm.FormType = (int)ENUM.ServiceType.云商品;
                yunForm.FormTypeName = ENUM.ServiceType.云商品.ToString();
                res = yunForm.Save();
            }
            return res;
        }


        /// <summary>
        /// 创建一个未支付订单
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public RES CreatePrepayOrder(string goodsIDStr,long count, string sourceIDStr, string consumerIDStr)
        {
            var res = RES.New;
            if (!string.IsNullOrWhiteSpace(goodsIDStr) && 0 < count && !string.IsNullOrWhiteSpace(goodsIDStr) && !string.IsNullOrWhiteSpace(goodsIDStr))
            {

                var db = ModelEF.GetInst();
                ///若数据符合要求
                var goodsID = new Guid(goodsIDStr);
                var sourceID = new Guid(sourceIDStr);
                var consumerID = new Guid(consumerIDStr);
                var yunOrder = new YunOrder();
                yunOrder.GoodsID = goodsID;
                yunOrder.SourceID = sourceID;
                yunOrder.ConsumerID = consumerID;
                yunOrder.Count = (int)count;
                yunOrder.ID = new Guid();

                for (int k = 0; k < count; k++)
                {
                    var item = new YunQRCode();
                    item.ID =Guid.NewGuid();
                    item.OrderID = yunOrder.ID;
                    item.QRCode = item.OrderID.ToString() + k;
                    //item.Status = (int)ENUM.EntityStatus.正常;
                    db.YunQRCodes.Add(item);
                }

                db.YunOrders.Add(yunOrder);
                db.SaveChanges();

            }
            return res.SetAsOK();
        }



        /// <summary>
        /// 支付一个订单
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public RES PayOrder(string json)
        {
            var res = RES.New;

            return res.SetAsOK();


        }

        /// <summary>
        /// 取消一个订单
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public RES CancelOrder(string json)
        {
            var res = RES.New;

            return res.SetAsOK();
        }

        /// <summary>
        /// 验证一个订单
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public RES QRCodeCheckIn(string json)
        {
            var res = RES.New;

            return res.SetAsOK();
        }





    }
}
