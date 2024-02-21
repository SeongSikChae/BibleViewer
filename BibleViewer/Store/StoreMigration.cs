using BibleViewer.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BibleViewer.Store
{
    public sealed class StoreMigration
    {
        public void Initialize(BibleContext context)
        {
            foreach (BibleSubject subject in context.BibleSubject.ToList())
                dic.Add(subject.BibleSubjectName, subject);
        }

        private readonly Dictionary<string, BibleSubject> dic = new Dictionary<string, BibleSubject>();

        public void Migration(Action<StoreMigrationData> action)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("Data");
            IEnumerable<FileInfo> enumerable = directoryInfo.EnumerateFiles("*.txt", SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in enumerable)
            {
                if (file.Name.Equals("Subject.txt"))
                    continue;

                using StreamReader reader = new StreamReader(new BufferedStream(new FileStream(file.FullName, FileMode.Open, FileAccess.Read)));
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line is null)
                        break;
                    Match m = Pattern.Match(line);
                    if (m.Success)
                    {
                        StoreMigrationData d = new StoreMigrationData();
                        d.BibleTypeKey = 1;
                        BibleSubject sub = dic[m.Groups["Subject"].Value];
                        d.BibleSubjectName = sub.BibleSubjectName;
                        d.BibleSubjectDescription = sub.BibleSubjectDescription;
                        d.BibleSubjectKey = sub.BibleSubjectKey;
                        d.ChapterNumber = int.Parse(m.Groups["Chapter"].Value);
                        d.LineNumber = int.Parse(m.Groups["LineNumber"].Value);
                        d.Body = line.Substring(m.Length);
                        action(d);
                    }
                }
            }
        }

        private readonly Regex Pattern = new Regex("(?<Subject>[가-힣]+)(?<Chapter>\\d+):(?<LineNumber>\\d+) ");
    }

    public sealed class StoreMigrationData
    {
        public int BibleTypeKey { get; set; }

        public int BibleSubjectKey { get; set; }

        public string BibleSubjectName { get; set; }

        public string BibleSubjectDescription { get; set; }

        public int ChapterNumber { get; set; }

        public int LineNumber { get; set; }

        public string Body { get; set; }
    }
}
