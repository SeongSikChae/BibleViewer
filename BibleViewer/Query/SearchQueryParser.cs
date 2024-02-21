using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BibleViewer.Query
{
    public sealed class SearchQueryParser
    {
        public ISearchQuery Parse(string query)
        {
            Match match = SearchPattern.Match(query);
            Match match2 = SearchPattern2.Match(query);
            if (match.Success)
            {
                List<AndSearchQuery.AndSearchItem> list = new List<AndSearchQuery.AndSearchItem>();
                {
                    List<ISearchQuery> orList = new List<ISearchQuery>();
                    OrSearchQuery orSearchQuery = new OrSearchQuery(orList);
                    orList.Add(new NamedSearchQuery("BibleSubjectName", new TermSearchQuery(match.Groups["Subject"].Value)));
                    orList.Add(new NamedSearchQuery("BibleSubjectDescription", new TermSearchQuery(match.Groups["Subject"].Value)));
                    list.Add(new AndSearchQuery.AndSearchItem(false, orSearchQuery));
                }
                list.Add(new AndSearchQuery.AndSearchItem(false, new NamedSearchQuery("ChapterNumber", new TermSearchQuery(match.Groups["Chapter"].Value))));
                list.Add(new AndSearchQuery.AndSearchItem(false, new NamedSearchQuery("LineNumber", new RangeSearchQuery(match.Groups["StartLine"].Value, match.Groups["EndLine"].Value, true, true))));
                return new AndSearchQuery(new AllSearchQuery(), list);
            }
            else if (match2.Success)
            {
                List<AndSearchQuery.AndSearchItem> list = new List<AndSearchQuery.AndSearchItem>();
                {
                    List<ISearchQuery> orList = new List<ISearchQuery>();
                    OrSearchQuery orSearchQuery = new OrSearchQuery(orList);
                    orList.Add(new NamedSearchQuery("BibleSubjectName", new TermSearchQuery(match2.Groups["Subject"].Value)));
                    orList.Add(new NamedSearchQuery("BibleSubjectDescription", new TermSearchQuery(match2.Groups["Subject"].Value)));
                    list.Add(new AndSearchQuery.AndSearchItem(false, orSearchQuery));
                }
                list.Add(new AndSearchQuery.AndSearchItem(false, new NamedSearchQuery("ChapterNumber", new TermSearchQuery(match2.Groups["Chapter"].Value))));
                list.Add(new AndSearchQuery.AndSearchItem(false, new NamedSearchQuery("LineNumber", new TermSearchQuery(match2.Groups["Line"].Value))));
                return new AndSearchQuery(new AllSearchQuery(), list);
            }
            return new TermSearchQuery(query);
        }

        private static readonly Regex SearchPattern = new Regex("(?<Subject>\\S+) (?<Chapter>\\d+):(?<StartLine>\\d+)-(?<EndLine>\\d+)");
        private static readonly Regex SearchPattern2 = new Regex("(?<Subject>\\S+) (?<Chapter>\\d+):(?<Line>\\d+)");
    }
}
