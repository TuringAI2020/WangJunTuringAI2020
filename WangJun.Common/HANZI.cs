﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public static class HANZI
    {
        public static string GetAll() {
            var str = new StringBuilder();
            for (int k = 0x4e00; k < 0x9fbb; k++)
            {
                str.AppendFormat(Convert.ToChar(k).ToString());
            }
            return str.ToString();
        }

        /// <summary>
        /// 字符串转为UniCode码字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string StringToUnicode(string s)
        {
            char[] charbuffers = s.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("//u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }
        /// <summary>
        /// Unicode字符串转为正常字符串
        /// </summary>
        /// <param name="srcText"></param>
        /// <returns></returns>
        public static string UnicodeToString(string srcText)
        {
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }
    }
}
