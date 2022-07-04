using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE = System.Text.Encoding;

namespace Vst
{
    public class Encoding
    {
        public static string ToBase64(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            var bytes = SE.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }
        public static string FromBase64(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return SE.UTF8.GetString(Convert.FromBase64String(text));
        }
        public static string ToHex(string ascii)
        {
            var v = new char[ascii.Length << 1];
            int i = 0;
            foreach (char c in ascii)
            {
                var d = (c >> 4) + 48;
                if (d > '9') d += 7;
                v[i++] = (char)d;

                d = (c & 15) + 48;
                if (d > '9') d += 7;
                v[i++] = (char)d;
            }
            return new string(v);
        }
        public static string FromHex(string text)
        {
            var v = text.ToCharArray();

            int i = 0, k = 0;
            while (i < v.Length)
            {
                var H = v[i++] - 48;
                if (H > '9') H -= 7;

                var L = v[i++] - 48;
                if (L > '9') L -= 7;

                v[k++] = (char)((H << 4) | L);
            }
            return new string(v, 0, k);
        }

        public static byte[] String2Bytes(string text)
        {
            return SE.UTF8.GetBytes(text);
        }
        public static string Bytes2String(byte[] bytes)
        {
            return SE.UTF8.GetString(bytes);
        }
    }
}
