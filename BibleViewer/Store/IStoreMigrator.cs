using BibleViewer.Store.Dic;
using J2N.Collections.Generic;
using Lucene.Net.Documents;
using System;

namespace BibleViewer.Store
{
    public interface IStoreMigrator
    {
        void Migrate(StoreMigrationData d);
    }

    public sealed class ChapterStoreMigrator : IStoreMigrator
    {
        public void Initialize(IIndexStore store)
        {
            this.store = store;
        }

        private IIndexStore store;
        private HashSet<int> hashSet = new HashSet<int>();

        public void Migrate(StoreMigrationData d)
        {
            HashCode hashCode = new HashCode();
            hashCode.Add(d.BibleSubjectKey);
            hashCode.Add(d.ChapterNumber);
            int hash = hashCode.ToHashCode();
            if(!hashSet.Contains(hash))
            {
                IIndexInput input = store.NewInput(Guid.NewGuid().ToString());
                input.AddInt32("BibleSubjectKey", d.BibleSubjectKey);
                input.AddInt32("ChapterNumber", d.ChapterNumber);
                store.Put(input);
                hashSet.Add(hash);
            }
        }
    }

    public sealed class BibleStoreMigrator : IStoreMigrator
    {
        public void Initialize(IIndexStore store, LevelDB.DB db)
        {
            this.store = store;
            this.db = db;
        }

        private IIndexStore store;
        private LevelDB.DB db;

        public void Migrate(StoreMigrationData d)
        {
            string key = Guid.NewGuid().ToString();
            db.Put(key, d.Body);
            IIndexInput input =  store.NewInput(key);
            input.AddInt32("BibleTypeKey", d.BibleTypeKey);
            input.AddInt32("BibleSubjectKey", d.BibleSubjectKey);
            input.AddString("BibleSubjectName", d.BibleSubjectName);
            input.AddString("BibleSubjectDescription", d.BibleSubjectDescription);
            input.AddInt32("ChapterNumber", d.ChapterNumber);
            input.AddInt32("LineNumber", d.LineNumber);
            input.AddText("Body", d.Body);
            store.Put(input);
        }
    }
}
