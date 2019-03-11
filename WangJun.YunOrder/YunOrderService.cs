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
            if ((int)ENUM.订单及消费项状态.未支付 == currentStatus)
            {
                ///下一步有效状态  未使用
                if (order.Status == (int)ENUM.订单及消费项状态.未支付 && order.QRCodeList.Count == order.QRCodeList.Count(p => p.Status == (int)ENUM.订单及消费项状态.未支付))
                {
                    return RES.New.SetAsOK(true);
                }
            }
            else if ((int)ENUM.订单及消费项状态.未使用 == currentStatus)
            {
                ///下一步有效状态  部分使用 无可用项目 退款处理中
                if (order.Status == (int)ENUM.订单及消费项状态.未使用 && order.QRCodeList.Count == order.QRCodeList.Count(p => p.Status == (int)ENUM.订单及消费项状态.未使用))
                {
                    return RES.New.SetAsOK(true);
                }
            }
            else if ((int)ENUM.订单及消费项状态.部分使用 == currentStatus)
            {
                ///下一步有效状态  部分使用 无可用项目
            }
            else if ((int)ENUM.订单及消费项状态.无可用项目 == currentStatus)
            {
                ///下一步有效状态    无可用项目
            }
            else if ((int)ENUM.订单及消费项状态.全部已退款 == currentStatus)
            {
                ///下一步有效状态    无可用项目
            }
            return RES.New.SetAsOK(true);
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
            var refundCount = 0;//
            var qrCode = string.Empty;//
            var db = ModelEF.GetInst();
            var order = db.YunOrders.FirstOrDefault(p => p.ID == orderId);
            if (param.ContainsKey("QRCode") && null != param["QRCode"])
            {
                qrCode = param["QRCode"].ToString();
                order.QRCodeList = db.YunQRCodes.Where(p => p.OrderID == orderId && p.QRCode==qrCode).Take(1).ToList(); ;
            }
            else if (param.ContainsKey("Count") && null != param["Count"])
            {
                refundCount = int.Parse(param["Count"].ToString());
                order.QRCodeList = db.YunQRCodes.Where(p => p.OrderID == orderId).Take(refundCount).ToList();
            }

             
            order.QRCodeList.ForEach(p =>
            {
                p.Status = (int)ENUM.订单及消费项状态.无可用项目;
            });

            if (0 < order.QRCodeList.Count(p => p.Status == (int)ENUM.订单及消费项状态.未使用))
            {
                ///若还有可使用的
                order.Status = (int)ENUM.订单及消费项状态.部分使用;
            }
            else if (0 < order.QRCodeList.Count(p => p.Status == (int)ENUM.订单及消费项状态.已退款)&& order.QRCodeList.Count(p => p.Status == (int)ENUM.订单及消费项状态.已退款)==order.QRCodeList.Count())
            {
                order.Status = (int)ENUM.订单及消费项状态.全部已退款;
            }
            else if (0 == order.QRCodeList.Count(p => p.Status == (int)ENUM.订单及消费项状态.未使用))
            {
                order.Status = (int)ENUM.订单及消费项状态.无可用项目;
            }


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
