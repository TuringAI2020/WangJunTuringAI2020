using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.Yun
{
    public class YunMail
    {
        public RES SendMail()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("tushu2019@163.com");
            mail.To.Add(new MailAddress("tushu2019@163.com"));
            mail.Subject = "定时测试";
            mail.Body = "定时测试";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.163.com", 25);
            //smtp.EnableSsl = true; 
            smtp.Credentials = new NetworkCredential("tushu2019", "7573Wj7573");
            smtp.Send(mail);
            return RES.OK();
        }
    }
}
