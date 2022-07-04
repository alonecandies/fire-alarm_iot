using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Reflection;
using Vst;
using System.IO;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace BsonData
{
    static class DataDirectory
    {
        public static void Clear(this DirectoryInfo di)
        {
            foreach (var fi in di.GetFiles())
            {
                fi.Delete();
                foreach (var sub in di.GetDirectories())
                {
                    sub.Clear();
                }
            }
        }
    }
    public class FileManager
    {
        public DirectoryInfo Folder { get; private set; }
        public FileManager(string path)
        {
            Folder = new System.IO.DirectoryInfo(path);
            if (Folder.Exists == false)
                Folder.Create();
        }

        public string GetFileName(object id)
        {
            return Folder.FullName + '/' + id;
        }

        public FileInfo GetProjectFileInfo(object id)
        {
            return new FileInfo(this.GetFileName(id));
        }
        public JObject ReadCore(FileInfo fi)
        {
            using (var s = fi.OpenRead())
            {
                return Vst.Bson.Read(s);
            }
        }

        public void WriteCore(object id, object value)
        {
            using (var s = this.GetProjectFileInfo(id).Create())
            {
                var o = JObject.FromObject(value);
                if (o.Property("Id") != null) { o.Remove("Id"); }

                Vst.Bson.Write(s, value);
            }
        }
        public List<DocumentInfo> GetDocumentInfo()
        {
            var lst = new List<DocumentInfo>();
            foreach (var fi in Folder.GetFiles())
            {
                var info = new DocumentInfo
                {
                    Id = fi.Name,
                    CreationTime = fi.CreationTime,
                    LastModifyTime = fi.CreationTime,
                    SizeOnDisk = fi.Length,
                };
                lst.Add(info);
            }
            return lst;
        }
        public DateTime GetLastUpdate(object id)
        {
            var fi = GetProjectFileInfo(id);
            return fi.LastWriteTime;
        }
    }
    public class Collection
    {

        #region FILE MANAGER

        public FileManager FileManager { get; private set; }
        #endregion

        public string Name { get; private set; }
        public DataBase DataBase { get; private set; }
        public Collection(string name, DataBase dataBase)
        {
            Name = name;
            DataBase = dataBase;
            FileManager = new FileManager(dataBase.PhysicalPath + '/' + name);
        }
        /// <summary>
        /// Duyệt qua tất cả các ObjectId
        /// </summary>
        /// <param name="action"></param>
        public void Traversal(Action<string> action)
        {
            foreach (var name in Directory.GetFiles(FileManager.Folder.FullName))
            {
                action(Path.GetFileNameWithoutExtension(name));
            }
        }
        /// <summary>
        /// Duyệt qua tất cả các ObjectId và Object
        /// </summary>
        /// <param name="action"></param>
        public void Traversal(Action<string, JObject> action)
        {
            foreach (var fi in FileManager.Folder.GetFiles())
            {
                var doc = FileManager.ReadCore(fi);
                action?.Invoke(fi.Name, doc);
            }
        }
        /// <summary>
        /// Duyệt qua tất cả các Document
        /// </summary>
        /// <param name="action"></param>
        public void Traversal<T>(Action<T> action)
        {
            this.Traversal((i, o) => {
                action(o.CreateObject<T>(i));
            });
        }
        public JObject FindById(string id)
        {
            var fi = FileManager.GetProjectFileInfo(id);
            if (fi.Exists)
            {
                return FileManager.ReadCore(fi);
            }
            return null;
        }
        public T FindById<T>(string id)
        {
            var o = this.FindById(id);
            if (o == null)
            {
                return default(T);
            }
            var e = o.CreateObject<T>(id);
            return e;
        }
        public void FindAndUpdate(string id, Action<JObject> preAction)
        {
            FindAndUpdate(id, x =>
            {
                preAction?.Invoke(x);
                return true;
            });
        }
        public void FindAndUpdate(string id, Func<JObject, bool> canUpdate)
        {
            var item = this.FindById(id);
            if (item == null)
            {
                return;
            }
            if (canUpdate(item))
            {
                this.Update(id, item);
            }
        }
        public virtual void FindAndDelete(string id, Action<JObject> preAction)
        {
            FindAndDelete(id, x =>
            {
                preAction?.Invoke(x);
                return true;
            });
        }
        public virtual void FindAndDelete(string id, Func<JObject, bool> canDelete)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var item = FindById(id);
                if (item == null)
                {
                    return;
                }
                if (canDelete(item))
                {
                    Delete(id);
                }
            }
        }
        public virtual bool Contains(string id)
        {
            return FileManager.GetProjectFileInfo(id).Exists;
        }
        public virtual void Insert(object item)
        {
            Insert(new ObjectId().ToString(), item);
        }
        public virtual void Insert(string id, object item)
        {
            FileManager.WriteCore(id, item);
        }

        public void Update(object item)
        {
            Update(((IDocument)item).Id, item);
        }
        public virtual void Update(string id, object item)
        {
            FileManager.WriteCore(id, item);
        }
        public void Update(UpdateRequest request)
        {
            var id = request.ObjectId;
            if (id == null)
            {
                if (request.Value == null) return;

                request.Action = UpdateActions.Insert;
                request.ObjectId = id = new ObjectId();
            }
            switch (request.Action)
            {
                case UpdateActions.Delete:
                    Delete(id);
                    return;

                case UpdateActions.Update:
                    Update(id, request.Value);
                    return;

                default:
                    Insert(id, request.Value);
                    return;
            }
        }

        public virtual void Delete(string id)
        {
            var fi = FileManager.GetProjectFileInfo(id);
            if (fi.Exists)
                fi.Delete();
        }
        public virtual List<JObject> ToList()
        {
            var lst = new List<JObject>();
            Traversal((i, e) => { e.Add("ObjectId", i); lst.Add(e); });
            return lst;
        }
        public virtual List<T> ToList<T>()
        {
            var lst = new List<T>();
            Traversal<T>(e => lst.Add(e));
            return lst;
        }
        public List<JObject> ToList(Func<JObject, bool> check)
        {
            var lst = new List<JObject>();
            foreach (var fi in FileManager.Folder.GetFiles())
            {
                var item = FileManager.ReadCore(fi);
                if (check(item))
                {
                    lst.Add(item);
                }
            }
            return lst;
        }

        public Dictionary<string, T> ToDictionary<T>(Func<string, T, bool> condition)
        {
            var map = new Dictionary<string, T>();
            Traversal((i, e) =>
            {
                var a = e.ToObject<T>();
                if (condition(i, a))
                    map.Add(i, a);
            });
            return map;
        }
        public Dictionary<string, T> ToDictionary<T>()
        {
            var map = new Dictionary<string, T>();
            Traversal((i, e) =>
            {
                var a = e.ToObject<T>();
                map.Add(i, a);
            });
            return map;
        }

        public Dictionary<object, T> ToDictionary<T>(string path)
        {
            var map = new Dictionary<object, T>();
            foreach (JObject obj in ToList())
            {
                map.Add(obj.Get(path), obj.ToObject<T>());
            }
            return map;
        }

        public DataBase ToDatabase()
        {
            return new DataBase(this.DataBase.ConnectionString, this.Name);
        }
        public virtual IEnumerable<T> Select<T>(Func<T, bool> where)
        {
            var lst = new List<T>();
            Traversal((i, o) => {
                var e = o.ToObject<T>();
                if (where(e)) { lst.Add(e); }
            });
            return lst;
        }
        public int Count()
        {
            return Directory.GetFiles(FileManager.Folder.FullName).Length;
        }
        public void Clear()
        {
            FileManager.Folder.Clear();
        }
    }
    public class Collection<T> : Collection
    {
        public Collection(string name, DataBase dataBase)
            : base(name, dataBase)
        {

        }
        public Collection(DataBase dataBase)
            : base(typeof(T).Name, dataBase)
        {

        }

        new public List<T> ToList()
        {
            return base.ToList<T>();
        }
        new public T FindById(string id)
        {
            return base.FindById<T>(id);
        }
        public void FindAndUpdate<TValue>(string id, Action<TValue> action)
        {
            var e = this.FindById<TValue>(id);
            if (e != null)
            {
                action?.Invoke(e);
            }
            this.Update(id, e);
        }
    }

    //public class Collection<T> : Collection
    //    where T : Document, new()
    //{

    //    class ItemMap
    //    {
    //        Dictionary<string, T> _dic;
    //        public Dictionary<string, T> GetDictionary(Collection collection)
    //        {
    //            //if (_dic == null)
    //            //{
    //            //    _dic = new Dictionary<string, T>();
    //            //    foreach (var fi in fileManager.GetAllDocument())
    //            //    {
    //            //        var item = fileManager.ReadCore(fi);
    //            //        _dic.Add(fi.Name.ToLower(), item);
    //            //    }
    //            //}
    //            return _dic;
    //        }
    //        public ItemMap()
    //        {
    //        }
    //        public bool Contains(string key)
    //        {
    //            return _dic != null && _dic.ContainsKey(key.ToLower());
    //        }
    //        public void Remove(string key)
    //        {
    //            if (_dic == null) return;
    //            _dic.Remove(key.ToLower());
    //        }
    //        public void Update(string key, T value)
    //        {
    //            if (_dic == null) return;
    //            key = key.ToLower();
    //            if (_dic.ContainsKey(key))
    //            {
    //                _dic[key] = value;
    //            }
    //            else
    //            {
    //                _dic.Add(key, value);
    //            }
    //        }
    //        public T Get(string key)
    //        {
    //            T a;
    //            _dic.TryGetValue(key.ToLower(), out a);
    //            return a;
    //        }
    //        public T Find(string key)
    //        {
    //            if (_dic == null) return null;
    //            return Get(key);
    //        }
    //    }


    //    ItemMap _itemMap;

    //    public Collection(DataBase dataBase)
    //        : this(typeof(T).Name, dataBase)
    //    {

    //    }
    //    public Collection(string name, DataBase dataBase)
    //        : base(name, dataBase)
    //    {
    //        _itemMap = new ItemMap();
    //    }

    //    public Dictionary<string, T> ToDictionary()
    //    {
    //        return _itemMap.GetDictionary(this);
    //    }

    //    public IList ToList()
    //    {
    //        this.ToDictionary();

    //        var lst = new List<T>();
    //        foreach (var p in this.ToDictionary())
    //        {
    //            lst.Add(p.Value);
    //            p.Value.Id = p.Key;
    //        }

    //        return lst;
    //    }
    //    public IList ToList(IEnumerable id)
    //    {
    //        var lst = new List<T>();
    //        this.ToDictionary();
    //        foreach (string i in id)
    //        {
    //            T src = _itemMap.Get(i);
    //            if (src != null)
    //            {
    //                lst.Add(src);
    //            }
    //        }
    //        return lst;
    //    }

    //    public int Count(Func<T, bool> func)
    //    {
    //        return base.Count<T>(func);
    //    }

    //    #region Convert
    //    public IEnumerable<TResult> GetRelation<TResult>(IEnumerable<TResult> elements, Action<T, TResult> action)
    //        where TResult: IDocument
    //    {
    //        foreach (TResult e in elements)
    //        {
    //            var s = FindById(e.Id);
    //            if (s != null)
    //                action(s, e);
    //        }
    //        return elements;
    //    }

    //    PropertyInfo[] _props;
    //    List<PropertyInfo> _getClonePropertiesCore(IEnumerable<PropertyInfo> src, IEnumerable<PropertyInfo> dst)
    //    {
    //        var map = new Dictionary<string, PropertyInfo>();
    //        foreach (var p in src)
    //        {
    //            if (p.CanRead)
    //            {
    //                map.Add(p.Name, p);
    //            }
    //        }

    //        var lst = new List<PropertyInfo>();
    //        foreach (var p in dst)
    //        {
    //            if (p.CanWrite && map.ContainsKey(p.Name))
    //            {
    //                lst.Add(map[p.Name]);
    //            }
    //        }
    //        return lst;
    //    }
    //    List<PropertyInfo> _getCloneProperties(Type type)
    //    {
    //        if (_props == null)
    //        {
    //            _props = typeof(T).GetProperties();
    //        }
    //        return _getClonePropertiesCore(_props, type.GetProperties());
    //    }
    //    List<PropertyInfo> _getCopyProperties<TSource>()
    //    {
    //        if (_props == null)
    //        {
    //            _props = typeof(T).GetProperties();
    //        }
    //        return _getClonePropertiesCore(typeof(TSource).GetProperties(), _props);
    //    }

    //    void _convertCore<TSource, TDestination>(TSource source, TDestination destination, IEnumerable<PropertyInfo> props)
    //    {
    //        foreach (var p in props)
    //        {
    //            var v = p.GetValue(source);
    //            if (v != null)
    //            {
    //                p.SetValue(destination, p.GetValue(source));
    //            }
    //        }
    //    }
    //    public List<TDestination> ToList<TDestination>(IEnumerable<string> id) where TDestination : IDocument, new()
    //    {
    //        var lst = new List<TDestination>();
    //        var props = _getCloneProperties(typeof(TDestination));
    //        this.ToDictionary();
    //        foreach (string i in id)
    //        {
    //            T src = _itemMap.Get(i);
    //            if (src != null)
    //            {
    //                var dst = new TDestination { Id = i };
    //                _convertCore(src, dst, props);
    //                lst.Add(dst);
    //            }
    //        }
    //        return lst;
    //    }
    //    //public List<TDestination> ToList<TDestination>() where TDestination : IDocument, new()
    //    //{
    //    //    this.ToDictionary();

    //    //    var lst = new List<TDestination>();
    //    //    var props = _getCloneProperties(typeof(TDestination));
    //    //    foreach (var p in this.ToDictionary())
    //    //    {
    //    //        TDestination dst = new TDestination { Id = p.Key };
    //    //        _convertCore(p.Value, dst, props);

    //    //        lst.Add(dst);
    //    //    }

    //    //    return lst;
    //    //}
    //    public IEnumerable<TDestination> ToList<TDestination>(Func<T, bool> selector) where TDestination : IDocument, new()
    //    {
    //        this.ToDictionary();

    //        var lst = new List<TDestination>();
    //        var props = _getCloneProperties(typeof(TDestination));
    //        foreach (var p in this.ToDictionary())
    //        {
    //            if (selector != null && !selector(p.Value)) continue;

    //            TDestination dst = new TDestination { Id = p.Key };
    //            _convertCore(p.Value, dst, props);

    //            lst.Add(dst);
    //        }

    //        return lst;
    //    }
    //    //public TDestination FindById<TDestination>(string id) where TDestination : IDocument, new()
    //    //{
    //    //    var src = this.FindById(id);
    //    //    if (src == null)
    //    //    {
    //    //        return default(TDestination);
    //    //    }
    //    //    var dst = new TDestination { Id = id };
    //    //    _convertCore(src, dst, _getCloneProperties(typeof(TDestination)));

    //    //    return dst;
    //    //}

    //    public T Insert<TSource>(string id, TSource item) where TSource : Document
    //    {
    //        var a = new T { Id = id };
    //        _convertCore<TSource, T>(item, a, _getCopyProperties<TSource>());

    //        this.Insert(id, a);
    //        return a;
    //    }
    //    public T Insert<TSource>(TSource item) where TSource : Document
    //    {
    //        var a = new T();
    //        _convertCore<TSource, T>(item, a, _getCopyProperties<TSource>());

    //        a.Id = this.Insert(a);
    //        return a;
    //    }

    //    public void Update<TSource>(string id, TSource item) where TSource : IDocument
    //    {
    //        var a = new T();
    //        _convertCore<TSource, T>(item, a, _getCopyProperties<TSource>());

    //        this.Update(id, a);
    //    }
    //    public void Update<TSource>(TSource item) where TSource : IDocument
    //    {
    //        this.Update<TSource>(item.Id, item);
    //    }
    //    #endregion
    //    public string Insert(string id, T item)
    //    {
    //        if (id == null)
    //        {
    //            id = new ObjectId().ToString();
    //        }
    //        _itemMap.Update(id, item);
    //        FileManager.WriteCore(id, item);

    //        return id;
    //    }
    //    public string Insert(T item)
    //    {
    //        return this.Insert(null, item);
    //    }

    //    public void Update(string id, T item)
    //    {
    //        _itemMap.Update(id, item);
    //        FileManager.WriteCore(id, item);
    //    }
    //    public void Update(T item)
    //    {
    //        this.Update(item.Id, item);
    //    }

    //    public T FindById(string id)
    //    {
    //        T value = _itemMap.Find(id);
    //        if (value == null)
    //        {
    //            var fi = FileManager.GetProjectFileInfo(id);
    //            if (!fi.Exists)
    //                return null;

    //            value = FileManager.ReadCore(fi);
    //            value.Id = id;
    //        }
    //        else
    //        {
    //            if (value.Id == null)
    //                value.Id = id;
    //        }
    //        return value;
    //    }
    //    public void Move<TDestination>(TDestination item, Collection<TDestination> destination)
    //        where TDestination : Document, new()
    //    {
    //        destination.Insert(item.Id, item);
    //        Delete(item.Id);
    //    }
    //    public bool Contains(string id)
    //    {
    //        if (_itemMap.Contains(id))
    //        {
    //            return true;
    //        }

    //        return FileManager.GetProjectFileInfo(id).Exists;
    //    }
    //}
}
