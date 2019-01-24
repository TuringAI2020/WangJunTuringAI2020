using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WangJun.Yun;

namespace WangJun.Yun
{
    public partial class YunFile
    {
        /// <summary>
        /// 存储文件
        /// </summary>
        /// <returns></returns>
        public string SaveFromHttp()
        {
            var context = HttpContext.Current;
            var filePath = string.Empty;
            var downloadPath = string.Empty;

            if (null != context && null != context.Request.Files && 0<context.Request.Files.Count)
            {
                for (int k = 0; k < context.Request.Files.Count; k++)
                {
                    HttpPostedFile file = context.Request.Files[k];

                    var localPath = this.GetLocalDirectory();
              
                    var bytes = new byte[(int)file.InputStream.Length];
                    file.InputStream.Read(bytes, 0, bytes.Length);
                    downloadPath = this.SaveFileToDisk(localPath, file.FileName, bytes);
                }
            }
            return downloadPath;
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

        /// <summary>
        /// 获取本地存储路径
        /// </summary>
        /// <returns></returns>
        public string GetLocalDirectory()
        {
            var path = string.Format("{0}/{1}/", HttpContext.Current.Server.MapPath("~"), "FILES");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localPath"></param>
        /// <param name="sourceFileName"></param>
        /// <param name="fileData"></param>
        public string SaveFileToDisk(string localPath, string sourceFileName, byte[] fileData)
        {
            if (!string.IsNullOrWhiteSpace(localPath) && !string.IsNullOrWhiteSpace(sourceFileName) && null != fileData) ///若数据符合要求
            {
                var fileMd5 = MD5.ToMD5(fileData);
                var extension = string.Empty;
                if (sourceFileName.Contains("."))
                {
                    var arrName =  sourceFileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    extension = string.Format(".{0}",arrName.Last());
                }

                var fullLocalPath = string.Format("{0}/{1}{2}",localPath,fileMd5,extension);

                var downloadPath = string.Format("http://{0}/{1}/{2}{3}", HttpContext.Current.Request.Url.Authority, "FILES", fileMd5, extension);
                var rawUrl = HttpContext.Current.Request.RawUrl;
                #region 写文件信息
                Task.Run(() =>
                {
                    File.WriteAllBytes(fullLocalPath, fileData);

                    var fileInfo = new StringBuilder();
                    fileInfo.AppendLine(string.Format("请求原始地址\t{0}", rawUrl));
                    fileInfo.AppendLine(string.Format("原始文件名\t{0}", sourceFileName));
                    fileInfo.AppendLine(string.Format("后缀名\t{0}", extension));
                    fileInfo.AppendLine(string.Format("存储路径\t{0}", fullLocalPath));
                    fileInfo.AppendLine(string.Format("存储文件名\t{0}", fileMd5));
                    fileInfo.AppendLine(string.Format("当前分片文件MD5\t{0}", fileMd5));
                    fileInfo.AppendLine(string.Format("原始文件大小\t{0}", fileData.Length));
                    fileInfo.AppendLine(string.Format("文件组文件MD5\t{0}", fileMd5));
                    fileInfo.AppendLine(string.Format("可下载地址\t{0}", downloadPath));
                    fileInfo.AppendLine(string.Format("上传时间\t{0}", DateTime.Now));
                    var fileInfoPath = string.Format("{0}/{1}{2}.txt", localPath, fileMd5, extension);
                    File.WriteAllText(fileInfoPath, fileInfo.ToString());
                });
                #endregion


                return downloadPath;
            }
            return string.Empty;
        }
    }
}
