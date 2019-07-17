using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.ProcApp
{
    public class QueueRunner
    {
        public void Run() {
            new YunQueue().Dequeue("Test", new EventHandler<BasicDeliverEventArgs>((sender, e) => {
                var msg = Encoding.UTF8.GetString(e.Body);
                Console.WriteLine($"{msg}-{DateTime.Now}");
            }));
        }
    }
}
