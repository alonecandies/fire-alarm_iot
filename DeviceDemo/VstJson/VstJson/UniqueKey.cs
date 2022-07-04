using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsonData
{
    public class UniqueKey : List<object>
    {
        const char separator = '\t';
        public static string[] Parse(string base64)
        {
            var uk = new UniqueKey(base64);
            var res = new string[uk.Count];
            int i = 0;
            foreach (var v in uk)
            {
                res[i++] = v.ToString();
            }
            return res;
        }
        public static string Generate(params object[] keys)
        {
            var uk = new UniqueKey();
            uk.AddRange(keys);
            return uk.ToString();
        }
        public UniqueKey() { }
        public UniqueKey(string base64)
        {
            if (!string.IsNullOrWhiteSpace(base64))
            {
                var s = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(base64));
                this.AddRange(s.Split(separator));
            }
        }
        public override string ToString()
        {
            string s = string.Empty;
            foreach (var v in this)
            {
                if (v == null)
                    continue;

                if (s != string.Empty)
                {
                    s += separator;
                }
                s += v.ToString();
            }
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(s));
        }
    }
}
