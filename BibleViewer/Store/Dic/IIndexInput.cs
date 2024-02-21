using Lucene.Net.Documents;
using System;

namespace BibleViewer.Store.Dic
{
    public interface IIndexInput
    {
        Document Doc { get; }

        void AddText(string name, string value);

        void AddString(string name, string value);

        void AddInt32(string name, int value);

        void AddInt64(string name, long value);

        void AddDouble(string name, double value);
    }
}
