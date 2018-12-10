using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public static class GZIP
    {
        public static byte[] Compress(byte[] input)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream zipStream = new GZipStream(ms, CompressionMode.Compress);
            zipStream.Write(input, 0, input.Length);//将数据压缩并写到基础流中  
            zipStream.Close();
            return ms.ToArray();
        }

        public static byte[] Decompress(byte[] input) {
            var sourceStream = new MemoryStream(input);
            var targetStream = new MemoryStream();
            int count = 0;
            GZipStream gzip = new GZipStream(sourceStream, CompressionMode.Decompress);
            byte[] buf = new byte[512];
            while ((count = gzip.Read(buf, 0, buf.Length)) > 0)
            {
                targetStream.Write(buf, 0, count);
            }
            byte[] targetBytes = targetStream.GetBuffer();
            sourceStream.Close();
            targetStream.Close();
            return targetBytes;
        }
    }
}
