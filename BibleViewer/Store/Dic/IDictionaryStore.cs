using System.Collections.Generic;

namespace BibleViewer.Store.Dic
{
    public interface IDictionaryStore<T>
    {
        bool ContainsKey(string key);

        void Put(string key, T value);

        T GetIfPresent(string key);

        T Get(string key, T value, bool putIfAbsent);

        int Count { get; }

        IEnumerator<string> Keys { get;}
    }
}
