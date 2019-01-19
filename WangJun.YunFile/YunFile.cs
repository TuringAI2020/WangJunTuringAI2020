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
        /// <summary>
        /// 存储文件
        /// </summary>
        /// <returns></returns>
        public string SaveFromHttp()
        {
            var context = HttpContext.Current;
            var filePath = string.Empty;
            if (null != context && null != context.Request.Files)
            {
                for (int k = 0; k < context.Request.Files.Count; k++)
                {
                    HttpPostedFile file = context.Request.Files[k];


                    var path = context.Server.MapPath("~") + "/" + "FILES/";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var bytes = new byte[(int)file.InputStream.Length];
                    file.InputStream.Read(bytes, 0, bytes.Length);
                    var fileName = MD5.ToMD5(bytes);
                    if (file.FileName.Contains("."))
                    {
                        fileName = fileName + "." + file.FileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[1];
                    }
                    filePath = context.Request.Url.Authority + "/FILES/" + fileName;
                    file.SaveAs(path + fileName);

                    #region 写文件信息
                    var fileInfo = new StringBuilder();
                    fileInfo.AppendLine(string.Format("请求原始地址\t{0}",context.Request.RawUrl));
                    fileInfo.AppendLine(string.Format("文件名\t{0}", file.FileName));
                    fileInfo.AppendLine(string.Format("后缀名\t{0}", file.FileName.Contains(".")? file.FileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[1]:string.Empty));
                    fileInfo.AppendLine(string.Format("存储路径\t{0}", filePath));
                    fileInfo.AppendLine(string.Format("存储文件名\t{0}", fileName));
                    fileInfo.AppendLine(string.Format("分片文件MD5\t{0}", fileName));
                    fileInfo.AppendLine(string.Format("原始文件大小\t{0}", file.InputStream.Length));
                    fileInfo.AppendLine(string.Format("组文件MD5\t{0}", fileName));
                    File.WriteAllText(path + fileName + ".txt", fileInfo.ToString());
                    #endregion
                }
            }
            return filePath;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <returns></returns>
        public string DeleteFromHttp(string fileName) {
            var context = HttpContext.Current;
            var filePath = string.Empty;
            if (null != context)
            {
                //var param = HttpRequestParam.Parse(HttpContext.Current.Request.InputStream, HttpContext.Current.Request.RawUrl);
                //var md5 = param.GetQueryParam["FileName"].ToString();
                var path = context.Server.MapPath("~") + "/" + "FILES/"+ fileName;

                File.Delete(path);

                File.Delete(path+".txt");
            }
            return "OK";

         }
    }
}
