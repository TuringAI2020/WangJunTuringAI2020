using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WangJun.Yun;

namespace WangJun.Yun
{
    public class YunFile
    {
        public string SaveFromHttp() {
            var context = HttpContext.Current;
            var filePath = string.Empty;
            if (null != context&& null != context.Request.Files ) {
                for (int k = 0; k < context.Request.Files.Count; k++)
                {
                    HttpPostedFile file = context.Request.Files[k];


                    var path = context.Server.MapPath("~")+"/"+"FILES/";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var bytes = new byte[(int)file.InputStream.Length];
                    file.InputStream.Read(bytes, 0, bytes.Length);
                    var fileName = MD5.ToMD5(bytes);
                    if (file.FileName.Contains(".")) {
                        fileName = fileName + "." + file.FileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[1];
                    }
                    filePath = context.Request.Url.Authority+ "/FILES/" + fileName;
                    file.SaveAs(path+fileName);
                }
            }
            return filePath;
        }
    }
}
