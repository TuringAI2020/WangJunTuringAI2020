using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;

namespace WangJun.Yun
{
    public class QRCode
    {


        public void Encode(string data)
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.CharacterSet = "UTF-8";
            options.Width = 500;
            options.Height = 500;
            options.Margin = 1;
            options.PureBarcode = false; // 是否是纯码，如果为 false，则会在图片下方显示数字
            options.ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.H; // 纠错级别
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            using (Bitmap bmp = writer.Write(data))
            {
                MemoryStream ms = new MemoryStream();
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    var md5 = MD5.ToMD5(data.Trim());
                    bmp.Save(string.Format("{0}.png",md5), System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }
        public void Decode()
        {
            BarcodeReader reader = new BarcodeReader();
            reader.Options.CharacterSet = "UTF-8";
            using (Bitmap bmp = new Bitmap("D:\\qr.png"))
            {
                Result result = reader.Decode(bmp);
            }
        }
    }


}
