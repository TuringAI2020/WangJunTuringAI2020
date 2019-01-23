using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    /// <summary>
    /// 邮件
    /// </summary>
    public class MAIL
    {
        /// <summary>
        /// SMTP 服务器 地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// SMTP 服务器 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 发送方邮箱地址
        /// </summary>
        public string SenderAddress { get; set; }

        /// <summary>
        /// 发送方密码
        /// </summary>
        public string SenderPassword { get; set; }

        /// <summary>
        /// 接收方邮箱地址
        /// </summary>
        public string RecverAddress { get; set; }


        /// <summary>
        /// 获取一个实例
        /// </summary>
        /// <returns></returns>
        public static MAIL GetInst()
        {
            var inst = new MAIL();
            return inst;
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <returns></returns>
        public RES Send()
        {
            var res = RES.New;

            var mail = new MailMessage(this.SenderAddress,this.RecverAddress);
            mail.Subject = "测试";
            mail.Body = "<b>测试</b>";

            SmtpClient smpt = new SmtpClient(this.Host,this.Port);
            smpt.Credentials = new NetworkCredential(this.SenderAddress,this.SenderPassword);
            smpt.Send(mail);
            return res.SetAsOK();
        }

        /// <summary>
        /// 接收
        /// </summary>
        /// <returns></returns>
        public RES Receive()
        {
            var res = RES.New;

            return res.SetAsOK();
        }
    }
}
