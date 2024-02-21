using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace BibleViewer.Store.Dic
{
    public sealed class DictionaryStoreBuilder<T>
    {
        public IDictionaryStore<T> Build(FileInfo f, IDictionaryValueCodec<T> valueCodec)
        {
            return new DictionaryStore<T>(f, valueCodec);
        }

        private sealed class DictionaryStore<T2> : IDictionaryStore<T2>
        {
            public DictionaryStore(FileInfo f, IDictionaryValueCodec<T2> valueCodec) 
            { 
                if (f.Exists)
                {
                    using StreamReader reader = new StreamReader(new BufferedStream(new FileStream(f.FullName, FileMode.Open, FileAccess.Read)));
                    while(true)
                    {
                        string line = reader.ReadLine();
                        if (line is null)
                            break;
                        int idx = line.IndexOf(SEPARATOR);
                        if (idx < 0)
                            throw new ArgumentException($"Illegal line {line}");
                        string k = line.Substring(0, idx);
                        string v = line.Substring(idx + 1);
                        T2 t = valueCodec.Decode(v);
                        if (dic.ContainsKey(k))
                            throw new ArgumentException($"Duplicate key : {k}");
                        dic.TryAdd(k, t);
                    }
                }
                this.f = f;
                this.valueCodec = valueCodec;
            }

            private readonly FileInfo f;
            private readonly IDictionaryValueCodec<T2> valueCodec;
            private const char SEPARATOR = '|';
            private readonly ConcurrentDictionary<string, T2> dic = new ConcurrentDictionary<string, T2>();
            public int Count
            {
                get
                {
                    lock (this)
                        return dic.Count;
                }
            }

            public IEnumerator<string> Keys
            {
                get
                {
                    lock(this)
                        return dic.Keys.GetEnumerator();
                }
            }

            public bool ContainsKey(string key)
            {
                lock(this)
                    return dic.ContainsKey(key);
            }

            public T2 Get(string key, T2 value, bool putIfAbsent)
            {
                lock (this)
                {
                    if(!dic.TryGetValue(key, out T2 t))
                    {
                        if (putIfAbsent)
                            Put(key, value);
                        return value;
                    }
                    return t;
                }
            }

            public T2 GetIfPresent(string key)
            {
                lock (this)
                {
                    if (dic.TryGetValue(key, out T2 t))
                        return t;
                    return default;
                }
            }

            public void Put(string key, T2 value)
            {
                lock(this)
                {
                    if (ContainsKey(key))
                        throw new ArgumentException($"Duplicate key : {key}");
                    using StreamWriter writer = new StreamWriter(new BufferedStream(new FileStream(f.FullName, FileMode.Append, FileAccess.Write)));
                    writer.WriteLine($"{key}{SEPARATOR}{valueCodec.Encode(value)}");
                    dic.TryAdd(key, value);
                }
            }
        }
    }
}
