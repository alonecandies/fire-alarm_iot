using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using JC = Newtonsoft.Json.JsonConvert;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace System
{
    public class Json
    {
        public static T Convert<T>(object value)
        {
            return GetObject<T>(GetString(value));
        }

        public static string GetString(object value)
        {
            return JC.SerializeObject(value);
        }
        public static object GetObject(string text)
        {
            return JC.DeserializeObject(text);
        }
        public static T GetObject<T>(string text)
        {
            return JC.DeserializeObject<T>(text);
        }

        public static void Save(string fileName, object value)
        {
            using (var sw = new System.IO.StreamWriter(fileName))
            {
                sw.Write(JC.SerializeObject(value));
            }
        }
        public static T Read<T>(string fileName)
        {
            using (var sr = new System.IO.StreamReader(fileName))
            {
                return JC.DeserializeObject<T>(sr.ReadToEnd());
            }
        }
    }
}

namespace System
{
    public static class JObjectExtension
    {
        public static JObject Append(this JObject o, string key, object value)
        {
            o.Add(key, JToken.FromObject(value));
            return o;
        }
        public static object Get(this JObject o, string path)
        {
            return o.SelectToken(path)?.ToObject<object>();
        }
        public static T Get<T>(this JObject o, string path)
        {
            var token = o.SelectToken(path);
            if (token == null) { return default(T); }
            return token.ToObject<T>();
        }
        public static T Get<T>(this JObject o)
        {
            return o.Get<T>(typeof(T).Name);
        }
        public static T CreateObject<T>(this JObject o, object objectId)
        {
            var token = o.SelectToken("Id");
            if (token == null)
            {
                return o.Append("Id", objectId).ToObject<T>();
            }

            token.Replace(JToken.FromObject(objectId));
            return o.ToObject<T>();
        }    

        public static JObject SetObject(this JObject o, string path, object value)
        {
            var token = o.SelectToken(path);
            token.Replace(JToken.FromObject(value));

            return o;
        }
        public static JObject Set<T>(this JObject o, string path, string value)
        {
            var token = o.SelectToken(path);
            token.Replace(JToken.Parse(value));

            return o;
        }
        public static JObject UpdateObject(this JObject o, string path, object value)
        {
            var token = o.SelectToken(path);
            var v = JToken.FromObject(value);
            if (token == null) { o.Add(path, v); }
            else { token.Replace(v); }

            return o;
        }
    }

}
