using System;

namespace BibleViewer.Entity
{
	public sealed class BibleBody(int chapter, int line, string body) : IComparable<BibleBody>
	{
		public int Chapter => chapter;
		public int Line => line;
		public string Body => body;

		public int CompareTo(BibleBody other)
		{
			int compare = Chapter.CompareTo(other.Chapter);
			if (compare != 0)
				return compare;
			compare = Line.CompareTo(other.Line);
			return compare;
		}
	}
}
