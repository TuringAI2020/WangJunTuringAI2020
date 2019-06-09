using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace WangJun.Yun
{
    public class YunFileService
    {
        public static YunFileInfo ReadFile(Stream stream)
        {
            var info = new YunFileInfo();
            if (null != stream&& 0<stream.Length)
            {
                var size = 1024 * 1024 * 10;
                var length = stream.Length;
                var count = (0 == length % size) ? length / size : (length / size) + 1;
                var md5Array = new string[count];
                var byteArray = new byte[size];
                for (int k = 0; k < count; k++)
                {
                    if (k != count || 0==length % size)
                    {
                        stream.Read(byteArray, 0, size);
                        var md5 = MD5.ToMD5(byteArray);
                        md5Array[k] = md5;
                        Array.Clear(byteArray, 0, byteArray.Length);
                    }
                    else if(0<length % size)
                    {
                        var tailByteArray = new byte[length % size];
                        var md5 = MD5.ToMD5(tailByteArray);
                        md5Array[k] = md5;
                    }
                }

                info.MD5Array = md5Array;
                var md5long = string.Empty;
                info.MD5Array.ToList().ForEach(p=> {
                    md5long += p;
                });
                info.FileMD5 = MD5.ToMD5(md5long);
                 
            }
            return info;

        }
    }
}
