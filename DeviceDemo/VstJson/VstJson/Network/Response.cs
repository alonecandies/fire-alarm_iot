using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VstJson.Network
{
    public class Response
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Value { get; set; }

        public bool HasValue => Value != null;
        public T GetObject<T>()
        {
            return ((Newtonsoft.Json.Linq.JObject)Value).ToObject<T>();
        }
    }
}
