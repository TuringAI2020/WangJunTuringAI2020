using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WangJun.SelfHostAPI;
using WangJun.Yun;

namespace WangJun.APITest
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();

            }
            return;

            七彩福星.计算();

            return;

            var allChar = HANZI.GetAll();
            ///创建1000个商品
            for (int k = 0; k < 10; k++)
            {
                var res = YunCommodityService.GetInst().Save(JSON.ToJson(new YunCommodity { FormType= (int)ENUM.ServiceType.云商品 
                    , Status=(int)ENUM.实体状态.正常 , ValueI01=(int)ENUM.CommodityStatus.待售,
                    ID =Guid.NewGuid(),
                    ValueS01 = allChar.Substring(3+k % 3000, 1+k % 20),
                    CreatorID =Guid.NewGuid(), CreatorName=allChar.Substring(k,k%4),
                    UpdaterID = Guid.NewGuid(), UpdaterName = allChar.Substring(k, k % 4)
                }));
                Console.WriteLine("创建"+k);
            }

            ///获取1000个商品
            var commodityList = YunCommodityService.GetInst().LoadList().DATA as List<YunForm>;

            ///上架1000个商品
            for (int k = 0; k < commodityList.Count; k++)
            {
                var commodity = commodityList[k];
                YunCommodityService.GetInst().OnShelves(commodity.ID.ToString());
                Console.WriteLine("上架" + k);
            }

            ///下架1000个商品
            for (int k = 0; k < commodityList.Count; k++)
            {
                var commodity = commodityList[k];
                YunCommodityService.GetInst().OffShelves(commodity.ID.ToString());
                Console.WriteLine("下架" + k);
            }

            ///修改1000个商品
            for (int k = 0; k < commodityList.Count; k++)
            {
                var commodity = commodityList[k];
                commodity.ValueS01 += "测试";
                YunCommodityService.GetInst().Save(JSON.ToJson(commodity));
                Console.WriteLine("修改" + k);
            }
            ///删除1000个商品
            for (int k = 0; k < commodityList.Count; k++)
            {
                var commodity = commodityList[k];
                YunCommodityService.GetInst().Remove(commodity.ID.ToString());
            }


            ///统计1000个商品
            ///
            ///创建未支付订单
            for(var k=0; k<10;k++)
            {
                var commodity = commodityList[k];
                YunOrderService.GetInst().CreatePrepayOrder(commodity.ID.ToString(), 10, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                Console.WriteLine("创建订单" + k);
            }

            ///支付订单
            var orderList = YunOrderService.GetInst().LoadOrderList().DATA as List<YunOrder>;
            for (int k = 0; k < orderList.Count; k++)
            {
                var order = orderList[k];
                YunOrderService.GetInst().PayOrder(JSON.ToJson(new { OrderId = order.ID }));
                Console.WriteLine("支付订单" + k);
            }

 
            ///取消未支付订单
            //var orderList = YunOrderService.GetInst().LoadOrderList().DATA as List<YunOrder>;
            for (int k = 0; k < orderList.Count; k++)
            {
                var order = orderList[k];
                YunOrderService.GetInst().CancelOrder(JSON.ToJson(new { OrderId = order.ID}));
                Console.WriteLine("取消订单" + k);
            }

            ///部分退款
            ///全部退款
            for (int k = 0; k < orderList.Count; k++)
            {
                var order = orderList[k];
                YunOrderService.GetInst().RefundOrder(JSON.ToJson(new { OrderId = order.ID, Count = 10 }));
                Console.WriteLine("退款订单" + k);
            }

            ///核销
            for (int k = 0; k < orderList.Count; k++)
            {
                var order = orderList[k];
                YunOrderService.GetInst().QRCodeCheckIn(JSON.ToJson(new { OrderId = order.ID, Count = 10 }));
                Console.WriteLine("核销订单" + k);
            }
            Console.WriteLine("全部结束");
            //Console.ReadKey();
            return;

            
            Console.WriteLine("全部结束");
            Console.ReadKey();
            return;
        }
    }
} 
