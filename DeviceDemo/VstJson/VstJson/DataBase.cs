using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BsonData
{
    public class ObjectId
    {
        static char[] _bytes;
        static char toHex(int value)
        {
            return (char)(value > 9 ? value + 87 : (value | 0x30));
        }
        static void setByte(ref int index, int value)
        {
            _bytes[index++] = toHex((byte)value >> 4);
            _bytes[index++] = toHex(value & 15);
        }

        static void Inc(int index)
        {
            if (index == 8)
            {
                createBytes();
                return;
            }

            char c = _bytes[index];
            if (c == 'f')
            {
                _bytes[index] = '0';
                Inc(index - 1);
                return;
            }
            if (c == '9')
            {
                c = 'a';
            }
            else
            {
                c++;
            }
            _bytes[index] = c;
        }

        static void createBytes()
        {
            int totalLength = 12;
            int index = 0;

            _bytes = new char[totalLength << 1];

            var time = DateTime.Today;
            setByte(ref index, time.Year / 100);
            setByte(ref index, time.Year % 100);
            setByte(ref index, time.Month);
            setByte(ref index, time.Day);

            var rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                setByte(ref index, rand.Next(256));
            }
            for (int i = 0; i < 3; i++)
            {
                setByte(ref index, rand.Next(256));
            }
        }

        public ObjectId()
        {
            if (_bytes == null)
            {
                createBytes();
            }
            else
            {
                Inc(_bytes.Length - 1);
            }
        }
        public static implicit operator string(ObjectId obj)
        {
            return obj.ToString();
        }
        public override string ToString()
        {
            return new string(_bytes);
        }
    }

    public class DataBase
    {
        string _connString;
        string _name;

        public string ConnectionString
        {
            get
            {
                return _connString;
            }
        }
        public string Name { get { return _name; } }
        public string PhysicalPath
        {
            get
            {
                return _connString + '/' + _name;
            }
        }

        public DataBase(string connectionString, string name)
        {
            _connString = connectionString;
            _name = name;
        }

        public DataBase Clone()
        {
            return new DataBase(_connString, _name);
        }

        Dictionary<string, object> _collectionsMap;
        protected object GetCollectionCore(string key)
        {
            object v = null;

            if (_collectionsMap == null)
            {
                _collectionsMap = new Dictionary<string, object>();

                //var di = new System.IO.DirectoryInfo(PhysicalPath);
                //if (!di.Exists)
                //{
                //    di.Create();
                //}
            }

            _collectionsMap.TryGetValue(key, out v);
            return v;
        }
        public void RegisterCollection(Collection collection)
        {
            if (_collectionsMap == null)
                _collectionsMap = new Dictionary<string, object>();

            _collectionsMap.Add(collection.Name, collection);
        }
        public Collection GetCollection(string name)
        {
            string key = name.ToLower();
            var v = GetCollectionCore(key);
            if (v == null)
            {
                _collectionsMap.Add(key, v = CreateCollection(name));
            }

            return (Collection)v;
        }
          
        public Collection GetCollection<T>()
        {
            return GetCollection(typeof(T).Name);
        }
        public void ClearColection(string name)
        {
            string key = name.ToLower();
            if (_collectionsMap != null && _collectionsMap.ContainsKey(key))
            {
                _collectionsMap.Remove(key);
            }

            var di = new System.IO.DirectoryInfo(PhysicalPath + '/' + key);
            if (di.Exists)
            {
                DeleteDirrectory(di);
            } 
        }

        public void Clear()
        {
            if (_collectionsMap != null)
                _collectionsMap.Clear();

            var di = new System.IO.DirectoryInfo(this.PhysicalPath);            
            if (di.Exists)
                DeleteDirrectory(di);
        }

        void DeleteDirrectory(System.IO.DirectoryInfo di)
        {
            foreach (var fi in di.GetFiles())
                fi.Delete();

            foreach (var d in di.GetDirectories())
                DeleteDirrectory(d);

            di.Delete();
        }

        protected virtual Collection CreateCollection(string name)
        {
            return new Collection(name, this);
        }
        public virtual void Reset()
        {
            if (_collectionsMap != null)
            {
                _collectionsMap.Clear();
            }
        }

        public T ReadJson<T>(string filename)
        {
            var path = _connString + "/" + filename;
            using (var sr = new System.IO.StreamReader(path))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
            }
        }

    }
}
