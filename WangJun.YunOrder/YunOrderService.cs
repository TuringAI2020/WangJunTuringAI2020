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

        public RES IsValidOrder()
        {
            return RES.New.SetAsOK();
        }

        public RES CanOrderCheckIn() {
            return RES.New.SetAsOK();
        }

        public RES CanOrderRefund()
        {
            return RES.New.SetAsOK();
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
                yunOrder.ID = Guid.NewGuid();
                yunOrder.Status = (int)ENUM.订单及消费项状态.未支付;
                //yunOrder.OrderID =GUID. MD5.ToMD5( ORDER.NewOrderID);

                for (int k = 0; k < count; k++)
                {
                    var item = new YunQRCode();
                    item.ID =Guid.NewGuid();
                    item.OrderID = yunOrder.ID;
                    item.QRCode = item.OrderID.ToString() + k;
                    //item.Status = (int)ENUM.EntityStatus.正常;
                    item.Status =  (int)ENUM.订单及消费项状态.未支付;
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

            var param = JSON.ToObject<Dictionary<string, object>>(json);
            var orderId = Guid.Parse( param["OrderId"].ToString());
            var db = ModelEF.GetInst();
            var order = db.YunOrders.FirstOrDefault(p => p.ID == orderId);
            var qrCodeList = db.YunQRCodes.Where(p => p.OrderID == orderId).ToList();
            order.QRCodeList = qrCodeList;

            order.Status = (int)ENUM.订单及消费项状态.未使用;
            qrCodeList.ForEach(p=> {
                p.Status = (int)ENUM.订单及消费项状态.未使用;
            });

            db.SaveChanges();

            return RES.New.SetAsOK(order); 
        }

        /// <summary>
        /// 是否可继续提交
        /// </summary>
        /// <param name="order"></param>
        /// <param name="nextStatus"></param>
        /// <returns></returns>
        public RES CanContinue(YunOrder order,int currentStatus,int nextStatus)
        {
            if (nextStatus == (int)ENUM.订单及消费项状态.未支付)
            {
                ///状态异常
            }
            else if (currentStatus == (int)ENUM.订单及消费项状态.未支付 && nextStatus == (int)ENUM.订单及消费项状态.未使用)
            {
                ///要求所有状态为未支付,无支付信息
                if (order.Status == (int)ENUM.订单及消费项状态.未支付 && order.QRCodeList.Count == order.QRCodeList.Count(p => p.Status == (int)ENUM.订单及消费项状态.未支付)) {
                    ///一张未用才转变为可支付状态
                }
            }
            else if (currentStatus == (int)ENUM.订单及消费项状态.未使用 && nextStatus == (int)ENUM.订单及消费项状态.部分使用)
            {
                ///所有的都是已支付状态,未使用状态
            }
        }

        /// <summary>
        /// 取消一个订单
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public RES CancelOrder(string json )
        {
            var param = JSON.ToObject<Dictionary<string, object>>(json);
            var orderId = Guid.Parse(param["OrderId"].ToString());
            var db = ModelEF.GetInst();
            var order = db.YunOrders.FirstOrDefault(p => p.ID == orderId);
            var qrCodeList = db.YunQRCodes.Where(p => p.OrderID == orderId).ToList();
            order.QRCodeList = qrCodeList;

            order.Status = (int)ENUM.订单及消费项状态.已取消;
            qrCodeList.ForEach(p =>
            {
                p.Status = (int)ENUM.订单及消费项状态.已取消;
            });

            #region 时间设置

            #endregion


            db.SaveChanges();
            return RES.New.SetAsOK(order);
        }

        /// <summary>
        /// 退款一个订单
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public RES RefundOrder(string json)
        {
            var param = JSON.ToObject<Dictionary<string, object>>(json);
            var orderId = Guid.Parse(param["OrderId"].ToString());
            var refundCount = int.Parse(param["Count"].ToString());
            var db = ModelEF.GetInst();
            var order = db.YunOrders.FirstOrDefault(p => p.ID == orderId);
            var qrCodeList = db.YunQRCodes.Where(p => p.OrderID == orderId).Take(refundCount).ToList();
            order.QRCodeList = qrCodeList;

            order.Status = (int)ENUM.订单及消费项状态.已退款;
            qrCodeList.ForEach(p =>
            {
                p.Status = (int)ENUM.订单及消费项状态.已退款;
            });

            db.SaveChanges();
            return RES.New.SetAsOK(order);
        }

        /// <summary>
        /// 验证一个订单
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public RES QRCodeCheckIn(string json)
        {

            var param = JSON.ToObject<Dictionary<string, object>>(json);
            var orderId = Guid.Parse(param["OrderId"].ToString());
            var refundCount = int.Parse(param["Count"].ToString());
            var db = ModelEF.GetInst();
            var order = db.YunOrders.FirstOrDefault(p => p.ID == orderId);
            var qrCodeList = db.YunQRCodes.Where(p => p.OrderID == orderId).Take(refundCount).ToList();
            order.QRCodeList = qrCodeList;

            order.Status = (int)ENUM.订单及消费项状态.无可用项目;
            qrCodeList.ForEach(p =>
            {
                p.Status = (int)ENUM.订单及消费项状态.无可用项目;
            });

            db.SaveChanges();
            return RES.New.SetAsOK(order);
             
        }


        /// <summary>
        /// 加载一个订单
        /// </summary>
        /// <returns></returns>
        public RES LoadOrder(string orderID)
        {
            var res = RES.New;
            var orderGuid = ORDER.OrderIDToGuid(orderID);
            var db = ModelEF.GetInst();
            var order = db.YunOrders.FirstOrDefault(p => p.ID == orderGuid);
            var qrCodeList = db.YunQRCodes.Where(p => p.OrderID == orderGuid).ToList();

            order.QRCodeList = qrCodeList;
            res.DATA = order;
            return res.SetAsOK();
        }


        public RES LoadOrderList()
        {
            var db = ModelEF.GetInst();
            var orderList = db.YunOrders.ToList();
            return RES.New.SetAsOK(orderList);
        }



    }
}
