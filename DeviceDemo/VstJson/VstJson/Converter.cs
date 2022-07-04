using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BsonData
{
    public class Converter
    {
        public static TResult Clone<T, TResult>(T source)
            where TResult: new()
        {
            var t = typeof(TResult);
            var r = new TResult();
            foreach (var pSource in typeof(T).GetProperties())
            {
                if (pSource.CanRead)
                {
                    var pResult = t.GetProperty(pSource.Name, pSource.PropertyType);
                    if (pResult != null && pResult.CanWrite)
                    {
                        pResult.SetValue(r, pSource.GetValue(source));
                    }
                }
            }
            return r;
        }
    }
}
